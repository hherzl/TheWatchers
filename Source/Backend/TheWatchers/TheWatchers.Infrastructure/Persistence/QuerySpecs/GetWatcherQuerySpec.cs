using TheWatchers.Domain.Common;
using TheWatchers.Domain.Entities;

namespace TheWatchers.Infrastructure.Persistence.QuerySpecs;

public class GetWatcherQuerySpec : BaseQuerySpec<Watcher>
{
    public GetWatcherQuerySpec(short? id)
    {
        Criteria = entity => entity.Id == id;
    }
}
