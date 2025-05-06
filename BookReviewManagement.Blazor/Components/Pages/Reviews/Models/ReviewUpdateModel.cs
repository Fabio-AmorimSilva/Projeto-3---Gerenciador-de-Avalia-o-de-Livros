namespace BookReviewManagement.Blazor.Components.Pages.Reviews.Models;

public sealed record ReviewUpdateModel
{
    public int Score { get; set; }
    public string Description { get; set; } = null!;
}