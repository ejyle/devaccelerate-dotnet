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
    public interface IDaBillingCycle<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string Name { get; set; }
        string Description { get; set; }
        DaBillingCycleType BillingCycleType { get; set; }
        int BillingCycleDuration { get; set; }
        decimal Amount { get; set; }
        bool AllowTrial { get; set; }
        bool StartOnlyWithTrial { get; set; }
        int? TrialDays { get; set; }
    }
}
