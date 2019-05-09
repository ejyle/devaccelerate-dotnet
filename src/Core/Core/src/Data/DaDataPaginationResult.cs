// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Core.Data
{
    /// <summary>
    /// Represents pagination info after a data query has been processed.
    /// </summary>
    public class DaDataPaginationResult
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaDataPaginationResult"/> class.
        /// </summary>
        /// <param name="paginationCriteria">Pagination criteria.</param>
        /// <param name="totalItems">Total items across all pages.</param>
        public DaDataPaginationResult(DaDataPaginationCriteria paginationCriteria, int totalItems)
        {
            if (paginationCriteria.PageSize <= 0)
            {
                throw new ArgumentOutOfRangeException("");
            }

            TotalItems = totalItems;
            PageIndex = paginationCriteria.PageIndex;
            PageSize = paginationCriteria.PageSize;
            MinimumPages = 1;
            TotalPages = CalculateTotalPages(totalItems, PageSize);
        }

        /// <summary>
        /// Gets the total pages across all items.
        /// </summary>
        public int TotalItems
        {
            get;
            private set;
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
        /// Gets the number of items in a page.
        /// </summary>
        public int PageSize
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the minimum number of page. This effectively equals to 1.
        /// </summary>
        public int MinimumPages
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the total number of pages.
        /// </summary>
        public int TotalPages
        {
            get;
            private set;
        }

        /// <summary>
        /// Calculates the total number of pages depending upon the total number of items and items per page.
        /// </summary>
        /// <param name="totalItems">Total number items across all pages.</param>
        /// <param name="pageSize">Number of items per page.</param>
        /// <returns>Returns the total number pages as an <see cref="int"/>.</returns>
        private int CalculateTotalPages(int totalItems, int pageSize)
        {
            int totalPages = totalItems / pageSize;

            if (totalItems % pageSize != 0)
            {
                totalPages++;
            }

            return totalPages;
        }
    }
}