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
    public class DaMTPTenant : DaMTPTenant<string>
    {
        public DaMTPTenant() : base()
        { }
    }

    public class DaMTPTenant<TKey> : DaAuditedEntityBase<TKey>, IDaMTPTenant<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey MTPTenantId { get; set; }
        public TKey TenantId { get; set; }
        public int MTPNumber { get; set; }
        public bool IsActive { get; set; }
    }
}