using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Carsales.Common.Exception;
using Carsales.Common.Models;

namespace Carsales.Common.Extension
{
    // ReSharper disable once InconsistentNaming
    public static class IQueryableHelper
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, IOrderedResultInput input)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source), "source is null.");

            if (input == null)
                throw new ArgumentException("IOrderedResultInput is null or empty.", nameof(input));

            var tType = typeof(T);

            var prop = tType.GetProperty(input.Sort);

            if (prop == null)
            {
                throw new ArgumentException($"No property '{input.Sort}' on type '{tType.Name}'");
            }

            var funcType = typeof(Func<,>)
                .MakeGenericType(tType, prop.PropertyType);

            var lambdaBuilder = typeof(Expression)
                .GetMethods()
                .First(x => x.Name == "Lambda" && x.ContainsGenericParameters && x.GetParameters().Length == 2)
                .MakeGenericMethod(funcType);

            var parameter = Expression.Parameter(tType);
            var propExpress = Expression.Property(parameter, prop);

            var sortLambda = lambdaBuilder
                .Invoke(null, new object[] { propExpress, new[] { parameter } });

            var sorter = typeof(Queryable)
                .GetMethods()
                .FirstOrDefault(x => x.Name == (input.Ascending ? "OrderBy": "OrderByDescending") && x.GetParameters().Length == 2)
                .MakeGenericMethod(tType, prop.PropertyType);

            return (IQueryable<T>)sorter
                .Invoke(null, new[] { source, sortLambda });

            return source;
        }

        public static IQueryable<TSource> PageBy<TSource>(this IQueryable<TSource> query, IPagedResultInput input)
        {
            return query.OrderBy(input).Skip(input.Skip).Take(input.Take);
        }

        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source,
            bool statement,Expression<Func<TSource, bool>> predicate)
        {
            if (statement)
            {
                return source.Where(predicate);
            }
            return source;
        }
    }
}
