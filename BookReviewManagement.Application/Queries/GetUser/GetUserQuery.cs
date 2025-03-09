namespace BookReviewManagement.Application.Queries.GetUser;

public sealed record GetUserQuery(Guid UserId) : IRequest<Result<GetUserViewModel>>;