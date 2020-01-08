// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Lists.Configuration
{
    /// <summary>
    /// Represents lists configuration.
    /// </summary>
    public class DaListsConfigurationSection : DaConfigurationSection
    {
        private const string DEFAULT_COUNTRY = "defaultCountry";
        private const string DEFAULT_CURRENCY = "defaultCurrency";
        private const string DEFAULT_TIME_ZONE = "defaultTimeZone";
        private const string DEFAULT_SYSTEM_LANGUAGE = "defaultSystemLanguage";

        /// <summary>
        /// Gets or sets the defualt country from the countries list.
        /// </summary>
        [ConfigurationProperty(DEFAULT_COUNTRY, IsRequired = false, DefaultValue = "United States of America")]
        public string DefaultCountry
        {
            get
            {
                return this[DEFAULT_COUNTRY] as string;
            }
            set
            {
                this[DEFAULT_COUNTRY] = value;
            }
        }

        /// <summary>
        /// Gets or sets the defualt currency from the currencies list.
        /// </summary>
        [ConfigurationProperty(DEFAULT_CURRENCY, IsRequired = false, DefaultValue = "US Dollar")]
        public string DefaultCurrency
        {
            get
            {
                return this[DEFAULT_CURRENCY] as string;
            }
            set
            {
                this[DEFAULT_CURRENCY] = value;
            }
        }

        /// <summary>
        /// Gets or sets the defualt time zone from the time zones list.
        /// </summary>
        [ConfigurationProperty(DEFAULT_TIME_ZONE, IsRequired = false, DefaultValue = "Eastern Standard Time")]
        public string DefaultTimeZone
        {
            get
            {
                return this[DEFAULT_TIME_ZONE] as string;
            }
            set
            {
                this[DEFAULT_TIME_ZONE] = value;
            }
        }

        /// <summary>
        /// Gets or sets the defualt system language from the system languages list.
        /// </summary>
        [ConfigurationProperty(DEFAULT_SYSTEM_LANGUAGE, IsRequired = false, DefaultValue = "en-US")]
        public string DefaultSystemLanguage
        {
            get
            {
                return this[DEFAULT_SYSTEM_LANGUAGE] as string;
            }
            set
            {
                this[DEFAULT_SYSTEM_LANGUAGE] = value;
            }
        }

        /// <summary>
        /// Gets the name of the lists configuration section.
        /// </summary>
        /// <returns>Returns daListsConfiguration as the name of the configuration section.</returns>
        public override string GetConfigurationSectionName()
        {
            return "daListsConfiguration";
        }
    }
}
