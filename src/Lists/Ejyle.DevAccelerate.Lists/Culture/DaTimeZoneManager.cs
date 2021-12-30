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
    public class DaTimeZoneManager<TKey, TNullableKey, TTimeZone>
        : DaEntityManagerBase<TKey, TTimeZone>
        where TKey : IEquatable<TKey>
        where TTimeZone : IDaTimeZone<TKey>
    {
        public DaTimeZoneManager(IDaTimeZoneRepository<TKey, TTimeZone> repository)
            : base(repository)
        { }

        protected virtual IDaTimeZoneRepository<TKey, TTimeZone> Repository
        {
            get
            {
                return GetRepository<IDaTimeZoneRepository<TKey, TTimeZone>>();
            }
        }

        public void Create(TTimeZone timeZone)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(timeZone));
        }

        public Task CreateAsync(TTimeZone timeZone)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(timeZone, nameof(timeZone));

            return Repository.CreateAsync(timeZone);
        }

        public void Update(TTimeZone timeZone)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(timeZone));
        }

        public Task UpdateAsync(TTimeZone timeZone)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(timeZone, nameof(timeZone));

            return Repository.UpdateAsync(timeZone);
        }

        public void Delete(TTimeZone timeZone)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(timeZone));
        }

        public Task DeleteAsync(TTimeZone timeZone)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(timeZone, nameof(timeZone));

            return Repository.DeleteAsync(timeZone);
        }

        public TTimeZone Find()
        {
            return DaAsyncHelper.RunSync<TTimeZone>(() => FindAsync());
        }

        public Task<TTimeZone> FindAsync()
        {
            ThrowIfDisposed();
            return Repository.FindFirstAsync();
        }

        public List<TTimeZone> FindAll()
        {
            return DaAsyncHelper.RunSync<List<TTimeZone>>(() => FindAllAsync());
        }

        public Task<List<TTimeZone>> FindAllAsync()
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync();
        }

        public TTimeZone FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TTimeZone>(() => FindByIdAsync(id));
        }

        public Task<TTimeZone> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public List<TTimeZone> FindByCountryId(TKey countryId)
        {
            return DaAsyncHelper.RunSync<List<TTimeZone>>(() => FindByCountryIdAsync(countryId));
        }

        public Task<List<TTimeZone>> FindByCountryIdAsync(TKey countryId)
        {
            ThrowIfDisposed();
            return Repository.FindByCountryIdAsync(countryId);
        }

        public TTimeZone FindByName(string name)
        {
            return DaAsyncHelper.RunSync<TTimeZone>(() => FindByNameAsync(name));
        }

        public Task<TTimeZone> FindByNameAsync(string name)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(name, nameof(name));

            return Repository.FindByNameAsync(name);
        }
    }
}