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
    public interface IDaNotification<TKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string Subject { get; set; }
        string Body { get; set; }
        string Format { get; set; }
        public DaNotificationChannel Channel { get; set; }
        TKey NotificationTemplateId { get; set; }
        DaNotificationStatus Status { get; set; }
        string FailureMessage { get; set; }
        int RecipientsCount { get; set; }
        int RecipientsProcessedCount { get; set; }
        string VariableDelimiter { get; set; }
        string ObjectIdentifier { get; set; }
    }
}
