// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Ejyle.DevAccelerate.Sms;

namespace Ejyle.DevAccelerate.Identity
{
    /// <summary>
    /// Represents the SMS service used by the <see cref="DaUserManager{TKey, TNullableKey, TUser}"/> to send SMS messages to users.
    /// </summary>
    public class DaSmsService : IIdentityMessageService
    {
        /// <summary>
        /// Asynchronously sends an SMS message to a user.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <returns>The task representing the asynchronous operation.</returns>
        public Task SendAsync(IdentityMessage message)
        {
            if(message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            var smsProvider = DaSmsProviderFactory.GetProvider();

            if(smsProvider == null)
            {
                return Task.FromResult(0);
            }

            return smsProvider.SendAsync(message.Destination, message.Body);
        }
    }
}
