namespace BookReviewManagement.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<BookReviewManagementDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString);
        });
        
        services.AddScoped<IBookReviewManagementDbContext>(provider => provider.GetRequiredService<BookReviewManagementDbContext>());
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<IPasswordHashService, PasswordHashService>();
        services.AddScoped<ITokenService, TokenService>();
        
        return services;
    }
}