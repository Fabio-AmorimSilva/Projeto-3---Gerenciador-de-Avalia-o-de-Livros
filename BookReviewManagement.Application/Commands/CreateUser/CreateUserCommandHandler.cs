namespace BookReviewManagement.Application.Commands.CreateUser;

public sealed class CreateUserCommandHandler(
    IBookReviewManagementDbContext context,
    IPasswordHashService passwordHashService
) : IRequestHandler<CreateUserCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var hashedPassword = passwordHashService.HashPassword(request.Password);

        var user = new User(
            name: request.Name,
            email: request.Email,
            password: hashedPassword
        );

        var emailAlreadyExists = await context.Users
            .WithSpecification(new EmailAlreadyExistsSpec(user.Id, request.Email))
            .AnyAsync(cancellationToken);

        if (emailAlreadyExists)
            return Result<Guid>.Error(ErrorMessages.EmailAlreadyExists());

        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(user.Id);
    }
}