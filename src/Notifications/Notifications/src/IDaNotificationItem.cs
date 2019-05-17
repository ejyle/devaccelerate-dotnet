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
    public interface IDaNotificationItem<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey EventId { get; set; }
        TKey SubscriberId { get; set; }
        TKey SubscriberEventId { get; set; }
        TKey SubscriberChannelDestinationId { get; set; }
        string Destination { get; set; }
        string Message { get; set; }
        DaNotificationItemStatus Status { get; set; }
        DateTime CreatedDateUtc { get; set; }
        DateTime LastStatusUpdatedUtc { get; set; }
    }
}
