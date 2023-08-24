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
    public class DaOrganization : DaOrganization<string, DaOrganization, DaOrganizationAttribute, DaOrganizationGroup>
    {
        public DaOrganization() : base()
        { }
    }

    public class DaOrganization<TKey, TOrganization, TOrganizationAttribute, TOrganizationGroup> : DaAuditedEntityBase<TKey>, IDaOrganization<TKey>
        where TKey : IEquatable<TKey>
        where TOrganization : IDaOrganization<TKey>
        where TOrganizationAttribute : IDaOrganizationAttribute<TKey>
        where TOrganizationGroup : IDaOrganizationGroup<TKey>
    {
        public DaOrganization() : base()
        {
            Attributes = new HashSet<TOrganizationAttribute>();
            Groups= new HashSet<TOrganizationGroup>();
        }

        public TKey TenantId { get; set; }
        public string OwnerUserId { get; set; }
        public string OrganizationName { get; set; }
        public DaOrganizationType OrganizationType { get; set; }
        public TKey ParentId { get; set; }
        public TOrganization Parent { get; set; }
        public ICollection<TOrganization> Children { get; set; }
        public string Industry { get; set; }
        public virtual ICollection<TOrganizationGroup> Groups { get; set; }
        public virtual ICollection<TOrganizationAttribute> Attributes { get; set; }
    }
}