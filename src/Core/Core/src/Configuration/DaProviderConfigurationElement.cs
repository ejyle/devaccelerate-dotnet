// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;

namespace Ejyle.DevAccelerate.Core.Configuration
{
    /// <summary>
    /// Represents the base configuration element for a provider under the library's provider model.
    /// </summary>
    public class DaProviderConfigurationElement : ConfigurationElement
    {
        private const string NAME = "name";
        private const string TYPE = "type";

        /// <summary>
        /// Gets or sets the name of a provider.
        /// </summary>
        [ConfigurationProperty(NAME)]
        public string Name
        {
            get
            {
                return this["name"] as string;
            }
            set
            {
                this["name"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of a provider.
        /// </summary>
        [ConfigurationProperty(TYPE, IsRequired = true)]
        public string Type
        {
            get
            {
                return this[TYPE] as string;
            }
            set
            {
                this[TYPE] = value;
            }
        }
    }
}
