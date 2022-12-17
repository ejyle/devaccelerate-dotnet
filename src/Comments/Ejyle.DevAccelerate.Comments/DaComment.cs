﻿// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Comments;
using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ejyle.DevAccelerate.Comments
{
    public class DaComment : DaComment<string, DaComment, DaCommentThread>
    {
        public DaComment()
        { }
    }

    public class DaComment<TKey, TComment, TCommentThread> : DaAuditedEntityBase<TKey>, IDaComment<TKey>
        where TKey : IEquatable<TKey>
        where TComment : IDaComment<TKey>
        where TCommentThread : IDaCommentThread<TKey>
    {
        public DaComment() : base()
        {
            Children = new HashSet<TComment>();
        }

        public string Message
        {
            get;
            set;
        }

        public TKey ParentId
        {
            get;
            set;
        }

        public TKey CommentThreadId
        {
            get;
            set;
        }

        public virtual TComment Parent
        {
            get;
            set;
        }

        public virtual TCommentThread CommentThread
        {
            get;
            set;
        }

        public virtual ICollection<TComment> Children
        {
            get;
            set;
        }
    }
}
