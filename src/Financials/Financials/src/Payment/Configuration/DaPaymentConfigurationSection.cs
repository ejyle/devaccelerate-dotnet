// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Financials.Payment.Configuration
{
    /// <summary>
    /// Represents apps configuration.
    /// </summary>
    public class DaAppsConfigurationSection : DaConfigurationSection
    {
        private const string DEFAULT_PAYMENT_GATEWAY = "defaultPaymentGateway";

        /// <summary>
        /// Gets or sets the name of the app.
        /// </summary>
        [ConfigurationProperty(DEFAULT_PAYMENT_GATEWAY, IsRequired = false, DefaultValue = "stripe")]
        public string DefaultPaymentGateway
        {
            get
            {
                return this[DEFAULT_PAYMENT_GATEWAY] as string;
            }
            set
            {
                this[DEFAULT_PAYMENT_GATEWAY] = value;
            }
        }

        /// <summary>
        /// Gets the name of the apps configuration section.
        /// </summary>
        /// <returns>Returns daAppsConfiguration as the name of the configuration section.</returns>
        public override string GetConfigurationSectionName()
        {
            return "daPaymentConfiguration";
        }
    }
}
