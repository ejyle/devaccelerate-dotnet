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
    public interface IDaCustomListRepository<TKey, TCustomList> : IDaEntityRepository<TKey, TCustomList>
        where TKey : IEquatable<TKey>
        where TCustomList : IDaCustomList<TKey>
    {
        Task CreateAsync(TCustomList customList);
        Task UpdateAsync(TCustomList customList);
        Task DeleteAsync(TCustomList customList);

        Task<TCustomList> FindByIdAsync(TKey id);
        Task<List<TCustomList>> FindAllAsync();
        Task<DaPaginatedEntityList<TKey, TCustomList>> FindAllAsync(DaDataPaginationCriteria paginationCriteria);
        Task<TCustomList> FindByNameAsync(string name);
    }
}
