// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Notifications.Templates
{
    public class DaNotificationChannelTemplate : DaNotificationChannelTemplate<string, DaNotificationTemplate>
    {
        public DaNotificationChannelTemplate()
        { 
        }
    }

    public class DaNotificationChannelTemplate<TKey, TNotificationTemplate> : DaEntityBase<TKey>, IDaNotificationChannelTemplate<TKey>
        where TKey : IEquatable<TKey>
        where TNotificationTemplate : IDaNotificationTemplate<TKey>
    {
        public TKey NotificationTemplateId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DaNotificationChannel Channel { get; set; }
        public string Format { get; set; }
        public virtual TNotificationTemplate NotificationTemplate { get; set; }
    }
}
