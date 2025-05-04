namespace BookReviewManagement.Application.Queries.GetUser;

public sealed record GetUserViewModel
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }
}