namespace TheWatcher.Domain.Core.Common
{
    public interface IEntity
    {
        bool? Active { get; set; }
        string CreationUser { get; set; }
        DateTime? CreationDateTime { get; set; }
        string LastUpdateUser { get; set; }
        DateTime? LastUpdateDateTime { get; set; }
        byte[] Version { get; set; }
    }
}
