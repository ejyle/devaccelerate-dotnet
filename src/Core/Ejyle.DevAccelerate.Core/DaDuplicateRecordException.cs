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
    /// Represents an exception when a to-be-created record already exists.
    /// </summary>
    public class DaDuplicateRecordException : ApplicationException
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaDuplicateRecordException"/> class.
        /// </summary>
        public DaDuplicateRecordException() { }

        /// <summary>
        /// Creates an instance of the <see cref="DaDuplicateRecordException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public DaDuplicateRecordException(string message) : base(message) { }
    }
}
