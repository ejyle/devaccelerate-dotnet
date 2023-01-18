using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Comments
{
    public interface IDaCommentFlag<TKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey CommentId { get; set; }
        DaCommentFlagType FlagType { get; set; }
    }
}
