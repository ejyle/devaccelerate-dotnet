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

namespace Ejyle.DevAccelerate.Core.Objects
{
    public interface IDaObjectInstanceRepository<TKey, TObjectInstance, TObjectHistoryItem, TObjectDependency> : IDaEntityRepository<TKey, TObjectInstance>
        where TKey : IEquatable<TKey>
        where TObjectInstance : IDaObjectInstance<TKey>
        where TObjectHistoryItem : IDaObjectHistoryItem<TKey>
        where TObjectDependency: IDaObjectDependency<TKey>
    {
        Task CreateAsync(TObjectInstance obj);
        Task<TObjectInstance> FindByIdAsync(TKey id);
        Task<long> FindDepdencyCountAsync(TKey id);
        Task CreateHistoryAsync(TKey id, TObjectHistoryItem objHistoryItem);
        Task ClearHistoryAsync(TKey id);
        Task ClearDependenciesAsync(TKey id);
        Task<List<TObjectDependency>> FindDependenciesAsync(TKey id, int top = 10);
        Task CreateDependencyAsync(TKey id, TObjectDependency dependency);
        Task CreateDependencyAsync(TKey id, TObjectDependency[] dependencies);
        Task DeleteDependenciesAsync(TKey[] objectDependencyId);
        Task DeleteAsync(TObjectInstance obj);
    }
}
