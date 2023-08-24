// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Social
{
    public class DaPostMention : DaPostMention<string, DaPost>
    { }

    public class DaPostMention<TKey, TPost> : DaEntityBase<TKey>, IDaPostMention<TKey>
        where TKey : IEquatable<TKey>
        where TPost : IDaPost<TKey>
    {
        public TKey PostId { get; set; }
        public string Mention { get; set; }
        public DaPostMediaType MentionType { get; set; }
        public virtual TPost Post { get; set; }
    }
}
