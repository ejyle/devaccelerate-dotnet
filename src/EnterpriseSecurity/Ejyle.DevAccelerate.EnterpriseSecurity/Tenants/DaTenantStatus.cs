// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Tenants
{
    /// <summary>
    /// Represents the status of a tenant account.
    /// </summary>
    public enum DaTenantStatus
    {
        /// <summary>
        /// Tenant is not activve.
        /// </summary>
        Inactive = 0,
        /// <summary>
        /// Tenant is active.
        /// </summary>
        Active = 1,
        /// <summary>
        /// Tenant is suspended.
        /// </summary>
        Suspended = 2,
        /// <summary>
        /// Tenant is closed.
        /// </summary>
        Closed = 3
    }
}