// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.MultiTenancy.Organizations
{
    public interface IDaOrganizationProfile<TKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {

        TKey TenantId { get; set; }
        TKey OwnerUserId { get; set; }

        string OrganizationName { get; set; }
        public TKey ParentId { get; set; }
        DaOrganizationType OrganizationType { get; set; }
        TKey IndustryId { get; set; }
    }
}
