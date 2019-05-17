// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Sms.Configuration
{
    /// <summary>
    /// Represents the configuration of a particular SMS provider.
    /// </summary>
    public class DaSmsProviderConfigurationElement : DaProviderConfigurationElement
    {
        private const string SID = "sid";
        private const string TOKEN = "token";
        private const string FROM = "from";

        /// <summary>
        /// Gets or sets the unique SID number that is provided by an SMS provider for API calls.
        /// </summary>
        [ConfigurationProperty(SID, IsRequired = false)]
        public string Sid
        {
            get
            {
                return this[SID] as string;
            }
            set
            {
                this[SID] = value;
            }
        }

        /// <summary>
        /// Gets or sets the token provided by an SMS provider for making SMS API calls.
        /// </summary>
        [ConfigurationProperty(TOKEN, IsRequired = false)]
        public string Token
        {
            get
            {
                return this[TOKEN] as string;
            }
            set
            {
                this[TOKEN] = value;
            }
        }

        /// <summary>
        /// Gets or sets the number from which the SMS are to be sent.
        /// </summary>
        [ConfigurationProperty(FROM, IsRequired = true)]
        public string From
        {
            get
            {
                return this[FROM] as string;
            }
            set
            {
                this[FROM] = value;
            }
        }
    }
}
