// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Notifications.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Notifications.Templates
{
    public interface IDaNotificationTemplate<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string Name { get; set; }
        string Key { get; set; }
        string Description { get; set; }
        string FromAddress { get; set; }
        string FromName { get; set; }
        DaNotificationLevel? Level { get; set; }
        string VariableDelimiter { get; set; }
    }
}
