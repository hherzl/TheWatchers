using TheWatcher.Domain.Core.Models;

namespace TheWatcher.API.Panel.Models
{
    public record ResourceWatchParameterDetailsModel
    {
        public ResourceWatchParameterDetailsModel()
        {
        }

        public ResourceWatchParameterDetailsModel(ResourceWatchParameter entity)
        {
            Parameter = entity.Parameter;
            Value = entity.Value;
            Description = entity.Description;
        }

        public string Parameter { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
