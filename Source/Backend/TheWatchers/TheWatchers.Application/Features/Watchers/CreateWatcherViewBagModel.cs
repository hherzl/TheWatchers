using System.Collections.ObjectModel;
using TheWatchers.SharedKernel.Models.Common;

namespace TheWatchers.Application.Features.Watchers;

public record CreateWatcherViewBagModel
{
    public Collection<ListItem<string>> Assemblies { get; set; }
}
