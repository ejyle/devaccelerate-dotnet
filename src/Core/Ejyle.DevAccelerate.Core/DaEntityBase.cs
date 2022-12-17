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
    /// Represents the base class for an entity. The type of the entity ID is <see cref="System.Int32"/>.
    /// </summary>
    public abstract class DaEntityBase : DaEntityBase<string>
    { }

    /// <summary>
    /// Represents the base class for an entity.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity's ID.</typeparam>
    public abstract class DaEntityBase<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets or sets the ID of the entity.
        /// </summary>
        [Key]
        [Required]
        public TKey Id
        {
            get;
            set;
        }
    }
}
