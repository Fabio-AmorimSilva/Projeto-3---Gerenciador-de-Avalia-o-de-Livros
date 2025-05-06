namespace BookReviewManagement.Application.Queries.GetReview;

public sealed class GetReviewQueryHandler(IBookReviewManagementDbContext context) : IRequestHandler<GetReviewQuery, Result<GetReviewViewModel>>
{
    public async Task<Result<GetReviewViewModel>> Handle(GetReviewQuery request, CancellationToken cancellationToken)
    {
        var review = await context.Reviews
            .Where(r => r.Id == request.ReviewId)
            .Select(r => new GetReviewViewModel
            {
                Description = r.Description,
                Score = r.Score
            })
            .FirstOrDefaultAsync(cancellationToken);
        
        if (review is null)
            return Result<GetReviewViewModel>.Error(ErrorMessages.NotFound<Review>());

        return Result<GetReviewViewModel>.Success(review);
    }
}