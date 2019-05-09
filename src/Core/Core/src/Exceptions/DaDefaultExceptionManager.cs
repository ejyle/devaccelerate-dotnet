// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Core.Exceptions
{
    /// <summary>
    /// Represents the default implementation of <see cref="IDaExceptionManager"/> class.
    /// </summary>
    public class DaDefaultExceptionManager : IDaExceptionManager
    {
        /// <summary>
        /// Handles the exception by logging it first and then rethrows the same exception.
        /// </summary>
        /// <param name="ex">The exception to handle.</param>
        public void HandleExpcetion(Exception ex)
        {            
            throw ex;
        }

        /// <summary>
        /// Handles an exception by logging it first and then throws the same exception.
        /// </summary>
        /// <param name="ex">The exception to handle.</param>
        /// <param name="exceptionPolicy">The exception policy to be used.</param>
        public void HandleExpcetion(Exception ex, string exceptionPolicy)
        {
            throw ex;
        }
    }
}
