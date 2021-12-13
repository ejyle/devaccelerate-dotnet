// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Sms
{
    /// <summary>
    /// Represents the interface for SMS providers.
    /// </summary>
    public interface IDaSmsProvider
    {
        /// <summary>
        /// Sends an SMS message.
        /// </summary>
        /// <param name="to">Phone number to which the SMS message to send.</param>
        /// <param name="body">The body of the message.</param>
        void Send(string to, string body);

        /// <summary>
        /// Asynchronously sends an SMS message.
        /// </summary>
        /// <param name="to">Phone number to which the SMS message to send.</param>
        /// <param name="body">The body of the message.</param>
        Task SendAsync(string to, string body);

        /// <summary>
        /// Gets the SMS settings.
        /// </summary>
        DaSmsSettings Settings { get; }
    }
}
