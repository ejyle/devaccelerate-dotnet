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

namespace Ejyle.DevAccelerate.Lists.Culture
{
    public class DaSystemLanguageManager<TKey, TSystemLanguage>
        : DaEntityManagerBase<TKey, TSystemLanguage>
        where TKey : IEquatable<TKey>
        where TSystemLanguage : IDaSystemLanguage<TKey>
    {
        public DaSystemLanguageManager(IDaSystemLanguageRepository<TKey, TSystemLanguage> repository)
            : base(repository)
        { }

        protected virtual IDaSystemLanguageRepository<TKey, TSystemLanguage> Repository
        {
            get
            {
                return GetRepository<IDaSystemLanguageRepository<TKey, TSystemLanguage>>();
            }
        }

        public void Create(TSystemLanguage systemLanguage)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(systemLanguage));
        }

        public Task CreateAsync(TSystemLanguage systemLanguage)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(systemLanguage, nameof(systemLanguage));

            return Repository.CreateAsync(systemLanguage);
        }

        public void Update(TSystemLanguage systemLanguage)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(systemLanguage));
        }

        public Task UpdateAsync(TSystemLanguage systemLanguage)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(systemLanguage, nameof(systemLanguage));

            return Repository.UpdateAsync(systemLanguage);
        }

        public void Delete(TSystemLanguage systemLanguage)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(systemLanguage));
        }

        public Task DeleteAsync(TSystemLanguage systemLanguage)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(systemLanguage, nameof(systemLanguage));

            return Repository.DeleteAsync(systemLanguage);
        }

        public TSystemLanguage Find()
        {
            return DaAsyncHelper.RunSync<TSystemLanguage>(() => FindAsync());
        }

        public Task<TSystemLanguage> FindAsync()
        {
            ThrowIfDisposed();
            return Repository.FindFirstAsync();
        }

        public List<TSystemLanguage> FindAll()
        {
            return DaAsyncHelper.RunSync<List<TSystemLanguage>>(() => FindAllAsync());
        }

        public Task<List<TSystemLanguage>> FindAllAsync()
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync();
        }

        public TSystemLanguage FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TSystemLanguage>(() => FindByIdAsync(id));
        }

        public Task<TSystemLanguage> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public List<TSystemLanguage> FindByCountryId(TKey countryId)
        {
            return DaAsyncHelper.RunSync<List<TSystemLanguage>>(() => FindByCountryIdAsync(countryId));
        }

        public Task<List<TSystemLanguage>> FindByCountryIdAsync(TKey countryId)
        {
            ThrowIfDisposed();
            return Repository.FindByCountryIdAsync(countryId);
        }

        public TSystemLanguage FindByName(string name)
        {
            return DaAsyncHelper.RunSync<TSystemLanguage>(() => FindByNameAsync(name));
        }

        public Task<TSystemLanguage> FindByNameAsync(string name)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(name, nameof(name));

            return Repository.FindByNameAsync(name);
        }
    }
}