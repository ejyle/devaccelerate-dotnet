using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Profiles.Organizations
{
    public interface IDaOrganizationGroup<TKey, TNullableKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey OrganizationProfileId { get; set; }
        TNullableKey ParentId { get; set; }
        TKey OwnerUserId { get; set; }
        string GroupName { get; set; }
        DaOrganizationGroupType GroupType { get; set; }
    }
}