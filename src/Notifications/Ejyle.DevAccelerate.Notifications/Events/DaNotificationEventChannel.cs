// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Notifications.Events
{
    public class DaNotificationEventChannel : DaNotificationEventChannel<string, DaNotificationEvent>
    {
        public DaNotificationEventChannel()
        { }
    }

    public class DaNotificationEventChannel<TKey, TNotificationEvent> : DaEntityBase<TKey>, IDaNotificationEventChannel<TKey>
        where TKey : IEquatable<TKey>
        where TNotificationEvent : IDaNotificationEvent<TKey>
    {
        public DaNotificationChannel Channel { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Format { get; set; }
        public TKey NotificationEventDefinitionChannelId { get; set; }
        public TKey NotificationEventId { get; set; }
        public virtual TNotificationEvent NotificationEvent { get; set; }
    }
}
