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
    /// Represents configuration for managing user account lockout policy.
    /// </summary>
    public class DaIdentityLockoutPolicyConfigurationElement : ConfigurationElement
    {
        private const string IS_ENABLED = "isEnabled";
        private const string DEFAULT_LOCKOUT_TIME_SPAN = "defaultLockoutTimeSpan";
        private const string USER_LOCKOUT_ENABLED_BY_DEFAULT = "userLockoutEnabledByDefault";
        private const string MAX_FAILED_ACCESS_ATTEMPTS_BEFORE_LOCKOUT = "maxFailedAccessAttemptsBeforeLockout";

        /// <summary>
        /// Determines if lockout policy is enabled.
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
        /// Gets or sets the amount of time a user account is locked out.
        /// </summary>
        /// <remarks>The name of the configuration property is defaultLockoutTimeSpan and the default value is 5.</remarks>
        [ConfigurationProperty(DEFAULT_LOCKOUT_TIME_SPAN, IsRequired = false, DefaultValue = 5)]
        public int DefaultLockoutTimeSpan
        {
            get
            {
                return Convert.ToInt32(this[DEFAULT_LOCKOUT_TIME_SPAN]);
            }
            set
            {
                this[DEFAULT_LOCKOUT_TIME_SPAN] = value;
            }
        }

        /// <summary>
        /// Determines if a user account is locked out by default when its created.
        /// </summary>
        /// <remarks>The name of the configuration property is userLockoutEnabledByDefault and the default value is False.</remarks>
        [ConfigurationProperty(USER_LOCKOUT_ENABLED_BY_DEFAULT, IsRequired = false, DefaultValue = false)]
        public bool UserLockoutEnabledByDefault
        {
            get
            {
                return Convert.ToBoolean(this[USER_LOCKOUT_ENABLED_BY_DEFAULT]);
            }
            set
            {
                this[USER_LOCKOUT_ENABLED_BY_DEFAULT] = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum number of failed access atempts before a user account is automatically locked out.
        /// </summary>
        /// <remarks>The name of the configuration property is maxFailedAccessAttemptsBeforeLockout and the default value is 5.</remarks>
        [ConfigurationProperty(MAX_FAILED_ACCESS_ATTEMPTS_BEFORE_LOCKOUT, IsRequired = false, DefaultValue = 5)]
        public int MaxFailedAccessAttemptsBeforeLockout
        {
            get
            {
                return Convert.ToInt32(this[MAX_FAILED_ACCESS_ATTEMPTS_BEFORE_LOCKOUT]);
            }
            set
            {
                this[MAX_FAILED_ACCESS_ATTEMPTS_BEFORE_LOCKOUT] = value;
            }
        }
    }
}
