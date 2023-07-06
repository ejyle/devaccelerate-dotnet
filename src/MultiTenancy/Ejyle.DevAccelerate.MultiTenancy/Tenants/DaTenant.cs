// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.MultiTenancy.Tenants
{
    public class DaTenant : DaTenant<string, DaTenantUser, DaTenantAttribute, DaMTPTenant>
    {
        public DaTenant() : base()
        { }
    }

    public class DaTenant<TKey, TTenantUser, TTenantAttribute, TMTPTenant> : DaAuditedEntityBase<TKey>, IDaTenant<TKey>
        where TKey : IEquatable<TKey>
        where TTenantUser : IDaTenantUser<TKey>
        where TTenantAttribute : IDaTenantAttribute<TKey>
        where TMTPTenant : IDaMTPTenant<TKey>
    {
        public DaTenant()
        {
            TenantUsers = new HashSet<TTenantUser>();
            MTPManagedTenants = new HashSet<TMTPTenant>();
            MTPTenants = new HashSet<TMTPTenant>();
        }

        public virtual ICollection<TTenantUser> TenantUsers { get; set; }
        public virtual ICollection<TTenantAttribute> Attributes { get; set; }
        public DaTenantType TenantType { get; set; }
        public string OwnerUserId { get; set; }
        public string Name { get; set; }
        public bool IsSystemTenant { get; set; }
        public string Domain { get; set; }
        public bool IsDomainOwnershipVerified { get; set; }
        public DaTenantStatus Status { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public string TimeZone { get; set; }
        public string BillingEmail { get; set; }
        public string DateFormat { get; set; }
        public string SystemLanguage { get; set; }
        public DaTenantMTPStatus MTPStatus { get; set; }
        public virtual ICollection<TMTPTenant> MTPTenants { get; set; }
        public virtual ICollection<TMTPTenant> MTPManagedTenants { get; set; }
    }
}