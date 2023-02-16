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

namespace Ejyle.DevAccelerate.Messages
{
    public interface IDaMessage<TKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string Subject { get; set; }
        string Message { get; set; }
        string Format { get; set; }
        string Category { get; set; }
        TKey MessageTemplateId { get; set; }
        DaMessageStatus Status { get; set; }
        string FailureMessage { get; set; }
    }
}
