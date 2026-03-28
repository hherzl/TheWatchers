using Microsoft.EntityFrameworkCore;
using TheWatcher.Domain.Core.Models;
using TheWatcher.Domain.Core.QueryModels;

namespace TheWatcher.Domain.Core
{
    public static class TheWatcherDbContextQueries
    {
        public static IQueryable<WatcherQueryModel> GetWatchers(this TheWatcherDbContext ctx)
        {
            var query =
                from watcher in ctx.Watcher
                select new WatcherQueryModel
                {
                    Id = watcher.Id,
                    Name = watcher.Name,
                    Description = watcher.Description,
                    ClassName = watcher.ClassName
                };

            return query;
        }

        public static IQueryable<ResourceQueryModel> GetResources(this TheWatcherDbContext ctx)
        {
            var query =
                from resource in ctx.Resource
                join category in ctx.ResourceCategory on resource.ResourceCategoryId equals category.Id
                select new ResourceQueryModel
                {
                    Id = resource.Id,
                    Name = resource.Name,
                    ResourceCategoryId = resource.ResourceCategoryId,
                    ResourceCategory = category.Name
                };

            return query;
        }

        public static IQueryable<ResourceWatchQueryModel> GetResourceWatchItems(this TheWatcherDbContext ctx)
        {
            var query =
                from resourceWatch in ctx.ResourceWatch
                join resource in ctx.Resource on resourceWatch.ResourceId equals resource.Id
                join resourceCategory in ctx.ResourceCategory on resource.ResourceCategoryId equals resourceCategory.Id
                join watcher in ctx.Watcher on resourceCategory.WatcherId equals watcher.Id
                join environment in ctx.Environment on resourceWatch.EnvironmentId equals environment.Id
                where resourceWatch.Active == true
                select new ResourceWatchQueryModel
                {
                    Id = resourceWatch.Id,
                    ResourceId = resourceWatch.ResourceId,
                    Resource = resource.Name,
                    ResourceCategoryId = resource.Id,
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

        public static async Task<Watcher> GetWatcherAsync(this TheWatcherDbContext ctx, short? id)
            => await ctx.Watcher.Include(e => e.WatcherParameterList).FirstOrDefaultAsync(item => item.Id == id);

        public static async Task<Resource> GetResourceAsync(this TheWatcherDbContext ctx, short? id)
        {
            return await ctx
                .Resource
                .Include(e => e.ResourceCategoryFk.WatcherFk)
                .Include(e => e.ResourceWatchList)
                    .ThenInclude(e => e.EnvironmentFk)
                .Include(e => e.ResourceWatchList)
                    .ThenInclude(e => e.ResourceWatchParameterList)
                .FirstOrDefaultAsync(item => item.Id == id)
                ;
        }

        public static async Task<ResourceWatch> GetResourceWatchAsync(this TheWatcherDbContext ctx, short? id)
            => await ctx.ResourceWatch.FirstOrDefaultAsync(item => item.Id == id);
    }
}
