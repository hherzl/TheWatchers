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
        var entity = await dbContext.GetWatcherAsync(request.Id, false, true, ct);
        if (entity == null)
            return null;

        return new()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            ClassName = entity.ClassName,
            ClassGuid = entity.ClassGuid,
            AssemblyQualifiedName = entity.AssemblyQualifiedName,
            Parameters = [.. entity.WatcherParameters.Select(item => item.ToItemModel())]
        };
    }
}
