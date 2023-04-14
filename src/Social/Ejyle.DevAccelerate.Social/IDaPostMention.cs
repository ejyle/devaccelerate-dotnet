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
    public interface IDaPostMention<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey PostId { get; set; }
        string Mention { get; set; }
        DaPostMediaType MentionType { get; set; }
    }
}
