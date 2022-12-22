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
    /// Represents an exception when weightage of list items in a list are duplicate and actually needs to be unique.
    /// </summary>
    public class DaDuplicateListItemWeightageException : ApplicationException
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaDuplicateListItemWeightageException"/> class.
        /// </summary>
        public DaDuplicateListItemWeightageException() { }

        /// <summary>
        /// Creates an instance of the <see cref="DaDuplicateListItemWeightageException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public DaDuplicateListItemWeightageException(string message) : base(message) { }
    }
}
