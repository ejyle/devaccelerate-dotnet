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
        public TKey MemberTenantId { get; set; }
        public TTenant MTPTenant { get; set; }
        public TTenant MemberTenant { get; set; }
        public int MTPId { get; set; }
        public bool IsActive { get; set; }
    }
}