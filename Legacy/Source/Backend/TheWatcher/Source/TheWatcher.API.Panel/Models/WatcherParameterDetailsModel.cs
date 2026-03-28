namespace TheWatcher.API.Panel.Models
{
    public record WatcherParameterDetailsModel
    {
        public WatcherParameterDetailsModel()
        {
        }

        public WatcherParameterDetailsModel(short? id, bool? isDefault, string parameter, string value, string description)
        {
            Id = id;
            IsDefault = isDefault;
            Parameter = parameter;
            Value = value;
            Description = description;
        }

        public short? Id { get; set; }
        public bool? IsDefault { get; set; }
        public string Parameter { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
