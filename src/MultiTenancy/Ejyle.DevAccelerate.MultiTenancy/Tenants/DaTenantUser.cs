﻿// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.MultiTenancy.Tenants
{
    public class DaTenantUser : DaTenantUser<string, DaTenant>
    { }

    public class DaTenantUser<TKey, TTenant> : DaEntityBase<TKey>, IDaTenantUser<TKey>
        where TKey : IEquatable<TKey>
        where TTenant : IDaTenant<TKey>
    {

        public TKey TenantId
        {
            get;
            set;
        }


        public string UserId
        {
            get;
            set;
        }

        public virtual TTenant Tenant { get; set; }
        public bool IsActive { get; set; }
    }
}
