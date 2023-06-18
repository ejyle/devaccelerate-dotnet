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

namespace Ejyle.DevAccelerate.MultiTenancy.Organizations
{
    public class DaOrganizationManager<TKey, TOrganization, TOrganizationGroup> : DaEntityManagerBase<TKey, TOrganization>
        where TKey : IEquatable<TKey>
        where TOrganization : IDaOrganization<TKey>
        where TOrganizationGroup : IDaOrganizationGroup<TKey>
    {
        public DaOrganizationManager(IDaOrganizationProfileRepository<TKey, TOrganization, TOrganizationGroup> repository) : base(repository)
        {
        }

        protected virtual IDaOrganizationProfileRepository<TKey, TOrganization, TOrganizationGroup> Repository
        {
            get
            {
                return GetRepository<IDaOrganizationProfileRepository<TKey, TOrganization, TOrganizationGroup>>();
            }
        }

        public virtual async Task CreateAsync(TOrganization organization)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(organization, nameof(organization));

            organization.CreatedDateUtc = DateTime.UtcNow;
            organization.LastUpdatedDateUtc = DateTime.UtcNow;

            await Repository.CreateAsync(organization);
        }

        public virtual void Create(TOrganization organization)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(organization));
        }

        public virtual async Task UpdateAsync(TOrganization organization)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(organization, nameof(organization));

            organization.LastUpdatedDateUtc = DateTime.UtcNow;

            await Repository.UpdateAsync(organization);
        }

        public virtual void Update(TOrganization organization)
        {
            DaAsyncHelper.RunSync(() => UpdateAsync(organization));
        }

        public virtual async Task DeleteAsync(TOrganization organization)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(organization, nameof(organization));

            await Repository.DeleteAsync(organization);
        }

        public virtual void Delete(TOrganization organization)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(organization));
        }

        public virtual TOrganization FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TOrganization>(() => FindByIdAsync(id));
        }

        public virtual Task<TOrganization> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public virtual List<TOrganization> FindByTenantId(TKey tenantId)
        {
            return DaAsyncHelper.RunSync<List<TOrganization>>(() => FindByTenantIdAsync(tenantId));
        }

        public virtual Task<List<TOrganization>> FindByTenantIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByTenantIdAsync(id);
        }

        public virtual Task<TOrganizationGroup> FindOrganizationGroupByIdAsync(TKey id, TKey organizationGroupId)
        {
            ThrowIfDisposed();
            return Repository.FindOrganizationGroupByIdAsync(id, organizationGroupId);
        }
    }
}
