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
    /// Represents a user's role.
    /// </summary>
    public class DaUserRole : DaUserRole<int>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaUserRole"/> class.
        /// </summary>
        public DaUserRole()
            : base()
        { }
    }

    /// <summary>
    /// Represents a user's role.
    /// </summary>
    /// <typeparam name="TKey">The type of the user and role IDs.</typeparam>
    public class DaUserRole<TKey> : IdentityUserRole<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaUserRole{TKey}"/> class.
        /// </summary>
        public DaUserRole()
            : base()
        { }
    }
}
