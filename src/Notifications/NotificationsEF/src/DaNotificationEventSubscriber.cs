// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Notifications.EF
{
    public class DaNotificationEventSubscriber : DaNotificationEventSubscriber<int, DaNotificationEvent, DaNotificationSubscriber, DaNotificationSubscriberDestination>
    { }

    public class DaNotificationEventSubscriber<TKey, TNotificationEvent, TNotificationSubscriber, TNotificationSubscriberChannelDestination>
        : DaEntityBase<TKey>, IDaNotificationEventSubscriber<TKey>
        where TKey : IEquatable<TKey>
        where TNotificationSubscriber : IDaNotificationSubscriber<TKey>
        where TNotificationEvent : IDaNotificationEvent<TKey>
        where TNotificationSubscriberChannelDestination : IDaNotificationSubscriberDestination<TKey>
    {
        [Required]
        public TKey SubscriberId { get; set; }

        public virtual TNotificationSubscriber Subscriber { get; set; }

        [Required]
        public TKey EventId { get; set; }

        public virtual TNotificationEvent Event { get; set; }

        [Required]
        public TKey SubscriberChannelDestinationId { get; set; }

        public virtual TNotificationSubscriberChannelDestination SubscriberChannelDestination { get; set; }

        [Required]
        public bool? IsActive { get; set; }        
    }
}
