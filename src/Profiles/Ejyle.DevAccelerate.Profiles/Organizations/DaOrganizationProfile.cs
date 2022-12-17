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
    public class DaOrganizationProfile : DaOrganizationProfile<string, DaOrganizationProfile, DaOrganizationProfileAttribute, DaOrganizationGroup>
    {
        public DaOrganizationProfile() : base()
        { }
    }

    public class DaOrganizationProfile<TKey, TOrganizationProfile, TOrganizationProfileAttribute, TOrganizationGroup> : DaAuditedEntityBase<TKey>, IDaOrganizationProfile<TKey>
        where TKey : IEquatable<TKey>
        where TOrganizationProfile : IDaOrganizationProfile<TKey>
        where TOrganizationProfileAttribute : IDaOrganizationProfileAttribute<TKey>
        where TOrganizationGroup : IDaOrganizationGroup<TKey>
    {
        public DaOrganizationProfile() : base()
        {
            Attributes = new HashSet<TOrganizationProfileAttribute>();
            Groups= new HashSet<TOrganizationGroup>();
        }

        public TKey TenantId { get; set; }
        public TKey OwnerUserId { get; set; }
        public string OrganizationName { get; set; }
        public DaOrganizationType OrganizationType { get; set; }
        public TKey ParentId { get; set; }
        public TOrganizationProfile Parent { get; set; }
        public ICollection<TOrganizationProfile> Children { get; set; }
        public TKey IndustryId { get; set; }
        public virtual ICollection<TOrganizationGroup> Groups { get; set; }
        public virtual ICollection<TOrganizationProfileAttribute> Attributes { get; set; }
    }
}