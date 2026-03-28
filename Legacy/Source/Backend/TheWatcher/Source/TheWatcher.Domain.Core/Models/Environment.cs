using System.Collections.ObjectModel;
using TheWatcher.Domain.Core.Common;

namespace TheWatcher.Domain.Core.Models
{
    public partial class Environment : Entity
	{
		public Environment()
		{
		}

		public Environment(short? id)
		{
			Id = id;
		}

		public short? Id { get; set; }
		public string Name { get; set; }

		public virtual Collection<ResourceWatch> ResourceWatchList { get; set; }
	}
}
