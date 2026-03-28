namespace TheWatcher.Domain.Core.Common
{
    public abstract class Entity : IEntity
    {
        public bool? Active { get; set; }
        public string CreationUser { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public string LastUpdateUser { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }
        public byte[] Version { get; set; }
    }
}
