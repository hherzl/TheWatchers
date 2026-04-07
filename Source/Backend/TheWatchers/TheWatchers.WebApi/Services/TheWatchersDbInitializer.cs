using TheWatchers.Domain.Entities;
using TheWatchers.Infrastructure.Persistence;
using TheWatchers.Watchers.MongoDB;
using TheWatchers.Watchers.PingClient;
using TheWatchers.Watchers.PostgreSql;
using TheWatchers.Watchers.RabbitMQ;
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

            dbContext.Watchers.Add(new("SQL Server Databases watcher", "Watcher for SQL Server databases", new SqlServerDatabaseWatcher(), new WatcherParameter("ConnectionString", "", false)));
            await dbContext.SaveChangesAsync(ct);

            dbContext.Watchers.Add(new("PostgerSQL Server Databases watcher", "Watcher for PostgreSQL Server databases", new PostgreSqlDatabaseWatcher(), new WatcherParameter("ConnectionString", "", false)));
            await dbContext.SaveChangesAsync(ct);

            dbContext.Watchers.Add(new("Mongo DB Databases watcher", "Watcher for Mongo DB databases", new MongoDBWatcher(),
                new WatcherParameter("ConnectionString", "", false),
                new WatcherParameter("DatabaseName", "", false))
            );
            await dbContext.SaveChangesAsync(ct);

            dbContext.Watchers.Add(new("Rabbit MQ watcher", "Watcher for Rabbit MQ instances", new RabbitMQWatcher(), new WatcherParameter("HostName", "", false)));
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

            dbContext.ResourceCategories.Add(new("PostgreSQL Server databases", 4));
            await dbContext.SaveChangesAsync(ct);

            dbContext.ResourceCategories.Add(new("MongoDB databases", 5));
            await dbContext.SaveChangesAsync(ct);

            dbContext.ResourceCategories.Add(new("Rabbit MQ instances", 6));
            await dbContext.SaveChangesAsync(ct);
        }

        if (!dbContext.Resources.Any())
        {
            logger.LogInformation("Creating resources...");

            dbContext.Resources.Add(new("Sample watcher for default gateway", 1));
            await dbContext.SaveChangesAsync(ct);

            dbContext.Resources.Add(new("Sample watcher for RESTful APIs", 2));
            await dbContext.SaveChangesAsync(ct);

            dbContext.Resources.Add(new("SQL Server Database sample resource", 3));
            await dbContext.SaveChangesAsync(ct);

            dbContext.Resources.Add(new("PostgreSQL Database sample resource", 4));
            await dbContext.SaveChangesAsync(ct);

            dbContext.Resources.Add(new("Mongo DB sample resource", 5));
            await dbContext.SaveChangesAsync(ct);

            dbContext.Resources.Add(new("Rabbit MQ sample resource", 6));
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
                new ResourceWatchParameter(3, "ConnectionString", "Server=(local); Database=TheWatchers; Integrated Security=yes; TrustServerCertificate=true;", "The Watchers database connection string"))
            );

            await dbContext.SaveChangesAsync(ct);

            dbContext.ResourceWatches.Add(new(4, 1, 70000, "PostgreSQL database connnection sample",
                new ResourceWatchParameter(3, "ConnectionString", "Server=localhost; Port=5432; Database=dvdrental; UserId=postgres; Password=Pass123$;", "PosgreSQL database connection string"))
            );

            await dbContext.SaveChangesAsync(ct);
        }
    }
}
