using TheWatcher.Domain.Core.Common;

namespace TheWatcher.Domain.Core.Models
{
    public class ResourceWatchLog : Entity
    {
        public ResourceWatchLog()
        {
        }

        public ResourceWatchLog(short? id)
        {
            Id = id;
        }

        public short? Id { get; set; }
        public short? ResourceWatchId { get; set; }
        public string AssemblyQualifiedName { get; set; }
        public string? ActionName { get; set; }
        public bool? Successful { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }

        public virtual ResourceWatch ResourceWatchFk { get; set; }
    }
}
