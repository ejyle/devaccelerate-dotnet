// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Notifications
{
    public class DaNotificationTemplate : DaNotificationTemplate<string>
    {
        public DaNotificationTemplate()
        { 
        }
    }

    public class DaNotificationTemplate<TKey> : DaEntityBase<TKey>, IDaNotificationTemplate<TKey>
        where TKey : IEquatable<TKey>
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string Format { get; set; }
        public DaNotificationChannel Channel { get; set; }
        public string Subject { get; set; }
        public string VariableDelimiter { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }
}
