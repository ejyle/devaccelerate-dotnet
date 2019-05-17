// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Sms;

namespace Ejyle.DevAccelerate.Sms.Textlocal
{
    public class DaTextlocalSmsProvider : DaSmsProviderBase
    {
        private HttpClient _httpClient = null;

        public DaTextlocalSmsProvider()
        {
            _httpClient = new HttpClient(); 
        }

        public override void Send(string to, string body)
        {
            DaAsyncHelper.RunSync(() => SendAsync(to, body));
        }

        public override void Send(string to, string template, IDictionary<string, string> variables)
        {
            var message = BuildMessageWithVariables(template, variables);
            Send(to, message);
        }

        public override async Task SendAsync(string to, string body)
        {
            var values = new Dictionary<string, string>
            {
                { "apikey", SmsProviderInfo.Token },
                { "sender", SmsProviderInfo.From },
                { "numbers", to },
                { "message", body }
            };

            var requestUri = "https://api.textlocal.in/send";
            var content = new FormUrlEncodedContent(values);
            await _httpClient.PostAsync(requestUri, content);
        }

        public override Task SendAsync(string to, string template, IDictionary<string, string> variables)
        {
            var message = BuildMessageWithVariables(template, variables);
            return SendAsync(to, message);
        }
    }
}
