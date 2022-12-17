// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Lists.Countries;

namespace Ejyle.DevAccelerate.Lists.DateFormats
{
    /// <summary>
    /// Represents the format of a date.
    /// </summary>
    public class DaDateFormat : DaDateFormat<string, DaCountryDateFormat>
    { }

    /// <summary>
    /// Represents the format of a date.
    /// </summary>
    /// <typeparam name="TKey">Represents a non-nullable type of an entity ID.</typeparam>
    /// <typeparam name="TCountryDateFormat">Represents the type for mapping applicable countries and date formats.</typeparam>
    public class DaDateFormat<TKey, TCountryDateFormat> : DaListItemBase<TKey>, IDaDateFormat<TKey>
        where TKey : IEquatable<TKey>
        where TCountryDateFormat : IDaCountryDateFormat<TKey>
    {
        /// <summary>
        /// The expression used to format a date with a particular pattern.
        /// </summary>
        public string DateFormatExpression
        {
            get;
            set;
        }

        /// <summary>
        /// The list of countries that are applicable to the date format.
        /// </summary>
        public virtual ICollection<TCountryDateFormat> CountryDateFormats { get; set; }
    }
}
