// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Mail
{
    /// <summary>
    /// Represents the generic SMTP mail provider implementation for sending mails.
    /// </summary>
    public class DaSmtpMailProvider : DaMailProviderBase
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaSmtpMailProvider"/> class.
        /// </summary>
        public DaSmtpMailProvider(IOptions<DaMailSettings> settings) : base(settings)
        { }

        /// <summary>
        /// Sends a mail.
        /// </summary>
        /// <param name="message">The mail message object.</param>
        public override void Send(MailMessage mail)
        {
            var smtpClient = new SmtpClient(Settings.Value.SmtpSettings.HostName);

            smtpClient.Port = Settings.Value.SmtpSettings.Port;
            smtpClient.Credentials = new System.Net.NetworkCredential(Settings.Value.SmtpSettings.UserId, Settings.Value.SmtpSettings.Password);
            smtpClient.EnableSsl = Settings.Value.SmtpSettings.UseSsl;

            smtpClient.Send(mail);
        }

        /// <summary>
        /// Sends a mail.
        /// </summary>
        /// <param name="to">The recipient of the mail.</param>
        /// <param name="from">The sender of the mail.</param>
        /// <param name="subject">The subject of the mail</param>
        /// <param name="body">The body of the mail message.</param>
        public override void Send(string to, string from, string subject, string body)
        {
            var message = new MailMessage()
            {
                From = new MailAddress(from),
                Subject = subject,
                Body = body
            };

            Send(message);
        }

        /// <summary>
        /// Asynchronously sends a mail.
        /// </summary>
        /// <param name="message">The mail message object.</param>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public override Task SendAsync(MailMessage message)
        {
            var smtpClient = new SmtpClient(Settings.Value.SmtpSettings.HostName);

            smtpClient.Port = (int)Settings.Value.SmtpSettings.Port;
            smtpClient.Credentials = new System.Net.NetworkCredential(Settings.Value.SmtpSettings.UserId, Settings.Value.SmtpSettings.Password);
            smtpClient.EnableSsl = Settings.Value.SmtpSettings.UseSsl;

            return smtpClient.SendMailAsync(message);
        }

        /// <summary>
        /// Asynchronously sends a mail.
        /// </summary>
        /// <param name="to">The recipient of the mail.</param>
        /// <param name="from">The sender of the mail.</param>
        /// <param name="subject">The subject of the mail</param>
        /// <param name="body">The body of the mail message.</param>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public override Task SendAsync(string to, string from, string subject, string body)
        {
            var message = new MailMessage()
            {
                From = new MailAddress(from),
                Subject = subject,
                Body = body
            };

            return SendAsync(message);
        }
    }
}
