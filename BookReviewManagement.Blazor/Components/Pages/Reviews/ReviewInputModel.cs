namespace BookReviewManagement.Blazor.Components.Pages.Reviews;

public sealed record ReviewInputModel
{
    public Guid BookId { get; set; }
    public int Score { get; set; }
    public string Description { get; set; } = null!;
}