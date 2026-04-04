using TheWatchers.Application.Features.Resources;
using TheWatchers.Application.Features.ResourcesWatches;
using TheWatchers.Domain.Entities;
using TheWatchers.SharedKernel.Models;

namespace TheWatchers.Application.Services;

public interface IResourcesService
{
    Task<IList<ResourceItemModel>> GetResourcesAsync(GetResourcesQuery request, CancellationToken ct = default);
    Task<ResourceDetailsModel> GetResourceAsync(GetResourceQuery request, CancellationToken ct = default);
    Task<IList<ResourceWatchItemModel>> GetResourcesWatchesAsync(GetResourcesWatchesQuery request, CancellationToken ct = default);
    Task<IList<ResourceWatchParameter>> GetResourceWatchParametersAsync(int? resourceWatchId, CancellationToken ct = default);
}
