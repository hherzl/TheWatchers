using System.Linq.Expressions;

namespace TheWatchers.Domain.Common;

public abstract class BaseQuerySpec<TModel> where TModel : class
{
    public Expression<Func<TModel, bool>> Criteria { get; set; }
    public List<Expression<Func<TModel, object>>> Includes { get; } = [];
    public List<string> IncludeStrings { get; } = [];

    protected virtual void AddInclude(Expression<Func<TModel, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    protected virtual void AddInclude(string includeString)
    {
        IncludeStrings.Add(includeString);
    }
}
