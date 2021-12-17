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
    /// Represents a user with <see cref="int"/> as key type.
    /// </summary>
    public class DaUser : DaUser<int, int?>
    { }

    /// <summary>
    /// Represents a user.
    /// </summary>
    /// <typeparam name="TKey">The type of a non-nullable key of an entity.</typeparam>
    /// <typeparam name="TNullableKey">The type of a nullable key of an entity.</typeparam>
    public class DaUser<TKey, TNullableKey> : IdentityUser<TKey>, IDaUser<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
    {
        public const string GLOBAL_SUPER_ADMIN = "GlobalSuperAdmin";

        /// <summary>
        /// Determines if the user needs to change password.
        /// </summary>
        public bool RequireChangePassword { get; set; }

        /// <summary>
        /// Gets or sets the status of the user account.
        /// </summary>
        public DaAccountStatus Status { get; set; }

        /// <summary>
        /// Determines if the user is flagged as deleted. This property is used for soft-deletion mechanism.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// The ID of the user account which deleted the user through a soft deletion mechanism.
        /// </summary>
        public TNullableKey DeletedBy { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user was deleted through a soft-deletion mechanism.
        /// </summary>
        public DateTime? DeletedDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the UTC date and time when the user account is created.
        /// </summary>
        public DateTime CreatedDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the UTC date and time when the user account was last modified.
        /// </summary>
        public DateTime LastUpdatedDateUtc { get; set; }
    }
}
