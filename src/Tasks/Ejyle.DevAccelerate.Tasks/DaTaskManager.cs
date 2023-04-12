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
using Ejyle.DevAccelerate.Core.Utils;

namespace Ejyle.DevAccelerate.Tasks
{
    public class DaTaskManager<TKey, TTask> : DaEntityManagerBase<TKey, TTask>
        where TKey : IEquatable<TKey>
        where TTask : IDaTask<TKey>
    {
        public DaTaskManager(IDaTaskRepository<TKey, TTask> repository)
            : base(repository)
        {
        }

        protected virtual IDaTaskRepository<TKey, TTask> Repository
        {
            get
            {
                return GetRepository<IDaTaskRepository<TKey, TTask>>();
            }
        }

        public virtual async Task CreateAsync(TTask task)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(task, nameof(task));

            await Repository.CreateAsync(task);
        }

        public virtual void Create(TTask task)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(task));
        }

        public virtual async Task UpdateAsync(TTask task)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(task, nameof(task));

            await Repository.UpdateAsync(task);
        }

        public virtual void Update(TTask task)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(task));
        }

        public virtual async Task DeleteAsync(TTask task)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(task, nameof(task));

            await Repository.DeleteAsync(task);
        }

        public virtual void Delete(TTask task)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(task));
        }

        public virtual TTask FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TTask>(() => FindByIdAsync(id));
        }

        public virtual Task<TTask> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public virtual DaPaginatedEntityList<TKey, TTask> FindByAssignedTo(TKey assignedTo, DaDataPaginationCriteria paginationCriteria)
        {
            return DaAsyncHelper.RunSync<DaPaginatedEntityList<TKey, TTask>>(() => FindByAssignedToAsync(assignedTo, paginationCriteria));
        }

        public virtual Task<DaPaginatedEntityList<TKey, TTask>> FindByAssignedToAsync(TKey asignedTo, DaDataPaginationCriteria paginationCriteria)
        {
            ThrowIfDisposed();
            return Repository.FindByAssignedToAsync(asignedTo, paginationCriteria);
        }

        public virtual DaPaginatedEntityList<TKey, TTask> FindByObjectInstanceId(TKey objectInstanceId, DaDataPaginationCriteria paginationCriteria)
        {
            return DaAsyncHelper.RunSync<DaPaginatedEntityList<TKey, TTask>>(() => FindByAssignedToAsync(objectInstanceId, paginationCriteria));
        }

        public virtual Task<DaPaginatedEntityList<TKey, TTask>> FindByObjectInstanceIdAsync(TKey objectInstanceId, DaDataPaginationCriteria paginationCriteria)
        {
            ThrowIfDisposed();
            return Repository.FindByObjectInstanceIdAsync(objectInstanceId, paginationCriteria);
        }

        public virtual DaPaginatedEntityList<TKey, TTask> FindByTenantId(TKey tenantId, DaDataPaginationCriteria paginationCriteria)
        {
            return DaAsyncHelper.RunSync<DaPaginatedEntityList<TKey, TTask>>(() => FindByTenantIdAsync(tenantId, paginationCriteria));
        }

        public virtual Task<DaPaginatedEntityList<TKey, TTask>> FindByTenantIdAsync(TKey tenantId, DaDataPaginationCriteria paginationCriteria)
        {
            ThrowIfDisposed();
            return Repository.FindByTenantIdAsync(tenantId, paginationCriteria);
        }

        public IQueryable<TTask> Tasks
        {
            get
            {
                return Repository.Tasks;
            }
        }
    }
}