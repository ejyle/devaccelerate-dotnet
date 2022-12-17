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
    public interface IDaRegistrationInfo<TKey,
        TAddressProfileRegistrationInfo,
        TOrganizationRegistrationInfo,
        TTenantRegistrationInfo,
        TSubscriptionRegistrationInfo>
        where TKey:IEquatable<TKey>
        where TAddressProfileRegistrationInfo : IDaAddressRegistrationInfo<TKey>
        where TTenantRegistrationInfo : IDaTenantRegistrationInfo
        where TOrganizationRegistrationInfo : IDaOrganizationRegistrationInfo
        where TSubscriptionRegistrationInfo : IDaSubscriptionRegistrationInfo<TKey>
    {
        string UserName { get; set; }
        string Roles { get; set; }
        string Salutation { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string JobTitle { get; set; }
        DateTime? Dob { get; set; }
        DaGender? Gender { get; set; }
        string UserPhoneNumber { get; set; }
        Dictionary<string, string> UserProfileAttributes { get; set; }
        TAddressProfileRegistrationInfo Address { get; set; }
        TOrganizationRegistrationInfo Organization { get; set; }
        TTenantRegistrationInfo Tenant { get; set; }
        TSubscriptionRegistrationInfo Subscription { get; set; }
    }

    public interface IDaAddressRegistrationInfo<TKey>
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

    public interface IDaTenantRegistrationInfo
    {
        DaTenantType TenantType { get; set; }
        Dictionary<string, string> TenantAttributes { get; set; }
    }

    public interface IDaOrganizationRegistrationInfo
    {
        string OrganizationName { get; set; }
        DaOrganizationType OrganizationType { get; set; }
        Dictionary<string, string> OrganizationProfileAttributes { get; set; }
    }

    public interface IDaSubscriptionRegistrationInfo<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey SubscriptionPlanId { get; set; }
        bool StartWithTrial { get; set; }
        TKey BillingCycleOptionId { get; set; }
        Dictionary<string, string> SubscriptionAttributes { get; set; }
    }
}
