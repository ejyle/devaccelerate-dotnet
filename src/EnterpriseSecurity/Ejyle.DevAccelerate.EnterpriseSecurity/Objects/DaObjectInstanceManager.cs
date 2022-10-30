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
using Ejyle.DevAccelerate.Core.Utils;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Objects
{
    public class DaObjectInstanceManager<TKey, TObjectInstance, TObjectHistoryItem> : DaEntityManagerBase<TKey, TObjectInstance>
        where TKey : IEquatable<TKey>
        where TObjectInstance : IDaObjectInstance<TKey>
        where TObjectHistoryItem : IDaObjectHistoryItem<TKey>
    {
        public DaObjectInstanceManager(IDaObjectInstanceRepository<TKey, TObjectInstance, TObjectHistoryItem> repository)
            : base(repository)
        {
        }

        protected virtual IDaObjectInstanceRepository<TKey, TObjectInstance, TObjectHistoryItem> Repository
        {
            get
            {
                return GetRepository<IDaObjectInstanceRepository<TKey, TObjectInstance, TObjectHistoryItem>>();
            }
        }

        public virtual async Task CreateAsync(TObjectInstance objType)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(objType, nameof(objType));

            await Repository.CreateAsync(objType);
        }

        public virtual void Create(TObjectInstance objType)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(objType));
        }

        public virtual async Task CreateObjectHistoryItemAsync(TKey id, TObjectHistoryItem objectHistoryItem)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(objectHistoryItem, nameof(objectHistoryItem));

            await Repository.CreateObjectHistoryItemAsync(id, objectHistoryItem);
        }

        public virtual void CreateObjectHistoryItem(TKey id, TObjectHistoryItem objectHistoryItem)
        {
            DaAsyncHelper.RunSync(() => CreateObjectHistoryItemAsync(id, objectHistoryItem));
        }

        public virtual async Task DeleteAsync(TObjectInstance objType)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(objType, nameof(objType));

            await Repository.DeleteAsync(objType);
        }

        public virtual void Delete(TObjectInstance objType)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(objType));
        }

        public virtual TObjectInstance FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TObjectInstance>(() => FindByIdAsync(id));
        }

        public virtual Task<TObjectInstance> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }
    }
}