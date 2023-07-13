using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.MultiTenancy.Tenants
{
    public class DaTenantDomain : DaTenantDomain<string, DaTenant>
    { }

    public class DaTenantDomain<TKey, TTenant> : IDaTenantDomain<TKey>
        where TKey : IEquatable<TKey>
        where TTenant : IDaTenant<TKey>
    {
        public TKey TenantId {get; set;}
        public virtual TTenant Tenant { get; set;}
        public string Domain {get; set;}
        public bool? IsDomainVerified {get; set;}
        public DaDomainVerificationMethod? VerificationMethod {get; set;}
        public string VerificationValue {get; set;}
        public string VerificationFileName {get; set;}
        public DateTime? VerificationCodeCreatedDateUtc {get; set;}
        public DateTime? VerificationCodeExpiryDateUtc {get; set;}
        public bool IsPrimary {get; set;}
        public string CreatedBy {get; set;}
        public DateTime CreatedDateUtc {get; set;}
        public string LastUpdatedBy {get; set;}
        public DateTime LastUpdatedDateUtc {get; set;}
        public TKey Id {get; set;}
    }
}
