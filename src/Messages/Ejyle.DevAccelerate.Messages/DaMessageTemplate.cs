// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Messages
{
    public class DaMessageTemplate : DaMessageTemplate<string>
    {
        public DaMessageTemplate()
        { 
        }
    }

    public class DaMessageTemplate<TKey> : DaEntityBase<TKey>, IDaMessageTemplate<TKey>
        where TKey : IEquatable<TKey>
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
        public string Format { get; set; }
        public string Category { get; set; }
        public string Subject { get; set; }
        public string VariableDelimiter { get; set; }
    }
}
