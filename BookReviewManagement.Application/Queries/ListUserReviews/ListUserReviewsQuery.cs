namespace BookReviewManagement.Application.Queries.ListUserReviews;

public sealed record ListUserReviewsQuery(Guid UserId) : IRequest<Result<IEnumerable<ListUserReviewsViewModel>>>;