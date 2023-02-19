// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Net.Mail;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Mail
{
    /// <summary>
    /// Represents the interface for mail providers.
    /// </summary>
    public interface IDaMailProvider<TResponse>
    {
        /// <summary>
        /// Gets the mail settings.
        /// </summary>
        DaMailSettings Settings { get; }

        /// <summary>
        /// Sends a mail.
        /// </summary>
        /// <param name="to">The recipient of the mail.</param>
        /// <param name="from">The sender of the mail.</param>
        /// <param name="subject">The subject of the mail</param>
        /// <param name="body">The body of the mail message.</param>
        TResponse Send(string to, string from, string subject, string body);

        /// <summary>
        /// Asynchronously sends a mail.
        /// </summary>
        /// <param name="to">The recipient of the mail.</param>
        /// <param name="from">The sender of the mail.</param>
        /// <param name="subject">The subject of the mail</param>
        /// <param name="body">The body of the mail message.</param>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        Task<TResponse> SendAsync(string to, string from, string subject, string body);

        /// <summary>
        /// Sends a mail.
        /// </summary>
        /// <param name="to">The recipient of the mail.</param>
        /// <param name="subject">The subject of the mail</param>
        /// <param name="body">The body of the mail message.</param>
        TResponse Send(string to, string subject, string body);

        /// <summary>
        /// Asynchronously sends a mail.
        /// </summary>
        /// <param name="to">The recipient of the mail.</param>
        /// <param name="subject">The subject of the mail</param>
        /// <param name="body">The body of the mail message.</param>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        Task<TResponse> SendAsync(string to, string subject, string body);

        /// <summary>
        /// Sends a mail.
        /// </summary>
        /// <param name="message">The mail message object.</param>
        TResponse Send(MailMessage message);

        /// <summary>
        /// Asynchronously sends a mail.
        /// </summary>
        /// <param name="message">The mail message object.</param>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        Task<TResponse> SendAsync(MailMessage message);
    }
}
