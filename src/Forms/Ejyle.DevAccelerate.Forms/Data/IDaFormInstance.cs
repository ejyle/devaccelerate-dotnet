using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Forms.Data
{
    public interface IDaFormInstance<TKey, TNullableKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey FormId { get; set; }
        TKey OwnerUserId { get; set; }
        TNullableKey TenantId { get; set; }
    }
}
