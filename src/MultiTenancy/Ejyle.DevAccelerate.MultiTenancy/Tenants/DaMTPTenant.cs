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
    public class DaMTPTenant : DaMTPTenant<string, DaTenant>
    {
        public DaMTPTenant() : base()
        { }
    }

    public class DaMTPTenant<TKey, TTenant> : DaAuditedEntityBase<TKey>, IDaMTPTenant<TKey>
        where TKey : IEquatable<TKey>
        where TTenant : IDaTenant<TKey>
    {
        public TKey MTPTenantId { get; set; }
        public TKey MTPManagedTenantId { get; set; }
        public int MTPNumber { get; set; }
        public bool IsActive { get; set; }
        public virtual TTenant MTPTenant { get; set; }
        public virtual TTenant MTPManagedTenant { get; set; }
    }
}