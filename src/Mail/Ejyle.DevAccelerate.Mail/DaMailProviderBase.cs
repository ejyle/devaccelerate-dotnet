// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;
using Microsoft.Extensions.Options;

namespace Ejyle.DevAccelerate.Mail
{
    /// <summary>
    /// Represents the base and common functionality for a mail provider.
    /// </summary>
    public abstract class DaMailProviderBase : IDaMailProvider
    {
        /// <summary>
        /// Creates an instance of <see cref="DaMailProviderBase"/>.
        /// </summary>
        public DaMailProviderBase(IOptions<DaMailSettings> options)
        {
            if(options == null) { throw new ArgumentNullException(nameof(options)); }            
            Settings = options.Value;
        }

        /// <summary>
        /// Gets the mail settings.
        /// </summary>
        public DaMailSettings Settings { get; private set; }

        /// <summary>
        /// Sends a mail.
        /// </summary>
        /// <param name="to">The recipient of the mail.</param>
        /// <param name="from">The sender of the mail.</param>
        /// <param name="subject">The subject of the mail</param>
        /// <param name="body">The body of the mail message.</param>
        public abstract void Send(string to, string from, string subject, string body);

        /// <summary>
        /// Sends a mail.
        /// </summary>
        /// <param name="message">The mail message object.</param>
        public abstract void Send(MailMessage message);

        /// <summary>
        /// Asynchronously sends a mail.
        /// </summary>
        /// <param name="to">The recipient of the mail.</param>
        /// <param name="from">The sender of the mail.</param>
        /// <param name="subject">The subject of the mail</param>
        /// <param name="body">The body of the mail message.</param>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public abstract Task SendAsync(string to, string from, string subject, string body);

        /// <summary>
        /// Asynchronously sends a mail.
        /// </summary>
        /// <param name="message">The mail message object.</param>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public abstract Task SendAsync(MailMessage message);
    }
}
