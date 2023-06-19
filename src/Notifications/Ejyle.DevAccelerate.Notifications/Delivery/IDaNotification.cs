// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Notifications.Delivery
{
    public interface IDaNotification<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey NotificationEventId { get; set; }
        DaNotificationLevel? Level { get; set; }
        DaNotificationChannel Channel { get; set; }
        DaNotificationStatus Status { get; set; }
        string FailureMessage { get; set; }
        string FromName { get; set; }
        string FromAddress { get; set; }
        string RecipientName { get; set; }
        string RecipientAddress { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
        string Format { get; set; }
        string ObjectInstanceId { get; set; }
        DateTime CreatedDateUtc { get; set; }
        DateTime LastUpdatedDateUtc { get; set; }
        DateTime? DeliveryDateUtc { get; set; }
    }
}
