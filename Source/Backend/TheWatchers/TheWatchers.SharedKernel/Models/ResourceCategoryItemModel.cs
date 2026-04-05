namespace TheWatchers.SharedKernel.Models;

public record ResourceCategoryItemModel
{
    public short? Id { get; set; }
    public string Name { get; set; }
    public short? WatcherId { get; set; }
}
