// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core.Properties;
using System;

namespace Ejyle.DevAccelerate.Core.Data
{
    /// <summary>
    /// Represents data pagination criteria before a data query is processed.
    /// </summary>
    public class DaDataPaginationCriteria
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaDataPaginationCriteria"/> class.
        /// </summary>
        /// <param name="pageIndex">The current page index.</param>
        /// <param name="pageSize">The total items per page.</param>
        public DaDataPaginationCriteria(int pageIndex, int pageSize)
        {
            if(pageIndex <= 0)
            {
                throw new ArgumentOutOfRangeException(Resources.PageIndexGreaterThanZero);
            }

            if(pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(Resources.PageSizeGreaterThanZero);
            }

            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        /// <summary>
        /// Gets the current page index.
        /// </summary>
        public int PageIndex
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the total number of items per page.
        /// </summary>
        public int PageSize
        {
            get;
            private set;
        }
    }
}
