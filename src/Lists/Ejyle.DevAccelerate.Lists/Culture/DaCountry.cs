// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ejyle.DevAccelerate.Lists.Culture
{
    /// <summary>
    /// Represents a country entity.
    /// </summary>
    public class DaCountry : DaCountry<int, int?, DaCurrency, DaCountryTimeZone, DaCountryRegion, DaCountrySystemLanguage, DaCountryDateFormat>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaCountry"/> entity.
        /// </summary>
        public DaCountry()
            : base()
        { }
    }

    /// <summary>
    /// Represents a country entity.
    /// </summary>
    /// <typeparam name="TKey">Represents a non-nullable type of an entity ID.</typeparam>
    /// <typeparam name="TNullableKey">Represents a nullable type for an entity ID.</typeparam>
    /// <typeparam name="TCurrency">Represents the type of a currency entity.</typeparam>
    /// <typeparam name="TCountryTimeZone">Represents the type of a time zone entity.</typeparam>
    /// <typeparam name="TCountryRegion">Represents the type of a country region entity.</typeparam>
    /// <typeparam name="TCountrySystemLanguage">Represents the type of a system language entity.</typeparam>
    /// <typeparam name="TCountryDateFormat">Represents the type of a date format entity.</typeparam> 
    public class DaCountry<TKey, TNullableKey, TCurrency, TCountryTimeZone, TCountryRegion, TCountrySystemLanguage, TCountryDateFormat> : DaListItemBase<TKey>, IDaCountry<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
        where TCurrency : IDaCurrency<TKey>
        where TCountryTimeZone : IDaCountryTimeZone<TKey>
        where TCountryRegion : IDaCountryRegion<TKey, TNullableKey>
        where TCountrySystemLanguage : IDaCountrySystemLanguage<TKey>
        where TCountryDateFormat : IDaCountryDateFormat<TKey>
    {

        /// <summary>
        /// Creates an instance of the <see cref="DaCountry{TKey, TNullableKey, TCurrency, TCountryTimeZone, TCountryRegion, TCountrySystemLanguage, TCountryDateFormat}"/> class.
        /// </summary>
        public DaCountry()
        {
            CountryTimeZones = new HashSet<TCountryTimeZone>();
            Regions = new HashSet<TCountryRegion>();
            CountrySystemLanguages = new HashSet<TCountrySystemLanguage>();
            CountryDateFormats = new HashSet<TCountryDateFormat>();
        }

        /// <summary>
        /// The international dialing code used to call a number from outside the country.
        /// </summary>
        [Required]
        [StringLength(10)]
        public string DialingCode { get; set; }

        /// <summary>
        /// The two-letter (alpha-2) ISO 3166 code of the country.
        /// </summary>
        [Required]
        [StringLength(2)]
        public string TwoLetterCode { get; set; }

        /// <summary>
        /// The three-letter (alpha-3) ISO 3166 code of the country.
        /// </summary>
        [Required]
        [StringLength(3)]
        public string ThreeLetterCode { get; set; }

        /// <summary>
        /// The numeric ISO 3166 code of the country.
        /// </summary>
        [Required]
        public int NumericCode { get; set; }

        /// <summary>
        /// The ID of the country's default currency.
        /// </summary>
        public TNullableKey CurrencyId { get; set; }

        /// <summary>
        /// The ID of the country's default time zone.
        /// </summary>
        public TNullableKey DefaultTimeZoneId { get; set; }

        /// <summary>
        /// The ID of the country's default date format.
        /// </summary>
        public TNullableKey DefaultDateFormatId { get; set; }

        /// <summary>
        /// The ID of the country's default system language.
        /// </summary>
        public TNullableKey DefaultSystemLanguageId { get; set; }

        /// <summary>
        /// List of time zones the country comes under.
        /// </summary>
        public virtual ICollection<TCountryTimeZone> CountryTimeZones { get; set; }

        /// <summary>
        /// List of system languages supported for the country.
        /// </summary>
        public virtual ICollection<TCountrySystemLanguage> CountrySystemLanguages { get; set; }

        /// <summary>
        /// List of date formats supported for the country.
        /// </summary>
        public virtual ICollection<TCountryDateFormat> CountryDateFormats { get; set; }

        /// <summary>
        /// The currency of the country.
        /// </summary>
        public virtual TCurrency Currency { get; set; }

        /// <summary>
        /// List of regions (states, provinces, districts, etc.) within the country.
        /// </summary>
        public virtual ICollection<TCountryRegion> Regions { get; set; }
    }
}
