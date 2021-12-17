// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans;

namespace Ejyle.DevAccelerate.Facades.Security.Subscriptions
{
    public class DaSubscriptionPlanInfo : DaSubscriptionPlanInfo<int,int?, DaBillingCycleInfo, DaAppInfo, DaAppFeatureInfo, DaAppFeatureAttributeInfo>
    { }

    public class DaSubscriptionPlanInfo<TKey, TNullableKey, TBillingCycleOptionInfo, TAppInfo, TAppFeatureInfo, TDaAppFeatureAttributeInfo> : IDaSubscriptionPlanInfo<TKey, TNullableKey, TBillingCycleOptionInfo, TAppInfo, TAppFeatureInfo, TDaAppFeatureAttributeInfo>
        where TKey : IEquatable<TKey>
        where TBillingCycleOptionInfo : IDaBillingCycleOptionInfo<TKey>
        where TAppInfo : IDaAppInfo<TKey, TAppFeatureInfo, TDaAppFeatureAttributeInfo>
        where TAppFeatureInfo : IDaAppFeatureInfo<TKey, TDaAppFeatureAttributeInfo>
        where TDaAppFeatureAttributeInfo : IDaAppFeatureAttributeInfo<TKey>
    {
        public TKey Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public TKey CurrencyId { get; set; }
        public bool IsAutoRenewUntilCanceled { get; set; }
        public bool IsFeatured { get; set; }
        public int? NumberOfBillingCyclesUntilExpiry { get; set; }
        public List<TBillingCycleOptionInfo> BillingCycleOptions { get; set; }
        public bool AllowTrial { get; set; }
        public bool StartOnlyWithTrial { get; set; }
        public int? TrialDays { get; set; }
        public decimal? SetupFee { get; set; }
        public List<TAppInfo> Apps { get; set; }
        public TNullableKey DefaulBillingCycleCycleId { get; set; }
    }

    public class DaBillingCycleInfo : DaBillingCycleInfo<int>
    { }

    public class DaBillingCycleInfo<TKey> : IDaBillingCycleOptionInfo<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DaBillingInterval BillingCycleType { get; set; }
        public int BillingCycleDuration { get; set; }
        public decimal Amount { get; set; }
    }

    public class DaAppInfo : DaAppInfo<int, DaAppFeatureInfo, DaAppFeatureAttributeInfo>
    { }

    public class DaAppInfo<TKey, TAppFeatureInfo, TDaAppFeatureAttributeInfo> : IDaAppInfo<TKey, TAppFeatureInfo, TDaAppFeatureAttributeInfo>
        where TKey : IEquatable<TKey>
        where TAppFeatureInfo : IDaAppFeatureInfo<TKey, TDaAppFeatureAttributeInfo>
        where TDaAppFeatureAttributeInfo : IDaAppFeatureAttributeInfo<TKey>
    {
        public TKey Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public List<TAppFeatureInfo> Features { get; set; }
    }

    public class DaAppFeatureInfo : DaAppFeatureInfo<int, DaAppFeatureAttributeInfo>
    { }

    public class DaAppFeatureInfo<TKey, TDaAppFeatureAttributeInfo> : IDaAppFeatureInfo<TKey, TDaAppFeatureAttributeInfo>
        where TKey : IEquatable<TKey>
        where TDaAppFeatureAttributeInfo : IDaAppFeatureAttributeInfo<TKey>
    {
        public TKey Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public List<TDaAppFeatureAttributeInfo> Attributes { get; set; }
    }

    public class DaAppFeatureAttributeInfo : DaAppFeatureAttributeInfo<int>
    { }

    public class DaAppFeatureAttributeInfo<TKey> : IDaAppFeatureAttributeInfo<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
