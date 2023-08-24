// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Notifications.Delivery
{
    public class DaNotification : DaNotification<string>
    { }

    public class DaNotification<TKey> : DaEntityBase<TKey>, IDaNotification<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey NotificationEventId { get; set; }
        public DaNotificationLevel? Level { get; set; }
        public DaNotificationChannel Channel { get; set; }
        public DaNotificationStatus Status { get; set; }
        public string FailureMessage { get; set; }
        public string FromName { get; set; }
        public string FromAddress { get; set; }
        public string RecipientName { get; set; }
        public string RecipientAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Format { get; set; }
        public string ObjectInstanceId { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime LastUpdatedDateUtc { get; set; }
        public DateTime? DeliveryDateUtc { get; set; }
    }
}
