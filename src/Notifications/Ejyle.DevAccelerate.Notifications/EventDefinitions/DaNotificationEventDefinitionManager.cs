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

namespace Ejyle.DevAccelerate.Notifications.EventDefinitions
{
    public class DaNotificationEventDefinitionManager<TKey, TNotificationEventDefinition> : DaEntityManagerBase<TKey, TNotificationEventDefinition>
        where TKey : IEquatable<TKey>
        where TNotificationEventDefinition : IDaNotificationEventDefinition<TKey>
    {
        public DaNotificationEventDefinitionManager(IDaNotificationEventDefinitionRepository<TKey, TNotificationEventDefinition> repository)
            : base(repository)
        {
        }

        protected virtual IDaNotificationEventDefinitionRepository<TKey, TNotificationEventDefinition> Repository
        {
            get
            {
                return GetRepository<IDaNotificationEventDefinitionRepository<TKey, TNotificationEventDefinition>>();
            }
        }

        public virtual async Task CreateAsync(TNotificationEventDefinition eventDefinition)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(eventDefinition, nameof(eventDefinition));

            await Repository.CreateAsync(eventDefinition);
        }

        public virtual void Create(TNotificationEventDefinition eventDefinition)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(eventDefinition));
        }

        public virtual async Task UpdateAsync(TNotificationEventDefinition eventDefinition)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(eventDefinition, nameof(eventDefinition));

            await Repository.UpdateAsync(eventDefinition);
        }

        public virtual void Update(TNotificationEventDefinition eventDefinition)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(eventDefinition));
        }

        public virtual async Task DeleteAsync(TNotificationEventDefinition eventDefinition)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(eventDefinition, nameof(eventDefinition));

            await Repository.DeleteAsync(eventDefinition);
        }

        public virtual void Delete(TNotificationEventDefinition eventDefinition)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(eventDefinition));
        }

        public virtual List<TNotificationEventDefinition> FindAll()
        {
            return DaAsyncHelper.RunSync(() => FindAllAsync());
        }

        public virtual Task<List<TNotificationEventDefinition>> FindAllAsync()
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync();
        }

        public virtual TNotificationEventDefinition FindById(TKey id)
        {
            return DaAsyncHelper.RunSync(() => FindByIdAsync(id));
        }

        public virtual Task<TNotificationEventDefinition> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public virtual TNotificationEventDefinition FindByName(string name)
        {
            return DaAsyncHelper.RunSync(() => FindByNameAsync(name));
        }

        public virtual Task<TNotificationEventDefinition> FindByNameAsync(string name)
        {
            ThrowIfDisposed();
            return Repository.FindByNameAsync(name);
        }
    }
}