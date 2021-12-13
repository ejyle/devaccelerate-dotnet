// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;

namespace Ejyle.DevAccelerate.Mail
{
    /// <summary>
    /// Represents mail settings.
    /// </summary>
    public class DaMailSettings
    {
        /// <summary>
        /// Gets or sets the default name of a mail sender.
        /// </summary>
        public string DefaultSenderName { get; set; }

        /// <summary>
        /// Gets or sets the default email address of a mail sender.
        /// </summary>
        public string DefaultSenderEmail { get; set; }

        /// <summary>
        /// Gets or sets the SMTP settings.
        /// </summary>
        public DaSmtpSettings SmtpSettings { get; set; }
    }

    /// <summary>
    /// Represents the configuration of a particular mail provider.
    /// </summary>
    public class DaSmtpSettings
    {
        /// <summary>
        /// Gets or sets the host name of a mail provider.
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets user ID of the mail provider.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets password of the mail provider.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets port of the mail provider.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the API key of the mail provider. This property is supposed to be mutually exclusive with <see cref="UserId"/> and <see cref="Password"/> properties.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Determines if the SSL is to be used for the mail provider.
        /// </summary>
        public bool UseSsl { get; set; }
    }
}
