// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Xml;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Core.Data.Configuration
{
    /// <summary>
    /// Provides access to data configuration. This class cannot be inherited.
    /// </summary>
    public static class DaDataConfigurationManager
    {
        private const string CONFIG_NAME = "daDataConfiguration";
        private static IDaConfigurationSource _configurationSource = null;

        /// <summary>
        /// Gets the underlying configuration source.
        /// </summary>
        public static IDaConfigurationSource ConfigurationSource
        {
            get
            {
                return _configurationSource;
            }
        }

        /// <summary>
        /// Loads data configuration into <see cref="DaGlobalApplicationContext"/> from the given configuration source.
        /// </summary>
        /// <param name="configurationSource">The configuration source from which configuration to load.</param>
        public static void InitConfiguration(IDaConfigurationSource configurationSource)
        {
            if(configurationSource == null)
            {
                throw new ArgumentNullException(nameof(configurationSource));
            }

            _configurationSource = configurationSource;

            InitConfiguration(CONFIG_NAME, configurationSource);
        }

        /// <summary>
        /// Loads data configuration into <see cref="DaGlobalApplicationContext"/> from the given configuration source.
        /// </summary>
        /// <param name="configurationSource">The configuration source from which configuration to load.</param>
        /// <param name="configurationName">The name of the configuration.</param>
        public static void InitConfiguration(string configurationName, IDaConfigurationSource configurationSource)
        {
            if (configurationSource == null)
            {
                throw new ArgumentNullException(nameof(configurationSource));
            }

            _configurationSource = configurationSource;

            DaGlobalApplicationContext.LoadConfiguration<DaDataConfigurationSection>(configurationName, configurationSource);
        }

        /// <summary>
        /// Gets data configuration from <see cref="DaGlobalApplicationContext"/>.
        /// </summary>
        /// <returns>Returns an instance of the <see cref="DaDataConfigurationSection"/> configuraiton.</returns>        
        public static DaDataConfigurationSection GetConfiguration()
        {
            return GetConfiguration(CONFIG_NAME);
        }

        /// <summary>
        /// Gets data configuration from <see cref="DaGlobalApplicationContext"/>.
        /// </summary>
        /// <param name="configurationName">The name of the configuration.</param>
        /// <returns>Returns an instance of the <see cref="DaDataConfigurationSection"/> configuration.</returns>
        public static DaDataConfigurationSection GetConfiguration(string configurationName)
        {
            var config = DaGlobalApplicationContext.GetConfiguration<DaDataConfigurationSection>(configurationName);

            if (config == null)
            {
                config = new DaDataConfigurationSection();
                config.DbConnection = "daDbConnection";
            }

            return config;
        }
    }
}
