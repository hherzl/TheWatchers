using System.Collections.ObjectModel;
using TheWatcher.Domain.Core.Common;

namespace TheWatcher.Domain.Core.Models
{
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

		public virtual Watcher WatcherFk { get; set; }
		public virtual Collection<Resource> ResourceList { get; set; }
	}
}
