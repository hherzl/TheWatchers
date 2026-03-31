namespace TheWatchers.SharedKernel.Models;

public record WatcherDetailsModel
{
    public WatcherDetailsModel()
    {
        Parameters = [];
    }

    public short? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ClassName { get; set; }
    public Guid? ClassGuid { get; set; }
    public string AssemblyQualifiedName { get; set; }

    public IList<WatcherParameterItemModel> Parameters { get; set; }
}
