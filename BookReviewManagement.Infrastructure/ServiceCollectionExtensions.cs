namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static ServiceCollection AddBookReviewManagement(this ServiceCollection services)
    {
        services.AddScoped<IBookReviewManagementDbContext>(provider => provider.GetRequiredService<BookReviewManagementDbContext>());
        services.AddScoped<IPasswordHashService, PasswordHashService>();
        
        return services;
    }
}