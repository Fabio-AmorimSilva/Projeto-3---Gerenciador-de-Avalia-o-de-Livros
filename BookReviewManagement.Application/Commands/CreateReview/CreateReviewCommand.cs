namespace BookReviewManagement.Application.Commands.CreateReview;

public sealed record CreateReviewCommand(
    Guid BookId,
    int Score,
    string Description
) : IRequest<Result<Guid>>;


public sealed class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
{
    public CreateReviewCommandValidator()
    {
        RuleFor(command => command.Score)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateReviewCommand.Score)));
        
        RuleFor(command => command.Description)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateReviewCommand.Description)))
            .MaximumLength(Review.MaxDescriptionLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CreateReviewCommand.Description), Review.MaxDescriptionLength));
        
        RuleFor(command => command.BookId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateReviewCommand.BookId)));
    }
}