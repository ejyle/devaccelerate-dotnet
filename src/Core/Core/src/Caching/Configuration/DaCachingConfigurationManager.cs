// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Core.Caching.Configuration
{
    /// <summary>
    /// Provides access to caching configuration. This class cannot be inherited.
    /// </summary>
    public static class DaCachingConfigurationManager
    {
        private const string CONFIG_NAME = "daCachingConfiguration";

        /// <summary>
        /// Loads caching configuration into <see cref="DaGlobalApplicationContext"/> from the given configuration source.
        /// </summary>
        /// <param name="configurationSource">The configuration source from which configuration to load.</param>
        public static void InitConfiguration(IDaConfigurationSource configurationSource)
        {
            InitConfiguration(CONFIG_NAME, configurationSource);
        }

        /// <summary>
        /// Loads caching configuration into <see cref="DaGlobalApplicationContext"/> from the given configuration source.
        /// </summary>
        /// <param name="configurationSource">The configuration source from which configuration to load.</param>
        /// <param name="configurationName">The name of the configuration.</param>
        public static void InitConfiguration(string configurationName, IDaConfigurationSource configurationSource)
        {
            DaGlobalApplicationContext.LoadConfiguration<DaCachingConfigurationSection>(configurationName, configurationSource);
        }

        /// <summary>
        /// Gets caching configuration from <see cref="DaGlobalApplicationContext"/>.
        /// </summary>
        /// <returns>Returns an instance of the <see cref="DaCachingConfigurationSection"/> configuraiton.</returns>
        public static DaCachingConfigurationSection GetConfiguration()
        {
            return GetConfiguration(CONFIG_NAME);
        }

        /// <summary>
        /// Gets caching configuration from <see cref="DaGlobalApplicationContext"/>.
        /// </summary>
        /// <param name="configurationName">The name of the configuration.</param>
        /// <returns>Returns an instance of the <see cref="DaCachingConfigurationSection"/> configuration.</returns>
        public static DaCachingConfigurationSection GetConfiguration(string configurationName)
        {
            var config = DaGlobalApplicationContext.GetConfiguration<DaCachingConfigurationSection>(configurationName);

            if (config == null)
            {
                config = new DaCachingConfigurationSection();
                config.Providers.Add(new DaProviderConfigurationElement()
                {
                    Name = "defaultCacheManager",
                    Type = "Ejyle.DevAccelerate.Core.Caching.DefaultCacheManager, DevAccelerate.Core"
                });

                config.DefaultProvider = "defaultCacheManager";
            }

            return config;
        }
    }
}
