// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Core.Exceptions.Configuration
{
    /// <summary>
    /// Provides access to exception handling configuration. This class cannot be inherited.
    /// </summary>
    public static class DaExceptionHandlingConfigurationManager
    {
        private const string CONFIG_NAME = "daExceptionHandlingConfiguration";

        /// <summary>
        /// Loads exception handling configuration into <see cref="DaGlobalApplicationContext"/> from the given configuration source.
        /// </summary>
        /// <param name="configurationSource">The configuration source from which configuration to load.</param>
        public static void InitConfiguration(IDaConfigurationSource configurationSource)
        {
            InitConfiguration(CONFIG_NAME, configurationSource);
        }

        /// <summary>
        /// Loads exception handling configuration into <see cref="DaGlobalApplicationContext"/> from the given configuration source.
        /// </summary>
        /// <param name="configurationSource">The configuration source from which configuration to load.</param>
        /// <param name="configurationName">The name of the configuration.</param>
        public static void InitConfiguration(string configurationName, IDaConfigurationSource configurationSource)
        {
            DaGlobalApplicationContext.LoadConfiguration<DaExceptionHandlingConfigurationSection>(configurationName, configurationSource);
        }

        /// <summary>
        /// Gets exception handling configuration from <see cref="DaGlobalApplicationContext"/>.
        /// </summary>
        /// <returns>Returns an instance of the <see cref="DaExceptionHandlingConfigurationSection"/> configuraiton.</returns>    
        public static DaExceptionHandlingConfigurationSection GetConfiguration()
        {
            return GetConfiguration(CONFIG_NAME);
        }

        /// <summary>
        /// Gets exception handling configuration from <see cref="DaGlobalApplicationContext"/>.
        /// </summary>
        /// <param name="configurationName">The name of the configuration.</param>
        /// <returns>Returns an instance of the <see cref="DaExceptionHandlingConfigurationSection"/> configuration.</returns>
        public static DaExceptionHandlingConfigurationSection GetConfiguration(string configurationName)
        {
            var config = DaGlobalApplicationContext.GetConfiguration<DaExceptionHandlingConfigurationSection>(configurationName);

            if (config == null)
            {
                config = new DaExceptionHandlingConfigurationSection();
                config.Providers.Add(new DaProviderConfigurationElement()
                {
                    Name = "defaultExceptionManager",
                    Type = "Ejyle.DevAccelerate.Core.Exceptions.DefaultExceptionManager, DevAccelerate.Core"
                });

                config.DefaultProvider = "defaultExceptionManager";
            }

            return config;
        }
    }
}
