// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Notifications
{
    public class DaNotificationRecipient : DaNotificationRecipient<string, DaNotification, DaNotificationRecipientVariable>
    {
        public DaNotificationRecipient()
        { }
    }

    public class DaNotificationRecipient<TKey, TNotification, TNotificationRecipientVariable> : DaEntityBase<TKey>, IDaNotificationRecipient<TKey>
        where TKey : IEquatable<TKey>
        where TNotification : IDaNotification<TKey>
        where TNotificationRecipientVariable : IDaNotificationRecipientVariable<TKey>
    {
        public DaNotificationRecipient()
        {
            Variables = new HashSet<TNotificationRecipientVariable>();
        }

        public virtual ICollection<TNotificationRecipientVariable> Variables
        {
            get;
            set;
        }

        public virtual TNotification Notification
        {
            get;
            set;
        }
        public TKey NotificationId { get; set; }
        public string RecipientName { get; set; }
        public string RecipientAddress { get; set; }
        public DaNotificationStatus Status { get; set; }
        public string FailureMessage { get; set; }
        public int AttemptCount { get; set; }
        public string UserId { get; set; }
    }
}
