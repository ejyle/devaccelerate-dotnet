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
    public class DaMessageRecipient : DaMessageRecipient<string, DaMessage, DaMessageRecipientVariable>
    {
        public DaMessageRecipient()
        { }
    }

    public class DaMessageRecipient<TKey, TMessage, TMessageRecipientVariable> : DaEntityBase<TKey>, IDaMessageRecipient<TKey>
        where TKey : IEquatable<TKey>
        where TMessage : IDaMessage<TKey>
        where TMessageRecipientVariable : IDaMessageRecipientVariable<TKey>
    {
        public DaMessageRecipient()
        {
            Variables = new HashSet<TMessageRecipientVariable>();
        }

        public virtual ICollection<TMessageRecipientVariable> Variables
        {
            get;
            set;
        }

        public virtual TMessage Message
        {
            get;
            set;
        }
        public TKey MessageId { get; set; }
        public string RecipientName { get; set; }
        public string RecipientAddress { get; set; }
        public DaMessageStatus Status { get; set; }
        public string FailureMessage { get; set; }
        public int AttemptCount { get; set; }
        public TKey UserId { get; set; }
    }
}
