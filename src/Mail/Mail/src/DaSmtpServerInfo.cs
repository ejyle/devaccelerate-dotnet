// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

namespace Ejyle.DevAccelerate.Mail
{
    public class DaSmtpServerInfo
    {
        public string Host { get; set; }

        public string UserId { get; set; }

        public string Password { get; set; }

        public int? Port { get; set; }

        public string ApiKey { get; set; }

        public bool UseSsl { get; set; }
    }
}
