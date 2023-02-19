// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Microsoft.Extensions.Options;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Mail
{
    /// <summary>
    /// Represents the mail provider that sends emails using local Microsoft IIS.
    /// </summary>
    public class DaMailProvider : DaMailProviderBase<bool>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaMailProvider"/> class.
        /// </summary>
        public DaMailProvider(DaMailSettings settings) : base(settings)
        { }

        /// <summary>
        /// Sends a mail.
        /// </summary>
        /// <param name="message">The mail message object.</param>
        public override bool Send(MailMessage mail)
        {
            var smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
            smtpClient.Send(mail);
            return true;
        }

        /// <summary>
        /// Sends a mail.
        /// </summary>
        /// <param name="to">The recipient of the mail.</param>
        /// <param name="from">The sender of the mail.</param>
        /// <param name="subject">The subject of the mail</param>
        /// <param name="body">The body of the mail message.</param>
        public override bool Send(string to, string from, string subject, string body)
        {
            var message = new MailMessage()
            {
                From = new MailAddress(from),
                Subject = subject,
                Body = body
            };

            return Send(message);
        }

        /// <summary>
        /// Sends a mail.
        /// </summary>
        /// <param name="to">The recipient of the mail.</param>
        /// <param name="subject">The subject of the mail</param>
        /// <param name="body">The body of the mail message.</param>
        public override bool Send(string to, string subject, string body)
        {
            var message = new MailMessage()
            {
                From = new MailAddress(Settings.DefaultSenderEmail, Settings.DefaultSenderName),
                Subject = subject,
                Body = body
            };

            return Send(message);
        }

        /// <summary>
        /// Asynchronously sends a mail.
        /// </summary>
        /// <param name="message">The mail message object.</param>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public override async Task<bool> SendAsync(MailMessage message)
        {
            if(message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if(message.To == null)
            {
                throw new InvalidOperationException("Must have the email address to whom the email needs to be sent.");
            }

            if (message.From == null)
            {
                message.From = new MailAddress(Settings.DefaultSenderEmail);
            }

            var smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
            await smtpClient.SendMailAsync(message);
            return true;
        }

        /// <summary>
        /// Asynchronously sends a mail.
        /// </summary>
        /// <param name="to">The recipient of the mail.</param>
        /// <param name="from">The sender of the mail.</param>
        /// <param name="subject">The subject of the mail</param>
        /// <param name="body">The body of the mail message.</param>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public override Task<bool> SendAsync(string to, string from, string subject, string body)
        {
            var message = new MailMessage()
            {
                From = new MailAddress(from),
                Subject = subject,
                Body = body
            };

            return SendAsync(message);
        }

        /// <summary>
        /// Asynchronously sends a mail.
        /// </summary>
        /// <param name="to">The recipient of the mail.</param>
        /// <param name="subject">The subject of the mail</param>
        /// <param name="body">The body of the mail message.</param>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public override Task<bool> SendAsync(string to, string subject, string body)
        {
            var message = new MailMessage()
            {
                From = new MailAddress(Settings.DefaultSenderEmail, Settings.DefaultSenderName),
                Subject = subject,
                Body = body
            };

            return SendAsync(message);
        }
    }
}
