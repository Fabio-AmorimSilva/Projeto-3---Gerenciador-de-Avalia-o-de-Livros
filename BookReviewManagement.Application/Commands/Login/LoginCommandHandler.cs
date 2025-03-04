namespace BookReviewManagement.Application.Commands.Login;

public sealed class LoginCommandHandler(
    IBookReviewManagementDbContext context,
    IPasswordHashService passwordService,
    ITokenService tokenService
) : IRequestHandler<LoginCommand, Result<string>>
{
    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var hashed = passwordService.HashPassword(request.Password);

        var user = await context.Users.FirstOrDefaultAsync(
            u => u.Email == request.Email &&
                 u.Password == hashed, cancellationToken);
        
        if(user is null)
            return Result<string>.Error(ErrorMessages.EmailOrPasswordAreIncorrect());

        var token = tokenService.GenerateToken(user);
        
        return Result<string>.Success(token);
    }
}