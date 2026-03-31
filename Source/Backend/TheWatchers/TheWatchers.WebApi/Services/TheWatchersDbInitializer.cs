using TheWatchers.Domain.Entities;
using TheWatchers.Infrastructure.Persistence;
using TheWatchers.Watchers.PingClient;

namespace TheWatchers.WebApi.Services;

public sealed class TheWatchersDbInitializer(TheWatchersDbContext dbContext)
{
    public async Task SeedAsync(CancellationToken ct = default)
    {
        if (!dbContext.Watchers.Any())
        {
            dbContext.Watchers.Add(new("Ping watcher", "Watcher for Ping requests", new PingWatcher(), new WatcherParameter("IPAddress", "", false)));
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
        }

        if (!dbContext.Resources.Any())
        {
            dbContext.Resources.Add(new("Sample watcher for default gateway", 1));
            await dbContext.SaveChangesAsync(ct);
        }

        if (!dbContext.ResourceWatches.Any())
        {
            dbContext.ResourceWatches.Add(new(1, 1, 10000, "Ping test in dev", new ResourceWatchParameter(1, "IPAddress", "192.168.1.1", "IP address (IP v4)")));
            await dbContext.SaveChangesAsync(ct);
        }
    }
}
