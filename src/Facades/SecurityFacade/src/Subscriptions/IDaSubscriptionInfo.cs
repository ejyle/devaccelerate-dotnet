// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.EnterpriseSecurity.Tenants;

namespace Ejyle.DevAccelerate.Facades.Security.Subscriptions
{
    public interface IDaSubscriptionInfo<TKey>
        where TKey : IEquatable<TKey>
    {
        string UserName { get; set; }
        string Email { get; set; }
        TKey SubscriptionPlanId { get; set; }    
        TKey BillingCycleId { get; set; }
        string OrganizationName { get; set; }
        DaTenantType TenantType { get; set; }
    }
}
