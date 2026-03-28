using TheWatcher.Domain.Core.Models;

namespace TheWatcher.API.Panel.Models
{
    public record ResourceWatchDetailsModel
    {
        public ResourceWatchDetailsModel()
        {
        }

        public ResourceWatchDetailsModel(ResourceWatch entity)
        {
            Id = entity.Id;
            EnvironmentId = entity.EnvironmentId;
            Environment = entity.EnvironmentFk.Name;
            Successful = entity.Successful;
            WatchCount = entity.WatchCount;
            LastWatch = entity.LastWatch;
            Interval = entity.Interval;
            Parameters = entity.ResourceWatchParameterList.Select(parameter => new ResourceWatchParameterDetailsModel(parameter)).ToList();
        }

        public short? Id { get; set; }
        public short? EnvironmentId { get; set; }
        public string Environment { get; set; }
        public bool? Successful { get; set; }
        public int? WatchCount { get; set; }
        public DateTime? LastWatch { get; set; }
        public int? Interval { get; set; }

        public List<ResourceWatchParameterDetailsModel> Parameters { get; set; }
    }
}
