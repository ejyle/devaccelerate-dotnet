// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Notifications.Delivery;
using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Notifications.Requests
{
    public class DaNotificationRequestRecipient : DaNotificationRequestRecipient<string, DaNotificationRequest, DaNotificationRequestRecipientVariable>
    {
        public DaNotificationRequestRecipient()
        { }
    }

    public class DaNotificationRequestRecipient<TKey, TNotificationRequest, TNotificationRequestRecipientVariable> : DaEntityBase<TKey>, IDaNotificationRequestRecipient<TKey>
        where TKey : IEquatable<TKey>
        where TNotificationRequest : IDaNotificationRequest<TKey>
        where TNotificationRequestRecipientVariable : IDaNotificationRequestRecipientVariable<TKey>
    {
        public DaNotificationRequestRecipient()
        {
            Variables = new HashSet<TNotificationRequestRecipientVariable>();
        }

        public virtual ICollection<TNotificationRequestRecipientVariable> Variables
        {
            get;
            set;
        }

        public virtual TNotificationRequest NotificationRequest
        {
            get;
            set;
        }
        public TKey NotificationRequestId { get; set; }
        public string RecipientName { get; set; }
        public string RecipientAddress { get; set; }
        public DaNotificationStatus Status { get; set; }
        public string FailureMessage { get; set; }
        public int AttemptCount { get; set; }
        public string UserId { get; set; }
    }
}
