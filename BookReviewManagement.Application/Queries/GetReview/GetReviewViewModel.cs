namespace BookReviewManagement.Application.Queries.GetReview;

public sealed record GetReviewViewModel
{
    public required int Score { get; init; }
    public required string Description { get; init; }
}