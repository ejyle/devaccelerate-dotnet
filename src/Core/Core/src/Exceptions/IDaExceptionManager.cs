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
    /// Defines the methods for handling exceptions.
    /// </summary>
    public interface IDaExceptionManager
    {
        /// <summary>
        /// Handles an exception based on the default exception policy.
        /// </summary>
        /// <param name="ex">The exception to handle.</param>
        void HandleExpcetion(Exception ex);

        /// <summary>
        /// Handles an exception based on a given exception policy.
        /// </summary>
        /// <param name="ex">The exception to handle.</param>
        /// <param name="exceptionPolicy">The name of the exception policy.</param>
        void HandleExpcetion(Exception ex, string exceptionPolicy);
    }
}
