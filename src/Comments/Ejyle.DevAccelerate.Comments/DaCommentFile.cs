﻿// ----------------------------------------------------------------------------------------------------------------------
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
    public class DaCommentFile : DaCommentFile<string, DaComment>
    { }

    public class DaCommentFile<TKey, TComment> : DaAuditedEntityBase<TKey>, IDaCommentFile<TKey>
        where TKey : IEquatable<TKey>
        where TComment: IDaComment<TKey>
    {
        public string FileId { get; set; }
        public TKey CommentId { get; set; }
        public virtual TComment Comment { get; set; }
    }
}
