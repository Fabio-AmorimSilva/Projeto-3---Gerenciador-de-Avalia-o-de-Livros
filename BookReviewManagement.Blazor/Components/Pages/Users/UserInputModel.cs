namespace BookReviewManagement.Blazor.Components.Pages.Users;

public sealed record UserInputModel
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}