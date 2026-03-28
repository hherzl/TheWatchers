using Microsoft.AspNetCore.Cors.Infrastructure;

namespace TheWatcher.API.Common
{
    public class CorsSettings
    {
        public List<CorsPolicySetting> Policies { get; set; }
    }

    public class CorsPolicySetting
    {
        public string? Name { get; set; }
        public CorsPolicy Policy { get; set; }
    }
}
