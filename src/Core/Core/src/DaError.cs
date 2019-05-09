// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Core
{
    /// <summary>
    /// Represents an error related for an entity result.
    /// </summary>
    public class DaError
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaError"/> class.
        /// </summary>
        /// <param name="errorCode">Assigns a value to the <see cref="ErrorCode"/> property.</param>
        /// <param name="errorDescription">Assigns a value to the <see cref="Message"/> property.</param>
        public DaError(string errorCode, string errorDescription)
        {
            if(string.IsNullOrEmpty(errorCode))
            {
                throw new ArgumentNullException(nameof(errorCode));
            }

            if(string.IsNullOrEmpty(errorDescription))
            {
                throw new ArgumentNullException(nameof(errorDescription));
            }

            ErrorCode = errorCode;
            Message = errorDescription;
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public string ErrorCode
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the message of the error.
        /// </summary>
        public string Message
        {
            get;
            private set;
        }
    }
}
