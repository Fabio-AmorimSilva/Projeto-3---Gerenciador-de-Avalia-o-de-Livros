namespace BookReviewManagement.Application.Commands.CreateBook;

public sealed record CreateBookCommand(
    string Title,
    string Description,
    string Isbn,
    string Author,
    string Publisher,
    BookGenre Genre,
    DateTime PublishDate,
    int Pages
) : IRequest<Result<Guid>>;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(command => command.Title)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateBookCommand.Title)))
            .MaximumLength(Book.MaxTitleLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CreateBookCommand.Title), Book.MaxTitleLength));

        RuleFor(command => command.Description)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateBookCommand.Description)))
            .MaximumLength(Book.MaxDescriptionLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CreateBookCommand.Description), Book.MaxDescriptionLength));

        RuleFor(command => command.Isbn)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateBookCommand.Isbn)));

        RuleFor(command => command.Author)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateBookCommand.Author)))
            .MaximumLength(Book.MaxAuthorLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CreateBookCommand.Author), Book.MaxAuthorLength));

        RuleFor(command => command.Publisher)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateBookCommand.Publisher)))
            .MaximumLength(Book.MaxPublisherLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CreateBookCommand.Publisher), Book.MaxPublisherLength));

        RuleFor(command => command.Genre)
            .IsInEnum()
            .WithMessage(ErrorMessages.IsInvalidEnum(nameof(CreateBookCommand.Genre)));

        RuleFor(command => command.PublishDate)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateBookCommand.PublishDate)));

        RuleFor(command => command.Pages)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateBookCommand.Pages)));
    }
}