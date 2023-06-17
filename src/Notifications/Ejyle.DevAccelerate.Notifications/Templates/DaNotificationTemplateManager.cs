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

namespace Ejyle.DevAccelerate.Notifications.Templates
{
    public class DaNotificationTemplateManager<TKey, TNotificationTemplate> : DaEntityManagerBase<TKey, TNotificationTemplate>
        where TKey : IEquatable<TKey>
        where TNotificationTemplate : IDaNotificationTemplate<TKey>
    {
        public DaNotificationTemplateManager(IDaNotificationTemplateRepository<TKey, TNotificationTemplate> repository)
            : base(repository)
        {
        }

        protected virtual IDaNotificationTemplateRepository<TKey, TNotificationTemplate> Repository
        {
            get
            {
                return GetRepository<IDaNotificationTemplateRepository<TKey, TNotificationTemplate>>();
            }
        }

        public virtual async Task CreateAsync(TNotificationTemplate notificationTemplate)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(notificationTemplate, nameof(notificationTemplate));

            await Repository.CreateAsync(notificationTemplate);
        }

        public virtual void Create(TNotificationTemplate notificationTemplate)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(notificationTemplate));
        }

        public virtual async Task UpdateAsync(TNotificationTemplate notificationTemplate)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(notificationTemplate, nameof(notificationTemplate));

            await Repository.UpdateAsync(notificationTemplate);
        }

        public virtual void Update(TNotificationTemplate notificationTemplate)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(notificationTemplate));
        }

        public virtual async Task DeleteAsync(TNotificationTemplate notificationTemplate)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(notificationTemplate, nameof(notificationTemplate));

            await Repository.DeleteAsync(notificationTemplate);
        }

        public virtual void Delete(TNotificationTemplate notificationTemplate)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(notificationTemplate));
        }

        public virtual List<TNotificationTemplate> FindAll()
        {
            return DaAsyncHelper.RunSync(() => FindAllAsync());
        }

        public virtual Task<List<TNotificationTemplate>> FindAllAsync()
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync();
        }

        public virtual TNotificationTemplate FindById(TKey id)
        {
            return DaAsyncHelper.RunSync(() => FindByIdAsync(id));
        }

        public virtual Task<TNotificationTemplate> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public virtual TNotificationTemplate FindByKey(string key)
        {
            return DaAsyncHelper.RunSync(() => FindByKeyAsync(key));
        }

        public virtual Task<TNotificationTemplate> FindByKeyAsync(string key)
        {
            ThrowIfDisposed();
            return Repository.FindByKeyAsync(key);
        }
    }
}