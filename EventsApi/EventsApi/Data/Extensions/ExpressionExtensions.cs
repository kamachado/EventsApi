using System.Linq.Expressions;

namespace EventsApi.Data.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> predicate1, Expression<Func<T, bool>>? predicate2)
        {
            if (predicate2 == null) return predicate1;
            if (predicate1 == null) return predicate2;
            var param = Expression.Parameter(typeof(T), "i");
            var body = Expression.AndAlso(Expression.Invoke(predicate1, param), Expression.Invoke(predicate2, param));
            return Expression.Lambda<Func<T, bool>>(body, param);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> predicate1, Expression<Func<T, bool>>? predicate2)
        {
            if (predicate2 == null) return predicate1;
            if (predicate1 == null) return predicate2;
            var param = Expression.Parameter(typeof(T), "i");
            var body = Expression.OrElse(Expression.Invoke(predicate1, param), Expression.Invoke(predicate2, param));
            return Expression.Lambda<Func<T, bool>>(body, param);
        }
    }
}
