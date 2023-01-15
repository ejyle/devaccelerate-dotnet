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
    /// Represents the basic interface of an entity with basic auditing properties.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity's ID.</typeparam>
    public interface IDaAuditedEntity<TKey> : IDaAuditedEntity<TKey, TKey>
        where TKey : IEquatable<TKey>
    {
    }

    /// <summary>
    /// Represents the basic interface of an entity with basic auditing properties.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity's ID.</typeparam>
    /// <typeparam name="TIdentityKey">The type of the entity's <see cref="CreatedBy"/> and <see cref="LastUpdatedBy"/> properties.</typeparam>
    public interface IDaAuditedEntity<TKey, TIdentityKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
        where TIdentityKey: IEquatable<TIdentityKey>
    {
        /// <summary>
        /// Gets or sets the ID of the user who created the entity.
        /// </summary>
        [Required]
        TIdentityKey CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created UTC date and time of the entity.
        /// </summary>
        [Required]
        DateTime CreatedDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who last updated the entity.
        /// </summary>
        [Required]
        TIdentityKey LastUpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the last updated UTC date and time of the entity.
        /// </summary>
        [Required]
        DateTime LastUpdatedDateUtc { get; set; }
    }
}
