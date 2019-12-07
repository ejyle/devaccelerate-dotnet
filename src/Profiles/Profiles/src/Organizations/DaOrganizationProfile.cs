// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Profiles.Organizations
{
    public class DaOrganizationProfile : DaOrganizationProfile<DaOrganizationProfileAttribute>
    {
        public DaOrganizationProfile() : base()
        { }
    }

    public class DaOrganizationProfile<TOrganizationProfileAttribute> : DaOrganizationProfile<int, int?, TOrganizationProfileAttribute>
        where TOrganizationProfileAttribute : IDaOrganizationProfileAttribute<int>
    {
    }

    public class DaOrganizationProfile<TKey, TNullableKey, TOrganizationProfileAttribute> : DaEntityBase<TKey>, IDaOrganizationProfile<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
        where TOrganizationProfileAttribute : IDaOrganizationProfileAttribute<TKey>
    {
        public DaOrganizationProfile() : base()
        {
            Attributes = new HashSet<TOrganizationProfileAttribute>();
        }

        public TKey TenantId { get; set; }
        public string OrganizationName { get; set; }
        public DaOrganizationType OrganizationType { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime LastUpdatedDateUtc { get; set; }
        public TNullableKey IndustryId { get; set; }
        public virtual ICollection<TOrganizationProfileAttribute> Attributes { get; set; }
    }
}