using Microsoft.EntityFrameworkCore;
using TheWatchers.Application.Features.ResourcesWatches;
using TheWatchers.Application.Services;
using TheWatchers.Domain.Entities;
using TheWatchers.Infrastructure.Persistence;
using TheWatchers.SharedKernel.Models;

namespace TheWatchers.Infrastructure.Services;

public sealed class ResourcesService(TheWatchersDbContext dbContext) : IResourcesService
{
    public async Task<IList<ResourceWatchItemModel>> GetResourcesWatchesAsync(GetResourcesWatchesQuery request, CancellationToken ct = default)
    {
        return await dbContext.GetResourceWatches().ToListAsync(ct);
    }

    public async Task<IList<ResourceWatchParameter>> GetResourceWatchParametersAsync(int? resourceWatchId, CancellationToken ct = default)
    {
        return await dbContext.ResourceWatcheParameters.Where(item => item.ResourceWatchId == resourceWatchId).ToListAsync(ct);
    }
}
