// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans
{
    public interface IDaSubscriptionPlan<TKey, TNullableKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string Name { get; set; }
        string Description { get; set; }
        string Code { get; set; }
        bool IsAutoRenewUntilCanceled { get; set; }
        int? ValidityInMonths { get; set; }
        bool IsFeatured { get; set; }
        double? SetupFee { get; set; }
        TKey CurrencyId { get; set; }
        bool AllowTrial { get; set; }
        bool StartOnlyWithTrial { get; set; }
        int? TrialDays { get; set; }
        int Level { get; set; }
        bool IsFree { get; set; }
        DaEntityWorkflowStatus Status { get; set; }
        TNullableKey UserAgreementVersionId { get; set; }
        TNullableKey DefaultBillingCycleId { get; set; }
        DateTime? PublishedDateUtc { get; set; }
    }
}
