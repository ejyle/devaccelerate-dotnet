// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Configuration;

namespace Ejyle.DevAccelerate.Identity.Configuration
{
    /// <summary>
    /// Represents configuration for username policy.
    /// </summary>
    public class DaIdentityUserNamePolicyConfigurationElement : ConfigurationElement
    {
        private const string IS_ENABLED = "isEnabled";
        private const string ALLOW_ONLY_ALPHANUMERIC_NAME = "allowOnlyAlphanumericUserNames";
        private const string REQUIRE_UNIQUE_EMAIL = "requireUniqueEmail";

        /// <summary>
        /// Determines if the username policy is enabled.
        /// </summary>
        /// <remarks>The name of the configuration property is isEnabled and the default value is False.</remarks>
        [ConfigurationProperty(IS_ENABLED, IsRequired = false, DefaultValue = false)]
        public bool IsEnabled
        {
            get
            {
                return Convert.ToBoolean(this[IS_ENABLED]);
            }
            set
            {
                this[IS_ENABLED] = value;
            }
        }

        /// <summary>
        /// Determines if only alphanumeric characters in a username.
        /// </summary>
        /// <remarks>The name of the configuration property allowOnlyAlphanumericUserNames and the default value is False.</remarks>
        [ConfigurationProperty(ALLOW_ONLY_ALPHANUMERIC_NAME, IsRequired = false, DefaultValue = false)]
        public bool AllowOnlyAlphanumericUserNames
        {
            get
            {
                return Convert.ToBoolean(this[ALLOW_ONLY_ALPHANUMERIC_NAME]);
            }
            set
            {
                this[ALLOW_ONLY_ALPHANUMERIC_NAME] = value;
            }
        }

        /// <summary>
        /// Determines if email is required to be unique.
        /// </summary>
        /// <remarks>The name of the configuration property is requireUniqueEmail and the default value is True.</remarks>
        [ConfigurationProperty(REQUIRE_UNIQUE_EMAIL, IsRequired = false, DefaultValue = true)]
        public bool RequireUniqueEmail
        {
            get
            {
                return Convert.ToBoolean(this[REQUIRE_UNIQUE_EMAIL]);
            }
            set
            {
                this[REQUIRE_UNIQUE_EMAIL] = value;
            }
        }
    }
}
