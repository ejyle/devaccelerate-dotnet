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
    public interface IDaOrganizationRepository<TKey, TOrganization, TOrganizationGroup> : IDaEntityRepository<TKey, TOrganization>
        where TKey : IEquatable<TKey>
        where TOrganization : IDaOrganization<TKey>
        where TOrganizationGroup : IDaOrganizationGroup<TKey>

    {
        Task CreateAsync(TOrganization organization);
        Task<TOrganization> FindByIdAsync(TKey id);
        Task<List<TOrganization>> FindByTenantIdAsync(TKey tenantId);
        Task UpdateAsync(TOrganization organization);
        Task DeleteAsync(TOrganization organization);
        Task<List<TOrganization>> FindByAttributeAsync(string attributeName, string attributeValue);
        Task<TOrganizationGroup> FindOrganizationGroupByIdAsync(TKey id, TKey organizationGroupId);
    }
}
