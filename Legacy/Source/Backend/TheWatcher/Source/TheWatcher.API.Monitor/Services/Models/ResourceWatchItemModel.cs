using TheWatcher.Domain.Core.QueryModels;
using TheWatcher.Library.Core;

namespace TheWatcher.API.Monitor.Services.Models
{
    public class ResourceWatchItemModel : ResourceWatchQueryModel
    {
        public ResourceWatchItemModel()
        {
            Param = new();
        }

        public WatcherParam Param { get; set; }
    }
}
