namespace BookReviewManagement.Application.Queries.ListUserReviews;

public sealed record ListUserReviewsViewModel
{
    public required Guid Id { get; init; }
    public required string UserName { get; init; }
    public required string Title { get; init; }
    public required int Score { get; init; }
    public required string Description { get; init; }
}