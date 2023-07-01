using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.MultiTenancy.Tenants
{
    public interface IDaMTPTenant<TKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey MTPTenantId { get; set; }
        TKey MemberTenantId { get; set; }
        int MTPId { get; set; }
        bool IsActive { get; set; }
    }
}
