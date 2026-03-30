using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TheWatchers.Domain.Entities;
using TheWatchers.Infrastructure.Persistence.QuerySpecs;
using TheWatchers.SharedKernel.Models;

namespace TheWatchers.Infrastructure.Persistence;

public partial class TheWatchersDbContext(DbContextOptions<TheWatchersDbContext> options) : DbContext(options)
{
    public DbSet<Watcher> Watchers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    #region [ Queries for Watcher ]

    public IQueryable<WatcherItemModel> GetWatchers()
    {
        var query =
            from watcher in Watchers
            select new WatcherItemModel
            {
                Id = watcher.Id,
                Name = watcher.Name,
                ClassName = watcher.ClassName,
                ClassGuid = watcher.ClassGuid
            };

        return query;
    }

    public async Task<Watcher> GetWatcherAsync(short? id, bool tracking = false, bool includes = false, CancellationToken ct = default)
    {
        var query = Watchers.AddQuerySpec(new GetWatcherQuerySpec(id));

        if (!tracking)
            query = query.AsNoTracking();

        if (includes)
            query = query.Include(entity => entity.WatcherParameters);

        return await query.FirstOrDefaultAsync(ct);
    }

    #endregion
}
