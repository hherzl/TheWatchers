using TheWatchers.WebApi.Services;

namespace TheWatchers.WebApi;

public static class ConfigureServices
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<TheWatchersDbInitializer>();
        services.AddHostedService<MonitorBackgroundService>();

        services.AddSignalR(options => options.EnableDetailedErrors = true);

        var policies = configuration.GetSection("Policies").Get<CorsPolicy[]>();
        services.AddCors(options =>
        {
            foreach (var policy in policies)
            {
                options.AddPolicy(policy.Name, builder =>
                {
                    foreach (var origin in policy.Origins)
                    {
                        builder.WithOrigins(origin).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                    }
                });
            }
        });

        return services;
    }
}
