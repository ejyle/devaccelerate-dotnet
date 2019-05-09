// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

namespace Ejyle.DevAccelerate.Core.Configuration
{
    /// <summary>
    /// Defines the methods for a configuration source.
    /// </summary>
    public interface IDaConfigurationSource
    {
        /// <summary>
        /// Gets a configuration section by its name from the configuration source.
        /// </summary>
        /// <typeparam name="TConfigurationSection">The type of the configuration section.</typeparam>
        /// <param name="configSectionName">The name of the configuration section.</param>
        /// <returns>Returns an instance of the generic configuration section type.</returns>
        TConfigurationSection GetConfigurationSection<TConfigurationSection>(string configSectionName)
            where TConfigurationSection : DaConfigurationSection;

        /// <summary>
        /// Gets the collection of connection strings stored in the configuration source.
        /// </summary>
        /// <returns>Returns an instance of the <see cref="System.Configuration.ConnectionStringSettingsCollection"/> class.</returns>
        System.Configuration.ConnectionStringSettingsCollection GetConnectionStrings();

        /// <summary>
        /// Saves changes into the configuration source.
        /// </summary>
        void Save();
    }
}
