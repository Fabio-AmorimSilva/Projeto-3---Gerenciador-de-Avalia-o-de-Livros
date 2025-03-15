namespace BookReviewManagement.Application.Common.Interfaces;

public interface IBookReviewManagementDbContext
{
    DbSet<Book> Books { get; }
    DbSet<User> Users { get; }
    DbSet<Review>Reviews { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}