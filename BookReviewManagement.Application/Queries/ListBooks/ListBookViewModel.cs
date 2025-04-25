namespace BookReviewManagement.Application.Queries.ListBooks;

public sealed record ListBookViewModel
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required string Isbn { get; init; }
    public required string Author { get; init; }
    public required string Publisher { get; init; }
    public required BookGenre Genre { get; init; }
    public required DateTime PublishDate { get; init; }
    public required decimal? Score { get; init; } = 0;
}