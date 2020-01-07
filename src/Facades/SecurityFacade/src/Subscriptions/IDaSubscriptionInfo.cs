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
    public interface IDaSubscriptionInfo<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
    {
        string UserName { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        TKey SubscriptionPlanId { get; set; }
        TNullableKey BillingCycleOptionId { get; set; }
        bool StartWithTrial { get; set; }
        string OrganizationName { get; set; }
        DaOrganizationType OrganizationType { get; set; }
        DaTenantType TenantType { get; set; }
        string Address1 { get; set; }
        string Address2 { get; set; }
        string ZipCode { get; set; }
        string State { get; set; }
        TNullableKey CountryId { get; set; }
        string PhoneNumber { get; set; }
        string AreaCode { get; set; }
        string Extension { get; set; }
        string FaxNumber { get; set; }
        Dictionary<string, string> SubscriptionAttributes { get; set; }
        Dictionary<string, string> UserProfileAttributes { get; set; }
        Dictionary<string, string> OrganizationProfileAttributes { get; set; }
    }
}
