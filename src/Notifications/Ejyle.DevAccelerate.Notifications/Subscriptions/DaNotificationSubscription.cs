// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Notifications.EventDefinitions;
using Ejyle.DevAccelerate.Notifications.Events;

namespace Ejyle.DevAccelerate.Notifications.Subscriptions
{
    public class DaNotificationSubscription : DaNotificationSubscription<string>
    { }

    public class DaNotificationSubscription<TKey> : DaAuditedEntityBase<TKey>, IDaNotificationSubscription<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey NotificationEventDefinitionId { get; set; }
        public DaNotificationChannel? Channel { get; set; }
        public string UserId { get; set; }
        public bool IsSubscribed { get; set; }
    }
}
