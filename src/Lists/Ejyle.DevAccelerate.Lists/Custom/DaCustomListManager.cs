// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Data;
using Ejyle.DevAccelerate.Core.Utils;

namespace Ejyle.DevAccelerate.Lists.Custom
{
    public abstract class DaCustomListManager<TKey, TCustomList, TCustomListItem> : DaEntityManagerBase<TKey, TCustomList>
        where TKey : IEquatable<TKey>
        where TCustomList : IDaCustomList<TKey>
        where TCustomListItem : IDaCustomListItem<TKey>
    {
        public DaCustomListManager(IDaCustomListRepository<TKey, TCustomList, TCustomListItem> repository)
            : base(repository)
        { }

        protected virtual IDaCustomListRepository<TKey, TCustomList, TCustomListItem> Repository
        {
            get
            {
                return GetRepository<IDaCustomListRepository<TKey, TCustomList, TCustomListItem>>();
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

            customList.Key = CreateKey(customList);    
            
            if(await IsKeyExistsAsync(customList.Key))
            {
                throw new DaDuplicateKeyException("The key already exists.");
            }

            if (customList.IsListItemNameUnique)
            {
                if (IsListNameUnique(customList))
                {
                    throw new DaListItemNameDuplicateException("Each list item in a list must have a unique name.");
                }
            }

            if (customList.CanListItemWeightageBeDuplicate)
            {
                if (IsWeightageDuplicate(customList))
                {
                    throw new DaDuplicateListItemWeightageException("List items in a list must have unique weigtage.");
                }
            }

            await Repository.CreateAsync(customList);
        }

        public void Create(TCustomList[] customLists)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(customLists));
        }

        public async Task CreateAsync(TCustomList[] customLists)
        {
            ThrowIfDisposed();
            foreach(var customList in customLists)
            {
                customList.Key = CreateKey(customList);

                if (await IsKeyExistsAsync(customList.Key))
                {
                    throw new DaDuplicateKeyException("The key already exists.");
                }

                if (customList.IsListItemNameUnique)
                {
                    if (IsListNameUnique(customList))
                    {
                        throw new DaListItemNameDuplicateException("Each list item in a list must have a unique name.");
                    }
                }

                if (customList.CanListItemWeightageBeDuplicate)
                {
                    if (IsWeightageDuplicate(customList))
                    {
                        throw new DaDuplicateListItemWeightageException("List items in a list must have unique weigtage.");
                    }
                }
            }

            await Repository.CreateAsync(customLists);
        }

        public void Update(TCustomList customList)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(customList));
        }

        public async Task UpdateAsync(TCustomList customList)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(customList, nameof(customList));

            if (await IsKeyExistsAsync(customList.Key, customList.Id))
            {
                throw new DaDuplicateKeyException("The key already exists.");
            }

            if (customList.CanListItemWeightageBeDuplicate)
            {
                if (IsWeightageDuplicate(customList))
                {
                    throw new DaDuplicateListItemWeightageException("List items in a list must have unique weigtage.");
                }
            }

            await Repository.UpdateAsync(customList);
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

        public void DeleteListItem(TCustomListItem customListItem)
        {
            DaAsyncHelper.RunSync(() => DeleteListItemAsync(customListItem));
        }

        public Task DeleteListItemAsync(TCustomListItem customListItem)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(customListItem, nameof(customListItem));

            return Repository.DeleteListItemAsync(customListItem);
        }

        public List<TCustomList> FindWithoutTenantId()
        {
            return DaAsyncHelper.RunSync<List<TCustomList>>(() => FindWithoutTenantIdAsync());
        }

        public Task<List<TCustomList>> FindWithoutTenantIdAsync()
        {
            ThrowIfDisposed();
            return Repository.FindWithoutTenantIdAsync();
        }

        public DaPaginatedEntityList<TKey, TCustomList> FindWithoutTenantId(DaDataPaginationCriteria paginationCriteria)
        {
            return DaAsyncHelper.RunSync<DaPaginatedEntityList<TKey, TCustomList>>(() => FindWithoutTenantIdAsync(paginationCriteria));
        }

        public Task<DaPaginatedEntityList<TKey, TCustomList>> FindWithoutTenantIdAsync(DaDataPaginationCriteria paginationCriteria)
        {
            ThrowIfDisposed();
            return Repository.FindWithoutTenantIdAsync(paginationCriteria);
        }

        public List<TCustomList> FindWithTenantId(string tenantId)
        {
            return DaAsyncHelper.RunSync<List<TCustomList>>(() => FindWithTenantIdAsync(tenantId));
        }

        public Task<List<TCustomList>> FindWithTenantIdAsync(string tenantId)
        {
            ThrowIfDisposed();
            return Repository.FindWithTenantIdAsync(tenantId);
        }

        public DaPaginatedEntityList<TKey, TCustomList> FindWithTenantId(string tenantId, DaDataPaginationCriteria paginationCriteria)
        {
            return DaAsyncHelper.RunSync<DaPaginatedEntityList<TKey, TCustomList>>(() => FindWithTenantIdAsync(tenantId, paginationCriteria));
        }

        public Task<DaPaginatedEntityList<TKey, TCustomList>> FindWithTenantIdAsync(string tenantId, DaDataPaginationCriteria paginationCriteria)
        {
            ThrowIfDisposed();
            return Repository.FindWithTenantIdAsync(tenantId, paginationCriteria);
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

        private string CreateKey(TCustomList customList)
        {
            return CreateKey(customList.Name, customList.TenantId);
        }

        public virtual string CreateKey(string name, string tenantId)
        {
            var key = name;
            if(tenantId != null)
            {
                key = key + "_" + tenantId.ToString();
            }

            key = key.Replace(" ", "_").ToLower();
            return key;
        }

        public TCustomListItem FindListItemById(TKey listItemId)
        {
            return DaAsyncHelper.RunSync<TCustomListItem>(() => FindListItemByIdAsync(listItemId));
        }

        public Task<TCustomListItem> FindListItemByIdAsync(TKey listItemId)
        {
            ThrowIfDisposed();
            return Repository.FindListItemByIdAsync(listItemId);
        }

        protected abstract bool IsWeightageDuplicate(TCustomList customList);
        protected abstract bool IsListNameUnique(TCustomList customList);

        private async Task<bool> IsKeyExistsAsync(string key)
        {
            var customList = await FindByKeyAsync(key);
            return (customList != null);
        }

        private async Task<bool> IsKeyExistsAsync(string key, TKey id)
        {
            var customList = await FindByKeyAsync(key);
            return (customList != null && !customList.Id.Equals(id));
        }
    }
}
