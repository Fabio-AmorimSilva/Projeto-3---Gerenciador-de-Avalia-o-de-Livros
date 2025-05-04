namespace BookReviewManagement.Application.Queries.ListBookReviews;

public sealed record ListBookReviewsQuery(Guid BookId) : IRequest<Result<IEnumerable<ListBookReviewsViewModel>>>;