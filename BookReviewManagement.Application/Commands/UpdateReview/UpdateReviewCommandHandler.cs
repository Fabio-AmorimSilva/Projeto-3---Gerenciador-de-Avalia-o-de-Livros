namespace BookReviewManagement.Application.Commands.UpdateReview;

public sealed class UpdateReviewCommandHandler(IBookReviewManagementDbContext context) : IRequestHandler<UpdateReviewCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await context.Books
            .SelectMany(b => b.Reviews.Where(r => r.Id == request.ReviewId))
            .FirstOrDefaultAsync(cancellationToken);

        if (review is null)
            return Result<Unit>.Error(ErrorMessages.NotFound<Review>());

        review.Update(
            score: request.Score,
            description: request.Description
        );

        await context.SaveChangesAsync(cancellationToken);

        return Result<Unit>.Success();
    }
}