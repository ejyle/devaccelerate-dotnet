// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.EnterpriseSecurity;
using Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans;

namespace Ejyle.DevAccelerate.Facades.Security.Subscriptions
{
    public interface IDaSubscriptionPlanInfo<TKey, TNullableKey, TBillingCycleCycleOptionInfo, TAppInfo, TAppFeatureInfo, TAppFeatureAttributeInfo>
        where TKey : IEquatable<TKey>
        where TBillingCycleCycleOptionInfo : IDaBillingCycleOptionInfo<TKey>
        where TAppInfo : IDaAppInfo<TKey, TAppFeatureInfo, TAppFeatureAttributeInfo>
        where TAppFeatureInfo : IDaAppFeatureInfo<TKey, TAppFeatureAttributeInfo>
        where TAppFeatureAttributeInfo : IDaAppFeatureAttributeInfo<TKey>
    {
        TKey Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Code { get; set; }
        TKey CurrencyId { get; set; }
        bool IsAutoRenewUntilCanceled { get; set; }
        bool IsFeatured { get; set; }
        int? NumberOfBillingCyclesUntilExpiry { get; set; }
        List<TBillingCycleCycleOptionInfo> BillingCycleOptions { get; set; }
        bool AllowTrial { get; set; }
        bool StartOnlyWithTrial { get; set; }
        int? TrialDays { get; set; }
        decimal? SetupFee { get; set; }
        TNullableKey DefaulBillingCycleCycleId { get; set; }
        List<TAppInfo> Apps { get; set; }
    }

    public interface IDaBillingCycleOptionInfo<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        DaBillingCycleType BillingCycleType { get; set; }
        int BillingCycleDuration { get; set; }
        decimal Amount { get; set; }
    }

    public interface IDaAppInfo<TKey, TAppFeature, TAppFeatureAttributeInfo>
        where TKey : IEquatable<TKey>
        where TAppFeature : IDaAppFeatureInfo<TKey, TAppFeatureAttributeInfo>
        where TAppFeatureAttributeInfo : IDaAppFeatureAttributeInfo<TKey>
    {
        TKey Id { get; set; }
        string Name { get; set; }
        string Key { get; set; }
        string Description { get; set; }
        List<TAppFeature> Features { get; set; }
    }

    public interface IDaAppFeatureInfo<TKey, TAppFeatureAttributeInfo>
        where TKey : IEquatable<TKey>
        where TAppFeatureAttributeInfo : IDaAppFeatureAttributeInfo<TKey>
    {
        TKey Id { get; set; }
        string Name { get; set; }
        string Key { get; set; }
        List<TAppFeatureAttributeInfo> Attributes { get; set; }
    }

    public interface IDaAppFeatureAttributeInfo<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
        string Name { get; set; }
        string Value { get; set; }
    }
}
