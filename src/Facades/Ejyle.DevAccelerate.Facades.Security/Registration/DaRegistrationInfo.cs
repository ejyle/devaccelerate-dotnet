// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ejyle.DevAccelerate.EnterpriseSecurity.Tenants;
using Ejyle.DevAccelerate.Profiles.Organizations;

namespace Ejyle.DevAccelerate.Facades.Security.Registration
{
    public class DaRegistrationInfo : DaRegistrationInfo<int, int?>
    { }

    public class DaRegistrationInfo<TKey, TNullableKey> : IDaRegistrationInfo<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
    {
        public DaRegistrationInfo()
        {
            SubscriptionAttributes = new Dictionary<string, string>();
            UserProfileAttributes = new Dictionary<string, string>();
            OrganizationProfileAttributes = new Dictionary<string, string>();
        }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public TKey SubscriptionPlanId { get; set; }
        public bool StartWithTrial { get; set; }
        public TNullableKey BillingCycleOptionId { get; set; }
        public string OrganizationName { get; set; }
        public DaOrganizationType OrganizationType { get; set; }
        public DaTenantType TenantType { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public TKey CountryId { get; set; }
        public string PhoneNumber { get; set; }
        public string AreaCode { get; set; }
        public string Extension { get; set; }
        public string FaxNumber { get; set; }
        public Dictionary<string, string> SubscriptionAttributes { get; set; }
        public Dictionary<string, string> UserProfileAttributes { get; set; }
        public Dictionary<string, string> OrganizationProfileAttributes { get; set; }
    }
}
