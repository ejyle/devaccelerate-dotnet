// ----------------------------------------------------------------------------------------------------------------------
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
    public class DaCommentThread : DaCommentThread<string, DaComment>
    {
        public DaCommentThread()
        { }
    }

    public class DaCommentThread<TKey, TComment> : DaAuditedEntityBase<TKey>, IDaCommentThread<TKey>
        where TKey : IEquatable<TKey>
        where TComment : IDaComment<TKey>
    {
        public DaCommentThread()
        {
            Comments = new HashSet<TComment>();
        }

        public virtual ICollection<TComment> Comments
        {
            get;
            set;
        }

        public string Format
        {
            get;
            set;
        }

        public string ObjectInstanceId
        {
            get;
            set;
        }
    }
}
