using System.Collections.ObjectModel;
using TheWatcher.Domain.Core.Common;

namespace TheWatcher.Domain.Core.Models
{
    public partial class Resource : Entity
	{
		public Resource()
		{
		}

		public Resource(short? id)
		{
			Id = id;
		}

		public short? Id { get; set; }
		public string Name { get; set; }
		public short? ResourceCategoryId { get; set; }

		public virtual ResourceCategory ResourceCategoryFk { get; set; }
		public virtual Collection<ResourceWatch> ResourceWatchList { get; set; }
	}
}
