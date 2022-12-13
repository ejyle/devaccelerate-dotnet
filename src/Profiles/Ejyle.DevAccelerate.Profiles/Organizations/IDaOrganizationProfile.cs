// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Profiles.Organizations
{
    public interface IDaOrganizationProfile<TKey, TNullableKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {

        TNullableKey TenantId { get; set; }
        TKey OwnerUserId { get; set; }

        string OrganizationName { get; set; }
        public TNullableKey ParentId { get; set; }
        DaOrganizationType OrganizationType { get; set; }
        TNullableKey IndustryId { get; set; }
    }
}
