namespace BookReviewManagement.Blazor.Components.Pages.Books.Models;

public sealed record BookUpdateCoverModel
{
    public byte[] Cover { get; set; } = null!;
}