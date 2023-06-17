// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Notifications.Requests
{
    public class DaNotificationRequestRecipientVariable : DaNotificationRequestRecipientVariable<string, DaNotificationRequestRecipient>
    { }

    public class DaNotificationRequestRecipientVariable<TKey, TNotificationRequestRecipient> : DaEntityBase<TKey>, IDaNotificationRequestRecipientVariable<TKey>
        where TKey : IEquatable<TKey>
        where TNotificationRequestRecipient : IDaNotificationRequestRecipient<TKey>
    {
        public virtual TNotificationRequestRecipient NotificationRequestRecipient
        {
            get;
            set;
        }
        public TKey NotificationRequestRecipientId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool ForSubject { get; set; }
        public bool ForNotification { get; set; }
    }
}
