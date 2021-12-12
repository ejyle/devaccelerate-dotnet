// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

namespace Ejyle.DevAccelerate.Core.Caching
{
    /// <summary>
    /// Defines the methods for storing and managing cache entries.
    /// </summary>
    public interface IDaCacheManager
    {
        /// <summary>
        /// Inserts a cache entry into the cache.
        /// </summary>
        /// <param name="key">A unique identifier for the cache entry.</param>
        /// <param name="value">The object to insert into the cache.</param>
        void Add(string key, object value);

        /// <summary>
        /// Gets a cache entry with a given key from the cache.
        /// </summary>
        /// <param name="key">The unique identifier for the cache entry to retrieve.</param>
        /// <returns>Returns the cache entry as an <see cref="object"/> type.</returns>
        object GetData(string key);

        /// <summary>
        /// Gets the number of entires in the cache.
        /// </summary>
        long Count { get; }

        /// <summary>
        /// Clears the cache.
        /// </summary>
        void Flush();

        /// <summary>
        /// Checks if cache entry with a given key already exists in the cache.
        /// </summary>
        /// <param name="key">The unique identifier for the cache entry.</param>
        /// <returns>Returns True if the cache entry exists; otherwise False.</returns>
        bool Contains(string key);
    }
}
