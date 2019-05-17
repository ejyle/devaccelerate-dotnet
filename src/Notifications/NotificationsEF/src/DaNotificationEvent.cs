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
    public class DaNotificationEvent : DaNotificationEvent<int, DaNotificationEventSubscriber>
    {
        public DaNotificationEvent() : base()
        { }
    }

    public class DaNotificationEvent<TKey, TDaNotificationEventSubscriber> : DaEntityBase<TKey>, IDaNotificationEvent<TKey>
        where TKey : IEquatable<TKey>
        where TDaNotificationEventSubscriber : IDaNotificationEventSubscriber<TKey>
    {
        public DaNotificationEvent() : base()
        {
            EventSubscribers = new HashSet<TDaNotificationEventSubscriber>();
        }

        [StringLength(256)]
        public string EventKey { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<TDaNotificationEventSubscriber> EventSubscribers { get; set; }
    }
}
