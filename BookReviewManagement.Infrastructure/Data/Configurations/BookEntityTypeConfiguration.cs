namespace BookReviewManagement.Infrastructure.Data.Configurations;

public sealed class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder
            .ToTable("Books");
        
        builder
            .HasKey(b => b.Id);

        builder
            .HasIndex(b => b.Id);
        
        builder
            .Property(b => b.Id)
            .IsRequired();
        
        builder
            .Property(b => b.Title)
            .HasMaxLength(Book.MaxTitleLength)
            .IsRequired();
        
        builder
            .Property(b => b.Description)
            .HasMaxLength(Book.MaxDescriptionLength)
            .IsRequired();
        
        builder
            .Property(b => b.Isbn)
            .IsRequired();
        
        builder
            .Property(b => b.Author)
            .HasMaxLength(Book.MaxAuthorLength)
            .IsRequired();
        
        builder
            .Property(b => b.Publisher)
            .HasMaxLength(Book.MaxPublisherLength)
            .IsRequired();
        
        builder
            .Property(b => b.Genre)
            .IsRequired();
        
        builder
            .Property(b => b.PublishDate)
            .IsRequired();
        
        builder
            .Property(b => b.Cover)
            .IsRequired();
        
        builder
            .Property(b => b.Pages)
            .IsRequired();
        
        builder
            .Property(b => b.Score)
            .IsRequired();
        
        builder
            .Property(b => b.CreatedAt)
            .IsRequired();
    }
}