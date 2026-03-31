using Microsoft.EntityFrameworkCore;
using TheWatchers.Application.Features.Watchers;
using TheWatchers.Application.Services;
using TheWatchers.Infrastructure.Persistence;
using TheWatchers.SharedKernel.Models;

namespace TheWatchers.Infrastructure.Services;

public sealed class WatchersService(TheWatchersDbContext dbContext) : IWatchersService
{
    public async Task<IList<WatcherItemModel>> GetWatchersAsync(GetWatchersQuery request, CancellationToken ct = default)
    {
        return await dbContext.GetWatchers().ToListAsync(ct);
    }

    public async Task<WatcherDetailsModel> GetWatcherAsync(GetWatcherQuery request, CancellationToken ct = default)
    {
        var watcher = await dbContext.GetWatcherAsync(request.Id, false, true, ct);
        if (watcher == null)
            return null;

        return new()
        {
            Id = watcher.Id,
            Name = watcher.Name,
            Description = watcher.Description,
            ClassName = watcher.ClassName,
            ClassGuid = watcher.ClassGuid,
            AssemblyQualifiedName = watcher.AssemblyQualifiedName,
            Parameters = [.. watcher.WatcherParameters.Select(item => item.ToItemModel())]
        };
    }
}
