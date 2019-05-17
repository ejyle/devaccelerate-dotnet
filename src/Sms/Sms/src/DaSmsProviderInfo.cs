// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

namespace Ejyle.DevAccelerate.Sms
{
    /// <summary>
    /// Represents SMS provider information.
    /// </summary>
    public class DaSmsProviderInfo
    {
        /// <summary>
        /// Gets or sets the number from which an SMS is sent.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Gets or sets the unique Sid for making API calls for sending SMS messages.
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// Gets or sets the token for making API calls for sending SMS messages.
        /// </summary>
        public string Token { get; set; }
    }
}
