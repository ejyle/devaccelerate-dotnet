// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.EnterpriseSecurity.Apps;
using System;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans
{
    public class DaSubscriptionPlanApp : DaSubscriptionPlanApp<string, DaApp, DaSubscriptionPlan>        
    {
        public DaSubscriptionPlanApp() : base()
        { }
    }

    public class DaSubscriptionPlanApp<TKey, TApp, TSubscriptionPlan> : DaEntityBase<TKey>, IDaSubscriptionPlanApp<TKey>
        where TKey : IEquatable<TKey>
        where TApp : IDaApp<TKey>
        where TSubscriptionPlan : IDaSubscriptionPlan<TKey>
    {
        public TKey SubscriptionPlanId { get; set; }

        public TKey AppId { get; set; }

        public virtual TApp App { get; set; }

        public virtual TSubscriptionPlan SubscriptionPlan { get; set; }
    }
}
