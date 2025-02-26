namespace BookReviewManagement.Application.Commands.CreateUser;

public sealed record CreateUserCommand(
    string Name, 
    string Email,
    string Password
) : IRequest<Result<Guid>>;

public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateUserCommand.Name)));

        RuleFor(command => command.Email)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateUserCommand.Email)))
            .EmailAddress();
        
        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateUserCommand.Name)));
    }
}