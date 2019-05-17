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
    /// Represents configuration for managing password policy.
    /// </summary>
    public class DaIdentityPasswordPolicyConfigurationElement : ConfigurationElement
    {
        private const string IS_ENABLED = "isEnabled";
        private const string MIN_REQUIRED_LENGTH = "minRequiredLength";
        private const string REQUIRE_SPECIAL_CHARACTERS = "requireSpecialCharacters";
        private const string REQUIRE_DIGITS = "requireDigits";
        private const string REQUIRE_LOWER_CASE = "requireLowerCase";
        private const string REQUIRE_UPPER_CASE = "requireUpperCase";

        /// <summary>
        /// Determines if the password policy is enabled.
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
        /// Gets or sets the minimum required length for a password.
        /// </summary>
        /// <remarks>The name of the configuration property is minRequiredLength and the default value is 6.</remarks>
        [ConfigurationProperty(MIN_REQUIRED_LENGTH, IsRequired = false, DefaultValue = 6)]
        public int MinRequiredLength
        {
            get
            {
                return Convert.ToInt32(this[MIN_REQUIRED_LENGTH]);
            }
            set
            {
                this[MIN_REQUIRED_LENGTH] = value;
            }
        }

        /// <summary>
        /// Determines if a password is requried to have at least one special character.
        /// </summary>
        /// <remarks>The name of the configuration property is requireSpecialCharacters and the default value is True. The 8 special characters considered are: !, @, #, $, %, ^, *, and _.</remarks>
        [ConfigurationProperty(REQUIRE_SPECIAL_CHARACTERS, IsRequired = false, DefaultValue = true)]
        public bool RequireSpecialCharacters
        {
            get
            {
                return Convert.ToBoolean(this[REQUIRE_SPECIAL_CHARACTERS]);
            }
            set
            {
                this[REQUIRE_SPECIAL_CHARACTERS] = value;
            }
        }

        /// <summary>
        /// Determines if a password requires at least one digit (0 - 9).
        /// </summary>
        /// <remarks>The name of the configuration proerty is requrieDigits and the default value is True.</remarks>
        [ConfigurationProperty(REQUIRE_DIGITS, IsRequired = false, DefaultValue = true)]
        public bool RequireDigits
        {
            get
            {
                return Convert.ToBoolean(this[REQUIRE_DIGITS]);
            }
            set
            {
                this[REQUIRE_DIGITS] = value;
            }
        }

        /// <summary>
        /// Determines if a password requires at least one lower case letter.
        /// </summary>
        /// <remarks>The name of the configuration property is requireLowerCase and the default value is True.</remarks>
        [ConfigurationProperty(REQUIRE_LOWER_CASE, IsRequired = false, DefaultValue = true)]
        public bool RequireLowerCase
        {
            get
            {
                return Convert.ToBoolean(this[REQUIRE_LOWER_CASE]);
            }
            set
            {
                this[REQUIRE_LOWER_CASE] = value;
            }
        }

        /// <summary>
        /// Determines if a password requires at least one upper case letter.
        /// </summary>
        /// <remarks>The name of the configuration property is requireUpperCase and the default value is True.</remarks>
        [ConfigurationProperty(REQUIRE_UPPER_CASE, IsRequired = false, DefaultValue = true)]
        public bool RequireUpperCase
        {
            get
            {
                return Convert.ToBoolean(this[REQUIRE_UPPER_CASE]);
            }
            set
            {
                this[REQUIRE_UPPER_CASE] = value;
            }
        }
    }
}
