using System.Collections.ObjectModel;
using TheWatchers.Domain.Common;

namespace TheWatchers.Domain.Entities;

public partial class ResourceWatch : Entity
{
    public ResourceWatch()
    {
        ResourceWatchParameters = [];
    }

    public ResourceWatch(short? id)
    {
        Id = id;
    }

    public int? Id { get; set; }
    public short? ResourceId { get; set; }
    public short? EnvironmentId { get; set; }
    public bool? Successful { get; set; }
    public int? WatchCount { get; set; }
    public DateTime? LastWatch { get; set; }
    public int? Interval { get; set; }
    public string Description { get; set; }

    public virtual Resource Resource { get; set; }
    public virtual Environment Environment { get; set; }
    public virtual Collection<ResourceWatchParameter> ResourceWatchParameters { get; set; }
}
