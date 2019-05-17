// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Notifications.EF
{
    public class DaNotificationItem : DaNotificationItem<int>
    { }

    public class DaNotificationItem<TKey> : DaEntityBase<TKey>, IDaNotificationItem<TKey>
        where TKey : IEquatable<TKey>
    {
        [Required]
        public TKey EventId { get; set; }

        [Required]
        public TKey SubscriberId { get; set; }

        [Required]
        public TKey SubscriberEventId { get; set; }

        [Required]
        public TKey SubscriberChannelDestinationId { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public DaNotificationItemStatus Status { get; set; }

        [Required]
        public DateTime CreatedDateUtc { get; set; }

        [Required]
        public DateTime LastStatusUpdatedUtc { get; set; }
    }
}
