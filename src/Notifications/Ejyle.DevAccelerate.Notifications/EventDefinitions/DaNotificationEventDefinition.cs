// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Notifications.Events;

namespace Ejyle.DevAccelerate.Notifications.EventDefinitions
{
    public class DaNotificationEventDefinition : DaNotificationEventDefinition<string, DaNotificationEventDefinitionChannel>
    {
        public DaNotificationEventDefinition()
        { 
        }
    }

    public class DaNotificationEventDefinition<TKey, TNotificationEventDefinitionChannel> : DaEntityBase<TKey>, IDaNotificationEventDefinition<TKey>
        where TKey : IEquatable<TKey>
        where TNotificationEventDefinitionChannel : IDaNotificationEventDefinitionChannel<TKey>
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VariableDelimiter { get; set; }
        public DaNotificationLevel? Level { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
        public virtual ICollection<TNotificationEventDefinitionChannel> Channels { get; set; }
    }
}
