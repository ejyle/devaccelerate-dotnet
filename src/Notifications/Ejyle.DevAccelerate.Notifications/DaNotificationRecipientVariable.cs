// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Notifications
{
    public class DaNotificationRecipientVariable : DaNotificationRecipientVariable<string, DaNotificationRecipient>
    { }

    public class DaNotificationRecipientVariable<TKey, TNotificationRecipient> : DaEntityBase<TKey>, IDaNotificationRecipientVariable<TKey>
        where TKey : IEquatable<TKey>
        where TNotificationRecipient : IDaNotificationRecipient<TKey>
    {
        public virtual TNotificationRecipient NotificationRecipient
        {
            get;
            set;
        }
        public TKey NotificationRecipientId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool ForSubject { get; set; }
        public bool ForNotification { get; set; }
    }
}
