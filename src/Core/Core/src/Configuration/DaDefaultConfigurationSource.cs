// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Core.Configuration
{
    /// <summary>
    /// Represents the default implementation of configuration source which is either web.config or app.config of the application.
    /// </summary>
    public class DaDefaultConfigurationSource : IDaConfigurationSource
    {
        /// <summary>
        /// Gets a configuration section of a given name from the configuration source.
        /// </summary>
        /// <typeparam name="T">The type of the configuration section.</typeparam>
        /// <param name="configSectionName">The name of the configuration section.</param>
        /// <returns>Returns a generic instance of the <see cref="DaConfigurationSection"/> type.</returns>
        public T GetConfigurationSection<T>(string configSectionName)
            where T : DaConfigurationSection
        {
            return System.Configuration.ConfigurationManager.GetSection(configSectionName) as T;
        }

        /// <summary>
        /// Gets the collection of connection strings stored in the configuration source.
        /// </summary>
        /// <returns>Returns an instance of the <see cref="System.Configuration.ConnectionStringSettingsCollection"/> class.</returns>
        public System.Configuration.ConnectionStringSettingsCollection GetConnectionStrings()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings;
        }

        /// <summary>
        /// Saves changes into the configuration source. This method is not implemented.
        /// </summary>
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
