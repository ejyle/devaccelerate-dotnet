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
    public class DaOrganizationProfileAttribute : DaOrganizationProfileAttribute<DaOrganizationProfile>
    {
        public DaOrganizationProfileAttribute() : base()
        { }
    }

    public class DaOrganizationProfileAttribute<TOrganizationProfile> : DaOrganizationProfileAttribute<string, TOrganizationProfile>
        where TOrganizationProfile : IDaOrganizationProfile<string>
    {
        public DaOrganizationProfileAttribute() : base()
        { }
    }

    public class DaOrganizationProfileAttribute<TKey, TOrganizationProfile> : DaEntityBase<TKey>, IDaOrganizationProfileAttribute<TKey>
        where TKey : IEquatable<TKey>
        where TOrganizationProfile : IDaOrganizationProfile<TKey>
    {
        public DaOrganizationProfileAttribute() : base()
        { }

        public TKey OrganizationProfileId { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public virtual TOrganizationProfile OrganizationProfile { get; set; }
    }
}
