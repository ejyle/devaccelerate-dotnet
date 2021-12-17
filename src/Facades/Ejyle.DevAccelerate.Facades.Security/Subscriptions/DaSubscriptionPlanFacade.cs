// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF.SubscriptionPlans;
using Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans;
using Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions;
using Ejyle.DevAccelerate.EnterpriseSecurity.Apps;
using Ejyle.DevAccelerate.EnterpriseSecurity.UserAgreements;
using System.Collections.Generic;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF.Apps;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Facades.Security.Properties;

namespace Ejyle.DevAccelerate.Facades.Security.Subscriptions
{
    public class DaSubscriptionPlanFacade 
        : DaSubscriptionPlanFacade<int, int?, DaSubscriptionPlanInfo, DaBillingCycleInfo, DaAppInfo, DaAppFeatureInfo, DaAppFeatureAttributeInfo, DaUserAgreement, DaUserAgreementVersion, DaUserAgreementVersionAction, DaAppManager, DaApp, DaAppAttribute, DaFeatureManager, DaFeature, DaAppFeature, DaFeatureAction, DaSubscriptionPlanManager, DaSubscriptionPlan, DaSubscriptionPlanAttribute, DaBillingCycleOption, DaSubscriptionPlanApp, DaSubscriptionPlanFeature, DaSubscriptionPlanFeatureAttribute, DaSubscription, DaSubscriptionAttribute, DaSubscriptionApp, DaSubscriptionFeature, DaSubscriptionFeatureAttribute, DaSubscriptionAppRole, DaSubscriptionAppUser, DaSubscriptionFeatureRole, DaSubscriptionFeatureRoleAction, DaSubscriptionFeatureUser, DaSubscriptionFeatureUserAction, DaBillingCycle, DaBillingCycleAttribute, DaBillingCycleFeatureUsage>
    {
        public DaSubscriptionPlanFacade(DaAppManager appManager, DaSubscriptionPlanManager subscriptionPlanManager)
            : base(appManager, subscriptionPlanManager)
        {
        }
    }

    public class DaSubscriptionPlanFacade<TKey, TNullableKey, TSubscriptionPlanInfo, TBillingCycleCycleInfo, TAppInfo, TAppFeatureInfo, TDaAppFeatureAttributeInfo, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction, TAppManager, TApp, TAppAttribute, TFeatureManager, TFeature, TAppFeature, TFeatureAction, TSubscriptionPlanManager, TSubscriptionPlan, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscriptionPlanFeatureAttribute, TSubscription, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionFeatureAttribute, TSubscriptionAppRole, TSubscriptionAppUser, TSubscriptionFeatureRole, TSubscriptionFeatureRoleAction, TSubscriptionFeatureUser, TSubscriptionFeatureUserAction, TBillingCycle, TBillingCycleAttribute, TBillingCycleFeatureUsage>
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
        where TSubscriptionFeature : DaSubscriptionFeature<TKey, TNullableKey, TFeature, TSubscriptionFeatureAttribute, TSubscriptionFeatureRole, TSubscription, TSubscriptionFeatureUser, TBillingCycleFeatureUsage>
        where TSubscriptionFeatureUserAction : DaSubscriptionFeatureUserAction<TKey, TSubscriptionFeatureUser>
        where TSubscriptionFeatureUser : DaSubscriptionFeatureUser<TKey, TNullableKey, TSubscriptionFeature, TSubscriptionFeatureUserAction>
        where TSubscriptionPlanManager : DaSubscriptionPlanManager<TKey, TNullableKey, TSubscriptionPlan>
        where TSubscriptionPlanApp : DaSubscriptionPlanApp<TKey, TNullableKey, TApp, TSubscriptionPlan>
        where TSubscriptionPlanFeatureAttribute : DaSubscriptionPlanFeatureAttribute<TKey, TSubscriptionPlanFeature>
        where TSubscriptionPlanFeature : DaSubscriptionPlanFeature<TKey, TNullableKey, TFeature, TSubscriptionPlanFeatureAttribute, TSubscriptionPlan>
        where TSubscriptionPlan : DaSubscriptionPlan<TKey, TNullableKey, TSubscriptionPlanAttribute, TBillingCycleOption, TSubscriptionPlanApp, TSubscriptionPlanFeature, TSubscription>
        where TSubscriptionPlanAttribute : DaSubscriptionPlanAttribute<TKey, TNullableKey, TSubscriptionPlan>
        where TSubscription : DaSubscription<TKey, TNullableKey, TSubscriptionAttribute, TSubscriptionApp, TSubscriptionFeature, TSubscriptionPlan, TBillingCycle>, new()
        where TBillingCycle : DaBillingCycle<TKey, TNullableKey, TBillingCycleAttribute, TSubscription, TBillingCycleFeatureUsage>
        where TBillingCycleAttribute : DaBillingCycleAttribute<TKey, TNullableKey, TBillingCycle>
        where TBillingCycleFeatureUsage : DaBillingCycleFeatureUsage<TKey, TNullableKey, TBillingCycle, TSubscriptionFeature>
        where TSubscriptionAttribute: DaSubscriptionAttribute<TKey, TNullableKey, TSubscription>
        where TUserAgreement : DaUserAgreement<TKey, TNullableKey, TApp, TUserAgreementVersion>
        where TUserAgreementVersion : DaUserAgreementVersion<TKey, TNullableKey, TUserAgreement, TUserAgreementVersionAction>
        where TUserAgreementVersionAction : DaUserAgreementVersionAction<TKey, TUserAgreementVersion>
    {
        public DaSubscriptionPlanFacade(TAppManager appManager, TSubscriptionPlanManager subscriptionPlanManager)
        {
            AppManager = appManager ?? throw new ArgumentNullException(nameof(appManager));
            SubscriptionPlanManager = subscriptionPlanManager ?? throw new ArgumentNullException(nameof(subscriptionPlanManager));
        }

        public TAppManager AppManager
        {
            get;
            private set;
        }

        public TSubscriptionPlanManager SubscriptionPlanManager
        {
            get;
            private set;
        }

        public List<TSubscriptionPlanInfo> GetSubscriptionPlans()
        {
            return DaAsyncHelper.RunSync<List<TSubscriptionPlanInfo>>(() => GetSubscriptionPlansAsync());
        }

        public virtual async Task<List<TSubscriptionPlanInfo>> GetSubscriptionPlansAsync()
        {
            var subscriptionPlans = await SubscriptionPlanManager.FindAllAsync();

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
                subscriptionPlanInfo.DefaulBillingCycleCycleId = subscriptionPlan.DefaultBillingCycleId;

                var billingCycles = subscriptionPlan.BillingCycleOptions.ToList();

                if(billingCycles != null & billingCycles.Count > 0)
                {
                    subscriptionPlanInfo.BillingCycleOptions = new List<TBillingCycleCycleInfo>();

                    foreach (var billingCycle in billingCycles)
                    {
                        var billingCycleInfo = new TBillingCycleCycleInfo();
                        billingCycleInfo.Name = billingCycle.Name;
                        billingCycleInfo.Description = billingCycle.Description;
                        billingCycleInfo.Id = billingCycle.Id;
                        billingCycleInfo.Amount = billingCycle.Amount;
                        billingCycleInfo.BillingCycleType = billingCycle.BillingInterval;
                        subscriptionPlanInfo.BillingCycleOptions.Add(billingCycleInfo);
                    }
                }

                if (subscriptionPlan.SubscriptionPlanApps != null && subscriptionPlan.SubscriptionPlanApps.Count > 0)
                {
                    subscriptionPlanInfo.Apps = new List<TAppInfo>();

                    foreach (var spApp in subscriptionPlan.SubscriptionPlanApps)
                    {
                        var app = await AppManager.FindByIdAsync(spApp.AppId);

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
