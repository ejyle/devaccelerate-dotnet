// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Core.Data
{
    /// <summary>
    /// Represents a paginated list of entities.
    /// </summary>
    /// <typeparam name="TKey">The type of a key.</typeparam>
    /// <typeparam name="TEntity">The type of an entity.</typeparam>
    public class DaPaginatedEntityList<TKey, TEntity>
        where TKey : IEquatable<TKey>
        where TEntity : IDaEntity<TKey>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaPaginatedEntityList{TKey, TEntity}"/> class.
        /// </summary>
        /// <param name="entities">The list of entities. Cannot be null.</param>
        /// <param name="pagination">The pagination result.</param>
        public DaPaginatedEntityList(List<TEntity> entities, DaDataPaginationResult pagination)
        {
            Entities = entities ?? throw new ArgumentNullException("entities");
            Pagination = pagination ?? throw new ArgumentNullException("pagination");
        }

        /// <summary>
        /// Gets the pagination result of the query that retrieved the list of entities.
        /// </summary>
        public DaDataPaginationResult Pagination
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the list of entities.
        /// </summary>
        public List<TEntity> Entities
        {
            get;
            private set;
        }
    }
}