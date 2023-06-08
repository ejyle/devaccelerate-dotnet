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

namespace Ejyle.DevAccelerate.Notifications
{
    public class DaNotificationTemplateManager<TKey, TMessageTemplate> : DaEntityManagerBase<TKey, TMessageTemplate>
        where TKey : IEquatable<TKey>
        where TMessageTemplate : IDaNotificationTemplate<TKey>
    {
        public DaNotificationTemplateManager(IDaNotificationTemplateRepository<TKey, TMessageTemplate> repository)
            : base(repository)
        {
        }

        protected virtual IDaNotificationTemplateRepository<TKey, TMessageTemplate> Repository
        {
            get
            {
                return GetRepository<IDaNotificationTemplateRepository<TKey, TMessageTemplate>>();
            }
        }

        public virtual async Task CreateAsync(TMessageTemplate notificationTemplate)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(notificationTemplate, nameof(notificationTemplate));

            await Repository.CreateAsync(notificationTemplate);
        }

        public virtual void Create(TMessageTemplate notificationTemplate)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(notificationTemplate));
        }

        public virtual async Task UpdateAsync(TMessageTemplate notificationTemplate)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(notificationTemplate, nameof(notificationTemplate));

            await Repository.UpdateAsync(notificationTemplate);
        }

        public virtual void Update(TMessageTemplate notificationTemplate)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(notificationTemplate));
        }

        public virtual async Task DeleteAsync(TMessageTemplate notificationTemplate)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(notificationTemplate, nameof(notificationTemplate));

            await Repository.DeleteAsync(notificationTemplate);
        }

        public virtual void Delete(TMessageTemplate notificationTemplate)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(notificationTemplate));
        }

        public virtual List<TMessageTemplate> FindAll()
        {
            return DaAsyncHelper.RunSync(() => FindAllAsync());
        }

        public virtual Task<List<TMessageTemplate>> FindAllAsync()
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync();
        }

        public virtual TMessageTemplate FindById(TKey id)
        {
            return DaAsyncHelper.RunSync(() => FindByIdAsync(id));
        }

        public virtual Task<TMessageTemplate> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public virtual TMessageTemplate FindByKey(string key)
        {
            return DaAsyncHelper.RunSync(() => FindByKeyAsync(key));
        }

        public virtual Task<TMessageTemplate> FindByKeyAsync(string key)
        {
            ThrowIfDisposed();
            return Repository.FindByKeyAsync(key);
        }
    }
}