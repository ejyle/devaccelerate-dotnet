// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Core
{
    /// <summary>
    /// Represents the basic interface for an entity.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity's ID.</typeparam>
    public interface IDaEntity<TKey> : IDaEntity
        where TKey: IEquatable<TKey>
    {
        /// <summary>
        /// Gets or sets the unique ID of the entity.
        /// </summary>
        TKey Id
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Represents the basic interface for an entity.
    /// </summary>
    public interface IDaEntity
    { }
}
