// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Lists
{
    /// <summary>
    /// Represents the base class for a list entity.
    /// </summary>
    /// <typeparam name="TKey">The type of the list entity's ID.</typeparam>
    public abstract class DaListItemBase<TKey> : DaAuditedEntityBase<TKey>, IDaListItem<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// The standard name of the list item.
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// The name of the list item for display purposes.
        /// </summary>
        [Required]
        [StringLength(256)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Determines if the list is active.
        /// </summary>
        [Required]
        public bool IsActive { get; set; }

        /// <summary>
        /// Determines if the list item information is verified to be valid.
        /// </summary>
        [Required]
        public bool IsVerified { get; set; }

        /// <summary>
        /// Determines if the list item is default.
        /// </summary>
        [Required]
        public bool IsDefault { get; set; }
    }
}
