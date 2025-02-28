namespace BookReviewManagement.Infrastructure.Data.Configurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("Users");
        
        builder
            .HasKey(u => u.Id);
        
        builder
            .Property(u => u.Id)
            .IsRequired();
        
        builder
            .HasIndex(u => new { u.Name, u.Email })
            .IsUnique();
        
        builder
            .Property(u => u.Name)
            .HasMaxLength(User.MaxNameLength)
            .IsRequired();
        
        builder
            .Property(u => u.Email)
            .IsRequired();
        
        builder
            .Property(u => u.Password)
            .IsRequired();
    }
}