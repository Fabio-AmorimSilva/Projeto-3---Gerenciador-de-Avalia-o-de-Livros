namespace BookReviewManagement.Application.Queries.ListUserReviews;

public sealed class ListUserReviewsQueryHandler(IBookReviewManagementDbContext context)
    : IRequestHandler<ListUserReviewsQuery, Result<IEnumerable<ListUserReviewsViewModel>>>
{
    public async Task<Result<IEnumerable<ListUserReviewsViewModel>>> Handle(ListUserReviewsQuery request, CancellationToken cancellationToken)
    {
        var reviews = await context.Users
            .SelectMany(u => u.Reviews.Where(r => r.UserId == request.UserId))
            .Select(r => new ListUserReviewsViewModel
            {
                Id = r.Id,
                UserName = r.User.Name,
                Title = r.Book.Title,
                Description = r.Description,
                Score = r.Score
            })
            .ToListAsync(cancellationToken);

        return Result<IEnumerable<ListUserReviewsViewModel>>.Success(reviews);
    }
}