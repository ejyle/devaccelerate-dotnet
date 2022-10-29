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
    public class DaMessageManager<TKey, TNullableKey, TMessage> : DaEntityManagerBase<TKey, TMessage>
        where TKey : IEquatable<TKey>
        where TMessage : IDaMessage<TKey>
    {
        public DaMessageManager(IDaMessageRepository<TKey, TMessage> repository)
            : base(repository)
        {
        }

        protected virtual IDaMessageRepository<TKey, TMessage> Repository
        {
            get
            {
                return GetRepository<IDaMessageRepository<TKey, TMessage>>();
            }
        }

        public virtual async Task CreateAsync(TMessage message)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(message, nameof(message));

            await Repository.CreateAsync(message);
        }

        public virtual void Create(TMessage message)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(message));
        }

        public virtual async Task UpdateAsync(TMessage message)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(message, nameof(message));

            await Repository.UpdateAsync(message);
        }

        public virtual void Update(TMessage message)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(message));
        }

        public virtual async Task DeleteAsync(TMessage message)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(message, nameof(message));

            await Repository.DeleteAsync(message);
        }

        public virtual void Delete(TMessage message)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(message));
        }

        public virtual TMessage FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TMessage>(() => FindByIdAsync(id));
        }

        public virtual Task<TMessage> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public DaPaginatedEntityList<TKey, TMessage> FindByStatus(DaMessageStatus status, DaDataPaginationCriteria paginationCriteria)
        {
            return DaAsyncHelper.RunSync<DaPaginatedEntityList<TKey, TMessage>>(() => FindByStatusAsync(status, paginationCriteria));
        }

        public Task<DaPaginatedEntityList<TKey, TMessage>> FindByStatusAsync(DaMessageStatus status, DaDataPaginationCriteria paginationCriteria)
        {
            ThrowIfDisposed();
            return Repository.FindByStatusAsync(status, paginationCriteria);
        }
    }
}