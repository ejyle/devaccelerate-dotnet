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
    public class DaMessageVariable : DaMessageVariable<string, DaMessage>
    { }

    public class DaMessageVariable<TKey, TMessage> : DaEntityBase<TKey>, IDaMessageVariable<TKey>
        where TKey : IEquatable<TKey>
        where TMessage : IDaMessage<TKey>
    {
        public virtual TMessage Message
        {
            get;
            set;
        }
        public TKey MessageId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool ForSubject { get; set; }
        public bool ForMessage { get; set; }
    }
}
