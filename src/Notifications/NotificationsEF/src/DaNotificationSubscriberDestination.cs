// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Notifications.EF
{
    public class DaNotificationSubscriberDestination : DaNotificationSubscriberDestination<int, DaNotificationSubscriber, DaNotificationEventSubscriber>
    {
        public DaNotificationSubscriberDestination() : base()
        { }
    }

    public class DaNotificationSubscriberDestination<TKey, TNotificationSubscriber, TDaNotificationEventSubscriber> : DaEntityBase<TKey>, IDaNotificationSubscriberDestination<TKey>
        where TKey : IEquatable<TKey>
        where TDaNotificationEventSubscriber : IDaNotificationEventSubscriber<TKey>
    {
        public DaNotificationSubscriberDestination() : base()
        {
            EventSubscribers = new HashSet<TDaNotificationEventSubscriber>();
        }

        [Required]
        public TKey SubscriberId { get; set; }

        public virtual TNotificationSubscriber Subscriber { get; set; }

        [Required]
        public DaNotificationChannel Channel { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public virtual ICollection<TDaNotificationEventSubscriber> EventSubscribers { get; set; }
    }
}
