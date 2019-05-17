// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Utils;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Apps
{
    public class DaFeatureManager<TKey, TNullableKey, TFeature> : DaEntityManagerBase<TKey, TFeature>
        where TKey : IEquatable<TKey>
        where TFeature : IDaFeature<TKey, TNullableKey>
    {
        public DaFeatureManager(IDaFeatureRepository<TKey, TNullableKey, TFeature> repository)
            : base(repository)
        {
        }

        protected virtual IDaFeatureRepository<TKey, TNullableKey, TFeature> Repository
        {
            get
            {
                return GetRepository<IDaFeatureRepository<TKey, TNullableKey, TFeature>>();
            }
        }

        public virtual async Task CreateAsync(TFeature feature)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(feature, nameof(feature));

            feature.Key = await CreateValidFeatureKeyAsync(feature);
            feature.Status = DaEntityWorkflowStatus.Draft;
            feature.LastUpdatedDateUtc = DateTime.UtcNow;

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

        public virtual async Task PublishAsync(TFeature feature)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(feature, nameof(feature));

            if (feature.Status != DaEntityWorkflowStatus.Draft)
            {
                if (feature.Status != DaEntityWorkflowStatus.Unpublished)
                {
                    throw new InvalidOperationException("A feature must be in draft or unpublished state to be published.");
                }
            }

            feature.Status = DaEntityWorkflowStatus.Published;
            feature.LastUpdatedDateUtc = DateTime.UtcNow;

            await Repository.UpdateAsync(feature);
        }

        public virtual void Publish(TFeature feature)
        {
            DaAsyncHelper.RunSync(() => PublishAsync(feature));
        }

        public virtual async Task UnpublishAsync(TFeature feature)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(feature, nameof(feature));

            if (feature.Status != DaEntityWorkflowStatus.Published)
            {
                throw new InvalidOperationException("A feature must be in published state to be unpublished.");
            }

            feature.Status = DaEntityWorkflowStatus.Unpublished;
            feature.LastUpdatedDateUtc = DateTime.UtcNow;

            await Repository.UpdateAsync(feature);
        }

        public virtual void Unpublish(TFeature feature)
        {
            DaAsyncHelper.RunSync(() => UnpublishAsync(feature));
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

        public virtual List<TFeature> FindAll()
        {
            return DaAsyncHelper.RunSync<List<TFeature>>(() => FindAllAsync());
        }

        public virtual Task<List<TFeature>> FindAllAsync()
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync();
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

        public Task<List<TFeature>> FindByAppIdAsync(TNullableKey appId)
        {
            ThrowIfDisposed();
            return Repository.FindByAppIdAsync(appId);
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