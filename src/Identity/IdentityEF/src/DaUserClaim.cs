// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ejyle.DevAccelerate.Identity.EF
{
    /// <summary>
    /// Represents a user's claim in the system.
    /// </summary>
    public class DaUserClaim : DaUserClaim<int>
    { }

    /// <summary>
    /// Represents a user's claim in the system.
    /// </summary>
    /// <typeparam name="TKey">The Type of the user ID.</typeparam>
    public class DaUserClaim<TKey> : IdentityUserClaim<TKey>
        where TKey : IEquatable<TKey>
    { }
}
