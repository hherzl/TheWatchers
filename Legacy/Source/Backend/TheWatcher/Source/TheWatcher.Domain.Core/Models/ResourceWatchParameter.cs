using TheWatcher.Domain.Core.Common;

namespace TheWatcher.Domain.Core.Models
{
    public partial class ResourceWatchParameter : Entity
	{
		public ResourceWatchParameter()
		{
		}

		public ResourceWatchParameter(short? id)
		{
			Id = id;
		}

		public short? Id { get; set; }
		public short? ResourceWatchId { get; set; }
		public string Parameter { get; set; }
		public string Value { get; set; }
		public string Description { get; set; }

		public virtual ResourceWatch ResourceWatchFk { get; set; }
	}
}
