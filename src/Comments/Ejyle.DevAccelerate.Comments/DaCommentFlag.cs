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

namespace Ejyle.DevAccelerate.Comments
{
    public class DaCommentFlag : DaCommentFlag<string, DaComment>
    { }

    public class DaCommentFlag<TKey, TComment> : DaAuditedEntityBase<TKey>, IDaCommentFlag<TKey>
        where TKey : IEquatable<TKey>
        where TComment : IDaComment<TKey>
    {
        public TKey CommentId { get; set; }
        public DaCommentFlagType FlagType { get; set; }
        public TComment Comment { get; set; }
    }
}
