// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Data;

namespace Ejyle.DevAccelerate.Lists.Custom
{
    public interface IDaCustomListRepository<TKey, TCustomList, TCustomListItem> : IDaEntityRepository<TKey, TCustomList>
        where TKey : IEquatable<TKey>
        where TCustomList : IDaCustomList<TKey>
        where TCustomListItem: IDaCustomListItem<TKey>
    {
        Task CreateAsync(TCustomList customList);
        Task CreateAsync(TCustomList[] customList);
        Task UpdateAsync(TCustomList customList);
        Task DeleteAsync(TCustomList customList);
        Task DeleteListItemAsync(TCustomListItem customListItem);

        Task<TCustomList> FindByIdAsync(TKey id);
        Task<List<TCustomList>> FindWithoutTenantIdAsync();
        Task<DaPaginatedEntityList<TKey, TCustomList>> FindWithoutTenantIdAsync(DaDataPaginationCriteria paginationCriteria);

        Task<List<TCustomList>> FindWithTenantIdAsync(string tenantId);
        Task<DaPaginatedEntityList<TKey, TCustomList>> FindWithTenantIdAsync(string tenantId, DaDataPaginationCriteria paginationCriteria);
        Task<TCustomList> FindByKeyAsync(string key);
        Task<TCustomListItem> FindListItemByIdAsync(TKey listItemId);
    }
}
