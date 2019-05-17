// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using MselLogging = Microsoft.Practices.EnterpriseLibrary.Logging;

namespace Ejyle.DevAccelerate.Core.Logging.Msel
{
    /// <summary>
    /// Represents the Microsoft Entejrprise Library Logging implementation for DevAccelerate Core.
    /// </summary>
    public class MselLogManager : IDaLogManager
    {
        /// <summary>
        /// Writes a message to the log.
        /// </summary>
        /// <param name="logMessage">The message to be written to the log.</param>
        public void Write(IDaLogMessage logMessage)
        {
            if(logMessage == null)
            {
                throw new ArgumentNullException();
            }

            var mselLogEntry = new MselLogging.LogEntry()
            {
                Priority = logMessage.Priority,
                Title = logMessage.Title,
                Message = logMessage.Text
            };

            if (logMessage.Categories != null)
            {
                mselLogEntry.Categories = logMessage.Categories;
            }

            MselLogging.Logger.Write(mselLogEntry);
        }
    }
}
