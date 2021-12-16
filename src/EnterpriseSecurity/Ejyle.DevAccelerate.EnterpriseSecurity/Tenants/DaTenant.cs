// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Tenants
{
    public class DaTenant : DaTenant<int, int?, DaTenantUser, DaTenantAttribute>
    {
        public DaTenant() : base()
        { }
    }

    public class DaTenant<TKey, TNullableKey, TTenantUser, TTenantAttribute> : DaAuditedEntityBase<TKey>, IDaTenant<TKey, TNullableKey>
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
        public string Domain { get; set; }
        public bool IsDomainOwnershipVerified { get; set; }
        public DaTenantStatus Status { get; set; }
        public TNullableKey CountryId { get; set; }
        public TNullableKey CurrencyId { get; set; }
        public TNullableKey TimeZoneId { get; set; }
        public string BillingEmail { get; set; }
        public TNullableKey DateFormatId { get; set; }
        public TNullableKey SystemLanguageId { get; set; }
    }
}