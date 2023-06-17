// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Notifications.Requests
{
    public interface IDaNotificationRequestChannel<TKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string Subject { get; set; }
        string Body { get; set; }
        string Format { get; set; }
        public DaNotificationChannel Channel { get; set; }
        TKey NotificationChannelTemplateId { get; set; }
        TKey NotificationRequestId { get; set; }
    }
}
