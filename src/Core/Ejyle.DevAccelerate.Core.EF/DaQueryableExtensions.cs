// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Core.EF
{
    /// <summary>
    /// Represents DevAccelerate extensions methods for <see cref="IQueryable{T}"/> types.
    /// </summary>
    public static class DaQueryableExtensions
    {
        /// <summary>
        /// Asynchronously applies pagination to a LINQ query.
        /// </summary>
        /// <typeparam name="TKey">The type of a key.</typeparam>
        /// <typeparam name="TEntity">The type of an entity.</typeparam>
        /// <param name="query">The query object on which the extension method is executed.</param>
        /// <param name="paginationCriteria">Pagination criteria.</param>
        /// <param name="paginationResult">Pagination result.</param>
        /// <returns>Returns an instance of the type <see cref="IQueryable{T}"/>.</returns>
        public static IQueryable<TEntity> Paginate<TKey, TEntity>(this IQueryable<TEntity> query, DaDataPaginationCriteria paginationCriteria, out DaDataPaginationResult paginationResult)
            where TKey : IEquatable<TKey>
            where TEntity : IDaEntity<TKey>
        {
            var q = query
                .Skip(GetSkip(paginationCriteria.PageIndex, paginationCriteria.PageSize))
                .Take(paginationCriteria.PageSize);

            paginationResult = new DaDataPaginationResult(paginationCriteria, q.Count());

            return q;
        }

        /// <summary>
        /// Asynchronously applies pagination to a LINQ query.
        /// </summary>
        /// <typeparam name="TKey">The type of a key.</typeparam>
        /// <typeparam name="TEntity">The type of an entity.</typeparam>
        /// <param name="query">The query object on which the extension method is executed.</param>
        /// <param name="paginationCriteria">Pagination criteria.</param>
        /// <returns>Returns an instance of the type <see cref="IQueryable{T}"/>.</returns>
        public static async Task<DaPaginatedEntityList<TKey, TEntity>> PaginateAsync<TKey, TEntity>(this IQueryable<TEntity> query, DaDataPaginationCriteria paginationCriteria)
            where TKey : IEquatable<TKey>
            where TEntity : IDaEntity<TKey>
        {
            var q = query
                .Skip(GetSkip(paginationCriteria.PageIndex, paginationCriteria.PageSize))
                .Take(paginationCriteria.PageSize);

            var count = await q.CountAsync();
            var paginationResult = new DaDataPaginationResult(paginationCriteria, count);
            var entities = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TEntity>(entities, paginationResult);
        }

        public static IOrderedQueryable<TSource> OrderBy<TSource>(
               this IQueryable<TSource> query, string propertyName, bool desc)
        {
            var entityType = typeof(TSource);

            //Create x=>x.PropName
            var propertyInfo = entityType.GetProperty(propertyName);
            ParameterExpression arg = Expression.Parameter(entityType, "x");
            MemberExpression property = Expression.Property(arg, propertyName);
            var selector = Expression.Lambda(property, new ParameterExpression[] { arg });

            //Get System.Linq.Queryable.OrderBy() method.
            var enumarableType = typeof(System.Linq.Queryable);

            var methodName = "OrderBy";

            if (desc)
            {
                methodName = "OrderByDescending";
            }

            var method = enumarableType.GetMethods()
                 .Where(m => m.Name == methodName && m.IsGenericMethodDefinition)
                 .Where(m =>
                 {
                     var parameters = m.GetParameters().ToList();
                     //Put more restriction here to ensure selecting the right overload                
                     return parameters.Count == 2;//overload that has 2 parameters
                 }).Single();

            //The linq's OrderBy<TSource, TKey> has two generic types, which provided here
            MethodInfo genericMethod = method
                 .MakeGenericMethod(entityType, propertyInfo.PropertyType);

            /*Call query.OrderBy(selector), with query and selector: x=> x.PropName
              Message that we pass the selector as Expression to the method and we don't compile it.
              By doing so EF can extract "order by" columns and generate SQL for it.*/
            var newQuery = (IOrderedQueryable<TSource>)genericMethod
                 .Invoke(genericMethod, new object[] { query, selector });
            return newQuery;
        }

        private static int GetSkip(int pageIndex, int take)
        {
            return (pageIndex - 1) * take;
        }
    }
}
