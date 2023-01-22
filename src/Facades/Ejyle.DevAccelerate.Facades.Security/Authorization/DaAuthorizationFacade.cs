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
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core;
using Microsoft.AspNetCore.Identity;
using Ejyle.DevAccelerate.Lists.Countries;
using Ejyle.DevAccelerate.Lists.Currencies;
using Ejyle.DevAccelerate.Lists.DateFormats;
using Ejyle.DevAccelerate.Lists.SystemLanguages;
using Ejyle.DevAccelerate.Lists.TimeZones;
using Ejyle.DevAccelerate.Lists.EF.Countries;
using Ejyle.DevAccelerate.Lists.EF.Currencies;
using Ejyle.DevAccelerate.Lists.EF.SystemLanguages;
using Ejyle.DevAccelerate.Lists.EF.TimeZones;
using Ejyle.DevAccelerate.Identity.Groups;
using Ejyle.DevAccelerate.Platform.Apps;
using Ejyle.DevAccelerate.Subscriptions.SubscriptionPlans;
using Ejyle.DevAccelerate.Platform.Features;
using Ejyle.DevAccelerate.Subscriptions.Subscriptions;
using Ejyle.DevAccelerate.MultiTenancy.Tenants;
using Ejyle.DevAccelerate.Identity.UserAgreements;
using Ejyle.DevAccelerate.Identity.EF.Groups;
using Ejyle.DevAccelerate.Platform.EF.Apps;
using Ejyle.DevAccelerate.Subscriptions.EF.SubscriptionPlans;
using Ejyle.DevAccelerate.Platform.EF.Features;
using Ejyle.DevAccelerate.Subscriptions.EF.Subscriptions;
using Ejyle.DevAccelerate.MultiTenancy.EF.Tenants;
using Ejyle.DevAccelerate.Identity.EF.UserAgreements;

namespace Ejyle.DevAccelerate.Facades.Security.Authorization
{
    public class DaAuthorizationFacade : DaAuthorizationFacade<string, DaAuthorizedFeatureInfo, DaAuthorizationInfo, DaAuthorizedActionInfo, UserManager<DaUser>, DaUser, RoleManager<DaRole>, DaRole, DaTenantManager, DaTenant, DaTenantUser, DaTenantAttribute, DaUserAgreementManager, DaUserAgreement, DaUserAgreementVersion, DaUserAgreementVersionAction, DaGroupManager, DaGroup, DaGroupRole, DaGroupUser, DaAppManager, DaApp, DaAppAttribute, DaFeatureManager, DaFeature, DaAppFeature, DaFeatureAction, DaSubscriptionPlanManager, DaSubscriptionPlan, DaSubscriptionPlanAttribute, DaBillingCycleOption, DaSubscriptionPlanApp, DaSubscriptionPlanFeature, DaSubscriptionPlanFeatureAttribute, DaSubscriptionManager, DaSubscription, DaSubscriptionAttribute, DaSubscriptionApp, DaSubscriptionFeature, DaSubscriptionFeatureAttribute, DaSubscriptionAppRole, DaSubscriptionAppUser, DaSubscriptionFeatureRole, DaSubscriptionFeatureRoleAction, DaSubscriptionFeatureUser, DaSubscriptionFeatureUserAction, DaBillingCycle, DaBillingCycleAttribute, DaBillingCycleFeatureUsage, DaCurrencyManager, DaCurrency, DaCountryManager, DaCountry, DaCountryRegion, DaCountryDateFormat, DaCountrySystemLanguage, DaCountryTimeZone, DaDateFormat, DaTimeZoneManager, DaTimeZone, DaSystemLanguageManager, DaSystemLanguage>
    {
        public DaAuthorizationFacade(UserManager<DaUser> userManager, RoleManager<DaRole> roleManager, DaTenantManager tenantManager, DaAppManager appManager, DaFeatureManager featureManager, DaUserAgreementManager userAgreementManager, DaSubscriptionPlanManager subscriptionPlanManager, DaSubscriptionManager subscriptionManager, DaCurrencyManager currencyManager, DaCountryManager countryManager, DaTimeZoneManager timeZoneManager, DaSystemLanguageManager systemLanguageManager)
            : base(userManager, roleManager, tenantManager, appManager, featureManager, userAgreementManager, subscriptionPlanManager, subscriptionManager, currencyManager, countryManager, timeZoneManager, systemLanguageManager)
        {
        }
    }

    public class DaAuthorizationFacade<TKey, TAuthorizedFeatureInfo, TAuthorizationInfo, TAuthorizedActionInfo, TUserManager, TUser, TRoleManager, TRole, TTenantManager, TTenant, TTenantUser, TTenantAttribute, TUserAgreementManager, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction, TGroupManager, TGroup, TGroupRole, TGroupUser, TAppManager, TApp, TAppAttribute, TFeatureManager, TFeature, TAppFeature, TFeatureAction, TSubscriptionPlanManager, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscriptionManager, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TBillingCycleFeatureUsage, TCurrencyManager, TCurrency, TCountryManager, TCountry, TCountryRegion, TCountryDateFormat, TCountrySystemLanguage, TCountryTimeZone, TDateFormat, TTimeZoneManager, TTimeZone, TSystemLanguageManager, TSystemLanguage>
        where TKey : IEquatable<TKey>
        where TAuthorizedFeatureInfo : DaAuthorizedFeatureInfo<TKey>, new()
        where TAuthorizationInfo : DaAuthorizationInfo<TKey, TAuthorizedActionInfo>, new()
        where TAuthorizedActionInfo : DaAuthorizedActionInfo<TKey>, new()
        where TUserManager : UserManager<TUser>
        where TUser : DaUser<TKey>, new()
        where TRoleManager : RoleManager<TRole>
        where TRole : DaRole<TKey>, new()
        where TGroup : DaGroup<TKey, TGroupRole, TGroupUser>
        where TGroupRole : DaGroupRole<TKey, TGroup>
        where TGroupUser : DaGroupUser<TKey, TGroup>
        where TGroupManager : DaGroupManager<TKey, TGroup>
        where TAppManager : DaAppManager<TKey, TApp>
        where TApp : DaApp<TKey, TAppAttribute, TFeature, TAppFeature>
        where TAppAttribute : DaAppAttribute<TKey, TApp>
        where TAppFeature : DaAppFeature<TKey, TApp, TFeature>
        where TBillingCycleOption : DaBillingCycleOption<TKey, TSubscriptionPlan>
        where TFeatureAction : DaFeatureAction<TKey, TFeature>
        where TFeatureManager : DaFeatureManager<TKey, TFeature>
        where TFeature : DaFeature<TKey, TApp, TAppFeature, TFeatureAction>
        where TSubscriptionManager : DaSubscriptionManager<TKey, TSubscription>
        where TSubscriptionAppRole : DaSubscriptionAppRole<TKey, TSubscriptionApp>
        where TSubscriptionApp : DaSubscriptionApp<TKey, TSubscriptionAppRole, TSubscription, TSubscriptionAppUser>, new()
        where TSubscriptionAppUser : DaSubscriptionAppUser<TKey, TSubscriptionApp>
        where TSubscriptionFeatureAttribute : DaSubscriptionFeatureAttribute<TKey, TSubscriptionFeature>, new()
        where TSubscriptionFeatureRoleAction : DaSubscriptionFeatureRoleAction<TKey, TSubscriptionFeatureRole>
        where TSubscriptionFeatureRole : DaSubscriptionFeatureRole<TKey, TSubscriptionFeatureRoleAction, TSubscriptionFeature>
        where TSubscriptionFeature : DaSubscriptionFeature<TKey, TSubscriptionFeatureAttribute, TSubscriptionFeatureRole, TSubscription, TSubscriptionFeatureUser, TBillingCycleFeatureUsage>, new()
        where TSubscriptionFeatureUserAction : DaSubscriptionFeatureUserAction<TKey, TSubscriptionFeatureUser>
        where TSubscriptionFeatureUser : DaSubscriptionFeatureUser<TKey, TSubscriptionFeature, TSubscriptionFeatureUserAction>
        where TSubscriptionPlanManager : DaSubscriptionPlanManager<TKey, TSubscriptionPlan>
        where TSubscriptionPlanApp : DaSubscriptionPlanApp<TKey, TSubscriptionPlan>
        where TSubscriptionPlanFeatureAttribute : DaSubscriptionPlanFeatureAttribute<TKey, TSubscriptionPlanFeature>
        where TSubscriptionPlanFeature : DaSubscriptionPlanFeature<TKey, TSubscriptionPlanFeatureAttribute, TSubscriptionPlan>
        where TSubscriptionPlan : DaSubscriptionPlan<TKey, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscription>
        where TSubscriptionPlanAttribute : DaSubscriptionPlanAttribute<TKey, TSubscriptionPlan>
        where TSubscription : DaSubscription<TKey, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionPlan, TBillingCycle>, new()
        where TBillingCycle : DaBillingCycle<TKey, TBillingCycleAttribute, TSubscription, TBillingCycleFeatureUsage>
        where TBillingCycleAttribute : DaBillingCycleAttribute<TKey, TBillingCycle>
        where TBillingCycleFeatureUsage : DaBillingCycleFeatureUsage<TKey, TBillingCycle, TSubscriptionFeature>
        where TSubscriptionAttribute : DaSubscriptionAttribute<TKey, TSubscription>
        where TTenantManager : DaTenantManager<TKey, TTenant, TTenantUser>
        where TTenant : DaTenant<TKey, TTenantUser, TTenantAttribute>, new()
        where TTenantAttribute : DaTenantAttribute<TKey, TTenant>
        where TTenantUser : DaTenantUser<TKey, TTenant>, new()
        where TUserAgreementManager : DaUserAgreementManager<TKey, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction>
        where TUserAgreement : DaUserAgreement<TKey, TUserAgreementVersion>
        where TUserAgreementVersion : DaUserAgreementVersion<TKey, TUserAgreement, TUserAgreementVersionAction>
        where TUserAgreementVersionAction : DaUserAgreementVersionAction<TKey, TUserAgreementVersion>
        where TCurrencyManager : DaCurrencyManager<TKey, TCurrency>
        where TCurrency : DaCurrency<TKey, TCountry>
        where TCountryManager : DaCountryManager<TKey, TCountry, TCountryRegion>
        where TCountry : DaCountry<TKey, TCurrency, TCountryTimeZone, TCountryRegion, TCountrySystemLanguage, TCountryDateFormat>
        where TCountryRegion : DaCountryRegion<TKey, TCountryRegion, TCountry>
        where TCountryDateFormat : DaCountryDateFormat<TKey, TCountry, TDateFormat>
        where TCountrySystemLanguage : DaCountrySystemLanguage<TKey, TCountry, TSystemLanguage>
        where TCountryTimeZone : DaCountryTimeZone<TKey, TCountry, TTimeZone>
        where TDateFormat : DaDateFormat<TKey, TCountryDateFormat>
        where TTimeZoneManager : DaTimeZoneManager<TKey, TTimeZone>
        where TTimeZone : DaTimeZone<TKey, TCountryTimeZone>
        where TSystemLanguageManager : DaSystemLanguageManager<TKey, TSystemLanguage>
        where TSystemLanguage : DaSystemLanguage<TKey, TCountrySystemLanguage>
    {
        public DaAuthorizationFacade(TUserManager userManager, TRoleManager roleManager, TTenantManager tenantManager, TAppManager appManager, TFeatureManager featureManager, TUserAgreementManager userAgreementManager, TSubscriptionPlanManager subscriptionPlanManager, TSubscriptionManager subscriptionManager, TCurrencyManager currencyManager, TCountryManager countryManager, TTimeZoneManager timeZoneManager, TSystemLanguageManager systemLanguageManager)
        {
            UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            RoleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
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

        public TUserManager UserManager
        {
            get;
            private set;
        }

        public TRoleManager RoleManager
        {
            get;
            private set;
        }

        public TTenantManager TenantManager
        {
            get;
            private set;
        }

        public TSubscriptionManager SubscriptionManager
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

        public TGroupManager GroupManager
        {
            get;
            private set;
        }

        public List<TAuthorizedFeatureInfo> GetAuthorizedFeatures(TKey userId, TKey subscriptionId)
        {
            return DaAsyncHelper.RunSync<List<TAuthorizedFeatureInfo>>(() => GetAuthorizedFeaturesAsync(userId, subscriptionId));
        }

        public virtual async Task<List<TAuthorizedFeatureInfo>> GetAuthorizedFeaturesAsync(TKey userId, TKey subscriptionId)
        {
            var user = await UserManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return null;
            }

            if (user.Status != DaAccountStatus.Active)
            {
                return null;
            }

            var subscription = await SubscriptionManager.FindByIdAsync(subscriptionId);

            if (subscription == null)
            {
                return null;
            }

            if (!subscription.IsActive)
            {
                return null;
            }

            var tenants = await TenantManager.FindByUserIdAsync(userId);
            TTenant tenant = null;

            for (var i = 0; i < tenants.Count; i++)
            {
                if (tenants[i].Id.Equals(subscription.TenantId))
                {
                    if (tenants[i].Status == DaTenantStatus.Active)
                    {
                        tenant = tenants[i];
                    }

                    break;
                }
            }

            if (tenant == null)
            {
                return null;
            }

            if (subscription.SubscriptionFeatures == null || subscription.SubscriptionFeatures.Count <= 0)
            {
                return null;
            }

            var result = new List<TAuthorizedFeatureInfo>();

            foreach (var subscriptionFeature in subscription.SubscriptionFeatures)
            {
                var subscriptionFeatureInfo = new TAuthorizedFeatureInfo();

                var feature = await FeatureManager.FindByIdAsync(subscriptionFeature.FeatureId);

                subscriptionFeatureInfo.Id = feature.Id;
                subscriptionFeatureInfo.Name = feature.Name;
                subscriptionFeatureInfo.Key = feature.Key;

                result.Add(subscriptionFeatureInfo);
            }

            return result;
        }

        public DaAuthorizationResult<TKey, TAuthorizationInfo, TAuthorizedActionInfo> Authorize(TKey userId, TKey subscriptionId, string featureKey)
        {
            return DaAsyncHelper.RunSync<DaAuthorizationResult<TKey, TAuthorizationInfo, TAuthorizedActionInfo>>(() => AuthorizeAsync(userId, subscriptionId, featureKey));
        }

        public virtual async Task<DaAuthorizationResult<TKey, TAuthorizationInfo, TAuthorizedActionInfo>> AuthorizeAsync(TKey userId, TKey subscriptionId, string featureKey)
        {
            var user = await UserManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID.");
            }

            if (user.Status != DaAccountStatus.Active)
            {
                return new DaAuthorizationResult<TKey, TAuthorizationInfo, TAuthorizedActionInfo>(DaAuthorizationStatus.UserAccountNotActive);
            }

            var subscription = await SubscriptionManager.FindByIdAsync(subscriptionId);

            if (subscription == null)
            {
                throw new ArgumentException("Invalid subscription ID.");
            }

            if (!subscription.IsActive)
            {
                return new DaAuthorizationResult<TKey, TAuthorizationInfo, TAuthorizedActionInfo>(DaAuthorizationStatus.SubscriptionNotActive);
            }

            var feature = await FeatureManager.FindByKeyAsync(featureKey);

            if (feature == null)
            {
                return new DaAuthorizationResult<TKey, TAuthorizationInfo, TAuthorizedActionInfo>(DaAuthorizationStatus.FeatureNotFoundInSubscription);
            }

            var tenants = await TenantManager.FindByUserIdAsync(userId);
            TTenant tenant = null;

            for (var i = 0; i < tenants.Count; i++)
            {
                if (tenants[i].Id.Equals(subscription.TenantId))
                {
                    if (tenants[i].Status == DaTenantStatus.Active)
                    {
                        tenant = tenants[i];
                    }

                    break;
                }
            }

            if (tenant == null)
            {
                return new DaAuthorizationResult<TKey, TAuthorizationInfo, TAuthorizedActionInfo>(DaAuthorizationStatus.NotAssociatedWithAnActiveTenant);
            }

            var subscriptionFeature = subscription.SubscriptionFeatures.Where(m => m.FeatureId.Equals(feature.Id)).SingleOrDefault();

            if (subscriptionFeature == null)
            {
                return new DaAuthorizationResult<TKey, TAuthorizationInfo, TAuthorizedActionInfo>(DaAuthorizationStatus.FeatureNotFoundInSubscription);
            }

            var subscriptionFeatureUser = subscriptionFeature.SubscriptionFeatureUsers.Where(m => m.UserId.Equals(userId)).SingleOrDefault();

            if (subscriptionFeatureUser != null)
            {
                if (!subscriptionFeatureUser.IsEnabled)
                {
                    return new DaAuthorizationResult<TKey, TAuthorizationInfo, TAuthorizedActionInfo>(DaAuthorizationStatus.FeatureDeniedToUser);
                }
            }

            var authorizationInfo = new TAuthorizationInfo();
            authorizationInfo.Id = subscriptionFeature.Id;
            authorizationInfo.Key = feature.Key;

            var authorizedActions = new List<TAuthorizedActionInfo>();

            if (subscriptionFeature.SubscriptionFeatureRoles != null && subscriptionFeature.SubscriptionFeatureRoles.Count > 0)
            {
                foreach (var roleName in await UserManager.GetRolesAsync(user))
                {
                    var role = await RoleManager.FindByNameAsync(roleName);
                    var featureRoles = subscriptionFeature.SubscriptionFeatureRoles.Where(m => m.RoleId.Equals(role.Id)).ToList();

                    foreach (var featureRole in featureRoles)
                    {
                        foreach (var action in featureRole.SubscriptionFeatureRoleActions)
                        {
                            var currentAction = authorizedActions.Where(m => m.ActionName == action.ActionName).SingleOrDefault();

                            if (currentAction == null)
                            {
                                authorizedActions.Add(new TAuthorizedActionInfo()
                                {
                                    ActionName = action.ActionName,
                                    Allowed = action.Allowed
                                });
                            }
                            else
                            {
                                if (currentAction.Allowed != false)
                                {
                                    if (currentAction.Allowed == null)
                                    {
                                        currentAction.Allowed = action.Allowed;
                                    }
                                    else
                                    {
                                        if (action.Allowed != null)
                                        {
                                            currentAction.Allowed = action.Allowed;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (subscriptionFeature.SubscriptionFeatureUsers != null && subscriptionFeature.SubscriptionFeatureUsers.Count > 0)
            {
                var featureUsers = subscriptionFeature.SubscriptionFeatureUsers.Where(m => m.UserId.Equals(userId)).ToList();

                foreach (var featureUser in featureUsers)
                {
                    foreach (var action in featureUser.SubscriptionFeatureUserActions)
                    {
                        var currentAction = authorizedActions.Where(m => m.ActionName == action.ActionName).SingleOrDefault();

                        if (currentAction == null)
                        {
                            authorizedActions.Add(new TAuthorizedActionInfo()
                            {
                                ActionName = action.ActionName,
                                Allowed = action.Allowed
                            });
                        }
                        else
                        {
                            if (currentAction.Allowed != false)
                            {
                                if (currentAction.Allowed == null)
                                {
                                    currentAction.Allowed = action.Allowed;
                                }
                                else
                                {
                                    if (action.Allowed != null)
                                    {
                                        currentAction.Allowed = action.Allowed;
                                    }
                                }
                            }
                        }
                    }
                }

                authorizationInfo.Actions = authorizedActions;
            }

            return new DaAuthorizationResult<TKey, TAuthorizationInfo, TAuthorizedActionInfo>(authorizationInfo); ;
        }
    }
}
