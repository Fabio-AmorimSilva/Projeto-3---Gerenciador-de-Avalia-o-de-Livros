namespace BookReviewManagement.Application.Commands.UpdateBookCover;

public sealed record UpdateBookCoverCommand(
    Guid BookId, 
    byte[] Cover
) : IRequest<Result<Guid>>;

public sealed class UpdateBookCoverCommandValidator : AbstractValidator<UpdateBookCoverCommand>
{
    public UpdateBookCoverCommandValidator()
    {
        RuleFor(command => command.BookId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateBookCoverCommand.BookId)));
        
        RuleFor(command => command.Cover)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateBookCoverCommand.Cover)));
    }
}