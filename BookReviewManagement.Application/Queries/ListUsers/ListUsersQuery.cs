namespace BookReviewManagement.Application.Queries.ListUsers;

public sealed record ListUsersQuery : IRequest<Result<IEnumerable<ListUsersViewModel>>>;