// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ejyle.DevAccelerate.Notifications.EF
{
    public class DaNotificationSubscriber : DaNotificationSubscriber<int, DaNotificationEventSubscriber, DaNotificationSubscriberDestination>
    {
        public DaNotificationSubscriber() : base()
        { }
    }

    public class DaNotificationSubscriber<TKey, TNotificationEventSubscriber, TNotificationSubscriberDestination> : DaEntityBase<TKey>, IDaNotificationSubscriber<TKey>
        where TKey : IEquatable<TKey>
        where TNotificationEventSubscriber : IDaNotificationEventSubscriber<TKey>
        where TNotificationSubscriberDestination : IDaNotificationSubscriberDestination<TKey>
    {
        public DaNotificationSubscriber() : base()
        {
            EventSubscribers = new HashSet<TNotificationEventSubscriber>();
            Destinations = new HashSet<TNotificationSubscriberDestination>();
        }

        [Required]
        public TKey UserId { get; set; }

        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public virtual ICollection<TNotificationSubscriberDestination> Destinations { get; set; }

        public virtual ICollection<TNotificationEventSubscriber> EventSubscribers { get; set; }
    }
}
