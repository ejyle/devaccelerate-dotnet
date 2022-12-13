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
    public interface IDaOrganizationProfileRepository<TKey, TNullableKey, TOrganizationProfile, TOrganizationGroup> : IDaEntityRepository<TKey, TOrganizationProfile>
        where TKey : IEquatable<TKey>
        where TOrganizationProfile : IDaOrganizationProfile<TKey, TNullableKey>
        where TOrganizationGroup : IDaOrganizationGroup<TKey, TNullableKey>

    {
        Task CreateAsync(TOrganizationProfile organizationProfile);
        Task<TOrganizationProfile> FindByIdAsync(TKey id);
        Task<List<TOrganizationProfile>> FindByTenantIdAsync(TKey tenantId);
        Task UpdateAsync(TOrganizationProfile organizationProfile);
        Task DeleteAsync(TOrganizationProfile organizationProfile);
        Task<List<TOrganizationProfile>> FindByAttributeAsync(string attributeName, string attributeValue);
        Task<TOrganizationGroup> FindOrganizaitonGroupByIdAsync(TKey id, TKey organizationGroupId);
    }
}
