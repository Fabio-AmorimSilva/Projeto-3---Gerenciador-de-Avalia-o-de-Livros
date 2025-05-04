namespace BookReviewManagement.Application.Commands.DeleteUser;

public sealed record DeleteUserCommand(Guid UserId) : IRequest<Result<Unit>>;

public sealed class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(command => command.UserId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(DeleteUserCommand.UserId)));
    }
}