namespace BookReviewManagement.Application.Queries.GetReview;

public sealed class GetReviewQueryHandler(IBookReviewManagementDbContext context) : IRequestHandler<GetReviewQuery, Result<GetReviewViewModel>>
{
    public async Task<Result<GetReviewViewModel>> Handle(GetReviewQuery request, CancellationToken cancellationToken)
    {
        var review = await context.Reviews
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == request.ReviewId, cancellationToken);

        if (review is null)
            return Result<GetReviewViewModel>.Error(ErrorMessages.NotFound<Review>());

        return Result<GetReviewViewModel>.Success(new GetReviewViewModel
        {
            Description = review.Description,
            Score = review.Score
        });
    }
}