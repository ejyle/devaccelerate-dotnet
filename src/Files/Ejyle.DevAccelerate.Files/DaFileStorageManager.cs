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
    public class DaFileStorageManager<TKey, TFileStorage> : DaEntityManagerBase<TKey, TFileStorage>
        where TKey : IEquatable<TKey>
        where TFileStorage : IDaFileStorage<TKey>
    {
        public DaFileStorageManager(IDaFileStorageRepository<TKey, TFileStorage> repository)
            : base(repository)
        {
        }

        protected virtual IDaFileStorageRepository<TKey, TFileStorage> Repository
        {
            get
            {
                return GetRepository<IDaFileStorageRepository<TKey, TFileStorage>>();
            }
        }

        public virtual async Task CreateAsync(TFileStorage fileStorage)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(fileStorage, nameof(fileStorage));

            await Repository.CreateAsync(fileStorage);
        }

        public virtual void Create(TFileStorage fileStorage)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(fileStorage));
        }

        public virtual async Task UpdateAsync(TFileStorage fileStorage)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(fileStorage, nameof(fileStorage));

            await Repository.UpdateAsync(fileStorage);
        }

        public virtual void Update(TFileStorage fileStorage)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(fileStorage));
        }

        public virtual async Task DeleteAsync(TFileStorage fileStorage)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(fileStorage, nameof(fileStorage));

            await Repository.DeleteAsync(fileStorage);
        }

        public virtual void Delete(TFileStorage fileStorage)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(fileStorage));
        }

        public virtual TFileStorage FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TFileStorage>(() => FindByIdAsync(id));
        }

        public virtual Task<TFileStorage> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public virtual TFileStorage FindByName(string name)
        {
            return DaAsyncHelper.RunSync<TFileStorage>(() => FindByNameAsync(name));
        }

        public virtual Task<TFileStorage> FindByNameAsync(string name)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(name, nameof(name));
            return Repository.FindByNameAsync(name);
        }

        public virtual List<TFileStorage> FindAll()
        {
            return DaAsyncHelper.RunSync<List<TFileStorage>>(() => FindAllAsync());
        }

        public virtual Task<List<TFileStorage>> FindAllAsync()
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync();
        }
    }
}