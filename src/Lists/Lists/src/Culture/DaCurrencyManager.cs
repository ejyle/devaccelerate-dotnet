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

namespace Ejyle.DevAccelerate.List.Culture
{
    public class DaCurrencyManager<TKey, TCurrency> : DaEntityManagerBase<TKey, TCurrency>
        where TKey : IEquatable<TKey>
        where TCurrency : IDaCurrency<TKey>
    {
        public DaCurrencyManager(IDaCurrencyRepository<TKey, TCurrency> repository)
            : base(repository)
        { }

        protected virtual IDaCurrencyRepository<TKey, TCurrency> Repository
        {
            get
            {
                return GetRepository<IDaCurrencyRepository<TKey, TCurrency>>();
            }
        }

        public void Create(TCurrency currency)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(currency));
        }

        public Task CreateAsync(TCurrency currency)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(currency, nameof(currency));

            return Repository.CreateAsync(currency);
        }

        public void Update(TCurrency currency)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(currency));
        }

        public Task UpdateAsync(TCurrency currency)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(currency, nameof(currency));

            return Repository.UpdateAsync(currency);
        }

        public void Delete(TCurrency currency)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(currency));
        }

        public Task DeleteAsync(TCurrency currency)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(currency, nameof(currency));

            return Repository.DeleteAsync(currency);
        }

        public List<TCurrency> FindAll()
        {
            return DaAsyncHelper.RunSync<List<TCurrency>>(() => FindAllAsync());
        }

        public Task<List<TCurrency>> FindAllAsync()
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync();
        }

        public TCurrency FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TCurrency>(() => FindByIdAsync(id));
        }

        public Task<TCurrency> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }
    }
}
