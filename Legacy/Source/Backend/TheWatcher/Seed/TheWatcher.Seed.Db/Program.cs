using TheWatcher.Seed.Db.Helpers;
using TheWatcher.Seed.Db.Seeds;

Console.WriteLine("Seeding...");
Console.WriteLine();

using var ctx = DbContextHelper.GetTheWatcherDbContext();

var audit = new
{
    CreationUser = "thewatcher.seed"
};

Console.WriteLine("Creating watchers...");

foreach (var tuple in Watchers.Items)
{
    var watcher = tuple.Item1;

    watcher.Active = true;
    watcher.CreationUser = audit.CreationUser;
    watcher.CreationDateTime = DateTime.Now;

    Console.WriteLine($" Adding '{watcher.Name}' watcher...");

    ctx.Watcher.Add(watcher);

    ctx.SaveChanges();

    Console.WriteLine("  Creating parameters for watcher...");

    foreach (var parameter in tuple.Item2)
    {
        parameter.WatcherId = watcher.Id;
        parameter.Active = true;
        parameter.CreationUser = audit.CreationUser;
        parameter.CreationDateTime = DateTime.Now;

        ctx.WatcherParameter.Add(parameter);

        ctx.SaveChanges();
    }

    Console.WriteLine("  The watcher parameters were created successfully");
}

Console.WriteLine(" The watchers were created successfully");
Console.WriteLine();

Console.WriteLine("Creating resource categories...");

foreach (var item in ResourceCategories.Items)
{
    item.Active = true;
    item.CreationUser = audit.CreationUser;
    item.CreationDateTime = DateTime.Now;

    ctx.ResourceCategory.Add(item);

    Console.WriteLine($" Adding '{item.Name}' resource category...");

    ctx.SaveChanges();
}

Console.WriteLine(" The resource categories were created successfully");
Console.WriteLine();

Console.WriteLine("Creating resources...");

foreach (var item in Resources.Items)
{
    item.Active = true;
    item.CreationUser = audit.CreationUser;
    item.CreationDateTime = DateTime.Now;

    ctx.Resource.Add(item);

    Console.WriteLine($" Adding '{item.Name}' resource...");

    ctx.SaveChanges();
}

Console.WriteLine(" The watchers were created successfully");
Console.WriteLine();

Console.WriteLine("Creating environments...");

foreach (var item in Environments.Items)
{
    item.Active = true;
    item.CreationUser = audit.CreationUser;
    item.CreationDateTime = DateTime.Now;

    ctx.Environment.Add(item);

    Console.WriteLine($" Adding '{item.Name}' environment...");

    ctx.SaveChanges();
}

Console.WriteLine(" The environments were created successfully");
Console.WriteLine();

Console.WriteLine("Creating resource watches...");

foreach (var tuple in ResourceWatches.Items)
{
    var resourceWatch = tuple.Item1;

    resourceWatch.Active = true;
    resourceWatch.CreationUser = audit.CreationUser;
    resourceWatch.CreationDateTime = DateTime.Now;

    ctx.ResourceWatch.Add(resourceWatch);

    Console.WriteLine($" Adding '{resourceWatch.ResourceId}' resource watch...");

    ctx.SaveChanges();

    Console.WriteLine("Creating resource watches parameters...");

    foreach (var resourceWatchParameter in tuple.Item2)
    {
        resourceWatchParameter.ResourceWatchId = resourceWatch.Id;
        resourceWatchParameter.Active = true;
        resourceWatchParameter.CreationUser = audit.CreationUser;
        resourceWatchParameter.CreationDateTime = DateTime.Now;

        ctx.ResourceWatchParameter.Add(resourceWatchParameter);

        ctx.SaveChanges();
    }

    Console.WriteLine(" The resource watches parameters were created successfully");
}

Console.WriteLine("The resource watches were created successfully");
Console.WriteLine();
