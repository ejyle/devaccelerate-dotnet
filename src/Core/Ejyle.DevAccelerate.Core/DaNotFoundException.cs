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
    /// Represents an exception when a object does not exist when it should have.
    /// </summary>
    /// <remarks>This exception should not be used when searching for objects as search may or may not render results. The exception should be used when updating or deleting an object because in such cases the object should have existed.</remarks>
    public class DaNotFoundException : ApplicationException
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaNotFoundException"/> class.
        /// </summary>
        public DaNotFoundException() { }

        /// <summary>
        /// Creates an instance of the <see cref="DaNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public DaNotFoundException(string message) : base(message) { }
    }
}
