// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Notifications.Requests;

namespace Ejyle.DevAccelerate.Notifications.Templates
{
    public class DaNotificationTemplate : DaNotificationTemplate<string, DaNotificationChannelTemplate>
    {
        public DaNotificationTemplate()
        { 
        }
    }

    public class DaNotificationTemplate<TKey, TNotificationChannelTemplate> : DaEntityBase<TKey>, IDaNotificationTemplate<TKey>
        where TKey : IEquatable<TKey>
        where TNotificationChannelTemplate : IDaNotificationChannelTemplate<TKey>
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public string VariableDelimiter { get; set; }
        public DaNotificationLevel? Level { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
        public virtual ICollection<TNotificationChannelTemplate> Channels { get; set; }
    }
}
