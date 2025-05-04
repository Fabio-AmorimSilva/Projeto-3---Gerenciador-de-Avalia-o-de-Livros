namespace Microsoft.Extensions.DependencyInjection;

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
        services.AddScoped<IReportsService, ReportsService>();

        services.AddJwtConfig(configuration);
        
        return services;
    }

    private static IServiceCollection AddJwtConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.GetSection("JwtSettings");
        services.Configure<JwtSettings>(settings);

        var appSettings = settings.Get<JwtSettings>();
        var key = Encoding.ASCII.GetBytes(appSettings?.JwtKey!);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = appSettings!.ValidOn,
                ValidIssuer = appSettings.Emissary
            };
        });

        return services;
    }
}