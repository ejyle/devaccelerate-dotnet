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

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Objects
{
    public interface IDaObjectInstanceRepository<TKey, TObjectInstance, TObjectHistoryItem> : IDaEntityRepository<TKey, TObjectInstance>
        where TKey : IEquatable<TKey>
        where TObjectInstance : IDaObjectInstance<TKey>
        where TObjectHistoryItem : IDaObjectHistoryItem<TKey>
    {
        Task CreateAsync(TObjectInstance obj);
        Task<TObjectInstance> FindByIdAsync(TKey id);
        Task CreateObjectHistoryItemAsync(TKey id, TObjectHistoryItem objHistoryItem);
        Task DeleteAsync(TObjectInstance obj);
    }
}
