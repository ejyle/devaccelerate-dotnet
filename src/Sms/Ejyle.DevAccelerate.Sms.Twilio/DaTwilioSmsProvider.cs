// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Ejyle.DevAccelerate.Sms.Twilio
{
    public class DaTwilioSmsProvider : DaSmsProviderBase
    {
        public DaTwilioSmsProvider(IOptions<DaSmsSettings> options)
            : base(options)
        { }

        public override void Send(string to, string body)
        {
            TwilioClient.Init(Settings.Sid, Settings.Token);

            var destination = new PhoneNumber(to);
            MessageResource.Create(to, from: new PhoneNumber(Settings.From), body: body);
        }

        public override void Send(string to, string template, IDictionary<string, string> variables)
        {
            var message = BuildMessageWithVariables(template, variables);
            Send(to, message);
        }

        public override async Task SendAsync(string to, string body)
        {
            TwilioClient.Init(Settings.Sid, Settings.Token);

            var destination = new PhoneNumber(to);
            await MessageResource.CreateAsync(to, from: new PhoneNumber(Settings.From), body: body);
        }

        public override Task SendAsync(string to, string template, IDictionary<string, string> variables)
        {
            var message = BuildMessageWithVariables(template, variables);
            return SendAsync(to, message);
        }
    }
}
