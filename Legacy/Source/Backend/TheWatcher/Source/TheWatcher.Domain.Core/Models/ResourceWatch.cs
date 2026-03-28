using System.Collections.ObjectModel;
using TheWatcher.Domain.Core.Common;

namespace TheWatcher.Domain.Core.Models
{
    public partial class ResourceWatch : Entity
    {
        public ResourceWatch()
        {
        }

        public ResourceWatch(short? id)
        {
            Id = id;
        }

        public short? Id { get; set; }
        public short? ResourceId { get; set; }
        public short? EnvironmentId { get; set; }
        public bool? Successful { get; set; }
        public int? WatchCount { get; set; }
        public DateTime? LastWatch { get; set; }
        public int? Interval { get; set; }
        public string Description { get; set; }

        public virtual Resource ResourceFk { get; set; }
        public virtual Environment EnvironmentFk { get; set; }
        public virtual Collection<ResourceWatchParameter> ResourceWatchParameterList { get; set; }
        public virtual Collection<ResourceWatchLog> ResourceWatchLogList { get; set; }
    }
}
