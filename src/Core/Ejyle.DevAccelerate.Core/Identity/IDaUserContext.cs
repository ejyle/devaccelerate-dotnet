// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Core.Identity
{
    /// <summary>
    /// Provides abstraction for a user context.
    /// </summary>
    /// <typeparam name="TKey">The type of an entity key.</typeparam>
    public interface IDaUserContext<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        string UserName { get; set; }
    }
}
