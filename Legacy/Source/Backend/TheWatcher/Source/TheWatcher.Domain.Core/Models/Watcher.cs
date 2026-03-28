using System.Collections.ObjectModel;
using TheWatcher.Domain.Core.Common;

namespace TheWatcher.Domain.Core.Models
{
    public partial class Watcher : Entity
	{
		public Watcher()
		{
		}

		public Watcher(short? id)
		{
			Id = id;
		}

		public short? Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string ClassName { get; set; }
		public Guid? ClassGuid { get; set; }
		public string AssemblyQualifiedName { get; set; }

		public virtual Collection<WatcherParameter> WatcherParameterList { get; set; }
		public virtual Collection<ResourceCategory> ResourceCategoryList { get; set; }
	}
}
