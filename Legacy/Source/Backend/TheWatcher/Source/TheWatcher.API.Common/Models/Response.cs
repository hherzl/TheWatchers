using TheWatcher.API.Common.Models.Contracts;

namespace TheWatcher.API.Common.Models
{
    public record Response : IResponse
    {
        public string Message { get; set; }
        public bool Failed { get; set; }
    }
}
