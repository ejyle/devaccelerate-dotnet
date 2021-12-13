// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

namespace Ejyle.DevAccelerate.Sms
{
    /// <summary>
    /// Represents the configuration of a particular SMS provider.
    /// </summary>
    public class DaSmsSettings
    {
        /// <summary>
        /// Gets or sets the unique SID number that is provided by an SMS provider for API calls.
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// Gets or sets the token provided by an SMS provider for making SMS API calls.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the number from which the SMS are to be sent.
        /// </summary>
        public string From { get; set; }
    }
}
