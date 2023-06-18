using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.MultiTenancy.Organizations
{
    public interface IDaOrganizationGroup<TKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey OrganizationId { get; set; }
        TKey ParentId { get; set; }
        string OwnerUserId { get; set; }
        string GroupName { get; set; }
        DaOrganizationGroupType GroupType { get; set; }
    }
}