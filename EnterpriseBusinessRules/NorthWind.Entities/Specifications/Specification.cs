using System.Linq.Expressions;

namespace NorthWind.Entities.Specifications;

public abstract class Specification<T>
{
    public abstract Expression<Func<T, bool>> Expression { get; }
    
    public bool IsSatisfiedBy(T entity)
    {
        Func<T, bool> expressionDelegate = Expression.Compile();
        return expressionDelegate(entity);
    }
}