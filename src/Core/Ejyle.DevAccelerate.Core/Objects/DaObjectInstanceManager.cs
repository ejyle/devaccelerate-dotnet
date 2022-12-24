// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Data;
using Ejyle.DevAccelerate.Core.Utils;

namespace Ejyle.DevAccelerate.Core.Objects
{
    public class DaObjectInstanceManager<TKey, TObjectInstance, TObjectHistoryItem, TObjectDependency> : DaEntityManagerBase<TKey, TObjectInstance>
        where TKey : IEquatable<TKey>
        where TObjectInstance : IDaObjectInstance<TKey>
        where TObjectHistoryItem : IDaObjectHistoryItem<TKey>
        where TObjectDependency : IDaObjectDependency<TKey>
    {
        public DaObjectInstanceManager(IDaObjectInstanceRepository<TKey, TObjectInstance, TObjectHistoryItem, TObjectDependency> repository)
            : base(repository)
        {
        }

        protected virtual IDaObjectInstanceRepository<TKey, TObjectInstance, TObjectHistoryItem, TObjectDependency> Repository
        {
            get
            {
                return GetRepository<IDaObjectInstanceRepository<TKey, TObjectInstance, TObjectHistoryItem, TObjectDependency>>();
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

        public virtual async Task CreateHistoryAsync(TKey id, TObjectHistoryItem objectHistoryItem)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(objectHistoryItem, nameof(objectHistoryItem));

            await Repository.CreateHistoryAsync(id, objectHistoryItem);
        }

        public virtual void CreateHistory(TKey id, TObjectHistoryItem objectHistoryItem)
        {
            DaAsyncHelper.RunSync(() => CreateHistoryAsync(id, objectHistoryItem));
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

        public virtual Task<long> FindDepdencyCountAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindDepdencyCountAsync(id);
        }

        public virtual long FindDepdencyCount(TKey id)
        {
            return DaAsyncHelper.RunSync<long>(() => FindDepdencyCountAsync(id));
        }

        public virtual async Task ClearHistoryAsync(TKey id)
        {
            ThrowIfDisposed();
            await Repository.ClearHistoryAsync(id);
        }

        public virtual void ClearHistory(TKey id)
        {
            DaAsyncHelper.RunSync(() => ClearHistoryAsync(id));
        }

        public virtual async Task ClearDependenciesAsync(TKey id)
        {
            ThrowIfDisposed();
            await Repository.ClearDependenciesAsync(id);
        }

        public virtual void ClearDependencies(TKey id)
        {
            DaAsyncHelper.RunSync(() => ClearDependenciesAsync(id));
        }

        public virtual Task<List<TObjectDependency>> FindDependenciesAsync(TKey id, int top = 10)
        {
            ThrowIfDisposed();
            return Repository.FindDependenciesAsync(id, top);
        }

        public virtual List<TObjectDependency> FindDependencies(TKey id, int top = 10)
        {
            return DaAsyncHelper.RunSync<List<TObjectDependency>>(() => FindDependenciesAsync(id, top));
        }

        public virtual async Task CreateDependencyAsync(TKey id, TObjectDependency dependency)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(dependency, nameof(dependency));

            await Repository.CreateDependencyAsync(id, dependency);
        }

        public virtual void CreateDependency(TKey id, TObjectDependency dependency)
        {
            DaAsyncHelper.RunSync(() => CreateDependencyAsync(id, dependency));
        }

        public virtual async Task CreateDependencyAsync(TKey id, TObjectDependency[] dependencies)
        {
            ThrowIfDisposed();
            await Repository.CreateDependencyAsync(id, dependencies);
        }

        public virtual void CreateDependency(TKey id, TObjectDependency[] dependencies)
        {
            DaAsyncHelper.RunSync(() => CreateDependencyAsync(id, dependencies));
        }

        public virtual async Task DeleteDependenciesAsync(TKey[] objectDependencyId)
        {
            ThrowIfDisposed();
            await Repository.DeleteDependenciesAsync(objectDependencyId);
        }

        public virtual void DeleteDependencies(TKey[] objectDependencyId)
        {
            DaAsyncHelper.RunSync(() => DeleteDependenciesAsync(objectDependencyId));
        }
    }
}