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

        [Required]
        public DaTenantType TenantType { get; set; }

        [Required]
        public TKey OwnerUserId { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(256)]
        public string? Domain { get; set; }

        [Required]
        public bool IsDomainOwnershipVerified { get; set; }

        [Required]
        public DaTenantStatus Status { get; set; }

        [Required]
        public TKey CountryId { get; set; }

        [Required]
        public TKey CurrencyId { get; set; }

        [Required]
        public TKey TimeZoneId { get; set; }

        [StringLength(256)]
        public string? BillingEmail { get; set; }

        [Required]
        public TKey DateFormatId { get; set; }

        [Required]
        public TKey SystemLanguageId { get; set; }
    }
}