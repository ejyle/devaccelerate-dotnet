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

namespace Ejyle.DevAccelerate.Social
{
    public class DaPostManager<TKey, TPost> : DaEntityManagerBase<TKey, TPost>
        where TKey : IEquatable<TKey>
        where TPost : IDaPost<TKey>
    {
        public DaPostManager(IDaPostRepository<TKey, TPost> repository)
            : base(repository)
        {
        }

        protected virtual IDaPostRepository<TKey, TPost> Repository
        {
            get
            {
                return GetRepository<IDaPostRepository<TKey, TPost>>();
            }
        }

        public virtual async Task CreateAsync(TPost post)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(post, nameof(post));

            await Repository.CreateAsync(post);
        }

        public virtual void Create(TPost post)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(post));
        }

        public virtual async Task UpdateAsync(TPost pst)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(pst, nameof(pst));

            await Repository.UpdateAsync(pst);
        }

        public virtual void Update(TPost post)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(post));
        }

        public virtual async Task DeleteAsync(TPost post)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(post, nameof(post));

            await Repository.DeleteAsync(post);
        }

        public virtual void Delete(TPost post)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(post));
        }

        public virtual TPost FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TPost>(() => FindByIdAsync(id));
        }

        public virtual Task<TPost> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public IQueryable<TPost> Posts
        {
            get
            {
                return Repository.Posts;
            }
        }
    }
}