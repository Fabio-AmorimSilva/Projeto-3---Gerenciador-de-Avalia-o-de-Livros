namespace BookReviewManagement.Application.Queries.GetReview;

public sealed record GetReviewQuery(Guid ReviewId) : IRequest<Result<GetReviewViewModel>>;