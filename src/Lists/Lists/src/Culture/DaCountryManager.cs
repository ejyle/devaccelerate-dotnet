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
    public class DaCountryManager<TKey, TNullableKey, TCountry, TCountryRegion>
        : DaEntityManagerBase<TKey, TCountry>
        where TKey : IEquatable<TKey>
        where TCountry : IDaCountry<TKey, TNullableKey>
        where TCountryRegion : IDaCountryRegion<TKey, TNullableKey>
    {
        public DaCountryManager(IDaCountryRepository<TKey, TNullableKey, TCountry, TCountryRegion> repository)
            : base(repository)
        { }

        protected virtual IDaCountryRepository<TKey, TNullableKey, TCountry, TCountryRegion> Repository
        {
            get
            {
                return GetRepository<IDaCountryRepository<TKey, TNullableKey, TCountry, TCountryRegion>>();
            }
        }

        public void Create(TCountry country)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(country));
        }

        public Task CreateAsync(TCountry country)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(country, nameof(country));

            return Repository.CreateAsync(country);
        }

        public void Update(TCountry country)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(country));
        }

        public Task UpdateAsync(TCountry country)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(country, nameof(country));

            return Repository.UpdateAsync(country);
        }

        public void Delete(TCountry country)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(country));
        }

        public Task DeleteAsync(TCountry country)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(country, nameof(country));

            return Repository.DeleteAsync(country);
        }

        public List<TCountry> FindAll()
        {
            return DaAsyncHelper.RunSync<List<TCountry>>(() => FindAllAsync());
        }

        public Task<List<TCountry>> FindAllAsync()
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync();
        }

        public TCountry FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TCountry>(() => FindByIdAsync(id));
        }

        public Task<TCountry> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public TCountryRegion FindCountryRegionById(TKey id)
        {
            return DaAsyncHelper.RunSync<TCountryRegion>(() => FindCountryRegionByIdAsync(id));
        }

        public Task<TCountryRegion> FindCountryRegionByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindCountryRegionByIdAsync(id);
        }

        public TCountry FindByName(string name)
        {
            return DaAsyncHelper.RunSync<TCountry>(() => FindByNameAsync(name));
        }

        public Task<TCountry> FindByNameAsync(string name)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(name, nameof(name));

            return Repository.FindByNameAsync(name);
        }

        public TCountry FindByTwoLetterCode(string twoLetterCode)
        {
            return DaAsyncHelper.RunSync<TCountry>(() => FindByTwoLetterCodeAsync(twoLetterCode));
        }

        public Task<TCountry> FindByTwoLetterCodeAsync(string twoLetterCode)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(twoLetterCode, nameof(twoLetterCode));

            return Repository.FindByTwoLetterCodeAsync(twoLetterCode);
        }

        public TCountry FindByThreeLetterCode(string threeLetterCode)
        {
            return DaAsyncHelper.RunSync<TCountry>(() => FindByThreeLetterCodeAsync(threeLetterCode));
        }

        public Task<TCountry> FindByThreeLetterCodeAsync(string threeLetterCode)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(threeLetterCode, nameof(threeLetterCode));

            return Repository.FindByThreeLetterCodeAsync(threeLetterCode);
        }
    }
}
