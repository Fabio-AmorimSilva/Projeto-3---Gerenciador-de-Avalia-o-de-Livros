namespace BookReviewManagement.Blazor.Components.Pages.Books;

public sealed record BookUpdateCoverModel
{
    public byte[] Cover { get; set; } = null!;
}