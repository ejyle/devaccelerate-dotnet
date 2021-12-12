// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Core.Logging
{
    /// <summary>
    /// Provides default implementation of <see cref="IDaLogManager"/> interface.
    /// </summary>
    public class DaDefaultLogManager : IDaLogManager
    {
        /// <summary>
        /// Writes a <see cref="IDaLogManager"/> object to the log.
        /// </summary>
        /// <param name="logMessage"></param>
        public void Write(IDaLogMessage logMessage)
        {
            throw new NotImplementedException();
        }
    }
}
