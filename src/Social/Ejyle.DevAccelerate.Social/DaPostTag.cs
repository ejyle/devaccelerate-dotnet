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
    public class DaPostTag : DaPostTag<string, DaPost>
    { }

    public class DaPostTag<TKey, TPost> : DaEntityBase<TKey>, IDaPostTag<TKey>
        where TKey : IEquatable<TKey>
        where TPost : IDaPost<TKey>
    {
        public TKey PostId { get; set;  }
        public string Tag { get; set;  }
        public virtual TPost Post { get; set; }
    }
}
