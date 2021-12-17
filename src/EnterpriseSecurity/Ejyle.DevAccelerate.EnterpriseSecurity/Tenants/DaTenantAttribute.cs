// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Tenants
{
    public class DaTenantAttribute : DaTenantAttribute<int, int?, DaTenant>
    {
        public DaTenantAttribute()
            : base()
        { }
    }

    public class DaTenantAttribute<TKey, TNullableKey, TTenant> : DaEntityBase<TKey>, IDaTenantAttribute<TKey>
        where TKey : IEquatable<TKey>
        where TTenant : IDaTenant<TKey, TNullableKey>
    {
        public TKey TenantId { get; set; }
        public virtual TTenant Tenant { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
    }
}
