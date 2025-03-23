namespace BookReviewManagement.Blazor.Components.Pages.Books;

public sealed record BookUpdateModel
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Isbn { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string Publisher { get; set; } = null!;
    public BookGenre Genre { get; set; }
    public DateTime? PublishDate { get; set; }
    public int Pages { get; set; }
}