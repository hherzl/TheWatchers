using TheWatchers.Domain.Entities;
using TheWatchers.SharedKernel.Models;

namespace TheWatchers.Infrastructure.Services;

internal static class WatcherParameterModelExtensions
{
    public static WatcherParameterItemModel ToItemModel(this WatcherParameter entity)
        => new()
        {
            Id = entity.Id,
            Parameter = entity.Parameter,
            Value = entity.Value,
            IsDefault = entity.IsDefault,
            Description = entity.Description
        };
}
