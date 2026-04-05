using Microsoft.AspNetCore.Mvc;
using TheWatchers.Application.Features.ResourcesCategories;

namespace TheWatchers.WebApi.Endpoints;

public static partial class Mappings
{
    public static WebApplication MapResourceCategories(this WebApplication webApplication)
    {
        webApplication.MapGet("resources-categories", async ([FromServices] GetResourcesCategoriesQueryHandler queryHandler, [AsParameters] GetResourcesCategoriesQuery request) =>
        {
            var value = await queryHandler.HandleAsync(request);
            return Results.Ok(value);
        });

        webApplication.MapGet("resources-categories/{id}", async ([FromServices] GetResourceCategoryQueryHandler queryHandler, short id) =>
        {
            var value = await queryHandler.HandleAsync(new GetResourceCategoryQuery(id));
            if (value == null)
                return Results.NotFound();

            return Results.Ok(value);
        });

        return webApplication;
    }
}
