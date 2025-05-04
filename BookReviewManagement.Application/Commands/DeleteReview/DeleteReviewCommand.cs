namespace BookReviewManagement.Application.Commands.DeleteReview;

public sealed record DeleteReviewCommand(Guid ReviewId) : IRequest<Result<Unit>>;

public sealed class DeleteReviewCommandValidator : AbstractValidator<DeleteReviewCommand>
{
    public DeleteReviewCommandValidator()
    {
        RuleFor(command => command.ReviewId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(DeleteReviewCommand.ReviewId)));
    }
}