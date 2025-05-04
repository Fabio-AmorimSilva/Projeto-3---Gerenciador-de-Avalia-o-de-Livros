namespace BookReviewManagement.Infrastructure.Data.Configurations;

public class ReviewEntityTypeConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder
            .ToTable("Reviews");
        
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired();
        
        builder
            .HasIndex(r => new { r.BookId, r.UserId });

        builder
            .Property(r => r.Id)
            .IsRequired();

        builder
            .Property(r => r.Description)
            .HasMaxLength(Review.MaxDescriptionLength)
            .IsRequired();
        
        builder
            .Property(r => r.UserId)
            .IsRequired();
        
        builder
            .Property(r => r.BookId)
            .IsRequired();
        
        builder
            .HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(r => r.Book)
            .WithMany(b => b.Reviews)
            .HasForeignKey(r => r.BookId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}