using TheWatcher.Domain.Core.Models;

namespace TheWatcher.API.Panel.Models
{
    public record ResourceDetailsModel
    {
        public ResourceDetailsModel()
        {
        }

        public ResourceDetailsModel(Resource entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            ResourceCategoryId = entity.ResourceCategoryId;
            ResourceCategory = entity.ResourceCategoryFk.Name;
            WatcherId = entity.ResourceCategoryFk.WatcherId;
            Watcher = entity.ResourceCategoryFk.WatcherFk.Name;
            Watches = entity.ResourceWatchList.Select(item => new ResourceWatchDetailsModel(item)).ToList();
        }

        public short? Id { get; set; }
        public string Name { get; set; }
        public short? ResourceCategoryId { get; set; }
        public string ResourceCategory { get; set; }
        public short? WatcherId { get; set; }
        public string Watcher { get; set; }

        public List<ResourceWatchDetailsModel> Watches { get; set; }
    }
}
