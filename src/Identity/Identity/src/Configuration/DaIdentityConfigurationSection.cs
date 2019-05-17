// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Identity.Configuration
{
    /// <summary>
    /// Represents the configuration section for identity management in the application.
    /// </summary>
    /// <remarks>The name of the configuration section is daIdentityConfiguration.</remarks>
    public class DaIdentityConfigurationSection : DaConfigurationSection
    {
        private const string TWO_FACTOR_POLICY = "twoFactorPolicy";
        private const string USER_NAME_POLICY = "userNamePolicy";
        private const string PASSWORD_POLICY = "passwordPolicy";
        private const string USER_LOCKOUT_POLICY = "userLockoutPolicy";
        private const string TYPES = "types";

        /// <summary>
        /// Gets or sets the two factory policy settings.
        /// </summary>
        /// <remarks>The name of the configuration property is twoFactorPolicy.</remarks>
        [ConfigurationProperty(TWO_FACTOR_POLICY, IsRequired = false)]
        public DaIdentityTwoFactorPolicyConfigurationElement TwoFactorPolicy
        {
            get
            {
                return this[TWO_FACTOR_POLICY] as DaIdentityTwoFactorPolicyConfigurationElement;
            }
            set
            {
                this[TWO_FACTOR_POLICY] = value;
            }
        }

        /// <summary>
        /// Gets or sets the username policy settings.
        /// </summary>
        /// <remarks>The name of the configuration property is userNamePolicy.</remarks>
        [ConfigurationProperty(USER_NAME_POLICY, IsRequired = false)]
        public DaIdentityUserNamePolicyConfigurationElement UserNamePolicy
        {
            get
            {
                return this[USER_NAME_POLICY] as DaIdentityUserNamePolicyConfigurationElement;
            }
            set
            {
                this[USER_NAME_POLICY] = value;
            }
        }

        /// <summary>
        /// Gets or sets the password policy settings.
        /// </summary>
        /// <remarks>The name of the configuration property is passwordPolicy.</remarks>
        [ConfigurationProperty(PASSWORD_POLICY, IsRequired = false)]
        public DaIdentityPasswordPolicyConfigurationElement PasswordPolicy
        {
            get
            {
                return this[PASSWORD_POLICY] as DaIdentityPasswordPolicyConfigurationElement;
            }
            set
            {
                this[PASSWORD_POLICY] = value;
            }
        }

        /// <summary>
        /// Gets or sets user lockout policy settings.
        /// </summary>
        /// <remarks>The name of the configuration property is userLockoutPolicy.</remarks>
        [ConfigurationProperty(USER_LOCKOUT_POLICY, IsRequired = false)]
        public DaIdentityLockoutPolicyConfigurationElement UserLockoutPolicy
        {
            get
            {
                return this[USER_LOCKOUT_POLICY] as DaIdentityLockoutPolicyConfigurationElement;
            }
            set
            {
                this[USER_LOCKOUT_POLICY] = value;
            }
        }

        /// <summary>
        /// Gets or sets identity types.
        /// </summary>
        public DaProviderConfigurationElementCollection Types
        {
            get
            {
                return this[TYPES] as DaProviderConfigurationElementCollection;
            }
            set
            {
                this[TYPES] = value;
            }
        }

        /// <summary>
        /// Gets the configuration section name.
        /// </summary>
        /// <returns>Returns <see cref="string"/> as configuration section name.</returns>
        public override string GetConfigurationSectionName()
        {
            return "daIdentityConfiguration";
        }
    }
}
