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

namespace Ejyle.DevAccelerate.Lists.Links
{
    public class DaLinkManager<TKey, TLink>
        : DaEntityManagerBase<TKey, TLink>
        where TKey : IEquatable<TKey>
        where TLink : IDaLink<TKey>
    {
        public DaLinkManager(IDaLinkRepository<TKey, TLink> repository)
            : base(repository)
        { }

        protected virtual IDaLinkRepository<TKey, TLink> Repository
        {
            get
            {
                return GetRepository<IDaLinkRepository<TKey, TLink>>();
            }
        }

        public void Create(TLink link)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(link));
        }

        public Task CreateAsync(TLink link)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(link, nameof(link));

            return Repository.CreateAsync(link);
        }

        public void Create(IEnumerable<TLink> links)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(links));
        }

        public Task CreateAsync(IEnumerable<TLink> links)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(links, nameof(links));

            return Repository.CreateAsync(links);
        }

        public void Update(TLink link)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(link, nameof(link));

            DaAsyncHelper.RunSync(() => UpdateAsync(link));
        }

        public Task UpdateAsync(TLink link)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(link, nameof(link));

            return Repository.UpdateAsync(link);
        }

        public void Delete(TLink link)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(link));
        }

        public Task DeleteAsync(TLink link)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(link, nameof(link));

            return Repository.DeleteAsync(link);
        }

        public TLink FindById(TKey id)
        {
            return DaAsyncHelper.RunSync(() => FindByIdAsync(id));
        }

        public Task<TLink> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public List<TLink> Find(string userId, string category)
        {
            return DaAsyncHelper.RunSync(() => FindAsync(userId, category));
        }

        public Task<List<TLink>> FindAsync(string userId, string category)
        {
            ThrowIfDisposed();
            return Repository.FindAsync(userId, category);
        }
    }
}