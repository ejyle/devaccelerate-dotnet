// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Identity
{
    /// <summary>
    /// Represents the basic interface of a role.
    /// </summary>
    /// <typeparam name="TKey">The type of a non-nullable key of an entity.</typeparam>
    public interface IDaRole<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the friendly name of the role.
        /// </summary>
        string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the type of the role.
        /// </summary>
        DaRoleType RoleType { get; set; }

        /// <summary>
        /// Gets or sets the owner of the role.
        /// </summary>
        string Owner { get; set; }

        /// <summary>
        /// Gets or sets the owner type of the role.
        /// </summary>
        string OwnerType { get; set; }

        /// <summary>
        /// Gets or sets the description of the role.
        /// </summary>
        string Description { get; set; }
    }
}
