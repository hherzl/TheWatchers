namespace TheWatchers.WebApi.Hubs;

public record ResourceWatchArgs
{
    public int? Id { get; set; }
    public string Resource { get; set; }
    public string ResourceCategory { get; set; }
    public string Environment { get; set; }
    public bool? Successful { get; set; }
    public int? WatchCount { get; set; }
    public DateTime? LastWatch { get; set; }
    public int? Cols { get; set; }
    public int? Rows { get; set; }
}
