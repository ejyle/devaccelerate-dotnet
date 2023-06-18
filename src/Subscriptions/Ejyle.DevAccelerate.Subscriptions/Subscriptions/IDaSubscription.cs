// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Subscriptions.SubscriptionPlans;

namespace Ejyle.DevAccelerate.Subscriptions.Subscriptions
{
    public interface IDaSubscription<TKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string Name { get; set; }
        bool IsActive { get; set; }
        string Currency { get; set; }
        string Country { get; set; }
        decimal BillingAmount { get; set; }
        TKey SubscriptionPlanId { get; set; }
        DateTime? TrialPeriodStartDateUtc { get; set; }
        DateTime? TrialPeriodEndDateUtc { get; set; }
        bool IsCurrentlyInTrial { get; set; }
        DaBillingInterval? BillingInterval { get; set; }
        DaBillingType BillingType { get; set; }
        int Level { get; set; }
        bool IsFree { get; set; }
        DateTime StartDateUtc { get; set; }
        bool IsAutoRenewUntilCanceled { get; set; }
        string TenantId { get; set; }
        string UserAgreementVersionId { get; set; }
        string OwnerUserId { get; set; }
        string LastTransactionId { get; set; }
        string LastPaymentMethodId { get; set; }
        string ReferenceNumber { get; set; }
        DateTime? NextBillingDateUtc { get; set; }
        DateTime? TrialStartDateUtc { get; set; }
        DateTime? ExpiryDateUtc { get; set; }
    }
}
