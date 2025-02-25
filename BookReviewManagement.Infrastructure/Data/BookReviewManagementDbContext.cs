namespace BookReviewManagement.Infrastructure.Data;

public class BookReviewManagementDbContext(DbContextOptions<BookReviewManagementDbContext> options) : DbContext(options), IBookReviewManagementDbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}