// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Identity;
using System;

namespace Ejyle.DevAccelerate.Identity.EF
{
    /// <summary>
    /// Represents the non-generics version of the <see cref="DaRole{TKey, TUserRole}"/> class.
    /// </summary>
    public class DaRole : DaRole<string>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaRole"/> class.
        /// </summary>
        public DaRole()
            : base()
        { }
    }

    /// <summary>
    /// Represents a role.
    /// </summary>
    /// <typeparam name="TKey">The type of the role ID.</typeparam>
    public class DaRole<TKey> : IdentityRole<TKey>, IDaRole<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Creates an instance of the Role class.
        /// </summary>
        public DaRole()
            : base()
        { }

        public string FriendlyName { get; set;  }
        public DaRoleType RoleType { get; set;  }
        public string Owner { get; set;  }
        public string Description { get; set; }
    }
}
