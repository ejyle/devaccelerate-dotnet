// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Notifications.EventDefinitions
{
    public class DaNotificationEventDefinitionChannel : DaNotificationEventDefinitionChannel<string, DaNotificationEventDefinition>
    {
        public DaNotificationEventDefinitionChannel()
        { 
        }
    }

    public class DaNotificationEventDefinitionChannel<TKey, TNotificationEventDefinition> : DaEntityBase<TKey>, IDaNotificationEventDefinitionChannel<TKey>
        where TKey : IEquatable<TKey>
        where TNotificationEventDefinition : IDaNotificationEventDefinition<TKey>
    {
        public TKey NotificationEventDefinitionId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DaNotificationChannel Channel { get; set; }
        public string Format { get; set; }
        public virtual TNotificationEventDefinition NotificationEventDefinition { get; set; }
    }
}
