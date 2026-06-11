namespace TheWatchers.SharedKernel.Models.Common;

public record ListItem<TId>
{
    public ListItem()
    {
    }

    public ListItem(TId id, string name)
    {
        Id = id;
        Name = name;
    }

    public TId Id { get; set; }
    public string Name { get; set; }
}
