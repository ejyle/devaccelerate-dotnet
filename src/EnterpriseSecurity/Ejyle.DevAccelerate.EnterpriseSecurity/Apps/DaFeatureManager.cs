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
    public class DaFeatureManager<TKey, TFeature> : DaEntityManagerBase<TKey, TFeature>
        where TKey : IEquatable<TKey>
        where TFeature : IDaFeature<TKey>
    {
        public DaFeatureManager(IDaFeatureRepository<TKey, TFeature> repository)
            : base(repository)
        {
        }

        protected virtual IDaFeatureRepository<TKey, TFeature> Repository
        {
            get
            {
                return GetRepository<IDaFeatureRepository<TKey, TFeature>>();
            }
        }

        public virtual async Task CreateAsync(TFeature feature)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(feature, nameof(feature));

            feature.Key = await CreateValidFeatureKeyAsync(feature);
            await Repository.CreateAsync(feature);
        }

        public virtual void Create(TFeature feature)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(feature));
        }

        public virtual async Task UpdateAsync(TFeature feature)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(feature, nameof(feature));

            await Repository.UpdateAsync(feature);
        }

        public virtual void Update(TFeature feature)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(feature));
        }

        public virtual async Task DeleteAsync(TFeature feature)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(feature, nameof(feature));

            await Repository.DeleteAsync(feature);
        }

        public virtual void Delete(TFeature feature)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(feature));
        }

        public virtual TFeature FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TFeature>(() => FindByIdAsync(id));
        }

        public virtual Task<TFeature> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public virtual TFeature FindByName(string name)
        {
            return DaAsyncHelper.RunSync<TFeature>(() => FindByKeyAsync(name));
        }

        public virtual Task<TFeature> FindByKeyAsync(string key)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(key, nameof(key));

            return Repository.FindByKeyAsync(key);
        }

        public Task<List<TFeature>> FindByAppIdAsync(TKey appId)
        {
            ThrowIfDisposed();
            return Repository.FindByAppIdAsync(appId);
        }

        public virtual Task<DaPaginatedEntityList<TKey, TFeature>> FindAllAsync(DaDataPaginationCriteria paginationCriteria)
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync(paginationCriteria);
        }

        public virtual DaPaginatedEntityList<TKey, TFeature> FindAll(DaDataPaginationCriteria paginationCriteria)
        {
            return DaAsyncHelper.RunSync<DaPaginatedEntityList<TKey, TFeature>>(() => FindAllAsync(paginationCriteria));
        }

        public virtual string CreateValidFeatureKey(TFeature feature)
        {
            return DaAsyncHelper.RunSync<string>(() => CreateValidFeatureKeyAsync(feature));
        }

        public virtual async Task<string> CreateValidFeatureKeyAsync(TFeature feature)
        {
            var featureName = feature.Name.Replace(" ", "-");
            featureName = featureName.ToLower();

            var duplicateFeatureName = await IsFeatureKeyExistsAsync(featureName);

            if (duplicateFeatureName)
            {
                featureName = featureName + "-" + DaRandomNumberUtil.GenerateInt();
            }

            return featureName;
        }

        private async Task<bool> IsFeatureKeyExistsAsync(string appName)
        {
            var app = await FindByKeyAsync(appName);
            return (app != null);
        }
    }
}