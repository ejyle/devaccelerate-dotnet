// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

namespace Ejyle.DevAccelerate.Core
{
    /// <summary>
    /// Represents the base class for an entity with basic auditing properties. The type of the entity ID is <see cref="System.Int32"/>.
    /// </summary>
    public abstract class DaAuditedEntityBase : DaAuditedEntityBase<string>
    { }

    /// <summary>
    /// Represents the base class for an entity with basic auditing properties.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity's ID.</typeparam>
    public abstract class DaAuditedEntityBase<TKey> : DaEntityBase<TKey>, IDaAuditedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets or sets the ID of the user who created the entity.
        /// </summary>
        [Required]
        public TKey CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created UTC date and time of the entity.
        /// </summary>
        [Required]
        public DateTime CreatedDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who last updated the entity.
        /// </summary>
        [Required]
        public TKey LastUpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the last updated UTC date and time of the entity.
        /// </summary>
        [Required]
        public DateTime LastUpdatedDateUtc { get; set; }
    }
}
