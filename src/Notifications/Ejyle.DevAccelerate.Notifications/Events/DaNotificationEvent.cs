// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Notifications.Delivery;

namespace Ejyle.DevAccelerate.Notifications.Events
{
    public class DaNotificationEvent : DaNotificationEvent<string, DaNotificationEventChannel, DaNotificationEventVariable, DaNotificationEventSubscriber>
    {
        public DaNotificationEvent()
        { }
    }

    public class DaNotificationEvent<TKey, TNotificationEventChannel, TNotificationEventVariable, TNotificationEventSubscriber> : DaAuditedEntityBase<TKey>, IDaNotificationEvent<TKey>
        where TKey : IEquatable<TKey>
        where TNotificationEventChannel : IDaNotificationEventChannel<TKey>
        where TNotificationEventVariable : IDaNotificationEventVariable<TKey>
        where TNotificationEventSubscriber : IDaNotificationEventSubscriber<TKey>
    {
        public DaNotificationEvent()
        {
            Variables = new HashSet<TNotificationEventVariable>();
            Subscribers = new HashSet<TNotificationEventSubscriber>();
            Channels = new HashSet<TNotificationEventChannel>();
        }

        public virtual ICollection<TNotificationEventVariable> Variables
        {
            get;
            set;
        }

        public virtual ICollection<TNotificationEventSubscriber> Subscribers
        {
            get;
            set;
        }

        public virtual ICollection<TNotificationEventChannel> Channels
        {
            get;
            set;
        }

        public TKey NotificationEventDefinitionId { get; set; }
        public DaNotificationLevel? Level { get; set; }
        public bool IsProcessingComplete { get; set; }
        public string VariableDelimiter { get; set; }
        public int SubscribersProcessedCount { get; set; }
        public int SubscribersCount { get; set; }
        public string ObjectIdentifier { get; set; }
    }
}
