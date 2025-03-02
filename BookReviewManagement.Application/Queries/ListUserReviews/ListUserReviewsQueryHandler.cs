namespace BookReviewManagement.Application.Queries.ListUserReviews;

public sealed class ListUserReviewsQueryHandler(IBookReviewManagementDbContext context)
    : IRequestHandler<ListUserReviewsQuery, Result<IEnumerable<ListUserReviewsViewModel>>>
{
    public async Task<Result<IEnumerable<ListUserReviewsViewModel>>> Handle(ListUserReviewsQuery request, CancellationToken cancellationToken)
    {
        var reviews = await context.Users
            .SelectMany(r => r.Reviews)
            .Select(r => new ListUserReviewsViewModel
            {
                Name = r.User.Name,
                Title = r.Book.Title,
                Description = r.Description,
                Score = r.Score
            })
            .ToListAsync(cancellationToken);

        return Result<IEnumerable<ListUserReviewsViewModel>>.Success(reviews);
    }
}