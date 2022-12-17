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
    public class DaMessageRecipientVariable : DaMessageRecipientVariable<string, DaMessageRecipient>
    { }

    public class DaMessageRecipientVariable<TKey, TMessageRecipient> : DaEntityBase<TKey>, IDaMessageRecipientVariable<TKey>
        where TKey : IEquatable<TKey>
        where TMessageRecipient : IDaMessageRecipient<TKey>
    {
        public virtual TMessageRecipient MessageRecipient
        {
            get;
            set;
        }
        public TKey MessageRecipientId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool ForSubject { get; set; }
        public bool ForMessage { get; set; }
    }
}
