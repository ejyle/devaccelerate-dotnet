// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Ejyle.DevAccelerate.Sms
{
    /// <summary>
    /// Represents the base and common functionality for a SMS provider.
    /// </summary>
    public abstract class DaSmsProviderBase : IDaSmsProvider
    {
        /// <summary>
        /// Creates an instance of <see cref="DaSmsProviderBase"/>.
        /// </summary>
        public DaSmsProviderBase(IOptions<DaSmsSettings> options)
        {
            if(options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            this.Settings = options.Value;        
        }

        /// <summary>
        /// Gets the SMS settings.
        /// </summary>
        public DaSmsSettings Settings { get; private set; }

        /// <summary>
        /// Sends an SMS.
        /// </summary>
        /// <param name="to">The recipient of the SMS.</param>
        /// <param name="body">The body of the SMS message.</param>
        public abstract void Send(string to, string body);

        /// <summary>
        /// Asynchronously sends an SMS.
        /// </summary>
        /// <param name="to">The recipient of the SMS.</param>
        /// <param name="body">The body of the SMS message.</param>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public abstract Task SendAsync(string to, string body);

        /// <summary>
        /// Sends an SMS out of a template.
        /// </summary>
        /// <param name="to">The recipient of the SMS.</param>
        /// <param name="template">The message template of the SMS message.</param>
        /// <param name="variables">The set of variables to be used with the message template.</param>
        public abstract void Send(string to, string template, IDictionary<string, string> variables);

        /// <summary>
        /// Asynchronously sends an SMS out of a template.
        /// </summary>
        /// <param name="to">The recipient of the SMS.</param>
        /// <param name="template">The message template of the SMS message.</param>
        /// <param name="variables">The set of variables to be used with the message template.</param>
        public abstract Task SendAsync(string to, string template, IDictionary<string, string> variables);

        /// <summary>
        /// Creates a message string out of message template and associated set of variables.
        /// </summary>
        /// <param name="template">The message template.</param>
        /// <param name="variables">The set of variables (keys and values).</param>
        /// <returns>Returns an instance of <see cref="System.String"/>.</returns>
        protected string BuildMessageWithVariables(string template, IDictionary<string, string> variables)
        {
            var message = template;

            foreach (var variable in variables)
            {
                message.Replace(variable.Key, variable.Value);
            }

            return message;
        }
    }
}
