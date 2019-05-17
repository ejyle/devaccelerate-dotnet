// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Apps.Configuration
{
    /// <summary>
    /// Represents apps configuration.
    /// </summary>
    public class DaAppsConfigurationSection : DaConfigurationSection
    {
        private const string APP_NAME = "appName";

        /// <summary>
        /// Gets or sets the name of the app.
        /// </summary>
        [ConfigurationProperty(APP_NAME, IsRequired = false, DefaultValue = "DevAccelerateApp")]
        public string AppName
        {
            get
            {
                return this[APP_NAME] as string;
            }
            set
            {
                this[APP_NAME] = value;
            }
        }

        /// <summary>
        /// Gets the name of the apps configuration section.
        /// </summary>
        /// <returns>Returns daAppsConfiguration as the name of the configuration section.</returns>
        public override string GetConfigurationSectionName()
        {
            return "daAppsConfiguration";
        }
    }
}
