namespace BookReviewManagement.Application.Queries.ListBookReviews;

public sealed record ListBookReviewsViewModel
{
    public required string Title { get; init; }
    public required string Isbn { get; init; }
    public required int Score { get; init; }
    public required string Description { get; init; }
}