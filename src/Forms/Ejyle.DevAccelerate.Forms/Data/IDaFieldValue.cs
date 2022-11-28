using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Forms.Data
{
    public interface IDaFieldValue<TKey> : IDaAuditedEntity<TKey>
        where TKey: IEquatable<TKey>
    {
        TKey FormInstanceId { get; set; }
        TKey FieldId { get; set; }
        string Value { get; set; }
    }
}
