namespace BookReviewManagement.Domain.Entities;

public sealed class Book : Entity, IAuditableEntity
{
    public const int MaxTitleLength = 500;
    public const int MaxDescriptionLength = 1000;
    public const int MaxAuthorLength = 150;
    public const int MaxPublisherLength = 200;
    
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Isbn { get; private set; }
    public string Author { get; private set; }
    public string Publisher { get; private set; }
    public BookGenre Genre { get; private set; }
    public DateTime PublishDate { get; private set; }
    public int Pages { get; private set; }
    public decimal Score { get; private set; }
    public byte[]? Cover { get; private set; }
    public DateTime CreatedAt { get; set; }
    
    public IReadOnlyCollection<Review> Reviews => _reviews;
    private readonly List<Review> _reviews = [];

    protected Book(){}
    
    public Book(
        string title, 
        string description,
        string isbn,
        string author, 
        string publisher,
        BookGenre genre,
        DateTime publishDate, 
        int pages
    )
    {
        Guard.IsNotWhiteSpace(title);
        Guard.IsLessThanOrEqualTo(title.Length, MaxTitleLength, nameof(title));
        Guard.IsNotWhiteSpace(description);
        Guard.IsLessThanOrEqualTo(description.Length, MaxDescriptionLength, nameof(description));
        Guard.IsNotNullOrWhiteSpace(isbn);
        Guard.IsNotNullOrWhiteSpace(author);
        Guard.IsLessThanOrEqualTo(author.Length, MaxAuthorLength, nameof(author));
        Guard.IsNotNullOrWhiteSpace(publisher);
        Guard.IsLessThanOrEqualTo(publisher.Length, MaxPublisherLength, nameof(publisher));
        Guard.IsNotDefault(publishDate);
        Guard.IsNotDefault(pages);
        
        Title = title;
        Description = description;
        Isbn = isbn;
        Author = author;
        Publisher = publisher;
        Genre = genre;
        PublishDate = publishDate;
        Pages = pages;
    }

    public void Update(string title, 
        string description,
        string author, 
        string publisher,
        BookGenre genre,
        DateTime publishDate, 
        int pages
    )
    {
        Guard.IsNotWhiteSpace(title);
        Guard.IsLessThanOrEqualTo(title.Length, MaxTitleLength, nameof(title));
        Guard.IsNotWhiteSpace(description);
        Guard.IsLessThanOrEqualTo(description.Length, MaxDescriptionLength, nameof(description));
        Guard.IsNotNullOrWhiteSpace(author);
        Guard.IsLessThanOrEqualTo(author.Length, MaxAuthorLength, nameof(author));
        Guard.IsNotNullOrWhiteSpace(publisher);
        Guard.IsLessThanOrEqualTo(publisher.Length, MaxPublisherLength, nameof(publisher));
        Guard.IsNotDefault(publishDate);
        Guard.IsNotDefault(pages);
       
        Title = title;
        Description = description;
        Author = author;
        Publisher = publisher;
        Genre = genre;
        PublishDate = publishDate;
        Pages = pages;
    }
    
    public Review? GetReview(Guid reviewId)
        => _reviews.FirstOrDefault(r => r.Id == reviewId);
    
    public void UpdateCover(byte[] cover)
        => Cover = cover;

    public decimal AverageScore()
    {
        return (decimal)_reviews.Average(r => r.Score);
    }
}