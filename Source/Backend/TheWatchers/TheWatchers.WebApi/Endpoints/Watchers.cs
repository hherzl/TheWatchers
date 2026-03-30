using Microsoft.AspNetCore.Mvc;
using TheWatchers.Application.Features.Watchers;

namespace TheWatchers.WebApi.Endpoints;

public static class Mappings
{
    public static WebApplication MapWatchers(this WebApplication webApplication)
    {
        webApplication.MapGet("watchers", async ([FromServices] GetWatchersQueryHandler queryHandler, [AsParameters] GetWatchersQuery request, CancellationToken ct = default) =>
        {
            var value = await queryHandler.HandleAsync(request, ct);
            return Results.Ok(value);
        });

        webApplication.MapGet("watchers/{id}", async ([FromServices] GetWatcherQueryHandler queryHandler, short id, CancellationToken ct = default) =>
        {
            var value = await queryHandler.HandleAsync(new GetWatcherQuery(id), ct);
            if (value == null)
                return Results.NotFound();

            return Results.Ok(value);
        });

        return webApplication;
    }
}
