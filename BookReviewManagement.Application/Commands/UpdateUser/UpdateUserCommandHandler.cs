namespace BookReviewManagement.Application.Commands.UpdateUser;

public sealed class UpdateUserCommandHandler(IBookReviewManagementDbContext context) : IRequestHandler<UpdateUserCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        if (user is null)
            return Result<Unit>.Error(ErrorMessages.NotFound<User>());

        user.Update(
            name: request.Name,
            email: request.Email
        );

        await context.SaveChangesAsync(cancellationToken);

        return Result<Unit>.Success();
    }
}