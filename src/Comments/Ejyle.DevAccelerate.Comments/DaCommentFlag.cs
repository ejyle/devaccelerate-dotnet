using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Comments
{
    public class DaCommentFlag<TKey> : DaAuditedEntityBase<TKey>, IDaCommentFlag<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey CommentId { get; set; }
        public DaCommentFlagType FlagType { get; set; }
    }
}
