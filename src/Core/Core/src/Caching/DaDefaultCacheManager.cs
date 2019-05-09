// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Caching;

namespace Ejyle.DevAccelerate.Core.Caching
{
    /// <summary>
    /// Represents the in-memory cache implementation of the <see cref="IDaCacheManager"/> interface.
    /// </summary>
    public class DaDefaultCacheManager : IDaCacheManager
    {
        ObjectCache cache = null;
        CacheItemPolicy policy = null;

        /// <summary>
        /// Initializes an instance of the <see cref="DaDefaultCacheManager"/> class.
        /// </summary>
        public DaDefaultCacheManager()
        {
            cache = MemoryCache.Default;
            policy = new CacheItemPolicy();
        }

        /// <summary>
        /// Inserts a cache entiry into the cache.
        /// </summary>
        /// <param name="key">A unique identifier for the cache entry.</param>
        /// <param name="value">The object to insert into the cache.</param>
        public void Add(string key, object value)
        {
            cache.Set(key, value, policy);
        }

        /// <summary>
        /// Gets a cache entry with a given key from the cache.
        /// </summary>
        /// <param name="key">The unique identifier for the cache entry to retrieve.</param>
        /// <returns>Returns the cache entry as an <see cref="object"/> type.</returns>
        public object GetData(string key)
        {
            return cache[key] as string;
        }

        /// <summary>
        /// Gets the number of entires in the cache.
        /// </summary>
        public long Count
        {
            get
            {
                return cache.GetCount();
            }
        }

        /// <summary>
        /// Clears the cache. This method is not currently implemented.
        /// </summary>
        public void Flush()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if cache entry with a given key already exists in the cache.
        /// </summary>
        /// <param name="key">The unique identifier for the cache entry.</param>
        /// <returns>Returns True if the cache entry exists; otherwise False.</returns>
        public bool Contains(string key)
        {
            return cache.Contains(key);
        }
    }
}
