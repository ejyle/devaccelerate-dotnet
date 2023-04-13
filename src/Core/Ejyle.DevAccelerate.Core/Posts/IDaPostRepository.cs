// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Data;

namespace Ejyle.DevAccelerate.Core.Posts
{
    public interface IDaPostRepository<TKey, TPost> : IDaEntityRepository<TKey, TPost>
        where TKey : IEquatable<TKey>
        where TPost : IDaPost<TKey>
    {
        Task CreateAsync(TPost post);
        Task<TPost> FindByIdAsync(TKey id);
        Task<DaPaginatedEntityList<TKey, TPost>> FindAsync(DaDataPaginationCriteria paginationCritria, string tenantId, string userId, string[] roleIds, string[] organizationGroupIds);
        Task UpdateAsync(TPost post);
        Task DeleteAsync(TPost post);
        IQueryable<TPost> Posts { get; }
    }
}
