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

namespace Ejyle.DevAccelerate.Lists.Countries
{
    public class DaCountryManager<TKey, TCountry, TCountryRegion>
        : DaEntityManagerBase<TKey, TCountry>
        where TKey : IEquatable<TKey>
        where TCountry : IDaCountry<TKey>
        where TCountryRegion : IDaCountryRegion<TKey>
    {
        public DaCountryManager(IDaCountryRepository<TKey, TCountry, TCountryRegion> repository)
            : base(repository)
        { }

        protected virtual IDaCountryRepository<TKey, TCountry, TCountryRegion> Repository
        {
            get
            {
                return GetRepository<IDaCountryRepository<TKey, TCountry, TCountryRegion>>();
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

        public void Create(IEnumerable<TCountry> countries)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(countries));
        }

        public Task CreateAsync(IEnumerable<TCountry> countries)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(countries, nameof(countries));

            return Repository.CreateAsync(countries);
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
            return DaAsyncHelper.RunSync(() => FindAllAsync());
        }

        public Task<List<TCountry>> FindAllAsync()
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync();
        }

        public DaPaginatedEntityList<TKey, TCountry> FindAll(DaDataPaginationCriteria paginationCriteria)
        {
            return DaAsyncHelper.RunSync(() => FindAllAsync(paginationCriteria));
        }

        public Task<DaPaginatedEntityList<TKey, TCountry>> FindAllAsync(DaDataPaginationCriteria paginationCriteria)
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync(paginationCriteria);
        }

        public TCountry FindById(TKey id)
        {
            return DaAsyncHelper.RunSync(() => FindByIdAsync(id));
        }

        public Task<TCountry> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public TCountry Find()
        {
            return DaAsyncHelper.RunSync(() => FindAsync());
        }

        public Task<TCountry> FindAsync()
        {
            ThrowIfDisposed();
            return Repository.FindFirstAsync();
        }

        public TCountryRegion FindCountryRegionById(TKey id)
        {
            return DaAsyncHelper.RunSync(() => FindCountryRegionByIdAsync(id));
        }

        public Task<TCountryRegion> FindCountryRegionByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindCountryRegionByIdAsync(id);
        }

        public TCountry FindByName(string name)
        {
            return DaAsyncHelper.RunSync(() => FindByNameAsync(name));
        }

        public Task<TCountry> FindByNameAsync(string name)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(name, nameof(name));

            return Repository.FindByNameAsync(name);
        }

        public TCountry FindByTwoLetterCode(string twoLetterCode)
        {
            return DaAsyncHelper.RunSync(() => FindByTwoLetterCodeAsync(twoLetterCode));
        }

        public Task<TCountry> FindByTwoLetterCodeAsync(string twoLetterCode)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(twoLetterCode, nameof(twoLetterCode));

            return Repository.FindByTwoLetterCodeAsync(twoLetterCode);
        }

        public TCountry FindByThreeLetterCode(string threeLetterCode)
        {
            return DaAsyncHelper.RunSync(() => FindByThreeLetterCodeAsync(threeLetterCode));
        }

        public Task<TCountry> FindByThreeLetterCodeAsync(string threeLetterCode)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(threeLetterCode, nameof(threeLetterCode));

            return Repository.FindByThreeLetterCodeAsync(threeLetterCode);
        }

        public TCountry FindByNameOrCode(string nameOrCode)
        {
            return DaAsyncHelper.RunSync(() => FindByNameOrCodeAsync(nameOrCode));
        }

        public Task<TCountry> FindByNameOrCodeAsync(string nameOrCode)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(nameOrCode, nameof(nameOrCode));

            return Repository.FindByNameOrCodeAsync(nameOrCode);
        }
    }
}
