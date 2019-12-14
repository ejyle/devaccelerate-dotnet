// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Ejyle.DevAccelerate.EnterpriseSecurity.Tenants;
using Ejyle.DevAccelerate.Profiles.Organizations;

namespace Ejyle.DevAccelerate.Facades.Security.Subscriptions
{
    public class DaSubscriptionInfo : DaSubscriptionInfo<int, int?>
    { }

    public class DaSubscriptionInfo<TKey, TNullableKey> : IDaSubscriptionInfo<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
    {
        public DaSubscriptionInfo()
        {
            UserProfileAttributes = new Dictionary<string, string>();
            OrganizationProfileAttributes = new Dictionary<string, string>();
        }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public TKey SubscriptionPlanId { get; set; }
        public TKey BillingCycleId { get; set; }
        public string OrganizationName { get; set; }
        public DaOrganizationType OrganizationType { get; set; }
        public DaTenantType TenantType { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public TNullableKey CountryId { get; set; }
        public string PhoneNumber { get; set; }
        public string AreaCode { get; set; }
        public string Extension { get; set; }
        public string FaxNumber { get; set; }
        public Dictionary<string, string> SubscriptionAttributes { get; set; }
        public Dictionary<string, string> UserProfileAttributes { get; set; }
        public Dictionary<string, string> OrganizationProfileAttributes { get; set; }
    }
}
