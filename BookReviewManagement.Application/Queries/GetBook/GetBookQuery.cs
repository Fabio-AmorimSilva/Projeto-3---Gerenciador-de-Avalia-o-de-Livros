namespace BookReviewManagement.Application.Queries.GetBook;

public sealed record GetBookQuery(Guid BookId) : IRequest<Result<GetBookViewModel>>;