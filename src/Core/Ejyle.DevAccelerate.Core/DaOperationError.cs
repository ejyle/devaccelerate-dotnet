// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Core
{
    /// <summary>
    /// Represents information about an error encountered during the execution of an operation.
    /// </summary>
    public class DaOperationError
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaOperationError"/> class.
        /// </summary>
        /// <param name="code">Sets the value of the <see cref="Code"/> property</param>
        /// <param name="description">Sets the value of the <see cref="Description"/> property</param>
        /// <exception cref="ArgumentNullException">Thrown if description is null or empty.</exception>
        public DaOperationError(string code, string description)
        {
            if(string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException(nameof(description));
            }

            this.Code = code;
            this.Description = description;
        }

        /// <summary>
        /// Creates an instance of the <see cref="DaOperationError"/> class.
        /// </summary>
        /// <param name="description">Sets the value of the <see cref="Description"/> property</param>
        /// <exception cref="ArgumentNullException">Thrown if description is null or empty.</exception>
        public DaOperationError(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException(nameof(description));
            }

            this.Description = description;
        }

        /// <summary>
        /// Gets the short code of the error.
        /// </summary>
        public string Code
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the more detailed description of the error.
        /// </summary>
        public string Description
        {
            get;
            private set;
        }
    }
}
