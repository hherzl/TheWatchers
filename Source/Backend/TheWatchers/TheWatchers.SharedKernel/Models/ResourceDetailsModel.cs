namespace TheWatchers.SharedKernel.Models;

public record ResourceDetailsModel
{
    public short? Id { get; set; }
    public string Name { get; set; }
    public short? ResourceCategoryId { get; set; }
    public string ResourceCategory { get; set; }
}
