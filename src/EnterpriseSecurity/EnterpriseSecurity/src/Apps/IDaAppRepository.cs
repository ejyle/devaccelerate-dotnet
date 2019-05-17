// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Apps
{
    public interface IDaAppRepository<TKey, TApp> : IDaEntityRepository<TKey, TApp>
        where TKey : IEquatable<TKey>
        where TApp : IDaApp<TKey>
    {
        Task CreateAsync(TApp app);
        Task<TApp> FindByIdAsync(TKey id);
        Task<TApp> FindByKeyAsync(string key);
        Task<List<TApp>> FindAllAsync();
        Task UpdateAsync(TApp app);
        Task DeleteAsync(TApp app);
        Task RemoveAppFeatureByIdAsync(TKey appFeatureId);
    }
}
