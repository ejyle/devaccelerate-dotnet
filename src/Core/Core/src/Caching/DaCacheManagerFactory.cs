// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core.Caching.Configuration;

namespace Ejyle.DevAccelerate.Core.Caching
{
    /// <summary>
    /// Represents the factory for creating <see cref="IDaCacheManager"/>.
    /// </summary>
    public static class DaCacheManagerFactory
    {
        /// <summary>
        /// Creates an intance of a cache manager.
        /// </summary>
        /// <typeparam name="TCacheManager">The type of the cache manager.</typeparam>
        /// <returns>Returns an instance of the TCacheManager type that implements the <see cref="IDaCacheManager"/> interface.</returns>
        public static TCacheManager CreateCacheManager<TCacheManager>()
            where TCacheManager : IDaCacheManager
        {
            var cachingConfiguration = DaCachingConfigurationManager.GetConfiguration();

            if (cachingConfiguration == null)
            {
                throw new InvalidOperationException("Caching configuration has not been set up and therefore cache manager cannot be created.");
            }

            var providerConfig = cachingConfiguration.Providers.GetByName(cachingConfiguration.DefaultProvider);

            Type type = Type.GetType(providerConfig.Type);
            var cacheManager = (TCacheManager)Activator.CreateInstance(type);

            return cacheManager;
        }

        /// <summary>
        /// Creates an intance of a cache manager.
        /// </summary>
        /// <returns>Returns an instance of the <see cref="IDaCacheManager"/> type.</returns>
        public static IDaCacheManager CreateCacheManager()
        {
            var cachingConfiguration = DaCachingConfigurationManager.GetConfiguration();

            if (cachingConfiguration == null)
            {
                throw new InvalidOperationException("Caching configuration has not been set up and therefore cache manager cannot be created.");
            }

            var providerConfig = cachingConfiguration.Providers.GetByName(cachingConfiguration.DefaultProvider);

            Type type = Type.GetType(providerConfig.Type);
            var cacheManager = (IDaCacheManager)Activator.CreateInstance(type);

            return cacheManager;
        }
    }
}
