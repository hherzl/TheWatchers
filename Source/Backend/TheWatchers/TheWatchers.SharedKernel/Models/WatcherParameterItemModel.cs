namespace TheWatchers.SharedKernel.Models;

public record WatcherParameterItemModel
{
    public short? Id { get; set; }
    public string Parameter { get; set; }
    public string Value { get; set; }
    public bool? IsDefault { get; set; }
    public string Description { get; set; }
}
