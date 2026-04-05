using Microsoft.AspNetCore.Mvc;
using TheWatchers.Application.Features.Watchers;

namespace TheWatchers.WebApi.Endpoints;

public static partial class Mappings
{
    public static WebApplication MapWatchers(this WebApplication webApplication)
    {
        webApplication.MapGet("watchers", async ([FromServices] GetWatchersQueryHandler queryHandler, [AsParameters] GetWatchersQuery request) =>
        {
            var result = await queryHandler.HandleAsync(request);
            return Results.Ok(result);
        });

        webApplication.MapGet("watchers/{id}", async ([FromServices] GetWatcherQueryHandler queryHandler, short id) =>
        {
            var result = await queryHandler.HandleAsync(new GetWatcherQuery(id));
            return result == null ? Results.NotFound() : Results.Ok(result);
        });

        return webApplication;
    }
}
