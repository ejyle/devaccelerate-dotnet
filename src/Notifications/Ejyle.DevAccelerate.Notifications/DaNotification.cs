// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Notifications
{
    public class DaNotification : DaNotification<string, DaNotificationVariable, DaNotificationRecipient>
    {
        public DaNotification()
        { }
    }

    public class DaNotification<TKey, TNotificationVariable, TNotificationRecipient> : DaAuditedEntityBase<TKey>, IDaNotification<TKey>
        where TKey : IEquatable<TKey>
        where TNotificationVariable : IDaNotificationVariable<TKey>
        where TNotificationRecipient : IDaNotificationRecipient<TKey>
    {
        public DaNotification()
        {
            Variables = new HashSet<TNotificationVariable>();
            Recipients = new HashSet<TNotificationRecipient>();
        }

        public virtual ICollection<TNotificationVariable> Variables
        {
            get;
            set;
        }

        public virtual ICollection<TNotificationRecipient> Recipients
        {
            get;
            set;
        }

        public DaNotificationChannel Channel { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Format { get; set; }
        public TKey NotificationTemplateId { get; set; }
        public DaNotificationStatus Status { get; set; }
        public string FailureMessage { get; set; }
        public int RecipientsCount { get; set; }
        public string VariableDelimiter { get; set; }
        public int RecipientsProcessedCount { get; set; }
        public string ObjectIdentifier { get; set; }
    }
}
