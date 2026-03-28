namespace TheWatcher.API.Monitor.Hubs.Models
{
    public record ResourceWatchArg
    {
        public short? ResourceId { get; set; }
        public string Resource { get; set; }
        public short? EnvironmentId { get; set; }
        public string Environment { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime LastWatch { get; set; }
    }
}
