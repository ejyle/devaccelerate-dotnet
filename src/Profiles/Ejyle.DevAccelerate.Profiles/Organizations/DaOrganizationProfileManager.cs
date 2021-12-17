// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Profiles.Organizations
{
    public class DaOrganizationProfileManager<TKey, TNullableKey, TOrganizationProfile> : DaEntityManagerBase<TKey, TOrganizationProfile>
        where TKey : IEquatable<TKey>
        where TOrganizationProfile : IDaOrganizationProfile<TKey, TNullableKey>
    {
        public DaOrganizationProfileManager(IDaOrganizationProfileRepository<TKey, TNullableKey, TOrganizationProfile> repository) : base(repository)
        {
        }

        protected virtual IDaOrganizationProfileRepository<TKey, TNullableKey, TOrganizationProfile> Repository
        {
            get
            {
                return GetRepository<IDaOrganizationProfileRepository<TKey,TNullableKey, TOrganizationProfile>>();
            }
        }

        public virtual async Task CreateAsync(TOrganizationProfile organizationProfile)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(organizationProfile, nameof(organizationProfile));

            organizationProfile.CreatedDateUtc = DateTime.UtcNow;
            organizationProfile.LastUpdatedDateUtc = DateTime.UtcNow;

            await Repository.CreateAsync(organizationProfile);
        }

        public virtual void Create(TOrganizationProfile organizationProfile)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(organizationProfile));
        }

        public virtual async Task UpdateAsync(TOrganizationProfile organizationProfile)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(organizationProfile, nameof(organizationProfile));

            organizationProfile.LastUpdatedDateUtc = DateTime.UtcNow;

            await Repository.UpdateAsync(organizationProfile);
        }

        public virtual void Update(TOrganizationProfile organizationProfile)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(organizationProfile));
        }

        public virtual async Task DeleteAsync(TOrganizationProfile organizationProfile)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(organizationProfile, nameof(organizationProfile));

            await Repository.DeleteAsync(organizationProfile);
        }

        public virtual void Delete(TOrganizationProfile organizationProfile)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(organizationProfile));
        }

        public virtual TOrganizationProfile FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TOrganizationProfile>(() => FindByIdAsync(id));
        }

        public virtual Task<TOrganizationProfile> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public virtual List<TOrganizationProfile> FindByTenantId(TKey tenantId)
        {
            return DaAsyncHelper.RunSync<List<TOrganizationProfile>>(() => FindByTenantIdAsync(tenantId));
        }

        public virtual Task<List<TOrganizationProfile>> FindByTenantIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByTenantIdAsync(id);
        }
    }
}
