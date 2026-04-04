using Microsoft.EntityFrameworkCore;
using TheWatchers.Application.Features.Resources;
using TheWatchers.Application.Features.ResourcesWatches;
using TheWatchers.Application.Services;
using TheWatchers.Domain.Entities;
using TheWatchers.Infrastructure.Persistence;
using TheWatchers.SharedKernel.Models;

namespace TheWatchers.Infrastructure.Services;

public sealed class ResourcesService(TheWatchersDbContext dbContext) : IResourcesService
{
    public async Task<IList<ResourceItemModel>> GetResourcesAsync(GetResourcesQuery request, CancellationToken ct = default)
    {
        return await dbContext.GetResources().ToListAsync(ct);
    }

    public async Task<ResourceDetailsModel> GetResourceAsync(GetResourceQuery request, CancellationToken ct = default)
    {
        var resource = await dbContext.GetResourceAsync(request.Id, false, true, ct);
        if (resource == null)
            return null;

        return new()
        {
            Id = resource.Id,
            Name = resource.Name,
            ResourceCategoryId = resource.ResourceCategoryId,
            ResourceCategory = resource.ResourceCategory.Name
        };
    }

    public async Task<IList<ResourceWatchItemModel>> GetResourcesWatchesAsync(GetResourcesWatchesQuery request, CancellationToken ct = default)
    {
        return await dbContext.GetResourceWatches().ToListAsync(ct);
    }

    public async Task<IList<ResourceWatchParameter>> GetResourceWatchParametersAsync(int? resourceWatchId, CancellationToken ct = default)
    {
        return await dbContext.ResourceWatcheParameters.Where(item => item.ResourceWatchId == resourceWatchId).ToListAsync(ct);
    }
}
