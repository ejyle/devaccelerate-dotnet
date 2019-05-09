// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

namespace Ejyle.DevAccelerate.Core.Logging
{
    /// <summary>
    /// Defines the methods for writing messages to a log.
    /// </summary>
    public interface IDaLogManager
    {
        /// <summary>
        /// Writes a message to the log.
        /// </summary>
        /// <param name="logMessage">The message to be written to the log.</param>
        void Write(IDaLogMessage logMessage);
    }
}
