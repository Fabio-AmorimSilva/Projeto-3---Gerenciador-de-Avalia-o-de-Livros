namespace BookReviewManagement.Domain.Interfaces;

public interface IAuditableEntity
{
    public DateTime CreatedAt { get; set; }
}