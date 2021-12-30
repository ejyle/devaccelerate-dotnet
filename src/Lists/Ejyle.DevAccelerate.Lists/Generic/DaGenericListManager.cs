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

namespace Ejyle.DevAccelerate.Lists.Generic
{
    public class DaGenericListManager<TKey, TGenericList> : DaEntityManagerBase<TKey, TGenericList>
        where TKey : IEquatable<TKey>
        where TGenericList : IDaGenericList<TKey>
    {
        public DaGenericListManager(IDaGenericListRepository<TKey, TGenericList> repository)
            : base(repository)
        { }

        protected virtual IDaGenericListRepository<TKey, TGenericList> Repository
        {
            get
            {
                return GetRepository<IDaGenericListRepository<TKey, TGenericList>>();
            }
        }

        public void Create(TGenericList genericList)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(genericList));
        }

        public Task CreateAsync(TGenericList genericList)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(genericList, nameof(genericList));

            return Repository.CreateAsync(genericList);
        }

        public void Update(TGenericList genericList)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(genericList));
        }

        public Task UpdateAsync(TGenericList genericList)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(genericList, nameof(genericList));

            return Repository.UpdateAsync(genericList);
        }

        public void Delete(TGenericList genericList)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(genericList));
        }

        public Task DeleteAsync(TGenericList genericList)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(genericList, nameof(genericList));

            return Repository.DeleteAsync(genericList);
        }

        public List<TGenericList> FindAll()
        {
            return DaAsyncHelper.RunSync<List<TGenericList>>(() => FindAllAsync());
        }

        public Task<List<TGenericList>> FindAllAsync()
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync();
        }

        public DaPaginatedEntityList<TKey, TGenericList> FindAll(DaDataPaginationCriteria paginationCriteria)
        {
            return DaAsyncHelper.RunSync<DaPaginatedEntityList<TKey, TGenericList>>(() => FindAllAsync(paginationCriteria));
        }

        public Task<DaPaginatedEntityList<TKey, TGenericList>> FindAllAsync(DaDataPaginationCriteria paginationCriteria)
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync(paginationCriteria);
        }

        public TGenericList FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TGenericList>(() => FindByIdAsync(id));
        }

        public Task<TGenericList> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public TGenericList FindByName(string name)
        {
            return DaAsyncHelper.RunSync<TGenericList>(() => FindByNameAsync(name));
        }

        public Task<TGenericList> FindByNameAsync(string name)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(name, nameof(name));

            return Repository.FindByNameAsync(name);
        }
    }
}
