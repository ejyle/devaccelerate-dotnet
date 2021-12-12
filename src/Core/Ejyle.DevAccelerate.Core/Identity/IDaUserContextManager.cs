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
    /// Provides abstraction for user context manager to retrieve and manage user context.
    /// </summary>
    public interface IDaUserContextManager : IDaUserContextManager<int>
    {
    }

    /// <summary>
    /// Provides abstraction for user context manager to retrieve and manage user context.
    /// </summary>
    /// <typeparam name="TKey">The type of an entity key.</typeparam>
    public interface IDaUserContextManager<TKey>
        where TKey: IEquatable<TKey>
    {
        /// <summary>
        /// Gets the current user context.
        /// </summary>
        /// <returns>Returns an instance of the <see cref="IDaEntity{TKey}"/> type.</returns>
        IDaUserContext<TKey> GetUserContext();
    }
}
