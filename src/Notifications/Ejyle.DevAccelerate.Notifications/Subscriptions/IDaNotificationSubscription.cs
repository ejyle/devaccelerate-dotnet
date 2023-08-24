// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Notifications.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Notifications.Subscriptions
{
    public interface IDaNotificationSubscription<TKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey NotificationEventDefinitionId { get; set; }
        DaNotificationChannel? Channel { get; set; }
        string UserId { get; set; }
        bool IsSubscribed { get; set; }
    }
}
