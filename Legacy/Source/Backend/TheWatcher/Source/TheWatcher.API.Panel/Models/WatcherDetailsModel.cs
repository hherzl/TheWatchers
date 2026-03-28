using TheWatcher.Domain.Core.Models;

namespace TheWatcher.API.Panel.Models
{
    public record WatcherDetailsModel
    {
        public WatcherDetailsModel()
        {
        }

        public WatcherDetailsModel(Watcher entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            ClassName = entity.ClassName;
            ClassGuid = entity.ClassGuid;
            AssemblyQualifiedName = entity.AssemblyQualifiedName;
            Parameters = entity
                .WatcherParameterList
                .Select(item => new WatcherParameterDetailsModel(item.Id, item.IsDefault, item.Parameter, item.Value, item.Description))
                .ToList()
                ;
        }

        public short? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ClassName { get; set; }
        public Guid? ClassGuid { get; set; }
        public string AssemblyQualifiedName { get; set; }

        public List<WatcherParameterDetailsModel> Parameters { get; set; }
    }
}
