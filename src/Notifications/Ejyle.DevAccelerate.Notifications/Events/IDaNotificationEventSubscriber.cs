// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Notifications.Delivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Notifications.Events
{
    public interface IDaNotificationEventSubscriber<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey NotificationEventId { get; set; }
        string SubscriberName { get; set; }
        string SubscriberAddress { get; set; }
        bool IsNotificationCreated { get; set; }
        string UserId { get; set; }
    }
}
