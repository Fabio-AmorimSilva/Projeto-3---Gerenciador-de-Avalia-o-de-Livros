namespace BookReviewManagement.Domain.Entities;

public sealed class Book : Entity, IAuditableEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Isbn { get; private set; }
    public string Author { get; private set; }
    public string Publisher { get; private set; }
    public BookGenre Genre { get; private set; }
    public DateTime PublishDate { get; private set; }
    public int Pages { get; private set; }
    public decimal Score { get; private set; }
    public byte[] Cover { get; private set; }
    public DateTime CreatedAt { get; set; }
    
    public IReadOnlyCollection<Review> Reviews => _reviews;
    private readonly List<Review> _reviews = [];

    public Book(
        string title, 
        string description,
        string isbn,
        string author, 
        string publisher,
        BookGenre genre,
        DateTime publishDate, 
        int pages, 
        decimal score,
        byte[] cover,
        DateTime createdAt
    )
    {
        Title = title;
        Description = description;
        Isbn = isbn;
        Author = author;
        Publisher = publisher;
        Genre = genre;
        PublishDate = publishDate;
        Pages = pages;
        Score = score;
        Cover = cover;
        CreatedAt = createdAt;
    }
}