// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Core
{
    /// <summary>
    /// Represents the APIs to manage the global context of a DevAccelerate application. This class cannot be inherited.
    /// </summary>
    public static class DaGlobalApplicationContext
    {
        private static Dictionary<string, DaConfigurationSection> _Settings = new Dictionary<string, DaConfigurationSection>();

        /// <summary>
        /// Initializes a given configuration from configuration source.
        /// </summary>
        /// <typeparam name="TConfigurationSection">The type of the configuration section.</typeparam>
        /// <param name="configurationName">The name of the configuration section.</param>
        /// <param name="configurationSource">The source of the configuration section.</param>
        public static void LoadConfiguration<TConfigurationSection>(string configurationName, IDaConfigurationSource configurationSource)
            where TConfigurationSection: DaConfigurationSection
        {
            if(string.IsNullOrEmpty(configurationName))
            {
                throw new ArgumentNullException(nameof(configurationName));
            }

            if(configurationSource == null)
            {
                throw new ArgumentNullException(nameof(configurationSource));
            }

            if(_Settings.ContainsKey(configurationName))
            {
                throw new InvalidOperationException($"The {configurationName} has already been loaded.");
            }

            var settings = configurationSource.GetConfigurationSection<TConfigurationSection>(configurationName);
            _Settings.Add(configurationName, settings);
        }

        /// <summary>
        /// Gets the configuration section by its name.
        /// </summary>
        /// <typeparam name="TConfigurationSection">The type of the configuration source.</typeparam>
        /// <param name="configurationName">The name of the configuration section.</param>
        /// <returns>Returns an instance of the <see cref="DaConfigurationSection"/> type.</returns>
        public static TConfigurationSection GetConfiguration<TConfigurationSection>(string configurationName)
            where TConfigurationSection: DaConfigurationSection
        {
            if (_Settings.ContainsKey(configurationName))
            {
                return _Settings[configurationName] as TConfigurationSection;
            }

            return null;
        }      
    }
}
