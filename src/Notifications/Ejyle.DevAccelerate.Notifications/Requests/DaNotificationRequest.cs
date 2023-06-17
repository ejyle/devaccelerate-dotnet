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

namespace Ejyle.DevAccelerate.Notifications.Requests
{
    public class DaNotificationRequest : DaNotificationRequest<string, DaNotificationRequestChannel, DaNotificationRequestVariable, DaNotificationRequestRecipient>
    {
        public DaNotificationRequest()
        { }
    }

    public class DaNotificationRequest<TKey, TNotificationRequestChannel, TNotificationRequestVariable, TNotificationRequestRecipient> : DaAuditedEntityBase<TKey>, IDaNotificationRequest<TKey>
        where TKey : IEquatable<TKey>
        where TNotificationRequestChannel : IDaNotificationRequestChannel<TKey>
        where TNotificationRequestVariable : IDaNotificationRequestVariable<TKey>
        where TNotificationRequestRecipient : IDaNotificationRequestRecipient<TKey>
    {
        public DaNotificationRequest()
        {
            Variables = new HashSet<TNotificationRequestVariable>();
            Recipients = new HashSet<TNotificationRequestRecipient>();
            Channels = new HashSet<TNotificationRequestChannel>();
        }

        public virtual ICollection<TNotificationRequestVariable> Variables
        {
            get;
            set;
        }

        public virtual ICollection<TNotificationRequestRecipient> Recipients
        {
            get;
            set;
        }

        public virtual ICollection<TNotificationRequestChannel> Channels
        {
            get;
            set;
        }

        public TKey NotificationTemplateId { get; set; }
        public DaNotificationLevel? Level { get; set; }
        public bool IsProcessingComplete { get; set; }
        public string FailureMessage { get; set; }
        public int RecipientsCount { get; set; }
        public string VariableDelimiter { get; set; }
        public int RecipientsProcessedCount { get; set; }
        public string ObjectIdentifier { get; set; }
    }
}
