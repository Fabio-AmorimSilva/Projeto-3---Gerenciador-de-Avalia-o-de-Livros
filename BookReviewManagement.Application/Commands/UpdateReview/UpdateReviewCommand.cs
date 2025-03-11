namespace BookReviewManagement.Application.Commands.UpdateReview;

public sealed record UpdateReviewCommand(
    Guid ReviewId,
    int Score,
    string Description
) : IRequest<Result<Unit>>;

public sealed class UpdateReviewCommandValidator : AbstractValidator<UpdateReviewCommand>
{
    public UpdateReviewCommandValidator()
    {
        RuleFor(command => command.ReviewId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateReviewCommand.ReviewId)));

        RuleFor(command => command.Score)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateReviewCommand.Score)));

        RuleFor(command => command.Description)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateReviewCommand.Description)))
            .MaximumLength(Review.MaxDescriptionLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(UpdateReviewCommand.Description), Review.MaxDescriptionLength));
    }
}