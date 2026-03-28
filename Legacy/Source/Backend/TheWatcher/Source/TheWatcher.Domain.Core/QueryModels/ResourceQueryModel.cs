namespace TheWatcher.Domain.Core.QueryModels
{
    public class ResourceQueryModel
    {
        public short? Id { get; set; }
        public string Name { get; set; }
        public short? ResourceCategoryId { get; set; }
        public string ResourceCategory { get; set; }
    }
}
