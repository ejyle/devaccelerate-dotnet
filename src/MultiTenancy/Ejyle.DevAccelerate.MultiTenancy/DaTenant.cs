// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.MultiTenancy
{
    public class DaTenant : DaTenant<string, DaTenantUser, DaTenantAttribute>
    {
        public DaTenant() : base()
        { }
    }

    public class DaTenant<TKey, TTenantUser, TTenantAttribute> : DaAuditedEntityBase<TKey>, IDaTenant<TKey>
        where TKey : IEquatable<TKey>
        where TTenantUser : IDaTenantUser<TKey>
        where TTenantAttribute : IDaTenantAttribute<TKey>
    {
        public DaTenant()
        {
            TenantUsers = new List<TTenantUser>();
        }

        public virtual ICollection<TTenantUser> TenantUsers { get; set; }
        public virtual ICollection<TTenantAttribute> Attributes { get; set; }
        public DaTenantType TenantType { get; set; }
        public TKey OwnerUserId { get; set; }
        public string Name { get; set; }
        public bool IsSystemTenant { get; set; }
        public string Domain { get; set; }
        public bool IsDomainOwnershipVerified { get; set; }
        public DaTenantStatus Status { get; set; }
        public TKey CountryId { get; set; }
        public TKey CurrencyId { get; set; }
        public TKey TimeZoneId { get; set; }
        public string BillingEmail { get; set; }
        public TKey DateFormatId { get; set; }
        public TKey SystemLanguageId { get; set; }
    }
}