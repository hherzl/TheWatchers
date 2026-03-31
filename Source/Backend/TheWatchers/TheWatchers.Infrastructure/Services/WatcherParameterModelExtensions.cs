using TheWatchers.Domain.Entities;
using TheWatchers.SharedKernel.Models;

namespace TheWatchers.Infrastructure.Services;

internal static class WatcherParameterModelExtensions
{
    public static WatcherParameterItemModel ToItemModel(this WatcherParameter item)
        => new()
        {
            Id = item.Id,
            Parameter = item.Parameter,
            Value = item.Value,
            IsDefault = item.IsDefault,
            Description = item.Description
        };
}
