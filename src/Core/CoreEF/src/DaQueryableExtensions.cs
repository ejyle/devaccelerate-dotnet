// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core.Data;

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

        private static int GetSkip(int pageIndex, int take)
        {
            return (pageIndex - 1) * take;
        }
    }
}
