namespace BookReviewManagement.Application.Commands.DeleteBook;

public sealed record DeleteBookCommand(Guid BookId) : IRequest<Result<Unit>>;

public sealed class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(command => command.BookId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(DeleteBookCommand.BookId)));
    }
}