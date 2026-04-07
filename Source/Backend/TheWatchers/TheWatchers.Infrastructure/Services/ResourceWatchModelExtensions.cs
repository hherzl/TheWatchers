using TheWatchers.Domain.Entities;
using TheWatchers.SharedKernel.Models;

namespace TheWatchers.Infrastructure.Services;

internal static class ResourceWatchModelExtensions
{
    public static ResourceWatchItemModel ToItemModel(this ResourceWatch entity)
        => new()
        {
            ResourceId = entity.ResourceId,
            Resource = entity.Resource.Name,
            EnvironmentId = entity.EnvironmentId,
            Environment = entity.Environment.Name,
            Successful = entity.Successful,
            WatchCount = entity.WatchCount,
            LastWatch = entity.LastWatch,
            Interval = entity.Interval
        };
}
