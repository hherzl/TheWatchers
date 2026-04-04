using Microsoft.AspNetCore.Mvc;
using TheWatchers.Application.Features.Watchers;

namespace TheWatchers.WebApi.Endpoints;

public static partial class Mappings
{
    public static WebApplication MapWatchers(this WebApplication webApplication)
    {
        webApplication.MapGet("watchers", async ([FromServices] GetWatchersQueryHandler queryHandler, [AsParameters] GetWatchersQuery request) =>
        {
            var value = await queryHandler.HandleAsync(request);
            return Results.Ok(value);
        });

        webApplication.MapGet("watchers/{id}", async ([FromServices] GetWatcherQueryHandler queryHandler, short id) =>
        {
            var value = await queryHandler.HandleAsync(new GetWatcherQuery(id));
            if (value == null)
                return Results.NotFound();

            return Results.Ok(value);
        });

        return webApplication;
    }
}
