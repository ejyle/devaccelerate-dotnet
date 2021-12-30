// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Lists.Culture
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

        public DaPaginatedEntityList<TKey, TCurrency> FindAll(DaDataPaginationCriteria paginationCriteria)
        {
            return DaAsyncHelper.RunSync<DaPaginatedEntityList<TKey, TCurrency>>(() => FindAllAsync(paginationCriteria));
        }

        public Task<DaPaginatedEntityList<TKey, TCurrency>> FindAllAsync(DaDataPaginationCriteria paginationCriteria)
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync(paginationCriteria);
        }

        public TCurrency Find()
        {
            return DaAsyncHelper.RunSync<TCurrency>(() => FindAsync());
        }

        public Task<TCurrency> FindAsync()
        {
            ThrowIfDisposed();
            return Repository.FindFirstAsync();
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

        public TCurrency FindByName(string name)
        {
            return DaAsyncHelper.RunSync<TCurrency>(() => FindByNameAsync(name));
        }

        public Task<TCurrency> FindByNameAsync(string name)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(name, nameof(name));

            return Repository.FindByNameAsync(name);
        }

        public TCurrency FindByAlphabeticCode(string alphabeticCode)
        {
            return DaAsyncHelper.RunSync<TCurrency>(() => FindByAlphabeticCodeAsync(alphabeticCode));
        }

        public Task<TCurrency> FindByAlphabeticCodeAsync(string alphabeticCode)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(alphabeticCode, nameof(alphabeticCode));

            return Repository.FindByAlphabeticCodeAsync(alphabeticCode);
        }
    }
}
