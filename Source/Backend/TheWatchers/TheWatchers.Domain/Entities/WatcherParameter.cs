using TheWatchers.Domain.Common;

namespace TheWatchers.Domain.Entities;

public partial class WatcherParameter : Entity
{
    public WatcherParameter()
    {
    }

    public WatcherParameter(short? id)
    {
        Id = id;
    }

    public short? Id { get; set; }
    public short? WatcherId { get; set; }
    public string Parameter { get; set; }
    public string Value { get; set; }
    public bool? IsDefault { get; set; }
    public string Description { get; set; }

    public virtual Watcher Watcher { get; set; }
}
