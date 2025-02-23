namespace BookReviewManagement.Domain.Entities;

public class Review: Entity, IAuditableEntity
{
    public const int MaxDescriptionLength = 1000;
    
    public int Score { get; private set; }
    public string Description { get; private set; }
    public Guid UserId { get; private set; }
    public User User { get; private set; }
    public Guid BookId { get; private set; }
    public Book Book { get; private set; }
    
    public DateTime CreatedAt { get; set; }

    public Review(
        int score, 
        string description,
        User user,
        Book book
    )
    {
        Guard.IsNotWhiteSpace(description);
        Guard.IsLessThanOrEqualTo(description.Length, MaxDescriptionLength, nameof(description));
        Guard.IsNotDefault(score);
        
        Score = score;
        Description = description;
        
        UserId = user.Id;
        User = user;
        
        BookId = book.Id;
        Book = book;
    }
}