// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Configuration;

namespace Ejyle.DevAccelerate.Core.Configuration
{
    /// <summary>
    /// Represents a file-based configuration source.
    /// </summary>
    public class DaFileConfigurationSource : IDaConfigurationSource
    {
        private string _ConfigurationFile = null;
        private static System.Configuration.Configuration _Configuration;

        /// <summary>
        /// Initializes an instance of the <see cref="DaFileConfigurationSource"/> class.
        /// </summary>
        /// <param name="configurationFile">The configuration source file.</param>
        public DaFileConfigurationSource(string configurationFile)
        {
            if(String.IsNullOrEmpty(configurationFile))
            {
                throw new ArgumentNullException("configurationFile");
            }

            _ConfigurationFile = configurationFile;

            var configFileMap = new ConfigurationFileMap(_ConfigurationFile);
            _Configuration = ConfigurationManager.OpenMappedMachineConfiguration(configFileMap);
        }

        /// <summary>
        /// Gets the collection of connection strings stored in the configuration source.
        /// </summary>
        /// <returns>Returns an instance of the <see cref="System.Configuration.ConnectionStringSettingsCollection"/> class.</returns>
        /// <remarks>Not implemented for <see cref="DaFileConfigurationSource"/> class.</remarks>
        public ConnectionStringSettingsCollection GetConnectionStrings()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a configuration section of a given name from the configuration source.
        /// </summary>
        /// <typeparam name="T">The type of the configuration section.</typeparam>
        /// <param name="configSectionName">The name of the configuration section.</param>
        /// <returns>Returns a generic instance of the <see cref="DaConfigurationSection"/> type.</returns>
        public T GetConfigurationSection<T>(string configSectionName)
            where T : DaConfigurationSection
        {
            if (_Configuration == null)
            {
                return ConfigurationManager.GetSection(configSectionName) as T;
            }

            return _Configuration.GetSection(configSectionName) as T;
        }

        /// <summary>
        /// Saves changes into the configuration source.
        /// </summary>
        public void Save()
        {
            Configuration.Save();
        }

        /// <summary>
        /// Gets the configuration file information. 
        /// </summary>
        public System.Configuration.Configuration Configuration
        {
            get
            {
                return _Configuration;
            }
        }
    }
}