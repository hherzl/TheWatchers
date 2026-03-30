namespace TheWatchers.SharedKernel.Models;

public record WatcherItemModel
{
    public short? Id { get; set; }
    public string Name { get; set; }
    public string ClassName { get; set; }
    public Guid? ClassGuid { get; set; }
}
