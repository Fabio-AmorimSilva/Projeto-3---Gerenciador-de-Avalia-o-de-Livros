namespace BookReviewManagement.Application.Commands.UpdateBook;

public sealed record UpdateBookCommand(
    Guid BookId,
    string Title,
    string Description,
    string Author,
    string Publisher,
    BookGenre Genre,
    DateTime PublishDate,
    int Pages
) : IRequest<Result<Unit>>;

public sealed class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(b => b.BookId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateBookCommand.BookId)));

        RuleFor(command => command.Title)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateBookCommand.Title)))
            .MaximumLength(Book.MaxTitleLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(UpdateBookCommand.Title), Book.MaxTitleLength));

        RuleFor(command => command.Description)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateBookCommand.Description)))
            .MaximumLength(Book.MaxDescriptionLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(UpdateBookCommand.Description), Book.MaxDescriptionLength));

        RuleFor(command => command.Author)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateBookCommand.Author)))
            .MaximumLength(Book.MaxAuthorLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(UpdateBookCommand.Author), Book.MaxAuthorLength));

        RuleFor(command => command.Publisher)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateBookCommand.Publisher)))
            .MaximumLength(Book.MaxPublisherLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(UpdateBookCommand.Publisher), Book.MaxPublisherLength));

        RuleFor(command => command.Genre)
            .IsInEnum()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateBookCommand.Genre)));

        RuleFor(command => command.PublishDate)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateBookCommand.PublishDate)));

        RuleFor(command => command.Pages)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateBookCommand.Pages)));
    }
}