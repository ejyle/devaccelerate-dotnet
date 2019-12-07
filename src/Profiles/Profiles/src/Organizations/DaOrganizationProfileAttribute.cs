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
    public class DaOrganizationProfileAttribute : DaOrganizationProfileAttribute<DaOrganizationProfile>
    {
        public DaOrganizationProfileAttribute() : base()
        { }
    }

    public class DaOrganizationProfileAttribute<TOrganizationProfile> : DaOrganizationProfileAttribute<int, int?, TOrganizationProfile>
        where TOrganizationProfile : IDaOrganizationProfile<int, int?>
    {
        public DaOrganizationProfileAttribute() : base()
        { }
    }

    public class DaOrganizationProfileAttribute<TKey, TNullableKey, TOrganizationProfile> : DaEntityBase<TKey>, IDaOrganizationProfileAttribute<TKey>
        where TKey : IEquatable<TKey>
        where TOrganizationProfile : IDaOrganizationProfile<TKey, TNullableKey>
    {
        public DaOrganizationProfileAttribute() : base()
        { }

        public TKey OrganizationProfileId { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime LastUpdatedDateUtc { get; set; }
        public virtual TOrganizationProfile OrganizationProfile { get; set; }
    }
}
