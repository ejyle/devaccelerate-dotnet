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

namespace Ejyle.DevAccelerate.Platform.Apps
{
    public interface IDaAppRepository<TKey, TApp> : IDaEntityRepository<TKey, TApp>
        where TKey : IEquatable<TKey>
        where TApp : IDaApp<TKey>
    {
        Task CreateAsync(TApp app);
        Task<TApp> FindByIdAsync(TKey id);
        Task<TApp> FindByKeyAsync(string key);
        Task<DaPaginatedEntityList<TKey, TApp>> FindAllAsync(DaDataPaginationCriteria paginationCriteria);
        Task UpdateAsync(TApp app);
        Task DeleteAsync(TApp app);
        Task RemoveAppFeatureByIdAsync(TKey appFeatureId);
    }
}
