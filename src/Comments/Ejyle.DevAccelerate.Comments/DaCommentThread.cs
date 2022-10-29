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

namespace Ejyle.CyberRisk.Comments
{
    public class DaCommentThread : DaCommentThread<int, int?, DaComment>
    {
        public DaCommentThread()
        { }
    }

    public class DaCommentThread<TKey, TNullableKey, TComment> : DaAuditedEntityBase<TKey>, IDaCommentThread<TKey>
        where TKey : IEquatable<TKey>
        where TComment : IDaComment<TKey, TNullableKey>
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

        public TKey ObjectInstanceId
        {
            get;
            set;
        }
    }
}
