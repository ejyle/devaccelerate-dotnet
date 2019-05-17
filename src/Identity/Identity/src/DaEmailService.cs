// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Mail;
using Microsoft.AspNet.Identity;

namespace Ejyle.DevAccelerate.Identity
{
    /// <summary>
    /// Represents the email service used by <see cref="DaUserManager{TKey, TNullableKey, TUser}"/> for sending emails to users.
    /// </summary>
    public class DaEmailService : IIdentityMessageService
    {
        /// <summary>
        /// Asynschronously sends an email to a user.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <returns>The task representing the asynchronous operation.</returns>
        public Task SendAsync(IdentityMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            var mailProvider = DaMailProviderFactory.GetProvider();

            if (mailProvider == null)
            {
                return Task.FromResult(0);
            }

            var mail = new MailMessage();
            mail.To.Add(message.Destination);
            mail.Subject = message.Subject;
            mail.Body = message.Body;

            return mailProvider.SendAsync(mail);
        }
    }
}
