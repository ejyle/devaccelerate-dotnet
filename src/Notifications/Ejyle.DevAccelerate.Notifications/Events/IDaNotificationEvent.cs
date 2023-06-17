// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Notifications.Events
{
    public interface IDaNotificationEvent<TKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey NotificationEventDefinitionId { get; set; }
        DaNotificationLevel? Level { get; set; }
        bool IsProcessingComplete { get; set; }
        int SubscribersProcessedCount { get; set; }
        int SubscribersCount { get; set; }
        string VariableDelimiter { get; set; }
        string ObjectIdentifier { get; set; }
    }
}
