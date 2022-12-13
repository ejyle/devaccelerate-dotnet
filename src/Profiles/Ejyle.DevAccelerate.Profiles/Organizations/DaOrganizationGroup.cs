// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Profiles.Organizations
{
    public class DaOrganizationGroup : DaOrganizationGroup<int, int?, DaOrganizationGroup, DaOrganizationProfile>
    {
        public DaOrganizationGroup() : base()
        { }
    }

    public class DaOrganizationGroup<TKey, TNullableKey, TOrganizationGroup, TOrganizationProfile> : DaAuditedEntityBase<TKey>, IDaOrganizationGroup<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
        where TOrganizationGroup : IDaOrganizationGroup<TKey, TNullableKey>
        where TOrganizationProfile : IDaOrganizationProfile<TKey, TNullableKey>
    {
        public DaOrganizationGroup() : base()
        {
            Children = new HashSet<TOrganizationGroup>();
        }

        public TKey OrganizationProfileId { get; set; }
        public TKey OwnerUserId { get; set; }
        public string GroupName { get; set; }
        public DaOrganizationGroupType GroupType { get; set; }
        public TNullableKey ParentId { get; set; }
        public TOrganizationGroup Parent { get; set; }
        public ICollection<TOrganizationGroup> Children { get; set; }
        public virtual TOrganizationProfile OrganizationProfile { get; set; }
    }
}