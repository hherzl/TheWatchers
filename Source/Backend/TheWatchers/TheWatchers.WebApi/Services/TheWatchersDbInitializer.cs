using TheWatchers.Domain.Entities;
using TheWatchers.Infrastructure.Persistence;
using TheWatchers.Watchers.PingClient;
using TheWatchers.Watchers.RESTfulGet;

namespace TheWatchers.WebApi.Services;

public sealed class TheWatchersDbInitializer(TheWatchersDbContext dbContext)
{
    public async Task SeedAsync(CancellationToken ct = default)
    {
        if (!dbContext.Watchers.Any())
        {
            dbContext.Watchers.Add(new("Ping watcher", "Watcher for Ping requests", new PingWatcher(), new WatcherParameter("IPAddress", "", false)));
            await dbContext.SaveChangesAsync(ct);

            dbContext.Watchers.Add(new("RESTfulGet watcher", "Watcher for RESTful APIs", new RESTfulGetWatcher(), new WatcherParameter("Endpoint", "", false)));
            await dbContext.SaveChangesAsync(ct);
        }

        if (!dbContext.Environments.Any())
        {
            dbContext.Environments.Add(new("Development"));
            dbContext.Environments.Add(new("QA"));
            dbContext.Environments.Add(new("Staging"));
            dbContext.Environments.Add(new("Production"));
            await dbContext.SaveChangesAsync(ct);
        }

        if (!dbContext.ResourceCategories.Any())
        {
            dbContext.ResourceCategories.Add(new("Servers", 1));
            await dbContext.SaveChangesAsync(ct);

            dbContext.ResourceCategories.Add(new("RESTful APIs", 2));
            await dbContext.SaveChangesAsync(ct);
        }

        if (!dbContext.Resources.Any())
        {
            dbContext.Resources.Add(new("Sample watcher for default gateway", 1));
            await dbContext.SaveChangesAsync(ct);

            dbContext.Resources.Add(new("Sample watcher for RESTful APIs", 2));
            await dbContext.SaveChangesAsync(ct);
        }

        if (!dbContext.ResourceWatches.Any())
        {
            dbContext.ResourceWatches.Add(new(1, 1, 60000, "Ping test in dev", new ResourceWatchParameter(1, "IPAddress", "192.168.1.1", "IP address (IP v4)")));
            await dbContext.SaveChangesAsync(ct);

            dbContext.ResourceWatches.Add(new(2, 1, 30000, "GET request sample", new ResourceWatchParameter(2, "Endpoint", "https://api.ipify.org/?format=json", "ipify API (Public IP Address API")));
            await dbContext.SaveChangesAsync(ct);
        }
    }
}
