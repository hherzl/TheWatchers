using Microsoft.EntityFrameworkCore;
using TheWatchers.Domain.Common;

namespace TheWatchers.Infrastructure.Persistence.QuerySpecs;

public static class QuerySpecExtensions
{
    public static IQueryable<TModel> AddQuerySpec<TModel>(this IQueryable<TModel> query, BaseQuerySpec<TModel> spec) where TModel : class
    {
        // fetch a Queryable that includes all expression-based includes
        var queryableResultWithIncludes = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

        // modify the IQueryable to include any string-based include statements
        var secondaryResult = spec.IncludeStrings.Aggregate(queryableResultWithIncludes, (current, include) => current.Include(include));

        // return the result of the query using the specification's criteria expression
        return spec.Criteria == null ? secondaryResult : secondaryResult.Where(spec.Criteria);
    }
}
