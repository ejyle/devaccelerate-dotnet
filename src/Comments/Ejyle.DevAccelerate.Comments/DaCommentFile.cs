using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Comments
{
    public class DaCommentFile<TKey> : DaAuditedEntityBase<TKey>, IDaCommentFile<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey FileId { get; set; }
        public TKey CommentId { get; set; }
    }
}
