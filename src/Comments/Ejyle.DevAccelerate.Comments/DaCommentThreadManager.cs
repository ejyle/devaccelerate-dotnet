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

namespace Ejyle.DevAccelerate.Comments
{
    public class DaCommentThreadManager<TKey, TNullableKey, TCommentThread, TComment> : DaEntityManagerBase<TKey, TCommentThread>
        where TKey : IEquatable<TKey>
        where TCommentThread : IDaCommentThread<TKey>
        where TComment : IDaComment<TKey, TNullableKey>
    {
        public DaCommentThreadManager(IDaCommentThreadRepository<TKey, TNullableKey, TCommentThread, TComment> repository)
            : base(repository)
        {
        }

        protected virtual IDaCommentThreadRepository<TKey, TNullableKey, TCommentThread, TComment> Repository
        {
            get
            {
                return GetRepository<IDaCommentThreadRepository<TKey, TNullableKey, TCommentThread, TComment>>();
            }
        }

        public virtual async Task CreateAsync(TCommentThread commentThread)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(commentThread, nameof(commentThread));

            await Repository.CreateAsync(commentThread);
        }

        public virtual void Create(TCommentThread commentThread)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(commentThread));
        }

        public virtual async Task CreateCommentAsync(TKey id, TComment comment)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(comment, nameof(comment));

            await Repository.CreateCommentAsync(id, comment);
        }

        public virtual void CreateComment(TKey id, TComment comment)
        {
            DaAsyncHelper.RunSync(() => CreateCommentAsync(id, comment));
        }

        public virtual async Task DeleteAsync(TCommentThread commentThread)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(commentThread, nameof(commentThread));

            await Repository.DeleteAsync(commentThread);
        }

        public virtual void Delete(TCommentThread commentThread)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(commentThread));
        }

        public virtual TCommentThread FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TCommentThread>(() => FindByIdAsync(id));
        }

        public virtual Task<TCommentThread> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public virtual DaPaginatedEntityList<TKey, TComment> FindComments(TKey commentThreadId, DaDataPaginationCriteria paginationCriteria)
        {
            return DaAsyncHelper.RunSync<DaPaginatedEntityList<TKey, TComment>>(() => FindCommentsAsync(commentThreadId, paginationCriteria));
        }

        public virtual Task<DaPaginatedEntityList<TKey, TComment>> FindCommentsAsync(TKey commentThreadId, DaDataPaginationCriteria paginationCriteria)
        {
            ThrowIfDisposed();
            return Repository.FindCommentsAsync(commentThreadId, paginationCriteria);
        }
    }
}