// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Lists
{
    /// <summary>
    /// Represents the basic interface for a list item entity.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity's ID.</typeparam>
    public interface IDaListItem<TKey> : IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// The standard name of the list item.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The name of the list item for display purposes.
        /// </summary>
        string DisplayName { get; set; }

        /// <summary>
        /// Determines if the list item is active or disabled.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Determines if the list item information is verified to be valid.
        /// </summary>
        bool IsVerified { get; set; }

        /// <summary>
        /// Determines if the list item is default.
        /// </summary>
        bool IsDefault { get; set; }
    }
}
