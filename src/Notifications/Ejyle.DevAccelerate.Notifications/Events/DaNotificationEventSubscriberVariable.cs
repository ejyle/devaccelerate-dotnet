// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Notifications.Events
{
    public class DaNotificationEventSubscriberVariable : DaNotificationEventSubscriberVariable<string, DaNotificationEventSubscriber>
    { }

    public class DaNotificationEventSubscriberVariable<TKey, TNotificationEventSubscriber> : DaEntityBase<TKey>, IDaNotificationEventSubscriberVariable<TKey>
        where TKey : IEquatable<TKey>
        where TNotificationEventSubscriber : IDaNotificationEventSubscriber<TKey>
    {
        public virtual TNotificationEventSubscriber NotificationEventSubscriber
        {
            get;
            set;
        }
        public TKey NotificationEventSubscriberId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool ForSubject { get; set; }
        public bool ForNotification { get; set; }
    }
}
