// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.SimpleWorkflow.WorkflowKit
{
    public class DaRestApiCallerWorkflowItem : IDaSimpleWorkflowItemAction
    {
        private const string URL = "https://example.com/api";
        private string urlParameters = "?apiKey=sample";

        public async Task<DaSimpleWorkflowItemResult> ExecuteAsync(Dictionary<string, object> mainInput, List<DaSimpleWorkflowItemResult> chainedResult)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;

            DaSimpleWorkflowItemResult result = null;

            if (response.IsSuccessStatusCode)
            {
                object data = await response.Content.ReadAsStringAsync();
                result = new DaSimpleWorkflowItemResult(data);
            }
            else
            {
                var errors = new List<string>();
                errors.Add(response.StatusCode.ToString());
                result = new DaSimpleWorkflowItemResult(errors.ToArray());
            }

            client.Dispose();
            return result;
        }
    }
}
