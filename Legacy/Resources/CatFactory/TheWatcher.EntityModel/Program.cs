using System.Dynamic;
using CatFactory.EntityFrameworkCore;
using CatFactory.ObjectRelationalMapping;
using CatFactory.SqlServer;
using CatFactory.SqlServer.CodeFactory;
using CatFactory.SqlServer.DatabaseObjectModel;
using CatFactory.SqlServer.ObjectRelationalMapping;

var db = SqlServerDatabase.CreateWithDefaults("TheWatcher");

db.AddDefaultTypeMapFor(typeof(string), "nvarchar");
db.AddDefaultTypeMapFor(typeof(DateTime), "datetime");

// todo: add version?

var watcher = db
    .DefineEntity(new
    {
        Id = (short)0,
        Name = "",
        Description = "",
        ClassName = "",
        ClassGuid = Guid.Empty,
        AssemblyQualifiedName = "",
    })
    .SetNaming("Watcher")
    .SetColumnFor(e => e.Name, length: 100)
    .SetColumnFor(e => e.Description, nullable: true)
    .SetColumnFor(e => e.ClassName, length: 511)
    .SetColumnFor(e => e.AssemblyQualifiedName, length: 511)
    .SetIdentity(e => e.Id)
    .SetPrimaryKey(e => e.Id)
    .AddUnique(e => e.Name)
    .AddUnique(e => e.ClassName)
    .AddUnique(e => e.ClassGuid)
    .AddUnique(e => e.AssemblyQualifiedName)
    ;

var watcherParameter = db
    .DefineEntity(new
    {
        Id = (short)0,
        WatcherId = (short)0,
        Parameter = "",
        Value = "",
        IsDefault = false,
        Description = ""
    })
    .SetNaming("WatcherParameter")
    .SetColumnFor(e => e.Parameter, length: 100)
    .SetColumnFor(e => e.Value, nullable: true)
    .SetColumnFor(e => e.Description, nullable: true)
    .SetIdentity(e => e.Id)
    .SetPrimaryKey(e => e.Id)
    .AddUnique(e => new { e.WatcherId, e.Parameter })
    .AddForeignKey(e => e.WatcherId, watcher.Table)
    ;

var resourceCategory = db
    .DefineEntity(new
    {
        Id = (short)0,
        Name = "",
        WatcherId = (short)0
    })
    .SetNaming("ResourceCategory")
    .SetColumnFor(e => e.Name, length: 100)
    .SetColumnFor(e => e.WatcherId, nullable: true)
    .SetIdentity(e => e.Id)
    .SetPrimaryKey(e => e.Id)
    .AddUnique(e => e.Name)
    .AddForeignKey(e => e.WatcherId, watcher.Table)
    ;

var resource = db
    .DefineEntity(new
    {
        Id = (short)0,
        Name = "",
        ResourceCategoryId = (short)0
    })
    .SetNaming("Resource")
    .SetColumnFor(e => e.Name, length: 100, nullable: true)
    .SetIdentity(e => e.Id)
    .SetPrimaryKey(e => e.Id)
    .AddForeignKey(e => e.ResourceCategoryId, resourceCategory.Table)
    ;

var environment = db
    .DefineEntity(new
    {
        Id = (short)0,
        Name = ""
    })
    .SetNaming("Environment")
    .SetColumnFor(e => e.Name, length: 100)
    .SetIdentity(e => e.Id)
    .SetPrimaryKey(e => e.Id)
    .AddUnique(e => e.Name)
    ;

var resourceWatch = db
    .DefineEntity(new
    {
        Id = (short)0,
        ResourceId = (short)0,
        EnvironmentId = (short)0,
        Successful = false,
        WatchCount = 0,
        LastWatch = DateTime.Now,
        Interval = 0,
        Description = ""
    })
    .SetNaming("ResourceWatch")
    .SetColumnFor(e => e.Successful, nullable: true)
    .SetColumnFor(e => e.WatchCount, nullable: true)
    .SetColumnFor(e => e.LastWatch, nullable: true)
    .SetColumnFor(e => e.Description, nullable: true)
    .SetIdentity(e => e.Id)
    .SetPrimaryKey(e => e.Id)
    .AddUnique(e => new { e.ResourceId, e.EnvironmentId })
    .AddForeignKey(e => e.ResourceId, resource.Table)
    .AddForeignKey(e => e.EnvironmentId, environment.Table)
    ;

var resourceWatchParameter = db
    .DefineEntity(new
    {
        Id = (short)0,
        ResourceWatchId = (short)0,
        Parameter = "",
        Value = "",
        Description = ""
    })
    .SetNaming("ResourceWatchParameter")
    .SetColumnFor(e => e.Parameter, length: 100)
    .SetColumnFor(e => e.Value, nullable: true)
    .SetColumnFor(e => e.Description, nullable: true)
    .SetIdentity(e => e.Id)
    .SetPrimaryKey(e => e.Id)
    .AddUnique(e => new { e.ResourceWatchId, e.Parameter })
    .AddForeignKey(e => e.ResourceWatchId, resourceWatch.Table)
    ;

var resourceWatchLog = db
    .DefineEntity(new
    {
        Id = (short)0,
        ResourceWatchId = (short)0,
        AssemblyQualifiedName = "",
        ActionName = "",
        Successful = false,
        Message = "",
        ErrorMessage = ""
    })
    .SetNaming("ResourceWatchLog")
    .SetColumnFor(e => e.AssemblyQualifiedName, length: 511)
    .SetColumnFor(e => e.ActionName, length: 511)
    .SetColumnFor(e => e.ErrorMessage, nullable: true)
    .SetIdentity(e => e.Id)
    .SetPrimaryKey(e => e.Id)
    .AddForeignKey(e => e.ResourceWatchId, resourceWatch.Table)
    ;

dynamic importBag = new ExpandoObject();

importBag.ExtendedProperties = new List<ExtendedProperty>();

db.AddColumnForTables(new Column { Name = "Active", Type = "bit", ImportBag = importBag });
db.AddColumnForTables(new Column { Name = "CreationUser", Type = "nvarchar", Length = 50, ImportBag = importBag });
db.AddColumnForTables(new Column { Name = "CreationDateTime", Type = "datetime", ImportBag = importBag });
db.AddColumnForTables(new Column { Name = "LastUpdateUser", Type = "nvarchar", Length = 50, Nullable = true, ImportBag = importBag });
db.AddColumnForTables(new Column { Name = "LastUpdateDateTime", Type = "datetime", Nullable = true, ImportBag = importBag });
db.AddColumnForTables(new Column { Name = "Version", Type = "rowversion", Nullable = true, ImportBag = importBag });

SqlServerDatabaseScriptCodeBuilder.CreateScript(db, @"C:\Temp\Databases", true, true);

// Create instance of Entity Framework Core project
var project = EntityFrameworkCoreProject
    .CreateForV3x("TheWatcher.Domain.Core", db, @"C:\Temp\TheWatcher.Domain.Core");

// Apply settings for Entity Framework Core project
project.GlobalSelection(settings =>
{
    settings.ForceOverwrite = true;
    settings.DeclareNavigationProperties = true;
    settings.DeclareNavigationPropertiesAsVirtual = true;
    settings.AddConfigurationForForeignKeysInFluentAPI = true;
});

// Build features for project, group all entities by schema into a feature
project.BuildFeatures();

// Scaffolding =^^=
project
    .ScaffoldDomain()
    ;
