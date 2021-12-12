// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Core.Logging
{
    /// <summary>
    /// Represents a log message.
    /// </summary>
    public interface IDaLogMessage
    {
        /// <summary>
        /// Gets or sets the title of the log message.
        /// </summary>
        string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the text of the log message.
        /// </summary>
        string Text
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the priority value of the log message.
        /// </summary>
        int Priority
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date of the log message.
        /// </summary>
        DateTime Date
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a collection of categories of the log message.
        /// </summary>
        ICollection<string> Categories
        {
            get;
            set;
        }
    }
}
