// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Subscriptions.Subscriptions;

namespace Ejyle.DevAccelerate.Subscriptions.EF.Subscriptions
{
    public class DaSubscriptionManager : DaSubscriptionManager<string, DaSubscription>
    {
        public DaSubscriptionManager(DaSubscriptionRepository repository)
            : base(repository)
        { }
    }
}
