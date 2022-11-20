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
using Ejyle.DevAccelerate.Core.Utils;

namespace Ejyle.DevAccelerate.Lists.Custom
{
    public class DaCustomListManager<TKey, TNullableKey, TCustomList> : DaEntityManagerBase<TKey, TCustomList>
        where TKey : IEquatable<TKey>
        where TCustomList : IDaCustomList<TKey, TNullableKey>
    {
        public DaCustomListManager(IDaCustomListRepository<TKey, TNullableKey, TCustomList> repository)
            : base(repository)
        { }

        protected virtual IDaCustomListRepository<TKey, TNullableKey, TCustomList> Repository
        {
            get
            {
                return GetRepository<IDaCustomListRepository<TKey, TNullableKey, TCustomList>>();
            }
        }

        public void Create(TCustomList customList)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(customList));
        }

        public async Task CreateAsync(TCustomList customList)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(customList, nameof(customList));

            customList.Key = await CreateValidKeyAsync(customList);            
            await Repository.CreateAsync(customList);
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

        public TCustomList FindByKey(string key)
        {
            return DaAsyncHelper.RunSync<TCustomList>(() => FindByKeyAsync(key));
        }

        public Task<TCustomList> FindByKeyAsync(string key)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(key, nameof(key));

            return Repository.FindByKeyAsync(key);
        }

        public virtual async Task<string> CreateValidKeyAsync(TCustomList customList)
        {
            if(!string.IsNullOrEmpty(customList.Key))
            {
                if(await IsKeyExistsAsync(customList.Key) == false)
                {
                    return customList.Key;
                }
            }

            var key = customList.Name;
            var tenantId = customList.TenantId as IEquatable<TNullableKey>;

            if(tenantId != null)
            {
                key = key + "_" + tenantId.ToString();
            }

            key = key.Replace(" ", "_").ToLower();

            if (await IsKeyExistsAsync(key))
            {
                key = key + "_" + DaRandomNumberUtil.GenerateInt().ToString();
            }

            return key;
        }

        private async Task<bool> IsKeyExistsAsync(string key)
        {
            var customList = await FindByKeyAsync(key);
            return (customList != null);
        }
    }
}
