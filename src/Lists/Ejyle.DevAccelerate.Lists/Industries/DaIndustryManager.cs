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

namespace Ejyle.DevAccelerate.Lists.Industries
{
    public class DaIndustryManager<TKey, TIndustry>
        : DaEntityManagerBase<TKey, TIndustry>
        where TKey : IEquatable<TKey>
        where TIndustry : IDaIndustry<TKey>
    {
        public DaIndustryManager(IDaIndustryRepository<TKey, TIndustry> repository)
            : base(repository)
        { }

        protected virtual IDaIndustryRepository<TKey, TIndustry> Repository
        {
            get
            {
                return GetRepository<IDaIndustryRepository<TKey, TIndustry>>();
            }
        }

        public void Create(TIndustry industry)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(industry));
        }

        public Task CreateAsync(TIndustry industry)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(industry, nameof(industry));

            return Repository.CreateAsync(industry);
        }

        public void Create(IEnumerable<TIndustry> industries)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(industries));
        }

        public Task CreateAsync(IEnumerable<TIndustry> industries)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(industries, nameof(industries));

            return Repository.CreateAsync(industries);
        }

        public void Update(TIndustry industry)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(industry));
        }

        public Task UpdateAsync(TIndustry industry)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(industry, nameof(industry));

            return Repository.UpdateAsync(industry);
        }

        public void Delete(TIndustry industry)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(industry));
        }

        public Task DeleteAsync(TIndustry industry)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(industry, nameof(industry));

            return Repository.DeleteAsync(industry);
        }

        public List<TIndustry> FindAll()
        {
            return DaAsyncHelper.RunSync(() => FindAllAsync());
        }

        public Task<List<TIndustry>> FindAllAsync()
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync();
        }

        public TIndustry FindById(TKey id)
        {
            return DaAsyncHelper.RunSync(() => FindByIdAsync(id));
        }

        public Task<TIndustry> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public TIndustry FindByName(string name)
        {
            return DaAsyncHelper.RunSync(() => FindByNameAsync(name));
        }

        public Task<TIndustry> FindByNameAsync(string name)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(name, nameof(name));

            return Repository.FindByNameAsync(name);
        }
    }
}