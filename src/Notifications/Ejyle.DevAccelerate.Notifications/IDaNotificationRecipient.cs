// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------
using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Notifications
{
    public interface IDaNotificationRecipient<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey NotificationId { get; set; }
        string RecipientName { get; set; }
        string RecipientAddress { get; set; }
        DaNotificationStatus Status { get; set; }
        string FailureMessage { get; set; }
        int AttemptCount { get; set; }
        string UserId { get; set; }
    }
}
