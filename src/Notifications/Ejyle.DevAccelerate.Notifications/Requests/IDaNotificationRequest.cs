// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Notifications.Delivery;

namespace Ejyle.DevAccelerate.Notifications.Requests
{
    public interface IDaNotificationRequest<TKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey NotificationTemplateId { get; set; }
        DaNotificationLevel? Level { get; set; }
        string FailureMessage { get; set; }
        bool IsProcessingComplete { get; set; }
        int RecipientsCount { get; set; }
        int RecipientsProcessedCount { get; set; }
        string VariableDelimiter { get; set; }
        string ObjectIdentifier { get; set; }
    }
}
