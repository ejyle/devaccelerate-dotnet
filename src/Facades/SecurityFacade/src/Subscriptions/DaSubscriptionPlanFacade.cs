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
using System.Data.Entity;
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
using System.Collections.Generic;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF.UserAgreements;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF.Apps;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Facades.Security.Subscriptions
{
    public class DaSubscriptionPlanFacade 
        : DaSubscriptionPlanFacade<DaSubscriptionPlanInfo, DaBillingCycleInfo, DaAppInfo, DaAppFeatureInfo, DaAppFeatureAttributeInfo, DaUserAgreementManager, DaUserAgreement, DaUserAgreementVersion, DaUserAgreementVersionAction, DaAppManager, DaApp, DaAppAttribute, DaFeatureManager, DaFeature, DaAppFeature, DaFeatureAction, DaSubscriptionPlanManager, DaSubscriptionPlan, DaSubscriptionPlanAttribute, DaBillingCycleOption, DaSubscriptionPlanApp, DaSubscriptionPlanFeature, DaSubscriptionPlanFeatureAttribute, DaSubscription, DaSubscriptionAttribute, DaSubscriptionApp, DaSubscriptionFeature, DaSubscriptionFeatureAttribute, DaSubscriptionAppRole, DaSubscriptionAppUser, DaSubscriptionFeatureRole, DaSubscriptionFeatureRoleAction, DaSubscriptionFeatureUser, DaSubscriptionFeatureUserAction, DaBillingCycle, DaBillingCycleAttribute, DaCurrencyManager, DaCurrency, DaCountryManager, DaCountry, DaCountryRegion, DaTimeZoneManager, DaTimeZone, DaSystemLanguageManager, DaSystemLanguage>
    {
        public DaSubscriptionPlanFacade(IOwinContext owinContext)
            : base(new DaAppManager(new DaAppRepository(owinContext.Get<DaEnterpriseSecurityDbContext>())),
                  new DaFeatureManager(new DaFeatureRepository(owinContext.Get<DaEnterpriseSecurityDbContext>())),
                  new DaUserAgreementManager(new DaUserAgreementRepository(owinContext.Get<DaEnterpriseSecurityDbContext>())),
                  new DaSubscriptionPlanManager(new DaSubscriptionPlanRepository(owinContext.Get<DaEnterpriseSecurityDbContext>())),
                  new DaCurrencyManager(new DaCurrencyRepository(owinContext.Get<DaListsDbContext>())),
                  new DaCountryManager(new DaCountryRepository(owinContext.Get<DaListsDbContext>())),
                  new DaTimeZoneManager(new DaTimeZoneRepository(owinContext.Get<DaListsDbContext>())),
                  new DaSystemLanguageManager(new DaSystemLanguageRepository(owinContext.Get<DaListsDbContext>())))
        {
        }

        public DaSubscriptionPlanFacade(DaAppManager appManager, DaFeatureManager featureManager, DaUserAgreementManager userAgreementManager, DaSubscriptionPlanManager subscriptionPlanManager, DaSubscriptionManager subscriptionManager, DaCurrencyManager currencyManager, DaCountryManager countryManager, DaTimeZoneManager timeZoneManager, DaSystemLanguageManager systemLanguageManager)
            : base(appManager, featureManager, userAgreementManager, subscriptionPlanManager, currencyManager, countryManager, timeZoneManager, systemLanguageManager)
        {
        }
    }

    public class DaSubscriptionPlanFacade<TSubscriptionPlanInfo, TBillingCycleCycleInfo, TAppInfo, TAppFeatureInfo, TDaAppFeatureAttributeInfo, TUserAgreementManager, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction, TAppManager, TApp, TAppAttribute, TFeatureManager, TFeature, TAppFeature, TFeatureAction, TSubscriptionPlanManager, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TCurrencyManager, TCurrency, TCountryManager, TCountry, TCountryRegion, TTimeZoneManager, TTimeZone, TSystemLanguageManager, TSystemLanguage>
        : DaSubscriptionPlanFacade<int, int?, TSubscriptionPlanInfo, TBillingCycleCycleInfo, TAppInfo, TAppFeatureInfo, TDaAppFeatureAttributeInfo, TUserAgreementManager, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction, TAppManager, TApp, TAppAttribute, TFeatureManager, TFeature, TAppFeature, TFeatureAction, TSubscriptionPlanManager, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TCurrencyManager, TCurrency, TCountryManager, TCountry, TCountryRegion, TTimeZoneManager, TTimeZone, TSystemLanguageManager, TSystemLanguage>
        where TSubscriptionPlanInfo : DaSubscriptionPlanInfo<int,int?, TBillingCycleCycleInfo, TAppInfo, TAppFeatureInfo, TDaAppFeatureAttributeInfo>, new()
        where TBillingCycleCycleInfo : DaBillingCycleInfo<int>, new()
        where TAppInfo : DaAppInfo<int, TAppFeatureInfo, TDaAppFeatureAttributeInfo>, new()
        where TAppFeatureInfo : DaAppFeatureInfo<int, TDaAppFeatureAttributeInfo>, new()
        where TDaAppFeatureAttributeInfo : DaAppFeatureAttributeInfo<int>, new()
        where TAppManager : DaAppManager<int, TApp>
        where TApp : DaApp<int, int?, TAppAttribute, TFeature, TAppFeature, TSubscriptionApp, TSubscriptionPlanApp, TUserAgreement>
        where TAppAttribute : DaAppAttribute<int, TApp>
        where TAppFeature : DaAppFeature<int, TApp, TFeature>
        where TBillingCycleOption : DaBillingCycleOption<int, int?, TSubscriptionPlan>
        where TFeatureAction : DaFeatureAction<int, int?, TFeature>
        where TFeatureManager : DaFeatureManager<int, int?, TFeature>
        where TFeature : DaFeature<int, int?, TApp, TAppFeature, TFeatureAction, TSubscriptionFeature, TSubscriptionPlanFeature>
        where TSubscriptionAppRole : DaSubscriptionAppRole<int, TSubscriptionApp>
        where TSubscriptionApp : DaSubscriptionApp<int, int?, TApp, TSubscriptionAppRole, TSubscription, TSubscriptionAppUser>
        where TSubscriptionAppUser : DaSubscriptionAppUser<int, TSubscriptionApp>
        where TSubscriptionFeatureAttribute : DaSubscriptionFeatureAttribute<int, TSubscriptionFeature>
        where TSubscriptionFeatureRoleAction : DaSubscriptionFeatureRoleAction<int, TSubscriptionFeatureRole>
        where TSubscriptionFeatureRole : DaSubscriptionFeatureRole<int, TSubscriptionFeatureRoleAction, TSubscriptionFeature>
        where TSubscriptionFeature : DaSubscriptionFeature<int, int?, TFeature, TSubscriptionFeatureAttribute, TSubscriptionFeatureRole, TSubscription, TSubscriptionFeatureUser>
        where TSubscriptionFeatureUserAction : DaSubscriptionFeatureUserAction<int, TSubscriptionFeatureUser>
        where TSubscriptionFeatureUser : DaSubscriptionFeatureUser<int, int?, TSubscriptionFeature, TSubscriptionFeatureUserAction>
        where TSubscriptionPlanManager : DaSubscriptionPlanManager<int, int?, TSubscriptionPlan>
        where TSubscriptionPlanApp : DaSubscriptionPlanApp<int, int?, TApp, TSubscriptionPlan>
        where TSubscriptionPlanFeatureAttribute : DaSubscriptionPlanFeatureAttribute<int, TSubscriptionPlanFeature>
        where TSubscriptionPlanFeature : DaSubscriptionPlanFeature<int, int?, TFeature, TSubscriptionPlanFeatureAttribute, TSubscriptionPlan>
        where TSubscriptionPlan : DaSubscriptionPlan<int, int?, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscription>
        where TSubscriptionPlanAttribute : DaSubscriptionPlanAttribute<int, int?, TSubscriptionPlan>
        where TSubscription : DaSubscription<int, int?, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionPlan, TBillingCycle>, new()
        where TBillingCycle : DaBillingCycle<int, int?, TBillingCycleAttribute, TSubscription>
        where TBillingCycleAttribute : DaBillingCycleAttribute<int, int?, TBillingCycle>
        where TSubscriptionAttribute : DaSubscriptionAttribute<int, int?, TSubscription>
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
        public DaSubscriptionPlanFacade(TAppManager appManager, TFeatureManager featureManager, TUserAgreementManager userAgreementManager, TSubscriptionPlanManager subscriptionPlanManager, TCurrencyManager currencyManager, TCountryManager countryManager, TTimeZoneManager timeZoneManager, TSystemLanguageManager systemLanguageManager)
            : base(appManager, featureManager, userAgreementManager, subscriptionPlanManager, currencyManager, countryManager, timeZoneManager, systemLanguageManager)
        {
        }
    }

    public class DaSubscriptionPlanFacade<TKey, TNullableKey, TSubscriptionPlanInfo, TBillingCycleCycleInfo, TAppInfo, TAppFeatureInfo, TDaAppFeatureAttributeInfo, TUserAgreementManager, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction, TAppManager, TApp, TAppAttribute, TFeatureManager, TFeature, TAppFeature, TFeatureAction, TSubscriptionPlanManager, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TCurrencyManager, TCurrency, TCountryManager, TCountry, TCountryRegion, TTimeZoneManager, TTimeZone, TSystemLanguageManager, TSystemLanguage>
        where TKey : IEquatable<TKey>
        where TSubscriptionPlanInfo : DaSubscriptionPlanInfo<TKey, TNullableKey, TBillingCycleCycleInfo, TAppInfo, TAppFeatureInfo, TDaAppFeatureAttributeInfo>, new()
        where TBillingCycleCycleInfo : DaBillingCycleInfo<TKey>, new()
        where TAppInfo : DaAppInfo<TKey, TAppFeatureInfo, TDaAppFeatureAttributeInfo>, new()
        where TAppFeatureInfo : DaAppFeatureInfo<TKey, TDaAppFeatureAttributeInfo>, new()
        where TDaAppFeatureAttributeInfo : DaAppFeatureAttributeInfo<TKey>, new()
        where TAppManager : DaAppManager<TKey, TApp>
        where TApp : DaApp<TKey, TNullableKey, TAppAttribute, TFeature, TAppFeature, TSubscriptionApp, TSubscriptionPlanApp, TUserAgreement>
        where TAppAttribute : DaAppAttribute<TKey, TApp>
        where TAppFeature : DaAppFeature<TKey, TApp, TFeature>
        where TBillingCycleOption : DaBillingCycleOption<TKey, TNullableKey, TSubscriptionPlan>
        where TFeatureAction : DaFeatureAction<TKey, TNullableKey, TFeature>
        where TFeatureManager : DaFeatureManager<TKey, TNullableKey, TFeature>
        where TFeature : DaFeature<TKey, TNullableKey, TApp, TAppFeature, TFeatureAction, TSubscriptionFeature, TSubscriptionPlanFeature>
        where TSubscriptionAppRole : DaSubscriptionAppRole<TKey, TSubscriptionApp>
        where TSubscriptionApp : DaSubscriptionApp<TKey, TNullableKey, TApp, TSubscriptionAppRole, TSubscription, TSubscriptionAppUser>
        where TSubscriptionAppUser : DaSubscriptionAppUser<TKey, TSubscriptionApp>
        where TSubscriptionFeatureAttribute : DaSubscriptionFeatureAttribute<TKey, TSubscriptionFeature>
        where TSubscriptionFeatureRoleAction : DaSubscriptionFeatureRoleAction<TKey, TSubscriptionFeatureRole>
        where TSubscriptionFeatureRole : DaSubscriptionFeatureRole<TKey, TSubscriptionFeatureRoleAction, TSubscriptionFeature>
        where TSubscriptionFeature : DaSubscriptionFeature<TKey, TNullableKey, TFeature, TSubscriptionFeatureAttribute, TSubscriptionFeatureRole, TSubscription, TSubscriptionFeatureUser>
        where TSubscriptionFeatureUserAction : DaSubscriptionFeatureUserAction<TKey, TSubscriptionFeatureUser>
        where TSubscriptionFeatureUser : DaSubscriptionFeatureUser<TKey, TNullableKey, TSubscriptionFeature, TSubscriptionFeatureUserAction>
        where TSubscriptionPlanManager : DaSubscriptionPlanManager<TKey, TNullableKey, TSubscriptionPlan>
        where TSubscriptionPlanApp : DaSubscriptionPlanApp<TKey, TNullableKey, TApp, TSubscriptionPlan>
        where TSubscriptionPlanFeatureAttribute : DaSubscriptionPlanFeatureAttribute<TKey, TSubscriptionPlanFeature>
        where TSubscriptionPlanFeature : DaSubscriptionPlanFeature<TKey, TNullableKey, TFeature, TSubscriptionPlanFeatureAttribute, TSubscriptionPlan>
        where TSubscriptionPlan : DaSubscriptionPlan<TKey, TNullableKey, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscription>
        where TSubscriptionPlanAttribute : DaSubscriptionPlanAttribute<TKey, TNullableKey, TSubscriptionPlan>
        where TSubscription : DaSubscription<TKey, TNullableKey, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionPlan, TBillingCycle>, new()
        where TBillingCycle : DaBillingCycle<TKey, TNullableKey, TBillingCycleAttribute, TSubscription>
        where TBillingCycleAttribute : DaBillingCycleAttribute<TKey, TNullableKey, TBillingCycle>
        where TSubscriptionAttribute: DaSubscriptionAttribute<TKey, TNullableKey, TSubscription>
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
        private TSubscriptionPlanManager _subscriptionPlanManager;
        private TCurrencyManager _currencyManager;
        private TCountryManager _countryManager;
        private TTimeZoneManager _timeZoneManager;
        private TSystemLanguageManager _systemLanguageManager;

        public DaSubscriptionPlanFacade(TAppManager appManager, TFeatureManager featureManager, TUserAgreementManager userAgreementManager, TSubscriptionPlanManager subscriptionPlanManager, TCurrencyManager currencyManager, TCountryManager countryManager, TTimeZoneManager timeZoneManager, TSystemLanguageManager systemLanguageManager)
        {
            _appManager = appManager ?? throw new ArgumentNullException(nameof(appManager));
            _featureManager = featureManager ?? throw new ArgumentNullException(nameof(featureManager));
            _userAgreementManager = userAgreementManager ?? throw new ArgumentNullException(nameof(userAgreementManager));
            _subscriptionPlanManager = subscriptionPlanManager ?? throw new ArgumentNullException(nameof(subscriptionPlanManager));
            _currencyManager = currencyManager ?? throw new ArgumentNullException(nameof(currencyManager));
            _countryManager = countryManager ?? throw new ArgumentNullException(nameof(countryManager));
            _timeZoneManager = timeZoneManager ?? throw new ArgumentNullException(nameof(timeZoneManager));
            _systemLanguageManager = systemLanguageManager ?? throw new ArgumentNullException(nameof(systemLanguageManager));
        }

        public List<TSubscriptionPlanInfo> GetSubscriptionPlans()
        {
            return DaAsyncHelper.RunSync<List<TSubscriptionPlanInfo>>(() => GetSubscriptionPlansAsync());
        }

        public virtual async Task<List<TSubscriptionPlanInfo>> GetSubscriptionPlansAsync()
        {
            var subscriptionPlans = await _subscriptionPlanManager.FindAllAsync();

            if (subscriptionPlans == null || subscriptionPlans.Count <= 0)
            {
                throw new InvalidOperationException(Resources.InvalidSubscriptionPlan);
            }

            var result = new List<TSubscriptionPlanInfo>();

            foreach (var subscriptionPlan in subscriptionPlans)
            {
                var subscriptionPlanInfo = new TSubscriptionPlanInfo();
                subscriptionPlanInfo.Id = subscriptionPlan.Id;
                subscriptionPlanInfo.IsFeatured = subscriptionPlan.IsFeatured;
                subscriptionPlanInfo.Code = subscriptionPlan.Code;
                subscriptionPlanInfo.Description = subscriptionPlan.Description;
                subscriptionPlanInfo.Name = subscriptionPlan.Name;
                subscriptionPlanInfo.CurrencyId = subscriptionPlan.CurrencyId;
                subscriptionPlanInfo.AllowTrial = subscriptionPlan.AllowTrial;
                subscriptionPlanInfo.StartOnlyWithTrial = subscriptionPlan.StartOnlyWithTrial;
                subscriptionPlanInfo.TrialDays = subscriptionPlan.TrialDays;
                subscriptionPlanInfo.DefaulTBillingCycleCycleId = subscriptionPlan.DefaultBillingCycleId;

                var billingCycles = subscriptionPlan.BillingCycleOptions.ToList();

                if(billingCycles != null & billingCycles.Count > 0)
                {
                    subscriptionPlanInfo.BillingCycles = new List<TBillingCycleCycleInfo>();

                    foreach (var billingCycle in billingCycles)
                    {
                        var billingCycleInfo = new TBillingCycleCycleInfo();
                        billingCycleInfo.Name = billingCycle.Name;
                        billingCycleInfo.Description = billingCycle.Description;
                        billingCycleInfo.Id = billingCycle.Id;
                        billingCycleInfo.Amount = billingCycle.Amount;
                        billingCycleInfo.BillingCycleDuration = billingCycle.BillingCycleDuration;
                        billingCycleInfo.BillingCycleType = billingCycle.BillingCycleType;
                        subscriptionPlanInfo.BillingCycles.Add(billingCycleInfo);
                    }
                }

                if (subscriptionPlan.SubscriptionPlanApps != null && subscriptionPlan.SubscriptionPlanApps.Count > 0)
                {
                    subscriptionPlanInfo.Apps = new List<TAppInfo>();

                    foreach (var spApp in subscriptionPlan.SubscriptionPlanApps)
                    {
                        var app = await _appManager.FindByIdAsync(spApp.AppId);

                        var appInfo = new TAppInfo();
                        appInfo.Id = app.Id;
                        appInfo.Name = app.Name;
                        appInfo.Key = app.Key;

                        if (subscriptionPlan.SubscriptionPlanFeatures != null && subscriptionPlan.SubscriptionPlanFeatures.Count > 0)
                        {
                            appInfo.Features = new List<TAppFeatureInfo>();

                            foreach (var feature in subscriptionPlan.SubscriptionPlanFeatures)
                            {
                                var featureInfo = new TAppFeatureInfo();
                                featureInfo.Id = feature.Feature.Id;
                                featureInfo.Name = feature.Feature.Name;
                                featureInfo.Key = feature.Feature.Key;

                                if (feature.SubscriptionPlanFeatureAttributes != null && feature.SubscriptionPlanFeatureAttributes.Count > 0)
                                {
                                    featureInfo.Attributes = new List<TDaAppFeatureAttributeInfo>();

                                    foreach (var attribute in feature.SubscriptionPlanFeatureAttributes)
                                    {
                                        var featureAttribute = new TDaAppFeatureAttributeInfo();
                                        featureAttribute.Id = attribute.Id;
                                        featureAttribute.Name = attribute.AttributeName;
                                        featureAttribute.Value = attribute.AttributeValue;
                                        featureInfo.Attributes.Add(featureAttribute);
                                    }
                                }

                                appInfo.Features.Add(featureInfo);
                            }
                        }

                        subscriptionPlanInfo.Apps.Add(appInfo);                        
                    }
                }

                result.Add(subscriptionPlanInfo);
            }

            return result;
        }
    }
}
