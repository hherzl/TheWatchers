using System.ComponentModel.DataAnnotations;

namespace TheWatchers.Application.Features.Watchers;

public class CreateWatcherCommand : IValidatableObject
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ClassName { get; set; }
    public Guid? ClassGuid { get; set; }
    public string AssemblyQualifiedName { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrEmpty(Name))
            yield return new ValidationResult("Name is required", [nameof(Name)]);

        if (string.IsNullOrEmpty(Description))
            yield return new ValidationResult("Description is required", [nameof(Description)]);

        if (string.IsNullOrEmpty(ClassName))
            yield return new ValidationResult("ClassName is required", [nameof(ClassName)]);

        if (ClassGuid == null)
            yield return new ValidationResult("ClassGuid is required", [nameof(ClassGuid)]);

        if (string.IsNullOrEmpty(AssemblyQualifiedName))
            yield return new ValidationResult("AssemblyQualifiedName is required", [nameof(AssemblyQualifiedName)]);
    }
}
