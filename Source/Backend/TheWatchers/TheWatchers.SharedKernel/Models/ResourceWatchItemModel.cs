using TheWatchers.SharedKernel.Core;

namespace TheWatchers.SharedKernel.Models;

public record ResourceWatchItemModel
{
    public ResourceWatchItemModel()
    {
        Parameters = new();
    }

    public int? Id { get; set; }
    public short? ResourceId { get; set; }
    public string Resource { get; set; }
    public short? ResourceCategoryId { get; set; }
    public string ResourceCategory { get; set; }
    public string AssemblyQualifiedName { get; set; }
    public short? EnvironmentId { get; set; }
    public string Environment { get; set; }
    public bool? Successful { get; set; }
    public int? WatchCount { get; set; }
    public DateTime? LastWatch { get; set; }
    public double? Interval { get; set; }

    public WatchParameters Parameters { get; set; }
}
