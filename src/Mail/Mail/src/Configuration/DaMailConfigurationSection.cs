// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Mail.Configuration
{
    /// <summary>
    /// Represents mail configuration.
    /// </summary>
    public class DaMailConfigurationSection : DaProviderConfigurationSection<DaMailProviderConfigurationElementCollection, DaMailProviderConfigurationElement>
    {
        private const string DEFAULT_SENDER_NAME = "defaultSenderName";
        private const string DEFAULT_SENDER_EMAIL = "defaultSenderEmail";

        /// <summary>
        /// Gets or sets the default name of a mail sender.
        /// </summary>
        [ConfigurationProperty(DEFAULT_SENDER_NAME, IsRequired = false, DefaultValue = "DevAccelerate")]
        public string DefaultSenderName
        {
            get
            {
                return this[DEFAULT_SENDER_NAME] as string;
            }
            set
            {
                this[DEFAULT_SENDER_NAME] = value;
            }
        }

        /// <summary>
        /// Gets or sets the default email address of a mail sender.
        /// </summary>
        [ConfigurationProperty(DEFAULT_SENDER_EMAIL, IsRequired = false, DefaultValue = "email@devaccelerate.com")]
        public string DefaultSenderEmail
        {
            get
            {
                return this[DEFAULT_SENDER_EMAIL] as string;
            }
            set
            {
                this[DEFAULT_SENDER_EMAIL] = value;
            }
        }

        /// <summary>
        /// Gets the name of the mail configuration section.
        /// </summary>
        /// <returns>Returns daMailConfiguration as the name of the configuration section.</returns>
        public override string GetConfigurationSectionName()
        {
            return "daMailConfiguration";
        }
    }
}
