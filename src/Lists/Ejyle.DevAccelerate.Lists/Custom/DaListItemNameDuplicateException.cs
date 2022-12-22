// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Lists.Custom
{
    /// <summary>
    /// Represents an exception when more than one list item has the same name in a list.
    /// </summary>
    public class DaListItemNameDuplicateException : ApplicationException
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaListItemNameDuplicateException"/> class.
        /// </summary>
        public DaListItemNameDuplicateException() { }

        /// <summary>
        /// Creates an instance of the <see cref="DaListItemNameDuplicateException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public DaListItemNameDuplicateException(string message) : base(message) { }
    }
}
