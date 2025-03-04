namespace BookReviewManagement.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static ServiceCollection AddBookReviewManagement(this ServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<BookReviewManagementDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
        });
        
        services.AddScoped<IBookReviewManagementDbContext>(provider => provider.GetRequiredService<BookReviewManagementDbContext>());
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<IPasswordHashService, PasswordHashService>();
        services.AddScoped<JwtTokenService>();
        
        return services;
    }
}