namespace TheWatchers.SharedKernel.Models;

public record ResourceCategoryDetailsModel
{
    public short? Id { get; set; }
    public string Name { get; set; }
    public short? WatcherId { get; set; }
}
