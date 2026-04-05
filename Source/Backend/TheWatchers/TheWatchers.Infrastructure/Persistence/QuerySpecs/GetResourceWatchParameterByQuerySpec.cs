using TheWatchers.Domain.Common;
using TheWatchers.Domain.Entities;

namespace TheWatchers.Infrastructure.Persistence.QuerySpecs;

public class GetResourceWatchParameterByQuerySpec : BaseQuerySpec<ResourceWatchParameter>
{
    public GetResourceWatchParameterByQuerySpec(int? resourceWatchId)
    {
        if (resourceWatchId.HasValue)
            Criteria = entity => entity.ResourceWatchId == resourceWatchId;
    }
}
