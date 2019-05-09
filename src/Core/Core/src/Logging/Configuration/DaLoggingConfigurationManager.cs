// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Core.Logging.Configuration
{
    /// <summary>
    /// Provides access to logging configuration. This class cannot be inherited.
    /// </summary>
    public static class DaLoggingConfigurationManager
    {
        private const string CONFIG_NAME = "daLoggingConfiguration";

        /// <summary>
        /// Loads logging configuration into <see cref="DaGlobalApplicationContext"/> from the given configuration source.
        /// </summary>
        /// <param name="configurationSource">The configuration source from which configuration to load.</param>
        public static void InitConfiguration(IDaConfigurationSource configurationSource)
        {
            InitConfiguration(CONFIG_NAME, configurationSource);
        }

        /// <summary>
        /// Loads logging configuration into <see cref="DaGlobalApplicationContext"/> from the given configuration source.
        /// </summary>
        /// <param name="configurationSource">The configuration source from which configuration to load.</param>
        /// <param name="configurationName">The name of the configuration.</param>
        public static void InitConfiguration(string configurationName, IDaConfigurationSource configurationSource)
        {
            DaGlobalApplicationContext.LoadConfiguration<DaLoggingConfigurationSection>(configurationName, configurationSource);
        }

        /// <summary>
        /// Gets logging configuration from <see cref="DaGlobalApplicationContext"/>.
        /// </summary>
        /// <returns>Returns an instance of the <see cref="DaLoggingConfigurationSection"/> configuraiton.</returns>    
        public static DaLoggingConfigurationSection GetConfiguration()
        {
            return GetConfiguration(CONFIG_NAME);
        }

        /// <summary>
        /// Gets logging configuration from <see cref="DaGlobalApplicationContext"/>.
        /// </summary>
        /// <param name="configurationName">The name of the configuration.</param>
        /// <returns>Returns an instance of the <see cref="DaLoggingConfigurationSection"/> configuration.</returns>
        public static DaLoggingConfigurationSection GetConfiguration(string configurationName)
        {
            var config = DaGlobalApplicationContext.GetConfiguration<DaLoggingConfigurationSection>(configurationName);

            if(config == null)
            {
                config = new DaLoggingConfigurationSection();
                config.Providers.Add(new DaProviderConfigurationElement()
                {
                     Name = "defaultLogManager",
                     Type = "Ejyle.DevAccelerate.Core.Logging.DefaultLogManager, DevAccelerate.Core"
                });

                config.DefaultProvider = "defaultLogManager";
            }

            return config;
        }
    }
}
