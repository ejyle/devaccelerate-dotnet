// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Notifications.Requests
{
    public class DaNotificationRequestChannel : DaNotificationRequestChannel<string, DaNotificationRequest>
    {
        public DaNotificationRequestChannel()
        { }
    }

    public class DaNotificationRequestChannel<TKey, TNotificationRequest> : DaAuditedEntityBase<TKey>, IDaNotificationRequestChannel<TKey>
        where TKey : IEquatable<TKey>
        where TNotificationRequest : IDaNotificationRequest<TKey>
    {
        public DaNotificationChannel Channel { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Format { get; set; }
        public TKey NotificationChannelTemplateId { get; set; }
        public TKey NotificationRequestId { get; set; }
        public virtual TNotificationRequest NotificationRequest { get; set; }
    }
}
