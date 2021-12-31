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

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Apps
{
    public class DaAppManager<TKey, TApp> : DaEntityManagerBase<TKey, TApp>
        where TKey : IEquatable<TKey>
        where TApp : IDaApp<TKey>
    {
        public DaAppManager(IDaAppRepository<TKey, TApp> repository) : base(repository)
        {
        }

        protected virtual IDaAppRepository<TKey, TApp> Repository
        {
            get
            {
                return GetRepository<IDaAppRepository<TKey, TApp>>();
            }
        }

        public virtual async Task CreateAsync(TApp app)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(app, nameof(app));

            app.Key = await CreateValidAppKeyAsync(app);
            await Repository.CreateAsync(app);
        }

        public virtual void Create(TApp app)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(app));
        }

        public virtual async Task UpdateAsync(TApp app)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(app, nameof(app));

            await Repository.UpdateAsync(app);
        }

        public virtual void Update(TApp app)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(app));
        }

        public virtual async Task RemoveAppFeatureByIdAsync(TKey appProfileFeatureId)
        {
            ThrowIfDisposed();
            await Repository.RemoveAppFeatureByIdAsync(appProfileFeatureId);
        }

        public virtual void RemoveAppFeatureById(TKey appProfileFeatureId)
        {
            DaAsyncHelper.RunSync(() => RemoveAppFeatureByIdAsync(appProfileFeatureId));
        }

        public virtual async Task DeleteAsync(TApp app)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(app, nameof(app));

            await Repository.DeleteAsync(app);
        }

        public virtual void Delete(TApp app)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(app));
        }

        public virtual TApp FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TApp>(() => FindByIdAsync(id));
        }

        public virtual Task<TApp> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public virtual TApp FindByName(string name)
        {
            return DaAsyncHelper.RunSync<TApp>(() => FindByKeyAsync(name));
        }

        public virtual Task<TApp> FindByKeyAsync(string key)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(key, nameof(key));

            return Repository.FindByKeyAsync(key);
        }

        public virtual Task<DaPaginatedEntityList<TKey, TApp>> FindAllAsync(DaDataPaginationCriteria paginationCriteria)
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync(paginationCriteria);
        }

        public virtual DaPaginatedEntityList<TKey, TApp> FindAll(DaDataPaginationCriteria paginationCriteria)
        {
            return DaAsyncHelper.RunSync<DaPaginatedEntityList<TKey, TApp>>(() => FindAllAsync(paginationCriteria));
        }

        public virtual string CreateValidAppKey(TApp app)
        {
            return DaAsyncHelper.RunSync<string>(() => CreateValidAppKeyAsync(app));
        }

        public virtual async Task<string> CreateValidAppKeyAsync(TApp app)
        {
            var appName = app.Name.Replace(" ", "-");
            appName = appName.ToLower();

            var duplicateFeatureName = await IsAppKeyExistsAsync(appName);

            if (duplicateFeatureName)
            {
                appName = appName + "-" + DaRandomNumberUtil.GenerateInt();
            }

            return appName;
        }

        private async Task<bool> IsAppKeyExistsAsync(string appName)
        {
            var app = await FindByKeyAsync(appName);
            return (app != null);
        }
    }
}
