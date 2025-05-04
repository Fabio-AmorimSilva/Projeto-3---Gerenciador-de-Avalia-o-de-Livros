namespace BookReviewManagement.Application.Commands.Login;

public sealed record LoginCommand(
    string Email,
    string Password
) : IRequest<Result<string>>;

public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(command => command.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(LoginCommand.Email)));
        
        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(LoginCommand.Password)));
    }
}
