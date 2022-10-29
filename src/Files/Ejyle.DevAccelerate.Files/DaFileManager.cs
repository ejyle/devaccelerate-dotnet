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
    public class DaFileManager<TKey, TNullableKey, TFile> : DaEntityManagerBase<TKey, TFile>
        where TKey : IEquatable<TKey>
        where TFile : IDaFile<TKey, TNullableKey>
    {
        public DaFileManager(IDaFileRepository<TKey, TNullableKey, TFile> repository)
            : base(repository)
        {
        }

        protected virtual IDaFileRepository<TKey, TNullableKey, TFile> Repository
        {
            get
            {
                return GetRepository<IDaFileRepository<TKey, TNullableKey, TFile>>();
            }
        }

        public virtual async Task CreateAsync(TFile file)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(file, nameof(file));

            await Repository.CreateAsync(file);
        }

        public virtual void Create(TFile file)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(file));
        }

        public virtual async Task RenameAsync(TKey id, string newName)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(newName, nameof(newName));

            await Repository.RenameAsync(id, newName);
        }

        public virtual void Rename(TKey id, string newName)
        {
            DaAsyncHelper.RunSync(() => RenameAsync(id, newName));
        }

        public virtual async Task DeleteAsync(TFile file)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(file, nameof(file));

            await Repository.DeleteAsync(file);
        }

        public virtual void Delete(TFile file)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(file));
        }

        public virtual TFile FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TFile>(() => FindByIdAsync(id));
        }

        public virtual Task<TFile> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public virtual DaPaginatedEntityList<TKey, TFile> FindByFileCollectionId(TKey fileCollectionId, DaDataPaginationCriteria paginationCriteria)
        {
            return DaAsyncHelper.RunSync<DaPaginatedEntityList<TKey, TFile>>(() => FindByFileCollectionIdAsync(fileCollectionId, paginationCriteria));
        }

        public virtual Task<DaPaginatedEntityList<TKey, TFile>> FindByFileCollectionIdAsync(TKey fileCollectionId, DaDataPaginationCriteria paginationCriteria)
        {
            ThrowIfDisposed();
            return Repository.FindByFileCollectionIdAsync(fileCollectionId, paginationCriteria);
        }

        public virtual DaPaginatedEntityList<TKey, TFile> FindByObjectInstanceId(TKey objectInstanceId, DaDataPaginationCriteria paginationCriteria)
        {
            return DaAsyncHelper.RunSync<DaPaginatedEntityList<TKey, TFile>>(() => FindByFileCollectionIdAsync(objectInstanceId, paginationCriteria));
        }

        public virtual Task<DaPaginatedEntityList<TKey, TFile>> FindByObjectInstanceIdAsync(TKey objectInstanceId, DaDataPaginationCriteria paginationCriteria)
        {
            ThrowIfDisposed();
            return Repository.FindByObjectInstanceIdAsync(objectInstanceId, paginationCriteria);
        }
    }
}