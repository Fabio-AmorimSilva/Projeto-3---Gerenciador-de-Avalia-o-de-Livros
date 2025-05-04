namespace BookReviewManagement.Blazor.Components.Pages.Users.Models;

public sealed record LoginInputModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}