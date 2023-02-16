// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace Ejyle.DevAccelerate.Messages
{
    public class DaMessage : DaMessage<string, DaMessageVariable, DaMessageRecipient>
    {
        public DaMessage()
        { }
    }

    public class DaMessage<TKey, TMessageVariable, TMessageRecipient> : DaAuditedEntityBase<TKey>, IDaMessage<TKey>
        where TKey : IEquatable<TKey>
        where TMessageVariable : IDaMessageVariable<TKey>
        where TMessageRecipient : IDaMessageRecipient<TKey>
    {
        public DaMessage()
        {
            Variables = new HashSet<TMessageVariable>();
            Recipients = new HashSet<TMessageRecipient>();
        }

        public virtual ICollection<TMessageVariable> Variables
        {
            get;
            set;
        }

        public virtual ICollection<TMessageRecipient> Recipients
        {
            get;
            set;
        }

        public string Category { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Format { get; set; }
        public TKey MessageTemplateId { get; set; }
        public DaMessageStatus Status { get; set; }
        public string FailureMessage { get; set; }
    }
}
