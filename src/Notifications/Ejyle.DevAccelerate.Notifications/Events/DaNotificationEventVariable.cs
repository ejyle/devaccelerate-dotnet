// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace Ejyle.DevAccelerate.Notifications.Events
{
    public class DaNotificationEventVariable : DaNotificationEventVariable<string, DaNotificationEvent>
    { }

    public class DaNotificationEventVariable<TKey, TNotificationEvent> : DaEntityBase<TKey>, IDaNotificationEventVariable<TKey>
        where TKey : IEquatable<TKey>
        where TNotificationEvent : IDaNotificationEvent<TKey>
    {
        public virtual TNotificationEvent NotificationEvent
        {
            get;
            set;
        }
        public TKey NotificationEventId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool ForSubject { get; set; }
        public bool ForNotification { get; set; }
    }
}
