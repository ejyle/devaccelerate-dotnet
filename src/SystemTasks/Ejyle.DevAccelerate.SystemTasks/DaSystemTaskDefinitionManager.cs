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

namespace Ejyle.DevAccelerate.SystemTasks
{
    public class DaSystemTaskDefinitionManager<TKey, TSystemTaskDefinition> : DaEntityManagerBase<TKey, TSystemTaskDefinition>
        where TKey : IEquatable<TKey>
        where TSystemTaskDefinition : IDaSystemTaskDefinition<TKey>
    {
        public DaSystemTaskDefinitionManager(IDaSystemTaskDefinitionRepository<TKey, TSystemTaskDefinition> repository)
            : base(repository)
        { }

        protected virtual IDaSystemTaskDefinitionRepository<TKey, TSystemTaskDefinition> Repository
        {
            get
            {
                return GetRepository<IDaSystemTaskDefinitionRepository<TKey, TSystemTaskDefinition>>();
            }
        }

        public void Create(TSystemTaskDefinition systemTask)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(systemTask));
        }

        public Task CreateAsync(TSystemTaskDefinition systemTask)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(systemTask, nameof(systemTask));

            systemTask.CreatedDateUtc = DateTime.UtcNow;
            systemTask.LastUpdatedDateUtc = DateTime.UtcNow;

            return Repository.CreateAsync(systemTask);
        }

        public void Create(List<TSystemTaskDefinition> systemTasks)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(systemTasks));
        }

        public Task CreateAsync(List<TSystemTaskDefinition> systemTasks)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(systemTasks, nameof(systemTasks));

            foreach(var systemTask in systemTasks)
            {
                systemTask.CreatedDateUtc = DateTime.UtcNow;
                systemTask.LastUpdatedDateUtc = DateTime.UtcNow;
            }

            return Repository.CreateAsync(systemTasks);
        }

        public void Update(TSystemTaskDefinition systemTask)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(systemTask));
        }

        public Task UpdateAsync(TSystemTaskDefinition systemTask)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(systemTask, nameof(systemTask));

            systemTask.LastUpdatedDateUtc = DateTime.UtcNow;

            return Repository.UpdateAsync(systemTask);
        }

        public void Update(List<TSystemTaskDefinition> systemTasks)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(systemTasks));
        }

        public Task UpdateAsync(List<TSystemTaskDefinition> systemTasks)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(systemTasks, nameof(systemTasks));

            foreach (var systemTask in systemTasks)
            {
                systemTask.LastUpdatedDateUtc = DateTime.UtcNow;
            }

            return Repository.UpdateAsync(systemTasks);
        }

        public void Delete(TSystemTaskDefinition systemTask)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(systemTask));
        }

        public Task DeleteAsync(TSystemTaskDefinition systemTask)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(systemTask, nameof(systemTask));

            return Repository.DeleteAsync(systemTask);
        }

        public void Clear(int olderThanInDays, List<DaSystemTaskStatus> statusCriteria)
        {
            DaAsyncHelper.RunSync(() => ClearAsync(olderThanInDays, statusCriteria));
        }

        public Task ClearAsync(int olderThanInDays, List<DaSystemTaskStatus> statusCriteria)
        {
            ThrowIfDisposed();
            return Repository.ClearAsync(olderThanInDays, statusCriteria);
        }

        public List<TSystemTaskDefinition> FindInProgress(int top)
        {
            return DaAsyncHelper.RunSync<List<TSystemTaskDefinition>>(() => FindInProgressAsync(top));
        }

        public Task<List<TSystemTaskDefinition>> FindInProgressAsync(int top)
        {
            ThrowIfDisposed();
            return Repository.FindInProgressAsync(top);
        }

        public List<TSystemTaskDefinition> FindNew(int top)
        {
            return DaAsyncHelper.RunSync<List<TSystemTaskDefinition>>(() => FindNewAsync(top));
        }

        public Task<List<TSystemTaskDefinition>> FindNewAsync(int top)
        {
            ThrowIfDisposed();
            return Repository.FindNewAsync(top);
        }

        public DaPaginatedEntityList<TKey, TSystemTaskDefinition> FindAll(DaDataPaginationCriteria paginationCriteria)
        {
            return DaAsyncHelper.RunSync<DaPaginatedEntityList<TKey, TSystemTaskDefinition>>(() => FindAllAsync(paginationCriteria));
        }

        public Task<DaPaginatedEntityList<TKey, TSystemTaskDefinition>> FindAllAsync(DaDataPaginationCriteria paginationCriteria)
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync(paginationCriteria);
        }

        public TSystemTaskDefinition FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TSystemTaskDefinition>(() => FindByIdAsync(id));
        }

        public Task<TSystemTaskDefinition> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }
    }
}
