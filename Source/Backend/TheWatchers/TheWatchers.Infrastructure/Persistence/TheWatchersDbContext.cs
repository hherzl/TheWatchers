using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TheWatchers.Domain.Entities;
using TheWatchers.Infrastructure.Persistence.QuerySpecs;
using TheWatchers.SharedKernel.Models;

namespace TheWatchers.Infrastructure.Persistence;

public partial class TheWatchersDbContext(DbContextOptions<TheWatchersDbContext> options) : DbContext(options)
{
    public DbSet<Watcher> Watchers { get; set; }
    public DbSet<WatcherParameter> WatcherParameters { get; set; }

    public DbSet<Domain.Entities.Environment> Environments { get; set; }
    public DbSet<ResourceCategory> ResourceCategories { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<ResourceWatch> ResourceWatches { get; set; }
    public DbSet<ResourceWatchParameter> ResourceWatchParameters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    #region [ Watchers ]

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

        return await query.SingleOrDefaultAsync(ct);
    }

    #endregion

    #region [ Resources Categories ]

    public IQueryable<ResourceCategoryItemModel> GetResourcesCategories()
    {
        var query =
            from resourceCategory in ResourceCategories
            where resourceCategory.Active == true
            select new ResourceCategoryItemModel
            {
                Id = resourceCategory.Id,
                Name = resourceCategory.Name,
            };

        return query;
    }

    public async Task<ResourceCategory> GetResourceCategoryAsync(int? id, bool tracking = false, bool includes = false, CancellationToken ct = default)
    {
        var query = ResourceCategories.AddQuerySpec(new GetResourceCategoryQuerySpec(id));

        if (!tracking)
            query = query.AsNoTracking();

        if (includes)
        {
        }

        return await query.SingleOrDefaultAsync(ct);
    }

    #endregion

    #region [ Resources ]

    public IQueryable<ResourceItemModel> GetResources()
    {
        var query =
            from resource in Resources
            join resourceCategory in ResourceCategories on resource.ResourceCategoryId equals resourceCategory.Id
            where resource.Active == true
            select new ResourceItemModel
            {
                Id = resource.Id,
                Name = resource.Name,
                ResourceCategoryId = resource.Id,
                ResourceCategory = resourceCategory.Name
            };

        return query;
    }

    public async Task<Resource> GetResourceAsync(int? id, bool tracking = false, bool includes = false, CancellationToken ct = default)
    {
        var query = Resources.AddQuerySpec(new GetResourceQuerySpec(id));

        if (!tracking)
            query = query.AsNoTracking();

        if (includes)
        {
            query = query
                .Include(entity => entity.ResourceCategory)
                .Include(entity => entity.ResourceWatches)
                    .ThenInclude(entity => entity.Environment);
        }

        return await query.SingleOrDefaultAsync(ct);
    }

    #endregion

    #region [ Resources watches ]

    public IQueryable<ResourceWatchItemModel> GetResourceWatches()
    {
        var query =
            from resourceWatch in ResourceWatches
            join resource in Resources on resourceWatch.ResourceId equals resource.Id
            join resourceCategory in ResourceCategories on resource.ResourceCategoryId equals resourceCategory.Id
            join watcher in Watchers on resourceCategory.WatcherId equals watcher.Id
            join environment in Environments on resourceWatch.EnvironmentId equals environment.Id
            where resourceWatch.Active == true
            select new ResourceWatchItemModel
            {
                Id = resourceWatch.Id,
                ResourceId = resourceWatch.ResourceId,
                Resource = resource.Name,
                ResourceCategoryId = resource.ResourceCategoryId,
                ResourceCategory = resourceCategory.Name,
                AssemblyQualifiedName = watcher.AssemblyQualifiedName,
                EnvironmentId = environment.Id,
                Environment = environment.Name,
                Successful = resourceWatch.Successful,
                WatchCount = resourceWatch.WatchCount,
                LastWatch = resourceWatch.LastWatch,
                Interval = resourceWatch.Interval
            };

        return query;
    }

    public async Task<ResourceWatch> GetResourceWatchAsync(int? id, bool tracking = false, bool includes = false, CancellationToken ct = default)
    {
        var query = ResourceWatches.AddQuerySpec(new GetResourceWatchQuerySpec(id));

        if (!tracking)
            query = query.AsNoTracking();

        if (includes)
        {
            query = query
                .Include(entity => entity.Resource)
                .Include(entity => entity.Environment)
                .Include(entity => entity.ResourceWatchParameters);
        }

        return await query.SingleOrDefaultAsync(ct);
    }

    public IQueryable<ResourceWatchParameter> GetResourceWatchParameters(short? resourceWatchId)
    {
        return ResourceWatchParameters.AddQuerySpec(new GetResourceWatchParameterByQuerySpec(resourceWatchId));
    }

    #endregion
}
