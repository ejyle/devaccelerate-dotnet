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

namespace Ejyle.DevAccelerate.Notifications.Events
{
    public class DaNotificationEventSubscriber : DaNotificationEventSubscriber<string, DaNotificationEvent, DaNotificationEventSubscriberVariable>
    {
        public DaNotificationEventSubscriber()
        { }
    }

    public class DaNotificationEventSubscriber<TKey, TNotificationEvent, TNotificationEventSubscriberVariable> : DaEntityBase<TKey>, IDaNotificationEventSubscriber<TKey>
        where TKey : IEquatable<TKey>
        where TNotificationEvent : IDaNotificationEvent<TKey>
        where TNotificationEventSubscriberVariable : IDaNotificationEventSubscriberVariable<TKey>
    {
        public DaNotificationEventSubscriber()
        {
            Variables = new HashSet<TNotificationEventSubscriberVariable>();
        }

        public virtual ICollection<TNotificationEventSubscriberVariable> Variables
        {
            get;
            set;
        }

        public virtual TNotificationEvent NotificationEvent
        {
            get;
            set;
        }
        public TKey NotificationEventId { get; set; }
        public string SubscriberName { get; set; }
        public string SubscriberAddress { get; set; }
        public bool IsNotificationCreated { get; set; }
        public string UserId { get; set; }
    }
}
