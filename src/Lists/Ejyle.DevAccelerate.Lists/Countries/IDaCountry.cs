// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Lists.Countries
{
    /// <summary>
    /// Represents the basic interface of a country entity.
    /// </summary>
    /// <typeparam name="TKey">Represents the type of an entity ID.</typeparam>
    public interface IDaCountry<TKey> : IDaListItem<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// The international dialing code used to call a number from outside the country.
        /// </summary>
        string InternationalDialingCode { get; set; }

        /// <summary>
        /// The two-letter (alpha-2) ISO 3166 code of the country.
        /// </summary>
        string TwoLetterCode { get; set; }

        /// <summary>
        /// The three-letter (alpha-3) ISO 3166 code of the country.
        /// </summary>
        string ThreeLetterCode { get; set; }

        /// <summary>
        /// The numeric ISO 3166 code of the country.
        /// </summary>
        int NumericCode { get; set; }

        /// <summary>
        /// The ID of the country's currency.
        /// </summary>
        TKey CurrencyId { get; set; }

        /// <summary>
        /// The ID of the country's default time zone.
        /// </summary>
        TKey DefaultTimeZoneId { get; set; }

        /// <summary>
        /// The ID of the country's default date format.
        /// </summary>
        TKey DefaultDateFormatId { get; set; }

        /// <summary>
        /// The ID of the country's default system language.
        /// </summary>
        TKey DefaultSystemLanguageId { get; set; }
    }
}
