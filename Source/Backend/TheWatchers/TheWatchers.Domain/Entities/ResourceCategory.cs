using System.Collections.ObjectModel;
using TheWatchers.Domain.Common;

namespace TheWatchers.Domain.Entities;

public partial class ResourceCategory : Entity
{
    public ResourceCategory()
    {
    }

    public ResourceCategory(short? id)
    {
        Id = id;
    }

    public short? Id { get; set; }
    public string Name { get; set; }
    public short? WatcherId { get; set; }

    public virtual Watcher Watcher { get; set; }
    public virtual Collection<Resource> Resources { get; set; }
}
