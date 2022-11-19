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

namespace Ejyle.DevAccelerate.Lists.Custom
{
    public class DaCustomListManager<TKey, TCustomList> : DaEntityManagerBase<TKey, TCustomList>
        where TKey : IEquatable<TKey>
        where TCustomList : IDaCustomList<TKey>
    {
        public DaCustomListManager(IDaCustomListRepository<TKey, TCustomList> repository)
            : base(repository)
        { }

        protected virtual IDaCustomListRepository<TKey, TCustomList> Repository
        {
            get
            {
                return GetRepository<IDaCustomListRepository<TKey, TCustomList>>();
            }
        }

        public void Create(TCustomList customList)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(customList));
        }

        public Task CreateAsync(TCustomList customList)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(customList, nameof(customList));

            return Repository.CreateAsync(customList);
        }

        public void Update(TCustomList customList)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(customList));
        }

        public Task UpdateAsync(TCustomList customList)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(customList, nameof(customList));

            return Repository.UpdateAsync(customList);
        }

        public void Delete(TCustomList customList)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(customList));
        }

        public Task DeleteAsync(TCustomList customList)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(customList, nameof(customList));

            return Repository.DeleteAsync(customList);
        }

        public List<TCustomList> FindAll()
        {
            return DaAsyncHelper.RunSync<List<TCustomList>>(() => FindAllAsync());
        }

        public Task<List<TCustomList>> FindAllAsync()
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync();
        }

        public DaPaginatedEntityList<TKey, TCustomList> FindAll(DaDataPaginationCriteria paginationCriteria)
        {
            return DaAsyncHelper.RunSync<DaPaginatedEntityList<TKey, TCustomList>>(() => FindAllAsync(paginationCriteria));
        }

        public Task<DaPaginatedEntityList<TKey, TCustomList>> FindAllAsync(DaDataPaginationCriteria paginationCriteria)
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync(paginationCriteria);
        }

        public TCustomList FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TCustomList>(() => FindByIdAsync(id));
        }

        public Task<TCustomList> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public TCustomList FindByName(string name)
        {
            return DaAsyncHelper.RunSync<TCustomList>(() => FindByNameAsync(name));
        }

        public Task<TCustomList> FindByNameAsync(string name)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(name, nameof(name));

            return Repository.FindByNameAsync(name);
        }
    }
}
