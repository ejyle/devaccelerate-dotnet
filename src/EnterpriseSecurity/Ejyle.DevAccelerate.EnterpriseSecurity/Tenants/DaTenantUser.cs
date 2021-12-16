// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Tenants
{
    public class DaTenantUser : DaTenantUser<int, int?, DaTenant>
    { }

    public class DaTenantUser<TKey, TNullableKey, TTenant> : DaEntityBase<TKey>, IDaTenantUser<TKey>
        where TKey : IEquatable<TKey>
        where TTenant : IDaTenant<TKey, TNullableKey>
    {

        public TKey TenantId
        {
            get;
            set;
        }


        public TKey UserId
        {
            get;
            set;
        }

        public virtual TTenant Tenant { get; set; }
        public bool IsActive { get; set; }
    }
}
