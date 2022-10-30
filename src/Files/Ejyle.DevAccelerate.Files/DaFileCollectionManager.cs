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

namespace Ejyle.DevAccelerate.Files
{
    public class DaFileCollectionManager<TKey, TNullableKey, TFileCollection> : DaEntityManagerBase<TKey, TFileCollection>
        where TKey : IEquatable<TKey>
        where TFileCollection : IDaFileCollection<TKey, TNullableKey>
    {
        public DaFileCollectionManager(IDaFileCollectionRepository<TKey, TNullableKey, TFileCollection> repository)
            : base(repository)
        {
        }

        protected virtual IDaFileCollectionRepository<TKey, TNullableKey, TFileCollection> Repository
        {
            get
            {
                return GetRepository<IDaFileCollectionRepository<TKey, TNullableKey, TFileCollection>>();
            }
        }

        public virtual async Task CreateAsync(TFileCollection fileCollection)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(fileCollection, nameof(fileCollection));

            await Repository.CreateAsync(fileCollection);
        }

        public virtual void Create(TFileCollection fileCollection)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(fileCollection));
        }

        public virtual async Task RenameAsync(TKey id, string newName)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(newName, nameof(newName));

            await Repository.RenameAsync(id, newName);
        }

        public virtual void Rename(TKey id, string newName)
        {
            DaAsyncHelper.RunSync(() =>RenameAsync(id, newName));
        }

        public virtual async Task DeleteAsync(TFileCollection fileCollection)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(fileCollection, nameof(fileCollection));

            await Repository.DeleteAsync(fileCollection);
        }

        public virtual void Delete(TFileCollection fileCollection)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(fileCollection));
        }

        public virtual TFileCollection FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TFileCollection>(() => FindByIdAsync(id));
        }

        public virtual Task<TFileCollection> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public virtual DaPaginatedEntityList<TKey, TFileCollection> FindByParentId(TKey parentId, DaDataPaginationCriteria paginationCriteria)
        {
            return DaAsyncHelper.RunSync<DaPaginatedEntityList<TKey, TFileCollection>>(() => FindByParentIdAsync(parentId, paginationCriteria));
        }

        public virtual Task<DaPaginatedEntityList<TKey, TFileCollection>> FindByParentIdAsync(TKey parentId, DaDataPaginationCriteria paginationCriteria)
        {
            ThrowIfDisposed();
            return Repository.FindByParentIdAsync(parentId, paginationCriteria);
        }

        public virtual DaPaginatedEntityList<TKey, TFileCollection> FindByObjectInstanceId(TKey objectInstanceId, DaDataPaginationCriteria paginationCriteria)
        {
            return DaAsyncHelper.RunSync<DaPaginatedEntityList<TKey, TFileCollection>>(() => FindByParentIdAsync(objectInstanceId, paginationCriteria));
        }

        public virtual Task<DaPaginatedEntityList<TKey, TFileCollection>> FindByObjectInstanceIdAsync(TKey objectInstanceId, DaDataPaginationCriteria paginationCriteria)
        {
            ThrowIfDisposed();
            return Repository.FindByObjectInstanceIdAsync(objectInstanceId, paginationCriteria);
        }
    }
}