using TheWatchers.SharedKernel.Core;

namespace TheWatchers.Domain.Entities;

public partial class Watcher
{
    public Watcher(string name, string description, IWatcher watcher, params WatcherParameter[] parameters)
        : this()
    {
        Active = true;

        Name = name;
        Description = description;

        ClassName = watcher.GetType().Name;
        ClassGuid = watcher.Guid;
        AssemblyQualifiedName = watcher.GetType().AssemblyQualifiedName;

        foreach (var parameter in parameters)
        {
            WatcherParameters.Add(parameter);
        }
    }
}
