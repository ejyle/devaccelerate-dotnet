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
using Ejyle.DevAccelerate.Profiles.UserProfiles;

namespace Ejyle.DevAccelerate.Facades.Security.Registration
{
    public class DaRegistrationInfo
        : DaRegistrationInfo<int, int?, DaAddressRegistrationInfo,DaOrganizationRegistrationInfo, DaTenantRegistrationInfo, DaSubscriptionRegistrationInfo>
    {
        public DaRegistrationInfo()
            : base()
        { }
    }

    public class DaRegistrationInfo<TKey,
        TNullableKey,
        TAddressProfileRegistrationInfo,
        TOrganizationRegistrationInfo,
        TTenantRegistrationInfo,
        TSubscriptionRegistrationInfo>
        where TKey : IEquatable<TKey>
        where TAddressProfileRegistrationInfo : IDaAddressRegistrationInfo<TKey>
        where TTenantRegistrationInfo : IDaTenantRegistrationInfo
        where TOrganizationRegistrationInfo : IDaOrganizationRegistrationInfo
        where TSubscriptionRegistrationInfo : IDaSubscriptionRegistrationInfo<TKey, TNullableKey>
    {
        public DaRegistrationInfo()
        {
            UserProfileAttributes = new Dictionary<string, string>();
        }

        public string UserName { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public DateTime? Dob { get; set; }
        public DaGender? Gender { get; set; }
        public string UserPhoneNumber { get; set; }
        public Dictionary<string, string> UserProfileAttributes { get; set; }
        public TAddressProfileRegistrationInfo Address { get; set; }
        public TOrganizationRegistrationInfo Organization { get; set; }
        public TTenantRegistrationInfo Tenant { get; set; }
        public TSubscriptionRegistrationInfo Subscription { get; set; }
    }

    public class DaAddressRegistrationInfo : DaAddressRegistrationInfo<int>
    { }

    public class DaAddressRegistrationInfo<TKey> : IDaAddressRegistrationInfo<TKey>
        where TKey : IEquatable<TKey>
    {
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
    }

    public class DaTenantRegistrationInfo : IDaTenantRegistrationInfo
    {
        public DaTenantRegistrationInfo()
        {
            TenantAttributes = new Dictionary<string, string>();
        }

        public DaTenantType TenantType { get; set; }
        public Dictionary<string, string> TenantAttributes { get; set; }
    }

    public class DaOrganizationRegistrationInfo : IDaOrganizationRegistrationInfo
    {
        public DaOrganizationRegistrationInfo()
        {
            OrganizationProfileAttributes = new Dictionary<string, string>();
        }

        public string OrganizationName { get; set; }
        public DaOrganizationType OrganizationType { get; set; }
        public Dictionary<string, string> OrganizationProfileAttributes { get; set; }
    }

    public class DaSubscriptionRegistrationInfo
        : DaSubscriptionRegistrationInfo<int, int?>
    {
        public DaSubscriptionRegistrationInfo()
            : base()
        { }
    }

    public class DaSubscriptionRegistrationInfo<TKey, TNullableKey>
        : IDaSubscriptionRegistrationInfo<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
    {
        public DaSubscriptionRegistrationInfo()
        {
            SubscriptionAttributes = new Dictionary<string, string>();
        }

        public TKey SubscriptionPlanId { get; set; }
        public bool StartWithTrial { get; set; }
        public TNullableKey BillingCycleOptionId { get; set; }
        public Dictionary<string, string> SubscriptionAttributes { get; set; }
    }
}
