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
    public class DaHttpGetCallerWorkflowItem : IDaSimpleWorkflowItemAction
    {
        private IDaSimpleWorkflowItemSetting[] _settings = null;

        public async Task<DaSimpleWorkflowItemResult> ExecuteAsync(Dictionary<string, object> parameters)
        {
            if (_settings == null)
            {
                throw new ArgumentNullException("Settings have not been set yet.");
            }

            string url = "", mediaType = "application/json";
            string[] headerParameters = null;

            foreach (var setting in _settings)
            {
                if (setting.Name == "url")
                {
                    url = setting.Value;
                }
                else if (setting.Name == "mediaType")
                {
                    mediaType = setting.Value;
                }
                else if(setting.Name == "headerParameters")
                {
                    headerParameters = setting.Value.Split(',');
                }
            }

            if (string.IsNullOrEmpty(url))
            {
                throw new InvalidOperationException("URL must be set.");
            }

            var client = new HttpClient();
            client.BaseAddress = new Uri(url);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

            StringBuilder sbParams = new StringBuilder();
            sbParams.Append("?");

            foreach (var key in parameters.Keys)
            {
                bool isHeader = false;

                if (headerParameters != null && headerParameters.Length > 0)
                {
                    foreach (var headerParam in headerParameters)
                    {
                        if (key == headerParam.Trim())
                        {
                            client.DefaultRequestHeaders.Add(headerParam.Trim(), parameters[key] as string);
                            isHeader = true;
                        }
                    }
                }

                if (!isHeader)
                {
                    sbParams.Append($"{key}={parameters[key]}&");
                }
            }

            string urlParams = sbParams.ToString();
            urlParams = urlParams.Remove(urlParams.Length - 1, 1);

            HttpResponseMessage response = client.GetAsync(urlParams).Result;

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

        public void SetWorkflowItemSettings(IDaSimpleWorkflowItemSetting[] settings)
        {
            if(settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            _settings = settings;
        }
    }
}
