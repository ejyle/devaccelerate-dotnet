// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions
{
    public interface IDaSubscription<TKey, TNullableKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string Name { get; set; }
        bool IsActive { get; set; }
        TKey CurrencyId { get; set; }
        TKey CountryId { get; set; }
        decimal BillingAmount { get; set; }
        TKey SubscriptionPlanId { get; set; }
        DateTime? TrialPeriodStartDateUtc { get; set; }
        DateTime? TrialPeriodEndDateUtc { get; set; }
        bool IsCurrentlyInTrial { get; set; }
        DaBillingCycleType? BillingCycleType { get; set; }
        int Level { get; set; }
        bool IsFree { get; set; }
        DateTime StartDateUtc { get; set; }
        bool IsAutoRenewUntilCanceled { get; set; }
        TKey TenantId { get; set; }
        TNullableKey UserAgreementVersionId { get; set; }
        TKey OwnerUserId { get; set; }
        TNullableKey LastTransactionId { get; set; }
        TNullableKey LastPaymentMethodId { get; set; }
        string ReferenceNumber { get; set; }
        DateTime? NextBillingDateUtc { get; set; }
        DateTime? TrialStartDateUtc { get; set; }
        DateTime? ExpiryDateUtc { get; set; }
        DateTime CreatedDateUtc { get; set; }
        DateTime LastUpdatedDateUtc { get; set; }
    }
}
