// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Configuration;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Mail.Configuration
{
    /// <summary>
    /// Represents the configuration of a particular mail provider.
    /// </summary>
    public class DaMailProviderConfigurationElement : DaProviderConfigurationElement
    {
        private const string HOST_NAME = "hostName";
        private const string USER_ID = "userId";
        private const string PASSWORD = "password";
        private const string PORT = "port";
        private const string API_KEY = "apiKey";
        private const string USE_SSL = "useSsl";

        /// <summary>
        /// Gets or sets the host name of a mail provider.
        /// </summary>
        [ConfigurationProperty(HOST_NAME, IsRequired = false, DefaultValue = null)]
        public string HostName
        {
            get
            {
                return this[HOST_NAME] as string;
            }
            set
            {
                this[HOST_NAME] = value;
            }
        }

        /// <summary>
        /// Gets or sets user ID of the mail provider.
        /// </summary>
        [ConfigurationProperty(USER_ID, IsRequired = false, DefaultValue = null)]
        public string UserId
        {
            get
            {
                return this[USER_ID] as string;
            }
            set
            {
                this[USER_ID] = value;
            }
        }

        /// <summary>
        /// Gets or sets password of the mail provider.
        /// </summary>
        [ConfigurationProperty(PASSWORD, IsRequired = false, DefaultValue = null)]
        public string Password
        {
            get
            {
                return this[PASSWORD] as string;
            }
            set
            {
                this[PASSWORD] = value;
            }
        }

        /// <summary>
        /// Gets or sets port of the mail provider.
        /// </summary>
        [ConfigurationProperty(PORT, IsRequired = false, DefaultValue = 25)]
        public int Port
        {
            get
            {
                return Convert.ToInt32(this[PORT]);
            }
            set
            {
                this[PORT] = value;
            }
        }

        /// <summary>
        /// Gets or sets the API key of the mail provider. This property is supposed to be mutually exclusive with <see cref="UserId"/> and <see cref="Password"/> properties.
        /// </summary>
        [ConfigurationProperty(API_KEY, IsRequired = false, DefaultValue = null)]
        public string ApiKey
        {
            get
            {
                return this[API_KEY] as string;
            }
            set
            {
                this[API_KEY] = value;
            }
        }

        /// <summary>
        /// Determines if the SSL is to be used for the mail provider.
        /// </summary>
        [ConfigurationProperty(USE_SSL, IsRequired = false, DefaultValue = true)]
        public bool UseSsl
        {
            get
            {
                return Convert.ToBoolean(this[USE_SSL]);
            }
            set
            {
                this[USE_SSL] = value;
            }
        }
    }
}
