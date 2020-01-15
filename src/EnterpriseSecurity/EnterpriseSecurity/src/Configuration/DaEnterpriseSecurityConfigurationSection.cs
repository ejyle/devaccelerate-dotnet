// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Configuration
{
    /// <summary>
    /// Represents enterprise security configuration.
    /// </summary>
    public class DaEnterpriseSecurityConfigurationSection : DaConfigurationSection
    {
        private const string APP_KEY = "appKey";

        /// <summary>
        /// Gets or sets the app key.
        /// </summary>
        [ConfigurationProperty(APP_KEY, IsRequired = true)]
        public string AppKey
        {
            get
            {
                return this[APP_KEY] as string;
            }
            set
            {
                this[APP_KEY] = value;
            }
        }

        /// <summary>
        /// Gets the name of the enterprise security configuration section.
        /// </summary>
        /// <returns>Returns daEnterpriseSecurityConfiguration as the name of the configuration section.</returns>
        public override string GetConfigurationSectionName()
        {
            return "daEnterpriseSecurityConfiguration";
        }
    }
}
