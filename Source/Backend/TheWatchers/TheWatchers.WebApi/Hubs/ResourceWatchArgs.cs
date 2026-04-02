namespace TheWatchers.WebApi.Hubs;

public record ResourceWatchArgs(short? ResourceId, string Resource, short? EnvironmentId, string Environment, bool IsSuccess, DateTime LastWatch);
