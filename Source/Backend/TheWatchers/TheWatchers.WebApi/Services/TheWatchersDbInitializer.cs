using TheWatchers.Domain.Entities;
using TheWatchers.Infrastructure.Persistence;
using TheWatchers.Watchers.PingClient;
using TheWatchers.Watchers.RESTfulGet;
using TheWatchers.Watchers.SqlServer;

namespace TheWatchers.WebApi.Services;

public sealed class TheWatchersDbInitializer(ILogger<TheWatchersDbInitializer> logger, TheWatchersDbContext dbContext)
{
    public async Task SeedAsync(CancellationToken ct = default)
    {
        if (!dbContext.Watchers.Any())
        {
            logger.LogInformation("Creating watchers...");

            dbContext.Watchers.Add(new("Ping watcher", "Watcher for Ping requests", new PingWatcher(), new WatcherParameter("IPAddress", "", false)));
            await dbContext.SaveChangesAsync(ct);

            dbContext.Watchers.Add(new("RESTfulGet watcher", "Watcher for RESTful APIs", new RESTfulGetWatcher(), new WatcherParameter("Endpoint", "", false)));
            await dbContext.SaveChangesAsync(ct);

            dbContext.Watchers.Add(new("RESTfulGet watcher", "Watcher for RESTful APIs", new SqlServerDatabaseWatcher(), new WatcherParameter("ConnectionString", "", false)));
            await dbContext.SaveChangesAsync(ct);
        }

        if (!dbContext.Environments.Any())
        {
            logger.LogInformation("Creating environments...");

            dbContext.Environments.Add(new("Development"));
            dbContext.Environments.Add(new("QA"));
            dbContext.Environments.Add(new("Staging"));
            dbContext.Environments.Add(new("Production"));
            await dbContext.SaveChangesAsync(ct);
        }

        if (!dbContext.ResourceCategories.Any())
        {
            logger.LogInformation("Creating resource categories...");

            dbContext.ResourceCategories.Add(new("Servers", 1));
            await dbContext.SaveChangesAsync(ct);

            dbContext.ResourceCategories.Add(new("RESTful APIs", 2));
            await dbContext.SaveChangesAsync(ct);

            dbContext.ResourceCategories.Add(new("SQL Server databases", 3));
            await dbContext.SaveChangesAsync(ct);
        }

        if (!dbContext.Resources.Any())
        {
            logger.LogInformation("Creating resources...");

            dbContext.Resources.Add(new("Sample watcher for default gateway", 1));
            await dbContext.SaveChangesAsync(ct);

            dbContext.Resources.Add(new("Sample watcher for RESTful APIs", 2));
            await dbContext.SaveChangesAsync(ct);

            dbContext.Resources.Add(new("SQL Server Database sample watcher", 3));
            await dbContext.SaveChangesAsync(ct);
        }

        if (!dbContext.ResourceWatches.Any())
        {
            logger.LogInformation("Creating resource watches...");

            dbContext.ResourceWatches.Add(new(1, 1, 50000, "Ping test in dev",
                new ResourceWatchParameter(1, "IPAddress", "192.168.1.1", "IP address (IP v4)"))
            );

            await dbContext.SaveChangesAsync(ct);

            dbContext.ResourceWatches.Add(new(2, 1, 55000, "GET request sample",
                new ResourceWatchParameter(2, "Endpoint", "https://api.ipify.org/?format=json", "ipify API (Public IP Address API"))
            );

            await dbContext.SaveChangesAsync(ct);

            dbContext.ResourceWatches.Add(new(3, 1, 60000, "SQL Server database connnection sample",
                new ResourceWatchParameter(3, "ConnecionString", "Server=(local); Database=TheWatchers; Integrated Security=yes; TrustServerCertificate=true;", "The Watchers database connection string"))
            );

            await dbContext.SaveChangesAsync(ct);
        }
    }
}
