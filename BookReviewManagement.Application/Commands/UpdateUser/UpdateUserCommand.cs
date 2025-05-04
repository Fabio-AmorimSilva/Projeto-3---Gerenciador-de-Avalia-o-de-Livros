namespace BookReviewManagement.Application.Commands.UpdateUser;

public sealed record UpdateUserCommand(
    Guid Id,
    string Name,
    string Email
) : IRequest<Result<Unit>>;

public sealed class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateUserCommand.Id)));

        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateUserCommand.Name)))
            .MaximumLength(User.MaxNameLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(UpdateUserCommand.Name), User.MaxNameLength));

        RuleFor(command => command.Email)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateUserCommand.Email)));
    }
}