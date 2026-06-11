using TheWatchers.Application.Abstractions;
using TheWatchers.SharedKernel.Core;
using TheWatchers.SharedKernel.Models.Common;

namespace TheWatchers.Application.Features.Watchers;

public sealed class GetCreateWatcherViewBagQueryHandler : IRequestHandler<GetCreateWatcherViewBagQuery, CreateWatcherViewBagModel>
{
    public async Task<CreateWatcherViewBagModel> HandleAsync(GetCreateWatcherViewBagQuery request, CancellationToken ct = default)
    {
        var types = AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => typeof(IWatcher).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
            .ToList();

        var model = new CreateWatcherViewBagModel
        {
            Assemblies = [.. types.Select(item => new ListItem<string>(item.AssemblyQualifiedName, item.FullName))]
        };

        return await Task.FromResult(model);
    }
}
