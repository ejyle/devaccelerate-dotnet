// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans
{
    public interface IDaSubscriptionPlanApp<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey SubscriptionPlanId { get; set; }
        TKey AppId { get; set; }
    }
}
