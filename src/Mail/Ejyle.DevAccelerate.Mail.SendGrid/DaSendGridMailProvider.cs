﻿// ----------------------------------------------------------------------------------------------------------------------
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
using SG = SendGrid;

namespace Ejyle.DevAccelerate.Mail.SendGrid
{
    public class DaSendGridMailProvider : DaMailProviderBase<SG.Response>
    {
        public DaSendGridMailProvider(DaMailSettings settings)
            : base(settings)
        { }

        public override SG.Response Send(string to, string from, string subject, string body)
        {
            var message = new MailMessage()
            {
                Body = body,
                Subject = subject
            };

            message.From = new MailAddress(from);
            message.To.Add(new MailAddress(to));
            return Send(message);
        }

        public override SG.Response Send(string to, string subject, string body)
        {
            var message = new MailMessage()
            {
                Body = body,
                Subject = subject
            };

            message.From = new MailAddress(Settings.DefaultSenderEmail, Settings.DefaultSenderName);
            message.To.Add(new MailAddress(to));
            return Send(message);
        }


        public override SG.Response Send(MailMessage message)
        {
            return DaAsyncHelper.RunSync(() => SendAsync(message));
        }

        public override Task<SG.Response> SendAsync(MailMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            var oclient = new SG.SendGridClient(Settings.SmtpSettings.ApiKey);

            var sgMessage = new SG.Helpers.Mail.SendGridMessage();

            var from = new SG.Helpers.Mail.EmailAddress();

            sgMessage.Subject = message.Subject;
            sgMessage.HtmlContent = message.Body;

            if (message.From != null)
            {
                sgMessage.From = new SG.Helpers.Mail.EmailAddress(message.From.Address, message.From.DisplayName);
            }
            else
            {
                sgMessage.From = new SG.Helpers.Mail.EmailAddress(Settings.DefaultSenderEmail, Settings.DefaultSenderName);
            }

            if (message.Attachments != null & message.Attachments.Count > 0)
            {
                foreach (var attachment in message.Attachments)
                {
                    using (var reader = new System.IO.StreamReader(attachment.ContentStream))
                    {
                        string contentDisposition = null;
                        string contentType = null;

                        if (attachment.ContentDisposition != null)
                        {
                            contentDisposition = attachment.ContentDisposition.DispositionType;
                        }

                        if (attachment.ContentType != null)
                        {
                            contentType = attachment.ContentType.Name;
                        }

                        sgMessage.AddAttachment(attachment.Name, reader.ReadToEnd(), contentType, contentDisposition, attachment.ContentId);
                    }
                }
            }

            foreach (var to in message.To)
            {
                sgMessage.AddTo(to.Address, to.DisplayName);
            }

            foreach(var cc in message.CC)
            {
                sgMessage.AddCc(cc.Address, cc.DisplayName);
            }

            foreach(var bcc in message.Bcc)
            {
                sgMessage.AddBcc(bcc.Address, bcc.DisplayName);
            }

            SG.Response r = null;

            return oclient.SendEmailAsync(sgMessage);
        }

        public override Task<SG.Response> SendAsync(string to, string from, string subject, string body)
        {
            var message = new MailMessage()
            {
                Body = body,
                Subject = subject
            };

            message.From = new MailAddress(from);
            message.To.Add(new MailAddress(to));

            return SendAsync(message);
        }

        public override Task<SG.Response> SendAsync(string to, string subject, string body)
        {
            var message = new MailMessage()
            {
                Body = body,
                Subject = subject
            };

            message.From = new MailAddress(Settings.DefaultSenderEmail, Settings.DefaultSenderName);
            message.To.Add(new MailAddress(to));

            return SendAsync(message);
        }
    }
}
