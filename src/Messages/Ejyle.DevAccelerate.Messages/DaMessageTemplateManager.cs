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

namespace Ejyle.DevAccelerate.Messages
{
    public class DaMessageTemplateManager<TKey, TMessageTemplate> : DaEntityManagerBase<TKey, TMessageTemplate>
        where TKey : IEquatable<TKey>
        where TMessageTemplate : IDaMessageTemplate<TKey>
    {
        public DaMessageTemplateManager(IDaMessageTemplateRepository<TKey, TMessageTemplate> repository)
            : base(repository)
        {
        }

        protected virtual IDaMessageTemplateRepository<TKey, TMessageTemplate> Repository
        {
            get
            {
                return GetRepository<IDaMessageTemplateRepository<TKey, TMessageTemplate>>();
            }
        }

        public virtual async Task CreateAsync(TMessageTemplate messageTemplate)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(messageTemplate, nameof(messageTemplate));

            await Repository.CreateAsync(messageTemplate);
        }

        public virtual void Create(TMessageTemplate messageTemplate)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(messageTemplate));
        }

        public virtual async Task UpdateAsync(TMessageTemplate messageTemplate)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(messageTemplate, nameof(messageTemplate));

            await Repository.UpdateAsync(messageTemplate);
        }

        public virtual void Update(TMessageTemplate messageTemplate)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(messageTemplate));
        }

        public virtual async Task DeleteAsync(TMessageTemplate messageTemplate)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(messageTemplate, nameof(messageTemplate));

            await Repository.DeleteAsync(messageTemplate);
        }

        public virtual void Delete(TMessageTemplate messageTemplate)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(messageTemplate));
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
    }
}