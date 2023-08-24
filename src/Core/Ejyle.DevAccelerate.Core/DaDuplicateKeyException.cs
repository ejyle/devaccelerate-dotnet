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
    /// Represents an exception when a key is duplicate and actually needs to be unique.
    /// </summary>
    public class DaDuplicateKeyException : ApplicationException
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaDuplicateKeyException"/> class.
        /// </summary>
        public DaDuplicateKeyException() { }

        /// <summary>
        /// Creates an instance of the <see cref="DaDuplicateKeyException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public DaDuplicateKeyException(string message) : base(message) { }
    }
}
