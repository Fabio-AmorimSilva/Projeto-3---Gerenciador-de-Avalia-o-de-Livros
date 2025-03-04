namespace BookReviewManagement.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static ServiceCollection AddBookReviewManagement(this ServiceCollection services)
    {
        services.AddDbContext<BookReviewManagementDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
        });
        
        services.AddScoped<IBookReviewManagementDbContext>(provider => provider.GetRequiredService<BookReviewManagementDbContext>());
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<IPasswordHashService, PasswordHashService>();
        
        return services;
    }
}