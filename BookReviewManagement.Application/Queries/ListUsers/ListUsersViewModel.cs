namespace BookReviewManagement.Application.Queries.ListUsers;

public sealed record ListUsersViewModel
{
    public required string Name { get; init; }
    public required string Email { get; init; }
}