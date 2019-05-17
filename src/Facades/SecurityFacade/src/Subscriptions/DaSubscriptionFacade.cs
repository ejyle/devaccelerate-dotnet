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
using Ejyle.DevAccelerate.Facades.Security.Properties;
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

namespace Ejyle.DevAccelerate.Facades.Security.Subscriptions
{
    public class DaSubscriptionFacade : DaSubscriptionFacade<DaSubscriptionInfo, DaSubscriptionFeatureInfo, DaSubscriptionFeatureAccessInfo, DaSubscriptionFeatureAccessActionInfo, DaUserManager, DaUser, DaUserLogin, DaUserRole, DaUserClaim, DaTenantManager, DaTenant, DaTenantUser, DaUserAgreementManager, DaUserAgreement, DaUserAgreementVersion, DaUserAgreementVersionAction, DaAppManager, DaApp, DaFeatureManager, DaFeature, DaAppFeature, DaFeatureAction, DaSubscriptionPlanManager, DaSubscriptionPlan, DaBillingCycle, DaSubscriptionPlanApp, DaSubscriptionPlanFeature, DaSubscriptionPlanFeatureAttribute, DaSubscriptionManager, DaSubscription, DaSubscriptionApp, DaSubscriptionFeature, DaSubscriptionFeatureAttribute, DaSubscriptionAppRole, DaSubscriptionAppUser, DaSubscriptionFeatureRole, DaSubscriptionFeatureRoleAction, DaSubscriptionFeatureUser, DaSubscriptionFeatureUserAction, DaCurrencyManager, DaCurrency, DaCountryManager, DaCountry, DaCountryRegion, DaTimeZoneManager, DaTimeZone, DaSystemLanguageManager, DaSystemLanguage>
    {
        public DaSubscriptionFacade(IOwinContext owinContext)
            : base(owinContext.Get<DaUserManager>(),
                  new DaTenantManager(new DaTenantRepository(owinContext.Get<DaEnterpriseSecurityDbContext>())),
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

        public DaSubscriptionFacade(DaUserManager userManager, DaTenantManager tenantManager, DaAppManager appManager, DaFeatureManager featureManager, DaUserAgreementManager userAgreementManager, DaSubscriptionPlanManager subscriptionPlanManager, DaSubscriptionManager subscriptionManager, DaCurrencyManager currencyManager, DaCountryManager countryManager, DaTimeZoneManager timeZoneManager, DaSystemLanguageManager systemLanguageManager)
            : base(userManager, tenantManager, appManager, featureManager, userAgreementManager, subscriptionPlanManager, subscriptionManager, currencyManager, countryManager, timeZoneManager, systemLanguageManager)
        {
        }
    }

    public class DaSubscriptionFacade<TSubscriptionInfo, TSubscriptionFeatureInfo, TSubscriptionFeatureAccessInfo, TSubscriptionFeatureAccessActionInfo, TUserManager, TUser, TUserLogin, TUserRole, TUserClaim, TTenantManager, TTenant, TTenantUser, TUserAgreementManager, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction, TAppManager, TApp, TFeatureManager, TFeature, TAppFeature, TFeatureAction, TSubscriptionPlanManager, TSubscriptionPlan, TBillingCycle, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscriptionManager, TSubscription, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TCurrencyManager, TCurrency, TCountryManager, TCountry, TCountryRegion, TTimeZoneManager, TTimeZone, TSystemLanguageManager, TSystemLanguage> 
        : DaSubscriptionFacade<int, int?, TSubscriptionInfo, TSubscriptionFeatureInfo, TSubscriptionFeatureAccessInfo, TSubscriptionFeatureAccessActionInfo, TUserManager, TUser, TUserLogin, TUserRole, TUserClaim, TTenantManager, TTenant, TTenantUser, TUserAgreementManager, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction, TAppManager, TApp, TFeatureManager, TFeature, TAppFeature, TFeatureAction, TSubscriptionPlanManager, TSubscriptionPlan, TBillingCycle, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscriptionManager, TSubscription, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TCurrencyManager, TCurrency, TCountryManager, TCountry, TCountryRegion, TTimeZoneManager, TTimeZone, TSystemLanguageManager, TSystemLanguage>
        where TSubscriptionInfo : IDaSubscriptionInfo<int>
        where TSubscriptionFeatureInfo : DaSubscriptionFeatureInfo<int>, new()
        where TSubscriptionFeatureAccessInfo : DaSubscriptionFeatureAccessInfo<int, TSubscriptionFeatureAccessActionInfo>, new()
        where TSubscriptionFeatureAccessActionInfo : DaSubscriptionFeatureAccessActionInfo<int>, new()
        where TUserManager : DaUserManager<int, int?, TUser>
        where TUser : DaUser<int, int?, TUserLogin, TUserRole, TUserClaim>, new()
        where TUserLogin : DaUserLogin<int>
        where TUserRole : DaUserRole<int>
        where TUserClaim : DaUserClaim<int>
        where TAppManager : DaAppManager<int, TApp>
        where TApp : DaApp<int, int?, TFeature, TAppFeature, TSubscriptionApp, TSubscriptionPlanApp, TUserAgreement>
        where TAppFeature : DaAppFeature<int, TApp, TFeature>
        where TBillingCycle : DaBillingCycle<int, int?, TSubscriptionPlan>
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
        where TSubscriptionFeature : DaSubscriptionFeature<int, int?, TFeature, TSubscriptionFeatureAttribute, TSubscriptionFeatureRole, TSubscription, TSubscriptionFeatureUser>, new()
        where TSubscriptionFeatureUserAction : DaSubscriptionFeatureUserAction<int, TSubscriptionFeatureUser>
        where TSubscriptionFeatureUser : DaSubscriptionFeatureUser<int, int?, TSubscriptionFeature, TSubscriptionFeatureUserAction>
        where TSubscriptionPlanManager : DaSubscriptionPlanManager<int, int?, TSubscriptionPlan>
        where TSubscriptionPlanApp : DaSubscriptionPlanApp<int, int?, TApp, TSubscriptionPlan>
        where TSubscriptionPlanFeatureAttribute : DaSubscriptionPlanFeatureAttribute<int, TSubscriptionPlanFeature>
        where TSubscriptionPlanFeature : DaSubscriptionPlanFeature<int, int?, TFeature, TSubscriptionPlanFeatureAttribute, TSubscriptionPlan>
        where TSubscriptionPlan : DaSubscriptionPlan<int, int?, TBillingCycle, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscription>
        where TSubscription : DaSubscription<int, int?, TSubscriptionApp, TSubscriptionFeature, TSubscriptionPlan>, new()
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
        public DaSubscriptionFacade(TUserManager userManager, TTenantManager tenantManager, TAppManager appManager, TFeatureManager featureManager, TUserAgreementManager userAgreementManager, TSubscriptionPlanManager subscriptionPlanManager, TSubscriptionManager subscriptionManager, TCurrencyManager currencyManager, TCountryManager countryManager, TTimeZoneManager timeZoneManager, TSystemLanguageManager systemLanguageManager)
            : base(userManager, tenantManager, appManager, featureManager, userAgreementManager, subscriptionPlanManager, subscriptionManager, currencyManager, countryManager, timeZoneManager, systemLanguageManager)
        {
        }
    }

    public class DaSubscriptionFacade<TKey, TNullableKey, TSubscriptionInfo, TSubscriptionFeatureInfo, TSubscriptionFeatureAccessInfo, TSubscriptionFeatureAccessActionInfo, TUserManager, TUser, TUserLogin, TUserRole, TUserClaim, TTenantManager, TTenant, TTenantUser, TUserAgreementManager, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction, TAppManager, TApp, TFeatureManager, TFeature, TAppFeature, TFeatureAction, TSubscriptionPlanManager, TSubscriptionPlan, TBillingCycle, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscriptionManager, TSubscription, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TCurrencyManager, TCurrency, TCountryManager, TCountry, TCountryRegion, TTimeZoneManager, TTimeZone, TSystemLanguageManager, TSystemLanguage>
        where TKey : IEquatable<TKey>
        where TSubscriptionInfo : IDaSubscriptionInfo<TKey>
        where TSubscriptionFeatureInfo : DaSubscriptionFeatureInfo<TKey>, new()
        where TSubscriptionFeatureAccessInfo : DaSubscriptionFeatureAccessInfo<TKey, TSubscriptionFeatureAccessActionInfo>, new()
        where TSubscriptionFeatureAccessActionInfo : DaSubscriptionFeatureAccessActionInfo<TKey>, new()
        where TUserManager : DaUserManager<TKey, TNullableKey, TUser>
        where TUser : DaUser<TKey, TNullableKey, TUserLogin, TUserRole, TUserClaim>, new()
        where TUserLogin : DaUserLogin<TKey>
        where TUserRole : DaUserRole<TKey>
        where TUserClaim : DaUserClaim<TKey>
        where TAppManager : DaAppManager<TKey, TApp>
        where TApp : DaApp<TKey, TNullableKey, TFeature, TAppFeature, TSubscriptionApp, TSubscriptionPlanApp, TUserAgreement>
        where TAppFeature : DaAppFeature<TKey, TApp, TFeature>
        where TBillingCycle : DaBillingCycle<TKey, TNullableKey, TSubscriptionPlan>
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
        where TSubscriptionFeature : DaSubscriptionFeature<TKey, TNullableKey, TFeature, TSubscriptionFeatureAttribute, TSubscriptionFeatureRole, TSubscription, TSubscriptionFeatureUser>, new()
        where TSubscriptionFeatureUserAction : DaSubscriptionFeatureUserAction<TKey, TSubscriptionFeatureUser>
        where TSubscriptionFeatureUser : DaSubscriptionFeatureUser<TKey, TNullableKey, TSubscriptionFeature, TSubscriptionFeatureUserAction>
        where TSubscriptionPlanManager : DaSubscriptionPlanManager<TKey, TNullableKey, TSubscriptionPlan>
        where TSubscriptionPlanApp : DaSubscriptionPlanApp<TKey, TNullableKey, TApp, TSubscriptionPlan>
        where TSubscriptionPlanFeatureAttribute : DaSubscriptionPlanFeatureAttribute<TKey, TSubscriptionPlanFeature>
        where TSubscriptionPlanFeature : DaSubscriptionPlanFeature<TKey, TNullableKey, TFeature, TSubscriptionPlanFeatureAttribute, TSubscriptionPlan>
        where TSubscriptionPlan : DaSubscriptionPlan<TKey, TNullableKey, TBillingCycle, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscription>
        where TSubscription : DaSubscription<TKey, TNullableKey, TSubscriptionApp, TSubscriptionFeature, TSubscriptionPlan>, new()
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
        private TUserAgreementManager _userAgreementManager;
        private TAppManager _appManager;
        private TFeatureManager _featureManager;
        private TUserManager _userManager;
        private TTenantManager _tenantManager;
        private TSubscriptionManager _subscriptionManager;
        private TSubscriptionPlanManager _subscriptionPlanManager;
        private TCurrencyManager _currencyManager;
        private TCountryManager _countryManager;
        private TTimeZoneManager _timeZoneManager;
        private TSystemLanguageManager _systemLanguageManager;

        public DaSubscriptionFacade(TUserManager userManager, TTenantManager tenantManager, TAppManager appManager, TFeatureManager featureManager, TUserAgreementManager userAgreementManager, TSubscriptionPlanManager subscriptionPlanManager, TSubscriptionManager subscriptionManager, TCurrencyManager currencyManager, TCountryManager countryManager, TTimeZoneManager timeZoneManager, TSystemLanguageManager systemLanguageManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _tenantManager = tenantManager ?? throw new ArgumentNullException(nameof(tenantManager));
            _appManager = appManager ?? throw new ArgumentNullException(nameof(appManager));
            _featureManager = featureManager ?? throw new ArgumentNullException(nameof(featureManager));
            _userAgreementManager = userAgreementManager ?? throw new ArgumentNullException(nameof(userAgreementManager));
            _subscriptionManager = subscriptionManager ?? throw new ArgumentNullException(nameof(subscriptionManager));
            _subscriptionPlanManager = subscriptionPlanManager ?? throw new ArgumentNullException(nameof(subscriptionPlanManager));
            _currencyManager = currencyManager ?? throw new ArgumentNullException(nameof(currencyManager));
            _countryManager = countryManager ?? throw new ArgumentNullException(nameof(countryManager));
            _timeZoneManager = timeZoneManager ?? throw new ArgumentNullException(nameof(timeZoneManager));
            _systemLanguageManager = systemLanguageManager ?? throw new ArgumentNullException(nameof(systemLanguageManager));
        }

        public virtual async Task<List<TSubscription>> GetSubscriptions(TKey userId, TKey tenantId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new InvalidOperationException("Invalid user ID.");
            }

            var tenant = await _tenantManager.FindByIdAsync(tenantId);

            if(tenant == null)
            {
                throw new InvalidOperationException("Invalid tenant ID.");
            }

            var associated = await _tenantManager.CheckTenantUserActiveAssociationAsync(tenantId, userId);

            if(!associated)
            {
                throw new InvalidOperationException("The tenant and user are not associated at all or the association is not active.");
            }

            return await _subscriptionManager.FindByTenantIdAsync(tenantId);
        }

        public virtual async Task<List<TSubscriptionFeatureInfo>> GetFeatures(TKey userId, TKey subscriptionId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return null;
            }

            if (user.Status != DaAccountStatus.Active)
            {
                return null;
            }

            var subscription = await _subscriptionManager.FindByIdAsync(subscriptionId);

            if (subscription == null)
            {
                return null;
            }

            if (!subscription.IsActive)
            {
                return null;
            }

            var tenants = await _tenantManager.FindByUserIdAsync(userId);
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

            if(subscription.SubscriptionFeatures == null || subscription.SubscriptionFeatures.Count <= 0)
            {
                return null;
            }

            var result = new List<TSubscriptionFeatureInfo>();

            foreach(var feature in subscription.SubscriptionFeatures)
            {
                var subscriptionFeatureInfo = new TSubscriptionFeatureInfo();
                subscriptionFeatureInfo.Id = feature.Feature.Id;
                subscriptionFeatureInfo.Name = feature.Feature.Name;
                subscriptionFeatureInfo.Key = feature.Feature.Key;
                subscriptionFeatureInfo.Location = feature.Feature.Location;

                result.Add(subscriptionFeatureInfo);
            }

            return result;
        }

        public virtual async Task<TSubscriptionFeatureAccessInfo> GetAccessInfoAsync(TKey userId, TKey subscriptionId, string key)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if(user == null)
            {
                return null;
            }

            if(user.Status != DaAccountStatus.Active)
            {
                return null;
            }

            var subscription = await _subscriptionManager.FindByIdAsync(subscriptionId);

            if(subscription == null)
            {
                return null;
            }

            if(!subscription.IsActive)
            {
                return null;
            }

            var tenants = await _tenantManager.FindByUserIdAsync(userId);
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

            if(tenant == null)
            {
                return null;
            }

            var feature = subscription.SubscriptionFeatures.Where(m => m.Feature.Key == key).SingleOrDefault();

            var result = new TSubscriptionFeatureAccessInfo();
            result.Id = feature.Id;
            result.Key = feature.Feature.Key;

            var subscriptionFeatureAccessActions = new List<TSubscriptionFeatureAccessActionInfo>();

            if (feature.SubscriptionFeatureRoles != null && feature.SubscriptionFeatureRoles.Count > 0)
            {
                foreach (var userRole in user.Roles)
                {
                    var featureRoles = feature.SubscriptionFeatureRoles.Where(m => m.RoleId.Equals(userRole.RoleId)).ToList();

                    foreach (var featureRole in featureRoles)
                    {
                        foreach (var action in featureRole.SubscriptionFeatureRoleActions)
                        {
                            var currentAction = subscriptionFeatureAccessActions.Where(m => m.ActionName == action.ActionName).SingleOrDefault();

                            if (currentAction == null)
                            {
                                subscriptionFeatureAccessActions.Add(new TSubscriptionFeatureAccessActionInfo()
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

            if (feature.SubscriptionFeatureUsers != null && feature.SubscriptionFeatureUsers.Count > 0)
            {
                var featureUsers = feature.SubscriptionFeatureUsers.Where(m => m.UserId.Equals(userId)).ToList();

                foreach (var featureUser in featureUsers)
                {
                    foreach (var action in featureUser.SubscriptionFeatureUserActions)
                    {
                        var currentAction = subscriptionFeatureAccessActions.Where(m => m.ActionName == action.ActionName).SingleOrDefault();

                        if (currentAction == null)
                        {
                            subscriptionFeatureAccessActions.Add(new TSubscriptionFeatureAccessActionInfo()
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

            return result;
        }

        public virtual async Task<IdentityResult> SubscribeAsync(TSubscriptionInfo subscriptionInfo, string password)
        {
            var subscriptionPlan = await _subscriptionPlanManager.FindByIdAsync(subscriptionInfo.SubscriptionPlanId);

            if(subscriptionPlan == null)
            {
                throw new InvalidOperationException(Resources.InvalidSubscriptionPlan);
            }

            var user = new TUser
            {
                UserName = subscriptionInfo.UserName,
                Email = subscriptionInfo.Email,
                EmailConfirmed = false
            };

            var result = await _userManager.CreateAsync(user, password);

            var tenant = new TTenant();

            if (subscriptionInfo.TenantType == DaTenantType.Individual)
            {
                tenant.Name = user.UserName;
            }
            else if(subscriptionInfo.TenantType == DaTenantType.Organization)
            {
                tenant.Name = subscriptionInfo.OrganizationName;
            }

            tenant.OwnerUserId = user.Id;
            tenant.Status = DaTenantStatus.Active;
            tenant.TenantType = DaTenantType.Organization;
            tenant.Domain = null;
            tenant.IsDomainOwnershipVerified = false;
            tenant.FriendlyName = tenant.Name;
            tenant.SystemLanguageId = default(TNullableKey);
            tenant.DateFormatId = default(TNullableKey);
            tenant.DateFormatWithDateOnlyId = default(TNullableKey);
            tenant.DateFormatWithTimeOnlyId = default(TNullableKey);
            tenant.CurrencyId = default(TNullableKey);
            tenant.CreatedDateUtc = DateTime.UtcNow;
            tenant.CreatedBy = user.Id;

            var tenantUser = new TTenantUser
            {
                Tenant = tenant,                 
                IsActive = true
            };

            tenant.TenantUsers.Add(tenantUser);

            await _tenantManager.CreateAsync(tenant);

            var subscription = new TSubscription
            {
                Name = subscriptionPlan.Name,
                IsTrial = false,
                OwnerUserId = user.Id,
                SubscriptionPlanId = subscriptionPlan.Id,
                ExpiryDateUtc = DateTime.UtcNow.AddDays(30),
                CountryId = default(TKey),
                TenantId = tenant.Id,
                UserAgreementVersionId = default(TNullableKey),
                CurrencyId = default(TKey),
                CreatedDateUtc = DateTime.UtcNow,
                BillingAmount = 0,
                BillingCycleEndDay = 10,
                BillingCycleStartDay = 10,
                BillingCycleType = DaBillingCycleType.Monthly
            };

            var billingCycle = subscriptionPlan.BillingCycles.Where(m => m.Id.Equals(subscriptionInfo.BillingCycleId)).SingleOrDefault();

            if(billingCycle != null)
            {
                DateTime dt = DateTime.UtcNow;

                subscription.BillingAmount = billingCycle.Amount;
                subscription.BillingCycleType = billingCycle.BillingCycleType;

                if(billingCycle.BillingCycleType == DaBillingCycleType.Monthly)
                {
                    subscription.BillingCycleStartDay = dt.Day;

                    if (dt.Month != 1)
                    {
                        subscription.BillingCycleEndDay = subscription.BillingCycleStartDay = 1;
                    }
                    else
                    {
                        subscription.BillingCycleEndDay = 1;
                    }
                }
                else if(billingCycle.BillingCycleType == DaBillingCycleType.Yearly)
                {
                    subscription.BillingCycleStartDay = dt.DayOfYear;
                    subscription.BillingCycleEndDay = dt.AddYears(1).DayOfYear;
                }
                else if(billingCycle.BillingCycleType == DaBillingCycleType.Quarterly)
                {
                    subscription.BillingCycleStartDay = dt.DayOfYear;
                    subscription.BillingCycleEndDay = dt.AddMonths(3).DayOfYear;
                }
                else if(billingCycle.BillingCycleType == DaBillingCycleType.Weekly)
                {
                    switch(dt.DayOfWeek)
                    {                   
                        case DayOfWeek.Sunday:
                            subscription.BillingCycleStartDay = 1;
                            subscription.BillingCycleEndDay = 7;
                            break;
                        case DayOfWeek.Monday:
                            subscription.BillingCycleStartDay = 2;
                             break;
                        case DayOfWeek.Tuesday:
                            subscription.BillingCycleStartDay = 3;
                            break;
                        case DayOfWeek.Wednesday:
                            subscription.BillingCycleStartDay = 6;
                            break;
                        case DayOfWeek.Thursday:
                            subscription.BillingCycleStartDay = 5;
                            break;
                        case DayOfWeek.Friday:
                            subscription.BillingCycleStartDay = 6;
                            break;
                        case DayOfWeek.Saturday:
                            subscription.BillingCycleStartDay = 7;
                            break;
                    }

                    if(dt.DayOfWeek == DayOfWeek.Saturday)
                    {
                        subscription.BillingCycleEndDay = 7;
                    }
                    else
                    {
                        subscription.BillingCycleEndDay = subscription.BillingCycleStartDay - 1;
                    }
                }
            }

            if(subscriptionPlan.SubscriptionPlanApps != null && subscriptionPlan.SubscriptionPlanApps.Count > 0)
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
                    subscriptionFeature.IsEnabled = true;

                    if (subscriptionPlanFeature.SubscriptionPlanFeatureAttributes != null && subscriptionPlanFeature.SubscriptionPlanFeatureAttributes.Count > 0)
                    {
                        subscriptionFeature.SubscriptionFeatureAttributes = new List<TSubscriptionFeatureAttribute>();

                        foreach (var subscriptionPlanFeatureAttribute in subscriptionPlanFeature.SubscriptionPlanFeatureAttributes)
                        {
                            var subscriptionFeatureAttribute = new TSubscriptionFeatureAttribute();

                            subscriptionFeatureAttribute.Name = subscriptionPlanFeatureAttribute.Name;
                            subscriptionFeatureAttribute.Value = subscriptionPlanFeatureAttribute.Value;
                            subscriptionFeatureAttribute.SubscriptionFeature = subscriptionFeature;

                            subscriptionFeature.SubscriptionFeatureAttributes.Add(subscriptionFeatureAttribute);
                        }
                    }
                    subscription.SubscriptionFeatures.Add(subscriptionFeature);
                }
            }

            subscription.IsActive = true;

            await _subscriptionManager.CreateAsync(subscription);
            return result;
        }
    }
}
