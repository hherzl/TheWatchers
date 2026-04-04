using System.Collections.ObjectModel;

namespace TheWatchers.WebApi;

public record CorsPolicy
{
    public string Name { get; set; }
    public Collection<string> Origins { get; set; }
}
