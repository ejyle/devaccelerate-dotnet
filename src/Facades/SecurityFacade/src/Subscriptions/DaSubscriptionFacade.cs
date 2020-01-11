// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Identity;
using Ejyle.DevAccelerate.Identity.EF;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF.Tenants;
using Ejyle.DevAccelerate.EnterpriseSecurity.Tenants;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF.SubscriptionPlans;
using Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF.Subscriptions;
using Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions;
using Ejyle.DevAccelerate.EnterpriseSecurity.Apps;
using Ejyle.DevAccelerate.EnterpriseSecurity.UserAgreements;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF;
using Ejyle.DevAccelerate.List.EF.Culture;
using Ejyle.DevAccelerate.List.Culture;
using Ejyle.DevAccelerate.List.EF;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF.Apps;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF.UserAgreements;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Profiles.EF.UserProfiles;
using Ejyle.DevAccelerate.Profiles.UserProfiles;
using Ejyle.DevAccelerate.Profiles.EF.Organizations;
using Ejyle.DevAccelerate.Profiles.Organizations;
using Ejyle.DevAccelerate.Profiles.EF;
using Ejyle.DevAccelerate.Profiles.Addresses;
using Ejyle.DevAccelerate.Profiles.EF.Addresses;
using Ejyle.DevAccelerate.Facades.Security.Properties;
using Ejyle.DevAccelerate.EnterpriseSecurity;
using System.Collections.Specialized;

namespace Ejyle.DevAccelerate.Facades.Security.Subscriptions
{
    public class DaSubscriptionFacade : DaSubscriptionFacade<DaSubscriptionInfo, DaUserManager, DaUser, DaUserLogin, DaUserRole, DaUserClaim, DaUserProfileManager, DaUserProfile, DaUserProfileAttribute, DaOrganizationProfileManager, DaOrganizationProfile, DaOrganizationProfileAttribute, DaTenantManager, DaTenant, DaTenantUser, DaAddressProfileManager, DaAddressProfile, DaUserAddress, DaUserAgreementManager, DaUserAgreement, DaUserAgreementVersion, DaUserAgreementVersionAction, DaAppManager, DaApp, DaAppAttribute, DaFeatureManager, DaFeature, DaAppFeature, DaFeatureAction, DaSubscriptionPlanManager, DaSubscriptionPlan, DaSubscriptionPlanAttribute, DaBillingCycleOption, DaSubscriptionPlanApp, DaSubscriptionPlanFeature, DaSubscriptionPlanFeatureAttribute, DaSubscriptionManager, DaSubscription, DaSubscriptionAttribute, DaSubscriptionApp, DaSubscriptionFeature, DaSubscriptionFeatureAttribute, DaSubscriptionAppRole, DaSubscriptionAppUser, DaSubscriptionFeatureRole, DaSubscriptionFeatureRoleAction, DaSubscriptionFeatureUser, DaSubscriptionFeatureUserAction, DaBillingCycle, DaBillingCycleAttribute, DaBillingCycleFeatureUsage, DaCurrencyManager, DaCurrency, DaCountryManager, DaCountry, DaCountryRegion, DaTimeZoneManager, DaTimeZone, DaSystemLanguageManager, DaSystemLanguage>
    {
        public DaSubscriptionFacade(IOwinContext owinContext)
            : base(owinContext.Get<DaUserManager>(),
                  new DaUserProfileManager(new DaUserProfileRepository(owinContext.Get<DaProfilesDbContext>())),
                  new DaOrganizationProfileManager(new DaOrganizationProfileRepository(owinContext.Get<DaProfilesDbContext>())),
                  new DaTenantManager(new DaTenantRepository(owinContext.Get<DaEnterpriseSecurityDbContext>())),
                  new DaAddressProfileManager(new DaAddressProfileRepository(owinContext.Get<DaProfilesDbContext>())),
                  new DaAppManager(new DaAppRepository(owinContext.Get<DaEnterpriseSecurityDbContext>())),
                  new DaFeatureManager(new DaFeatureRepository(owinContext.Get<DaEnterpriseSecurityDbContext>())),
                  new DaUserAgreementManager(new DaUserAgreementRepository(owinContext.Get<DaEnterpriseSecurityDbContext>())),
                  new DaSubscriptionPlanManager(new DaSubscriptionPlanRepository(owinContext.Get<DaEnterpriseSecurityDbContext>())),
                  new DaSubscriptionManager(new DaSubscriptionRepository(owinContext.Get<DaEnterpriseSecurityDbContext>())),
                  new DaCurrencyManager(new DaCurrencyRepository(owinContext.Get<DaListsDbContext>())),
                  new DaCountryManager(new DaCountryRepository(owinContext.Get<DaListsDbContext>())),
                  new DaTimeZoneManager(new DaTimeZoneRepository(owinContext.Get<DaListsDbContext>())),
                  new DaSystemLanguageManager(new DaSystemLanguageRepository(owinContext.Get<DaListsDbContext>())))
        {
        }

        public DaSubscriptionFacade(DaUserManager userManager, DaUserProfileManager userProfileManager, DaOrganizationProfileManager organizationProfileManager,  DaTenantManager tenantManager, DaAddressProfileManager addressProfileManager,  DaAppManager appManager, DaFeatureManager featureManager, DaUserAgreementManager userAgreementManager, DaSubscriptionPlanManager subscriptionPlanManager, DaSubscriptionManager subscriptionManager, DaCurrencyManager currencyManager, DaCountryManager countryManager, DaTimeZoneManager timeZoneManager, DaSystemLanguageManager systemLanguageManager)
            : base(userManager, userProfileManager, organizationProfileManager, tenantManager, addressProfileManager, appManager, featureManager, userAgreementManager, subscriptionPlanManager, subscriptionManager, currencyManager, countryManager, timeZoneManager, systemLanguageManager)
        {
        }
    }

    public class DaSubscriptionFacade<TSubscriptionInfo, TUserManager, TUser, TUserLogin, TUserRole, TUserClaim, TUserProfileManager, TUserProfile, TUserProfileAttribute, TOrganizationProfileManager, TOrganizationProfile, TOrganizationProfileAttribute, TTenantManager, TTenant, TTenantUser, TAddressProfileManager, TAddressProfile, TUserAddress, TUserAgreementManager, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction, TAppManager, TApp, TAppAttribute, TFeatureManager, TFeature, TAppFeature, TFeatureAction, TSubscriptionPlanManager, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscriptionManager, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TBillingCycleFeatureUsage, TCurrencyManager, TCurrency, TCountryManager, TCountry, TCountryRegion, TTimeZoneManager, TTimeZone, TSystemLanguageManager, TSystemLanguage> 
        : DaSubscriptionFacade<int, int?, TSubscriptionInfo, TUserManager, TUser, TUserLogin, TUserRole, TUserClaim, TUserProfileManager, TUserProfile, TUserProfileAttribute, TOrganizationProfileManager, TOrganizationProfile, TOrganizationProfileAttribute, TTenantManager, TTenant, TTenantUser, TAddressProfileManager, TAddressProfile, TUserAddress, TUserAgreementManager, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction, TAppManager, TApp, TAppAttribute, TFeatureManager, TFeature, TAppFeature, TFeatureAction, TSubscriptionPlanManager, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscriptionManager, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TBillingCycleFeatureUsage, TCurrencyManager, TCurrency, TCountryManager, TCountry, TCountryRegion, TTimeZoneManager, TTimeZone, TSystemLanguageManager, TSystemLanguage>
        where TSubscriptionInfo : IDaSubscriptionInfo<int, int?>
        where TUserManager : DaUserManager<int, int?, TUser>
        where TUser : DaUser<int, int?, TUserLogin, TUserRole, TUserClaim>, new()
        where TUserLogin : DaUserLogin<int>
        where TUserRole : DaUserRole<int>
        where TUserClaim : DaUserClaim<int>
        where TUserProfile : DaUserProfile<int, TUserProfileAttribute>, new()
        where TUserProfileAttribute : DaUserProfileAttribute<int, TUserProfile>, new()
        where TUserProfileManager : DaUserProfileManager<int, TUserProfile>
        where TOrganizationProfile : DaOrganizationProfile<int, int?, TOrganizationProfileAttribute>, new()
        where TOrganizationProfileAttribute : DaOrganizationProfileAttribute<int, int?, TOrganizationProfile>, new()
        where TOrganizationProfileManager : DaOrganizationProfileManager<int, int?, TOrganizationProfile>
        where TAddressProfileManager : DaAddressProfileManager<int, int?, TAddressProfile>
        where TAddressProfile : DaAddressProfile<int, int?, TUserAddress>, new()
        where TUserAddress : DaUserAddress<int, int?, TAddressProfile>, new()
        where TAppManager : DaAppManager<int, TApp>
        where TApp : DaApp<int, int?, TAppAttribute, TFeature, TAppFeature, TSubscriptionApp, TSubscriptionPlanApp, TUserAgreement>
        where TAppAttribute : DaAppAttribute<int, TApp>
        where TAppFeature : DaAppFeature<int, TApp, TFeature>
        where TBillingCycleOption : DaBillingCycleOption<int, int?, TSubscriptionPlan>
        where TFeatureAction : DaFeatureAction<int, int?, TFeature>
        where TFeatureManager : DaFeatureManager<int, int?, TFeature>
        where TFeature : DaFeature<int, int?, TApp, TAppFeature, TFeatureAction, TSubscriptionFeature, TSubscriptionPlanFeature>
        where TSubscriptionManager : DaSubscriptionManager<int, int?, TSubscription>
        where TSubscriptionAppRole : DaSubscriptionAppRole<int, TSubscriptionApp>
        where TSubscriptionApp : DaSubscriptionApp<int, int?, TApp, TSubscriptionAppRole, TSubscription, TSubscriptionAppUser>, new()
        where TSubscriptionAppUser : DaSubscriptionAppUser<int, TSubscriptionApp>
        where TSubscriptionFeatureAttribute : DaSubscriptionFeatureAttribute<int, TSubscriptionFeature>, new()
        where TSubscriptionFeatureRoleAction : DaSubscriptionFeatureRoleAction<int, TSubscriptionFeatureRole>
        where TSubscriptionFeatureRole : DaSubscriptionFeatureRole<int, TSubscriptionFeatureRoleAction, TSubscriptionFeature>
        where TSubscriptionFeature : DaSubscriptionFeature<int, int?, TFeature, TSubscriptionFeatureAttribute, TSubscriptionFeatureRole, TSubscription, TSubscriptionFeatureUser, TBillingCycleFeatureUsage>, new()
        where TSubscriptionFeatureUserAction : DaSubscriptionFeatureUserAction<int, TSubscriptionFeatureUser>
        where TSubscriptionFeatureUser : DaSubscriptionFeatureUser<int, int?, TSubscriptionFeature, TSubscriptionFeatureUserAction>
        where TSubscriptionPlanManager : DaSubscriptionPlanManager<int, int?, TSubscriptionPlan>
        where TSubscriptionPlanApp : DaSubscriptionPlanApp<int, int?, TApp, TSubscriptionPlan>
        where TSubscriptionPlanFeatureAttribute : DaSubscriptionPlanFeatureAttribute<int, TSubscriptionPlanFeature>
        where TSubscriptionPlanFeature : DaSubscriptionPlanFeature<int, int?, TFeature, TSubscriptionPlanFeatureAttribute, TSubscriptionPlan>
        where TSubscriptionPlan : DaSubscriptionPlan<int, int?, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscription>
        where TSubscriptionPlanAttribute : DaSubscriptionPlanAttribute<int, int?, TSubscriptionPlan>
        where TSubscription : DaSubscription<int, int?, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionPlan, TBillingCycle>, new()
        where TBillingCycle : DaBillingCycle<int, int?, TBillingCycleAttribute, TSubscription, TBillingCycleFeatureUsage>, new()
        where TBillingCycleAttribute : DaBillingCycleAttribute<int, int?, TBillingCycle>, new()
        where TBillingCycleFeatureUsage : DaBillingCycleFeatureUsage<int, int?, TBillingCycle, TSubscriptionFeature>, new()
        where TSubscriptionAttribute : DaSubscriptionAttribute<int, int?, TSubscription>, new()
        where TTenantManager : DaTenantManager<int, int?, TTenant>
        where TTenant : DaTenant<int, int?, TTenantUser>, new()
        where TTenantUser : DaTenantUser<int, int?, TTenant>, new()
        where TUserAgreementManager : DaUserAgreementManager<int, int?, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction>
        where TUserAgreement : DaUserAgreement<int, int?, TApp, TUserAgreementVersion>
        where TUserAgreementVersion : DaUserAgreementVersion<int, int?, TUserAgreement, TUserAgreementVersionAction>
        where TUserAgreementVersionAction : DaUserAgreementVersionAction<int, TUserAgreementVersion>
        where TCurrencyManager : DaCurrencyManager<int, TCurrency>
        where TCurrency : DaCurrency<int, int?, TCountry>
        where TCountryManager : DaCountryManager<int, int?, TCountry, TCountryRegion>
        where TCountry : DaCountry<int, int?, TCurrency, TTimeZone, TCountryRegion, TSystemLanguage>
        where TCountryRegion : DaCountryRegion<int, int?, TCountryRegion, TCountry>
        where TTimeZoneManager : DaTimeZoneManager<int, int?, TTimeZone>
        where TTimeZone : DaTimeZone<int, int?, TCountry>
        where TSystemLanguageManager : DaSystemLanguageManager<int, TSystemLanguage>
        where TSystemLanguage : DaSystemLanguage<int, int?, TCountry>
    {
        public DaSubscriptionFacade(TUserManager userManager, TUserProfileManager userProfileManager, TOrganizationProfileManager organizationProfileManager, TTenantManager tenantManager, TAddressProfileManager addressProfileManager, TAppManager appManager, TFeatureManager featureManager, TUserAgreementManager userAgreementManager, TSubscriptionPlanManager subscriptionPlanManager, TSubscriptionManager subscriptionManager, TCurrencyManager currencyManager, TCountryManager countryManager, TTimeZoneManager timeZoneManager, TSystemLanguageManager systemLanguageManager)
            : base(userManager, userProfileManager, organizationProfileManager, tenantManager, addressProfileManager, appManager, featureManager, userAgreementManager, subscriptionPlanManager, subscriptionManager, currencyManager, countryManager, timeZoneManager, systemLanguageManager)
        {
        }
    }

    public class DaSubscriptionFacade<TKey, TNullableKey, TSubscriptionInfo, TUserManager, TUser, TUserLogin, TUserRole, TUserClaim, TUserProfileManager, TUserProfile, TUserProfileAttribute, TOrganizationProfileManager, TOrganizationProfile, TOrganizationProfileAttribute, TTenantManager, TTenant, TTenantUser, TAddressProfileManager, TAddressProfile, TUserAddress, TUserAgreementManager, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction, TAppManager, TApp, TAppAttribute, TFeatureManager, TFeature, TAppFeature, TFeatureAction, TSubscriptionPlanManager, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscriptionManager, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TBillingCycleFeatureUsage, TCurrencyManager, TCurrency, TCountryManager, TCountry, TCountryRegion, TTimeZoneManager, TTimeZone, TSystemLanguageManager, TSystemLanguage>
        where TKey : IEquatable<TKey>
        where TSubscriptionInfo : IDaSubscriptionInfo<TKey, TNullableKey>
        where TUserManager : DaUserManager<TKey, TNullableKey, TUser>
        where TUser : DaUser<TKey, TNullableKey, TUserLogin, TUserRole, TUserClaim>, new()
        where TUserLogin : DaUserLogin<TKey>
        where TUserRole : DaUserRole<TKey>
        where TUserClaim : DaUserClaim<TKey>
        where TUserProfile : DaUserProfile<TKey, TUserProfileAttribute>, new()
        where TUserProfileAttribute : DaUserProfileAttribute<TKey, TUserProfile>, new()
        where TUserProfileManager : DaUserProfileManager<TKey, TUserProfile>
        where TOrganizationProfile : DaOrganizationProfile<TKey, TNullableKey, TOrganizationProfileAttribute>, new()
        where TOrganizationProfileAttribute : DaOrganizationProfileAttribute<TKey, TNullableKey, TOrganizationProfile>, new()
        where TOrganizationProfileManager : DaOrganizationProfileManager<TKey, TNullableKey, TOrganizationProfile>
        where TAddressProfileManager : DaAddressProfileManager<TKey, TNullableKey, TAddressProfile>
        where TAddressProfile : DaAddressProfile<TKey, TNullableKey, TUserAddress>, new()
        where TUserAddress : DaUserAddress<TKey, TNullableKey, TAddressProfile>, new()
        where TAppManager : DaAppManager<TKey, TApp>
        where TApp : DaApp<TKey, TNullableKey, TAppAttribute, TFeature, TAppFeature, TSubscriptionApp, TSubscriptionPlanApp, TUserAgreement>
        where TAppAttribute : DaAppAttribute<TKey, TApp>
        where TAppFeature : DaAppFeature<TKey, TApp, TFeature>
        where TBillingCycleOption : DaBillingCycleOption<TKey, TNullableKey, TSubscriptionPlan>
        where TFeatureAction : DaFeatureAction<TKey, TNullableKey, TFeature>
        where TFeatureManager : DaFeatureManager<TKey, TNullableKey, TFeature>
        where TFeature : DaFeature<TKey, TNullableKey, TApp, TAppFeature, TFeatureAction, TSubscriptionFeature, TSubscriptionPlanFeature>
        where TSubscriptionManager : DaSubscriptionManager<TKey, TNullableKey, TSubscription>
        where TSubscriptionAppRole : DaSubscriptionAppRole<TKey, TSubscriptionApp>
        where TSubscriptionApp : DaSubscriptionApp<TKey, TNullableKey, TApp, TSubscriptionAppRole, TSubscription, TSubscriptionAppUser>, new()
        where TSubscriptionAppUser : DaSubscriptionAppUser<TKey, TSubscriptionApp>
        where TSubscriptionFeatureAttribute : DaSubscriptionFeatureAttribute<TKey, TSubscriptionFeature>, new()
        where TSubscriptionFeatureRoleAction : DaSubscriptionFeatureRoleAction<TKey, TSubscriptionFeatureRole>
        where TSubscriptionFeatureRole : DaSubscriptionFeatureRole<TKey, TSubscriptionFeatureRoleAction, TSubscriptionFeature>
        where TSubscriptionFeature : DaSubscriptionFeature<TKey, TNullableKey, TFeature, TSubscriptionFeatureAttribute, TSubscriptionFeatureRole, TSubscription, TSubscriptionFeatureUser, TBillingCycleFeatureUsage>, new()
        where TSubscriptionFeatureUserAction : DaSubscriptionFeatureUserAction<TKey, TSubscriptionFeatureUser>
        where TSubscriptionFeatureUser : DaSubscriptionFeatureUser<TKey, TNullableKey, TSubscriptionFeature, TSubscriptionFeatureUserAction>
        where TSubscriptionPlanManager : DaSubscriptionPlanManager<TKey, TNullableKey, TSubscriptionPlan>
        where TSubscriptionPlanApp : DaSubscriptionPlanApp<TKey, TNullableKey, TApp, TSubscriptionPlan>
        where TSubscriptionPlanFeatureAttribute : DaSubscriptionPlanFeatureAttribute<TKey, TSubscriptionPlanFeature>
        where TSubscriptionPlanFeature : DaSubscriptionPlanFeature<TKey, TNullableKey, TFeature, TSubscriptionPlanFeatureAttribute, TSubscriptionPlan>
        where TSubscriptionPlan : DaSubscriptionPlan<TKey, TNullableKey, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscription>
        where TSubscriptionPlanAttribute : DaSubscriptionPlanAttribute<TKey, TNullableKey, TSubscriptionPlan>
        where TSubscription : DaSubscription<TKey, TNullableKey, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionPlan, TBillingCycle>, new()
        where TBillingCycle : DaBillingCycle<TKey, TNullableKey, TBillingCycleAttribute, TSubscription, TBillingCycleFeatureUsage>, new()
        where TBillingCycleAttribute : DaBillingCycleAttribute<TKey, TNullableKey, TBillingCycle>, new()
        where TBillingCycleFeatureUsage : DaBillingCycleFeatureUsage<TKey, TNullableKey, TBillingCycle, TSubscriptionFeature>, new()
        where TSubscriptionAttribute : DaSubscriptionAttribute<TKey, TNullableKey, TSubscription>, new()
        where TTenantManager : DaTenantManager<TKey, TNullableKey, TTenant>
        where TTenant : DaTenant<TKey, TNullableKey, TTenantUser>, new()
        where TTenantUser : DaTenantUser<TKey, TNullableKey, TTenant>, new()
        where TUserAgreementManager : DaUserAgreementManager<TKey, TNullableKey, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction>
        where TUserAgreement : DaUserAgreement<TKey, TNullableKey, TApp, TUserAgreementVersion>
        where TUserAgreementVersion : DaUserAgreementVersion<TKey, TNullableKey, TUserAgreement, TUserAgreementVersionAction>
        where TUserAgreementVersionAction : DaUserAgreementVersionAction<TKey, TUserAgreementVersion>
        where TCurrencyManager : DaCurrencyManager<TKey, TCurrency>
        where TCurrency : DaCurrency<TKey, TNullableKey, TCountry>
        where TCountryManager : DaCountryManager<TKey, TNullableKey, TCountry, TCountryRegion>
        where TCountry : DaCountry<TKey, TNullableKey, TCurrency, TTimeZone, TCountryRegion, TSystemLanguage>
        where TCountryRegion : DaCountryRegion<TKey, TNullableKey, TCountryRegion, TCountry>
        where TTimeZoneManager : DaTimeZoneManager<TKey, TNullableKey, TTimeZone>
        where TTimeZone : DaTimeZone<TKey, TNullableKey, TCountry>
        where TSystemLanguageManager : DaSystemLanguageManager<TKey, TSystemLanguage>
        where TSystemLanguage : DaSystemLanguage<TKey, TNullableKey, TCountry>
    {
        public DaSubscriptionFacade(TUserManager userManager, TUserProfileManager userProfileManager, TOrganizationProfileManager organizationProfileManager, TTenantManager tenantManager, TAddressProfileManager addressProfileManager, TAppManager appManager, TFeatureManager featureManager, TUserAgreementManager userAgreementManager, TSubscriptionPlanManager subscriptionPlanManager, TSubscriptionManager subscriptionManager, TCurrencyManager currencyManager, TCountryManager countryManager, TTimeZoneManager timeZoneManager, TSystemLanguageManager systemLanguageManager)
        {
            UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            UserProfileManager = userProfileManager ?? throw new ArgumentNullException(nameof(userProfileManager));
            OrganizationProfileManager = organizationProfileManager ?? throw new ArgumentNullException(nameof(organizationProfileManager));
            AddressProfileManager = addressProfileManager ?? throw new ArgumentNullException(nameof(addressProfileManager));
            TenantManager = tenantManager ?? throw new ArgumentNullException(nameof(tenantManager));
            AppManager = appManager ?? throw new ArgumentNullException(nameof(appManager));
            FeatureManager = featureManager ?? throw new ArgumentNullException(nameof(featureManager));
            UserAgreementManager = userAgreementManager ?? throw new ArgumentNullException(nameof(userAgreementManager));
            SubscriptionManager = subscriptionManager ?? throw new ArgumentNullException(nameof(subscriptionManager));
            SubscriptionPlanManager = subscriptionPlanManager ?? throw new ArgumentNullException(nameof(subscriptionPlanManager));
            CurrencyManager = currencyManager ?? throw new ArgumentNullException(nameof(currencyManager));
            CountryManager = countryManager ?? throw new ArgumentNullException(nameof(countryManager));
            TimeZoneManager = timeZoneManager ?? throw new ArgumentNullException(nameof(timeZoneManager));
            SystemLanguageManager = systemLanguageManager ?? throw new ArgumentNullException(nameof(systemLanguageManager));
        }

        public TSubscriptionManager SubscriptionManager
        {
            get;
            private set;
        }

        public TUserManager UserManager
        {
            get;
            private set;
        }

        public TTenantManager TenantManager
        {
            get;
            private set;
        }

        public TUserProfileManager UserProfileManager
        {
            get;
            private set;
        }

        public TOrganizationProfileManager OrganizationProfileManager
        {
            get;
            private set;
        }

        public TAddressProfileManager AddressProfileManager
        {
            get;
            private set;
        }

        public TAppManager AppManager
        {
            get;
            private set;
        }

        public TFeatureManager FeatureManager
        {
            get;
            private set;
        }

        public TUserAgreementManager UserAgreementManager
        {
            get;
            private set;
        }

        public TSubscriptionPlanManager SubscriptionPlanManager
        {
            get;
            private set;
        }

        public TCurrencyManager CurrencyManager
        {
            get;
            private set;
        }

        public TCountryManager CountryManager
        {
            get;
            private set;
        }

        public TTimeZoneManager TimeZoneManager
        {
            get;
            private set;
        }

        public TSystemLanguageManager SystemLanguageManager
        {
            get;
            private set;
        }

        public List<TSubscription> GetSubscriptions(TKey userId, TKey tenantId)
        {
            return DaAsyncHelper.RunSync<List<TSubscription>>(() => GetSubscriptionsAsync(userId, tenantId));
        }

        public virtual async Task<List<TSubscription>> GetSubscriptionsAsync(TKey userId, TKey tenantId)
        {
            var user = await UserManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new InvalidOperationException("Invalid user ID.");
            }

            var tenant = await TenantManager.FindByIdAsync(tenantId);

            if (tenant == null)
            {
                throw new InvalidOperationException("Invalid tenant ID.");
            }

            var associated = await TenantManager.CheckTenantUserActiveAssociationAsync(tenantId, userId);

            if (!associated)
            {
                throw new InvalidOperationException("The tenant and user are not associated at all or the association is not active.");
            }

            return await SubscriptionManager.FindByTenantIdAsync(tenantId);
        }

        public DaRegistrationResult<TKey> Subscribe(TSubscriptionInfo subscriptionInfo, string password)
        {
            return DaAsyncHelper.RunSync<DaRegistrationResult<TKey>>(() => SubscribeAsync(subscriptionInfo, password));
        }

        public virtual async Task<DaRegistrationResult<TKey>> SubscribeAsync(TSubscriptionInfo subscriptionInfo, string password)
        {
            if(subscriptionInfo == null)
            {
                throw new ArgumentNullException(nameof(subscriptionInfo));
            }

            var subscriptionPlan = await SubscriptionPlanManager.FindByIdAsync(subscriptionInfo.SubscriptionPlanId);

            if (subscriptionPlan == null)
            {
                throw new InvalidOperationException(Resources.InvalidSubscriptionPlan);
            }

            if (string.IsNullOrEmpty(subscriptionInfo.UserName))
            {
                return new DaRegistrationResult<TKey>(DaRegistrationStatus.InvalidUserName, null);
            }

            if (string.IsNullOrEmpty(subscriptionInfo.Email))
            {
                return new DaRegistrationResult<TKey>(DaRegistrationStatus.InvalidEmail, null);
            }

            var user = await UserManager.FindByNameAsync(subscriptionInfo.UserName);

            if(user != null)
            {
                return new DaRegistrationResult<TKey>(DaRegistrationStatus.DuplicateUserName, null);
            }

            user = await UserManager.FindByEmailAsync(subscriptionInfo.Email);

            if (user != null)
            {
                return new DaRegistrationResult<TKey>(DaRegistrationStatus.DuplicateEmail, null);
            }

            user = new TUser
            {
                UserName = subscriptionInfo.UserName,
                Email = subscriptionInfo.Email,
                EmailConfirmed = false,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdatedDateUtc = DateTime.UtcNow
            };

            var result = await UserManager.CreateAsync(user, password);
            
            if(!result.Succeeded)
            {
                return new DaRegistrationResult<TKey>(DaRegistrationStatus.UnknownError, result.Errors);
            }

            var userProfile = new TUserProfile()
            {
                FirstName = subscriptionInfo.FirstName,
                LastName = subscriptionInfo.LastName,
                UserId = user.Id,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdatedDateUtc = DateTime.UtcNow
            };

            if (subscriptionInfo.UserProfileAttributes != null && subscriptionInfo.UserProfileAttributes.Count > 0)
            {
                foreach (var key in subscriptionInfo.UserProfileAttributes.Keys)
                {
                    var attribute = new TUserProfileAttribute()
                    {
                        AttributeName = key,
                        AttributeValue = subscriptionInfo.UserProfileAttributes[key],
                        UserProfileId = userProfile.Id,
                        UserProfile = userProfile,
                        CreatedDateUtc = DateTime.UtcNow,
                        LastUpdatedDateUtc = DateTime.UtcNow
                    };

                    userProfile.Attributes.Add(attribute);
                }
            }

            await UserProfileManager.CreateAsync(userProfile);

            var tenant = new TTenant();

            if (subscriptionInfo.TenantType == DaTenantType.Individual)
            {
                tenant.Name = user.UserName;
            }
            else if (subscriptionInfo.TenantType == DaTenantType.Organization)
            {
                tenant.Name = subscriptionInfo.OrganizationName;
            }

            tenant.OwnerUserId = user.Id;
            tenant.Status = DaTenantStatus.Active;
            tenant.TenantType = DaTenantType.Organization;
            tenant.Domain = null;
            tenant.IsDomainOwnershipVerified = false;
            tenant.FriendlyName = tenant.Name;
            tenant.CountryId = CountryManager.FindAsync().Result.Id;
            tenant.TimeZoneId = TimeZoneManager.FindAsync().Result.Id;
            tenant.SystemLanguageId =SystemLanguageManager.FindAsync().Result.Id;
            tenant.DateFormatId = default(TNullableKey);
            tenant.DateFormatWithDateOnlyId = default(TNullableKey);
            tenant.DateFormatWithTimeOnlyId = default(TNullableKey);
            tenant.CurrencyId = CurrencyManager.FindAsync().Result.Id;
            tenant.CreatedDateUtc = DateTime.UtcNow;
            tenant.CreatedBy = user.Id;

            var tenantUser = new TTenantUser
            {
                Tenant = tenant,
                IsActive = true,
                UserId = user.Id
            };

            tenant.TenantUsers.Add(tenantUser);

            await TenantManager.CreateAsync(tenant);

            if (subscriptionInfo.TenantType == DaTenantType.Organization)
            {
                var organizationProfile = new TOrganizationProfile()
                {
                    OrganizationName = subscriptionInfo.OrganizationName,
                    OrganizationType = subscriptionInfo.OrganizationType,
                    TenantId = tenant.Id,
                    CreatedDateUtc = DateTime.UtcNow,
                    LastUpdatedDateUtc = DateTime.UtcNow
                };

                if (subscriptionInfo.OrganizationProfileAttributes != null && subscriptionInfo.OrganizationProfileAttributes.Count > 0)
                {
                    foreach (var key in subscriptionInfo.OrganizationProfileAttributes.Keys)
                    {
                        var attribute = new TOrganizationProfileAttribute()
                        {
                            AttributeName = key,
                            AttributeValue = subscriptionInfo.OrganizationProfileAttributes[key],
                            OrganizationProfile = organizationProfile,
                            OrganizationProfileId = organizationProfile.Id,
                            CreatedDateUtc = DateTime.UtcNow,
                            LastUpdatedDateUtc = DateTime.UtcNow
                        };

                        organizationProfile.Attributes.Add(attribute);
                    }
                }

                await OrganizationProfileManager.CreateAsync(organizationProfile);
            }

            var addressProfile = new TAddressProfile()
            {
                Address1 = subscriptionInfo.Address1,
                Address2 = subscriptionInfo.Address2,
                PhoneNumber = subscriptionInfo.PhoneNumber,
                ZipCode = subscriptionInfo.ZipCode,
                Extension = subscriptionInfo.Extension,
                State = subscriptionInfo.State,
                FaxNumber = subscriptionInfo.FaxNumber,
                AreaCode = subscriptionInfo.AreaCode,
                City = subscriptionInfo.City,
                CountryId = subscriptionInfo.CountryId,
                OwnerUserId = user.Id,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdatedDateUtc = DateTime.UtcNow
            };

            var billingAddress = new TUserAddress()
            {
                AddressProfile = addressProfile,
                Name = "Billing",
                UserId = user.Id,
                AddressType = DaAddressType.Billing,
                TenantId = tenant.Id,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdatedDateUtc = DateTime.UtcNow,
                AddressProfileId = addressProfile.Id
            };

            addressProfile.UserAddresses.Add(billingAddress);

            await AddressProfileManager.CreateAsync(addressProfile);

            var subscription = new TSubscription
            {
                Name = subscriptionPlan.Name,
                IsCurrentlyInTrial = false,
                OwnerUserId = user.Id,
                SubscriptionPlanId = subscriptionPlan.Id,
                ExpiryDateUtc = DateTime.UtcNow.AddDays(30),
                CountryId = subscriptionInfo.CountryId,
                TenantId = tenant.Id,
                IsAutoRenewUntilCanceled = subscriptionPlan.IsAutoRenewUntilCanceled,
                UserAgreementVersionId = default(TNullableKey),
                CurrencyId = default(TKey),
                CreatedDateUtc = DateTime.UtcNow,
                LastTransactionId = default(TNullableKey),
                LastUpdatedDateUtc = DateTime.UtcNow,
                BillingAmount = 0,
                IsFree = subscriptionPlan.IsFree,
                Level = subscriptionPlan.Level,
                BillingInterval = DaBillingInterval.Monthly,
                StartDateUtc = DateTime.UtcNow,
                TrialStartDateUtc = null
            };

            DateTime subscriptionDate = DateTime.UtcNow;

            if ((subscriptionPlan.AllowTrial && subscriptionPlan.StartOnlyWithTrial) || (subscriptionPlan.AllowTrial && subscriptionInfo.StartWithTrial))
            {
                subscriptionDate.AddDays((double)subscriptionPlan.TrialDays);
                subscription.StartDateUtc = DateTime.UtcNow.AddDays((double)subscriptionPlan.TrialDays);
                subscription.TrialStartDateUtc = DateTime.UtcNow;
            }

            if (subscriptionPlan.ValidityInMonths == null)
            {
                subscription.ExpiryDateUtc = null;
            }
            else
            {
                subscription.ExpiryDateUtc = subscription.StartDateUtc.AddMonths((int)subscriptionPlan.ValidityInMonths);
            }

            TBillingCycleOption billingCycleOption = null;
            
            if(subscriptionInfo.BillingCycleOptionId != null)
            {
                billingCycleOption = subscriptionPlan.BillingCycleOptions.Where(m => m.Id.Equals(subscriptionInfo.BillingCycleOptionId)).SingleOrDefault();
            }
            else
            {
                billingCycleOption = subscriptionPlan.BillingCycleOptions.Where(m => m.Id.Equals(subscriptionPlan.DefaultBillingCycleId)).SingleOrDefault();
            }

            if (billingCycleOption != null)
            {
                var billingCycle = new TBillingCycle()
                {
                    Amount = billingCycleOption.Amount,
                    FromDateUtc = subscription.StartDateUtc,
                    CurrencyId = default(TNullableKey),
                    IsPaid = false,
                    Subscription = subscription,
                    InvoiceId = default(TNullableKey),
                    TransactionId = default(TNullableKey)
                };

                subscription.BillingAmount = billingCycleOption.Amount;
                subscription.BillingInterval = billingCycleOption.BillingInterval;

                if (billingCycleOption.BillingInterval == DaBillingInterval.Monthly)
                {
                    billingCycle.ToDateUtc = billingCycle.FromDateUtc.AddMonths(1);
                }
                else if (billingCycleOption.BillingInterval == DaBillingInterval.Yearly)
                {
                    billingCycle.ToDateUtc = billingCycle.FromDateUtc.AddYears(1);
                }
                else if (billingCycleOption.BillingInterval == DaBillingInterval.Weekly)
                {
                    billingCycle.ToDateUtc = billingCycle.FromDateUtc.AddDays(7);
                }
                else if (billingCycleOption.BillingInterval == DaBillingInterval.Quarterly)
                {
                    billingCycle.ToDateUtc = billingCycle.FromDateUtc.AddMonths(3);
                }

                subscription.BillingCycles.Add(billingCycle);
            }

            if (subscriptionPlan.SubscriptionPlanApps != null && subscriptionPlan.SubscriptionPlanApps.Count > 0)
            {
                subscription.SubscriptionApps = new List<TSubscriptionApp>();

                foreach (var subscriptionPlanApp in subscriptionPlan.SubscriptionPlanApps)
                {
                    var subscriptionApp = new TSubscriptionApp();
                    subscriptionApp.AppId = subscriptionPlanApp.AppId;
                    subscriptionApp.Subscription = subscription;
                    subscriptionApp.CreatedDateUtc = DateTime.UtcNow;

                    subscription.SubscriptionApps.Add(subscriptionApp);
                }
            }

            if (subscriptionPlan.SubscriptionPlanFeatures != null && subscriptionPlan.SubscriptionPlanFeatures.Count > 0)
            {
                subscription.SubscriptionFeatures = new List<TSubscriptionFeature>();

                foreach (var subscriptionPlanFeature in subscriptionPlan.SubscriptionPlanFeatures)
                {
                    var subscriptionFeature = new TSubscriptionFeature();
                    subscriptionFeature.FeatureId = subscriptionPlanFeature.FeatureId;
                    subscriptionFeature.Subscription = subscription;
                    subscriptionFeature.MaximumQuantity = subscriptionPlanFeature.MaximumQuantity;
                    subscriptionFeature.IsPremium = subscriptionPlanFeature.IsPremium;
                    subscriptionFeature.SubscriptionPlanFeatureType = subscriptionPlanFeature.SubscriptionPlanFeatureType;
                    subscriptionFeature.IsActive = true;
                    subscriptionFeature.CreatedDateUtc = DateTime.UtcNow;
                    subscriptionFeature.LastUpdatedDateUtc = DateTime.UtcNow;

                    if(subscriptionFeature.SubscriptionPlanFeatureType == DaSubscriptionPlanFeatureType.MeteredUsage)
                    {
                        if (subscription.BillingCycles != null && subscription.BillingCycles.Count > 0)
                        {
                            var billingCycle = subscription.BillingCycles.FirstOrDefault();
                            var billingCycleFeatureUsage = new TBillingCycleFeatureUsage()
                            {
                                BillingCycleId = billingCycle.Id,
                                Quantity = 0,
                                SubscriptionFeature = subscriptionFeature,
                                CreatedDateUtc = DateTime.UtcNow,
                                LastUpdatedDateUtc = DateTime.UtcNow
                            };

                            subscriptionFeature.FeatureUsage.Add(billingCycleFeatureUsage);
                        }
                    }

                    if (subscriptionPlanFeature.SubscriptionPlanFeatureAttributes != null && subscriptionPlanFeature.SubscriptionPlanFeatureAttributes.Count > 0)
                    {
                        subscriptionFeature.SubscriptionFeatureAttributes = new List<TSubscriptionFeatureAttribute>();

                        foreach (var subscriptionPlanFeatureAttribute in subscriptionPlanFeature.SubscriptionPlanFeatureAttributes)
                        {
                            var subscriptionFeatureAttribute = new TSubscriptionFeatureAttribute();

                            subscriptionFeatureAttribute.AttributeName = subscriptionPlanFeatureAttribute.AttributeName;
                            subscriptionFeatureAttribute.AttributeValue = subscriptionPlanFeatureAttribute.AttributeValue;
                            subscriptionFeatureAttribute.SubscriptionFeature = subscriptionFeature;
                            subscriptionFeatureAttribute.CreatedDateUtc = DateTime.UtcNow;
                            subscriptionFeatureAttribute.LastUpdatedDateUtc = DateTime.UtcNow;

                            subscriptionFeature.SubscriptionFeatureAttributes.Add(subscriptionFeatureAttribute);
                        }
                    }
                    subscription.SubscriptionFeatures.Add(subscriptionFeature);
                }
            }

            if (subscriptionPlan.Attributes != null && subscriptionPlan.Attributes.Count > 0)
            {
                TBillingCycle billingCycle = null;

                if (subscription.BillingCycles != null)
                {
                    billingCycle = subscription.BillingCycles.SingleOrDefault();
                }

                subscription.Attributes = new List<TSubscriptionAttribute>();

                foreach (var subscriptionPlanAttribute in subscriptionPlan.Attributes)
                {
                    if (subscriptionPlanAttribute.Target == DaSubscriptionPlanAttributeTarget.CopyToSubscription || subscriptionPlanAttribute.Target == DaSubscriptionPlanAttributeTarget.CopyToSubscriptionAndBillingCycle)
                    {
                        var attribute = new TSubscriptionAttribute();
                        attribute.AttributeName = subscriptionPlanAttribute.AttributeName;
                        attribute.AttributeValue = subscriptionPlanAttribute.AttributeValue;
                        attribute.Subscription = subscription;
                        attribute.CreatedDateUtc = DateTime.UtcNow;
                        attribute.LastUpdatedDateUtc = DateTime.UtcNow;

                        subscription.Attributes.Add(attribute);
                    }
                    if(billingCycle != null)
                    {
                        if (subscriptionPlanAttribute.Target == DaSubscriptionPlanAttributeTarget.CopyToBillingCycle || subscriptionPlanAttribute.Target == DaSubscriptionPlanAttributeTarget.CopyToSubscriptionAndBillingCycle)
                        {
                            var bcAttribute = new TBillingCycleAttribute();
                            bcAttribute.AttributeName = subscriptionPlanAttribute.AttributeName;
                            bcAttribute.AttributeValue = subscriptionPlanAttribute.AttributeValue;
                            bcAttribute.BillingCycle = billingCycle;
                            bcAttribute.CreatedDateUtc = DateTime.UtcNow;
                            bcAttribute.LastUpdatedDateUtc = DateTime.UtcNow;

                            billingCycle.Attributes.Add(bcAttribute);
                        }
                    }
                }
            }

            if (subscriptionInfo.SubscriptionAttributes != null && subscriptionInfo.SubscriptionAttributes.Count > 0)
            {
                foreach (var key in subscriptionInfo.SubscriptionAttributes.Keys)
                {
                    var attribute = new TSubscriptionAttribute()
                    {
                        AttributeName = key,
                        AttributeValue = subscriptionInfo.SubscriptionAttributes[key],
                        Subscription = subscription,
                        CreatedDateUtc = DateTime.UtcNow,
                        LastUpdatedDateUtc = DateTime.UtcNow
                    };

                    subscription.Attributes.Add(attribute);
                }
            }

            await SubscriptionManager.CreateAsync(subscription);
            return new DaRegistrationResult<TKey>(subscription.Id);
        }

        public virtual DaSubscriptionCreationResult<TKey> Subscribe(TKey subscriptionPlanId, TKey tenantId, TKey userId, TKey billingCycleOptionId, bool startWithTrial, Dictionary<string, string> subscriptionAttributes, bool deactivateAndExpireExistingSubscriptions = true)
        {
            return DaAsyncHelper.RunSync<DaSubscriptionCreationResult<TKey>>(() => SubscribeAsync(subscriptionPlanId, tenantId, userId, billingCycleOptionId, startWithTrial, subscriptionAttributes, deactivateAndExpireExistingSubscriptions));
        }

        public virtual async Task<DaSubscriptionCreationResult<TKey>> SubscribeAsync(TKey subscriptionPlanId, TKey tenantId, TKey userId, TKey billingCycleOptionId, bool startWithTrial, Dictionary<string, string> subscriptionAttributes, bool deactivateAndExpireExistingSubscriptions = true)
        {
            var subscriptionPlan = await SubscriptionPlanManager.FindByIdAsync(subscriptionPlanId);

            if (subscriptionPlan == null)
            {
                throw new ArgumentException("Invalid subscription plan ID.");
            }

            var user = await UserManager.FindByIdAsync(userId);

            if(user == null)
            {
                throw new ArgumentException("Invalid user ID.");
            }

            if(user.Status != DaAccountStatus.Active)
            {
                throw new InvalidOperationException("User must be active before a subscription can be created.");
            }

            var tenant = await TenantManager.FindByIdAsync(tenantId);

            if(tenant == null)
            {
                throw new ArgumentException("Invalid tenant ID.");
            }

            if(tenant.Status == DaTenantStatus.Active)
            {
                throw new InvalidOperationException("Tenant must be active before a subscription can be created.");
            }

            var tenantUser = tenant.TenantUsers.Where(m => m.UserId.Equals(user.Id)).FirstOrDefault();

            if(tenantUser == null)
            {
                throw new InvalidOperationException("The user and tenant are not associated.");
            }

            if(!tenantUser.IsActive)
            {
                throw new InvalidOperationException("The user's tenant association is not active.");
            }

            var existingSubscriptions = await SubscriptionManager.FindByTenantIdAsync(tenant.Id);

            if(existingSubscriptions != null)
            {
                foreach(var existingSubscription in existingSubscriptions)
                {
                    if(existingSubscription.ExpiryDateUtc > DateTime.UtcNow)
                    {
                        existingSubscription.ExpiryDateUtc = DateTime.UtcNow;
                        existingSubscription.IsActive = false;
                        existingSubscription.LastUpdatedDateUtc = DateTime.UtcNow;
                        await SubscriptionManager.UpdateAsync(existingSubscription);
                    }
                }
            }

            var subscription = new TSubscription
            {
                Name = subscriptionPlan.Name,
                IsCurrentlyInTrial = false,
                OwnerUserId = user.Id,
                SubscriptionPlanId = subscriptionPlan.Id,
                ExpiryDateUtc = DateTime.UtcNow.AddDays(30),
                CountryId = default(TKey),
                TenantId = tenant.Id,
                IsAutoRenewUntilCanceled = subscriptionPlan.IsAutoRenewUntilCanceled,
                UserAgreementVersionId = default(TNullableKey),
                CurrencyId = default(TKey),
                CreatedDateUtc = DateTime.UtcNow,
                LastTransactionId = default(TNullableKey),
                LastUpdatedDateUtc = DateTime.UtcNow,
                BillingAmount = 0,
                IsFree = subscriptionPlan.IsFree,
                Level = subscriptionPlan.Level,
                BillingInterval = DaBillingInterval.Monthly,
                StartDateUtc = DateTime.UtcNow,
                TrialStartDateUtc = null
            };

            DateTime subscriptionDate = DateTime.UtcNow;

            if ((subscriptionPlan.AllowTrial && subscriptionPlan.StartOnlyWithTrial) || (subscriptionPlan.AllowTrial && startWithTrial))
            {
                subscriptionDate.AddDays((double)subscriptionPlan.TrialDays);
                subscription.StartDateUtc = DateTime.UtcNow.AddDays((double)subscriptionPlan.TrialDays);
                subscription.TrialStartDateUtc = DateTime.UtcNow;
            }

            if (subscriptionPlan.ValidityInMonths == null)
            {
                subscription.ExpiryDateUtc = null;
            }
            else
            {
                subscription.ExpiryDateUtc = subscription.StartDateUtc.AddMonths((int)subscriptionPlan.ValidityInMonths);
            }

            TBillingCycleOption billingCycleOption = null;
            billingCycleOption = subscriptionPlan.BillingCycleOptions.Where(m => m.Id.Equals(billingCycleOptionId)).SingleOrDefault();

            if (billingCycleOption != null)
            {
                var billingCycle = new TBillingCycle()
                {
                    Amount = billingCycleOption.Amount,
                    FromDateUtc = subscription.StartDateUtc,
                    CurrencyId = default(TNullableKey),
                    IsPaid = false,
                    Subscription = subscription,
                    InvoiceId = default(TNullableKey),
                    TransactionId = default(TNullableKey)
                };

                subscription.BillingAmount = billingCycleOption.Amount;
                subscription.BillingInterval = billingCycleOption.BillingInterval;

                if (billingCycleOption.BillingInterval == DaBillingInterval.Monthly)
                {
                    billingCycle.ToDateUtc = billingCycle.FromDateUtc.AddMonths(1);
                }
                else if (billingCycleOption.BillingInterval == DaBillingInterval.Yearly)
                {
                    billingCycle.ToDateUtc = billingCycle.FromDateUtc.AddYears(1);
                }
                else if (billingCycleOption.BillingInterval == DaBillingInterval.Weekly)
                {
                    billingCycle.ToDateUtc = billingCycle.FromDateUtc.AddDays(7);
                }
                else if (billingCycleOption.BillingInterval == DaBillingInterval.Quarterly)
                {
                    billingCycle.ToDateUtc = billingCycle.FromDateUtc.AddMonths(3);
                }

                subscription.BillingCycles.Add(billingCycle);
            }

            if (subscriptionPlan.SubscriptionPlanApps != null && subscriptionPlan.SubscriptionPlanApps.Count > 0)
            {
                subscription.SubscriptionApps = new List<TSubscriptionApp>();

                foreach (var subscriptionPlanApp in subscriptionPlan.SubscriptionPlanApps)
                {
                    var subscriptionApp = new TSubscriptionApp();
                    subscriptionApp.AppId = subscriptionPlanApp.AppId;
                    subscriptionApp.Subscription = subscription;
                    subscriptionApp.CreatedDateUtc = DateTime.UtcNow;

                    subscription.SubscriptionApps.Add(subscriptionApp);
                }
            }

            if (subscriptionPlan.SubscriptionPlanFeatures != null && subscriptionPlan.SubscriptionPlanFeatures.Count > 0)
            {
                subscription.SubscriptionFeatures = new List<TSubscriptionFeature>();

                foreach (var subscriptionPlanFeature in subscriptionPlan.SubscriptionPlanFeatures)
                {
                    var subscriptionFeature = new TSubscriptionFeature();
                    subscriptionFeature.FeatureId = subscriptionPlanFeature.FeatureId;
                    subscriptionFeature.Subscription = subscription;
                    subscriptionFeature.LastUpdatedDateUtc = DateTime.UtcNow;
                    subscriptionFeature.IsActive = true;

                    if (subscriptionPlanFeature.SubscriptionPlanFeatureAttributes != null && subscriptionPlanFeature.SubscriptionPlanFeatureAttributes.Count > 0)
                    {
                        subscriptionFeature.SubscriptionFeatureAttributes = new List<TSubscriptionFeatureAttribute>();

                        foreach (var subscriptionPlanFeatureAttribute in subscriptionPlanFeature.SubscriptionPlanFeatureAttributes)
                        {
                            var subscriptionFeatureAttribute = new TSubscriptionFeatureAttribute();

                            subscriptionFeatureAttribute.AttributeName = subscriptionPlanFeatureAttribute.AttributeName;
                            subscriptionFeatureAttribute.AttributeValue = subscriptionPlanFeatureAttribute.AttributeValue;
                            subscriptionFeatureAttribute.SubscriptionFeature = subscriptionFeature;
                            subscriptionFeatureAttribute.CreatedDateUtc = DateTime.UtcNow;
                            subscriptionFeatureAttribute.LastUpdatedDateUtc = DateTime.UtcNow;

                            subscriptionFeature.SubscriptionFeatureAttributes.Add(subscriptionFeatureAttribute);
                        }
                    }
                    subscription.SubscriptionFeatures.Add(subscriptionFeature);
                }
            }

            if (subscriptionPlan.Attributes != null && subscriptionPlan.Attributes.Count > 0)
            {
                TBillingCycle billingCycle = null;

                if (subscription.BillingCycles != null)
                {
                    billingCycle = subscription.BillingCycles.SingleOrDefault();
                    billingCycle.Attributes = new List<TBillingCycleAttribute>();
                }

                subscription.Attributes = new List<TSubscriptionAttribute>();

                foreach (var subscriptionPlanAttribute in subscriptionPlan.Attributes)
                {
                    if (subscriptionPlanAttribute.Target == DaSubscriptionPlanAttributeTarget.CopyToSubscription || subscriptionPlanAttribute.Target == DaSubscriptionPlanAttributeTarget.CopyToSubscriptionAndBillingCycle)
                    {
                        var attribute = new TSubscriptionAttribute();
                        attribute.AttributeName = subscriptionPlanAttribute.AttributeName;
                        attribute.AttributeValue = subscriptionPlanAttribute.AttributeValue;
                        attribute.Subscription = subscription;
                        attribute.CreatedDateUtc = DateTime.UtcNow;
                        attribute.LastUpdatedDateUtc = DateTime.UtcNow;

                        subscription.Attributes.Add(attribute);
                    }
                    if (billingCycle != null)
                    {
                        if (subscriptionPlanAttribute.Target == DaSubscriptionPlanAttributeTarget.CopyToBillingCycle || subscriptionPlanAttribute.Target == DaSubscriptionPlanAttributeTarget.CopyToSubscriptionAndBillingCycle)
                        {
                            var bcAttribute = new TBillingCycleAttribute();
                            bcAttribute.AttributeName = subscriptionPlanAttribute.AttributeName;
                            bcAttribute.AttributeValue = subscriptionPlanAttribute.AttributeValue;
                            bcAttribute.BillingCycle = billingCycle;
                            bcAttribute.CreatedDateUtc = DateTime.UtcNow;
                            bcAttribute.LastUpdatedDateUtc = DateTime.UtcNow;

                            billingCycle.Attributes.Add(bcAttribute);
                        }
                    }
                }
            }

            if (subscriptionAttributes != null && subscriptionAttributes.Count > 0)
            {
                foreach (var key in subscriptionAttributes.Keys)
                {
                    var attribute = new TSubscriptionAttribute()
                    {
                        AttributeName = key,
                        AttributeValue = subscriptionAttributes[key],
                        Subscription = subscription,
                        CreatedDateUtc = DateTime.UtcNow,
                        LastUpdatedDateUtc = DateTime.UtcNow
                    };

                    subscription.Attributes.Add(attribute);
                }
            }

            await SubscriptionManager.CreateAsync(subscription);
            return new DaSubscriptionCreationResult<TKey>(subscription.Id);
        }


        public virtual void UpdatePaymentInfo(TKey subscriptionId, TNullableKey transactionId, TNullableKey paymentMethodId)
        {
            DaAsyncHelper.RunSync(() => UpdatePaymentInfoAsync(subscriptionId, transactionId, paymentMethodId));
        }

        public virtual async Task UpdatePaymentInfoAsync(TKey subscriptionId, TNullableKey transactionId, TNullableKey paymentMethodId)
        {
            var subscription = await SubscriptionManager.FindByIdAsync(subscriptionId);

            if (subscription == null)
            {
                throw new InvalidOperationException($"{subscriptionId} subscription doesn't exist.");
            }

            subscription.LastTransactionId = transactionId;
            subscription.LastPaymentMethodId = paymentMethodId;

            subscription.LastUpdatedDateUtc = DateTime.UtcNow;
            await SubscriptionManager.UpdateAsync(subscription);
        }

        public virtual void Activate(TKey subscriptionId)
        {
            DaAsyncHelper.RunSync(() => ActivateAsync(subscriptionId));
        }

        public virtual async Task ActivateAsync(TKey subscriptionId)
        {
            var subscription = await SubscriptionManager.FindByIdAsync(subscriptionId);

            if(subscription == null)
            {
                throw new InvalidOperationException($"{subscriptionId} subscription doesn't exist.");
            }

            subscription.IsActive = true;
            subscription.LastUpdatedDateUtc = DateTime.UtcNow;
            await SubscriptionManager.UpdateAsync(subscription);
        }

        public virtual void DeActivate(TKey subscriptionId)
        {
            DaAsyncHelper.RunSync(() => DeActivateAsync(subscriptionId));
        }

        public virtual async Task DeActivateAsync(TKey subscriptionId)
        {
            var subscription = await SubscriptionManager.FindByIdAsync(subscriptionId);

            if (subscription == null)
            {
                throw new InvalidOperationException($"{subscriptionId} subscription doesn't exist.");
            }

            subscription.IsActive = false;
            subscription.LastUpdatedDateUtc = DateTime.UtcNow;
            await SubscriptionManager.UpdateAsync(subscription);
        }
    }
}
