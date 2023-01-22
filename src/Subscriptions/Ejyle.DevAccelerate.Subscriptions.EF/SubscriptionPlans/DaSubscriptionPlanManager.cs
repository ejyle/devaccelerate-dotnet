// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Subscriptions.SubscriptionPlans;

namespace Ejyle.DevAccelerate.Subscriptions.EF.SubscriptionPlans
{
    public class DaSubscriptionPlanManager : DaSubscriptionPlanManager<string, DaSubscriptionPlan>
    {
        public DaSubscriptionPlanManager(DaSubscriptionPlanRepository repository)
            : base(repository)
        { }
    }
}
