namespace BookReviewManagement.Application.Queries.ListBooks;

public sealed record ListBooksQuery : IRequest<Result<IEnumerable<ListBookViewModel>>>;