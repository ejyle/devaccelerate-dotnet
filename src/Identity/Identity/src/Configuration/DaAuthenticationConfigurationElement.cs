// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Identity.Configuration
{
    /// <summary>
    /// Represents configuration for authentication mechanism in DevAccelerate ASP.NET Identity.
    /// </summary>
    public class DaAuthenticationConfigurationElement : ConfigurationElement
    {
        private const string LOGIN_PATH = "loginPath";
        private const string COOKIE_EXPIRY_TIME = "cookieExpiryTime";
        private const string COOKIE_NAME = "cookieName";
        private const string COOKIE_DOMAIN = "cookieDomain";

        /// <summary>
        /// Gets or sets the path of the login page.
        /// </summary>
        /// <remarks>The name of the configuration property is loginPath and the default value is ~/account/login.</remarks>
        [ConfigurationProperty(LOGIN_PATH, IsRequired = false, DefaultValue = "~/account/login")]
        public string IsEnabled
        {
            get
            {
                return this[LOGIN_PATH] as string;
            }
            set
            {
                this[LOGIN_PATH] = value;
            }
        }

        /// <summary>
        /// Gets or sets the expiry time (in minutes) of the authentication cookie.
        /// </summary>
        /// <remarks>The name of the configuration property is cookieExpiryTime and the default value is 20.</remarks>
        [ConfigurationProperty(COOKIE_EXPIRY_TIME, IsRequired = false, DefaultValue = 20)]
        public int CookieExpiryTime
        {
            get
            {
                return Convert.ToInt32(this[COOKIE_EXPIRY_TIME]);
            }
            set
            {
                this[COOKIE_EXPIRY_TIME] = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the authentication cookie.
        /// </summary>
        /// <remarks>The name of the configuration property is cookieName and the default value is DaAuthenticationCookie.</remarks>
        [ConfigurationProperty(COOKIE_NAME, IsRequired = false, DefaultValue = "DaAuthenticationCookie")]
        public string CookieName
        {
            get
            {
                return this[COOKIE_NAME] as string;
            }
            set
            {
                this[COOKIE_NAME] = value;
            }
        }
    }
}
