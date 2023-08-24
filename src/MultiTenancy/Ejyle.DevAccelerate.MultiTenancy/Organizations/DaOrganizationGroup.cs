// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.MultiTenancy.Organizations
{
    public class DaOrganizationGroup : DaOrganizationGroup<string, DaOrganizationGroup, DaOrganization>
    {
        public DaOrganizationGroup() : base()
        { }
    }

    public class DaOrganizationGroup<TKey, TOrganizationGroup, TOrganization> : DaAuditedEntityBase<TKey>, IDaOrganizationGroup<TKey>
        where TKey : IEquatable<TKey>
        where TOrganizationGroup : IDaOrganizationGroup<TKey>
        where TOrganization : IDaOrganization<TKey>
    {
        public DaOrganizationGroup() : base()
        {
            Children = new HashSet<TOrganizationGroup>();
        }

        public TKey OrganizationId { get; set; }
        public string OwnerUserId { get; set; }
        public string GroupName { get; set; }
        public DaOrganizationGroupType GroupType { get; set; }
        public TKey ParentId { get; set; }
        public TOrganizationGroup Parent { get; set; }
        public ICollection<TOrganizationGroup> Children { get; set; }
        public virtual TOrganization Organization { get; set; }
    }
}