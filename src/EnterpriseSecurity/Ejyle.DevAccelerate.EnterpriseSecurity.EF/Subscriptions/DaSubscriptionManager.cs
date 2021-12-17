// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.EF.Subscriptions
{
    public class DaSubscriptionManager : DaSubscriptionManager<int, int?, DaSubscription>
    {
        public DaSubscriptionManager(DaSubscriptionRepository repository)
            : base(repository)
        { }
    }
}
