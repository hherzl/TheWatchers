namespace TheWatchers.Domain.Entities;

public partial class Resource
{
    public Resource(string name, short? categoryId)
    {
        Active = true;

        Name = name;
        ResourceCategoryId = categoryId;
    }
}
