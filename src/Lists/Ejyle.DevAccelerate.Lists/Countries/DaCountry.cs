﻿// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Lists.Currencies;

namespace Ejyle.DevAccelerate.Lists.Countries
{
    /// <summary>
    /// Represents a country entity.
    /// </summary>
    public class DaCountry : DaCountry<string, DaCurrency, DaCountryTimeZone, DaCountryRegion, DaCountrySystemLanguage, DaCountryDateFormat>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaCountry"/> entity.
        /// </summary>
        public DaCountry()
            : base()
        { }

        /// <summary>
        /// Creates an instance of the <see cref="DaCountry"/> class.
        /// </summary>
        /// <param name="name">The name of the country.</param>
        /// <param name="twoLetterCode">The two-letter (alpha-2) ISO 3166 code of the country.</param>
        /// <param name="threeLetterCode">The three-letter (alpha-3) ISO 3166 code of the country.</param>
        /// <param name="numericCode">The numeric ISO 3166 code of the country.</param>
        /// <param name="internationalDialingCode">The international dialing code used to call a number from outside the country.</param>
        /// <param name="isActive">Determines if the record for the country is active.</param>
        public DaCountry(string name, string twoLetterCode, string threeLetterCode, int numericCode, string internationalDialingCode, bool isActive = true)
            : base(name, twoLetterCode, threeLetterCode, numericCode, internationalDialingCode, isActive)
        { }
    }

    /// <summary>
    /// Represents a country entity.
    /// </summary>
    /// <typeparam name="TKey">Represents the type of an entity ID.</typeparam>
    /// <typeparam name="TCurrency">Represents the type of a currency entity.</typeparam>
    /// <typeparam name="TCountryTimeZone">Represents the type of a time zone entity.</typeparam>
    /// <typeparam name="TCountryRegion">Represents the type of a country region entity.</typeparam>
    /// <typeparam name="TCountrySystemLanguage">Represents the type of a system language entity.</typeparam>
    /// <typeparam name="TCountryDateFormat">Represents the type of a date format entity.</typeparam> 
    public class DaCountry<TKey, TCurrency, TCountryTimeZone, TCountryRegion, TCountrySystemLanguage, TCountryDateFormat> : DaListItemBase<TKey>, IDaCountry<TKey>
        where TKey : IEquatable<TKey>
        where TCurrency : IDaCurrency<TKey>
        where TCountryTimeZone : IDaCountryTimeZone<TKey>
        where TCountryRegion : IDaCountryRegion<TKey>
        where TCountrySystemLanguage : IDaCountrySystemLanguage<TKey>
        where TCountryDateFormat : IDaCountryDateFormat<TKey>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaCountry{TKey, TCurrency, TCountryTimeZone, TCountryRegion, TCountrySystemLanguage, TCountryDateFormat}"/> class.
        /// </summary>
        public DaCountry()
        {
            CountryTimeZones = new HashSet<TCountryTimeZone>();
            Regions = new HashSet<TCountryRegion>();
            CountrySystemLanguages = new HashSet<TCountrySystemLanguage>();
            CountryDateFormats = new HashSet<TCountryDateFormat>();
        }

        /// <summary>
        /// Creates an instance of the <see cref="DaCountry{TKey, TCurrency, TCountryTimeZone, TCountryRegion, TCountrySystemLanguage, TCountryDateFormat}"/> class.
        /// </summary>
        /// <param name="name">The name of the country.</param>
        /// <param name="twoLetterCode">The two-letter (alpha-2) ISO 3166 code of the country.</param>
        /// <param name="threeLetterCode">The three-letter (alpha-3) ISO 3166 code of the country.</param>
        /// <param name="numericCode">The numeric ISO 3166 code of the country.</param>
        /// <param name="internationalDialingCode">The international dialing code used to call a number from outside the country.</param>
        /// <param name="isActive">Determines if the record for the country is active.</param>
        public DaCountry(string name, string twoLetterCode, string threeLetterCode, int numericCode, string internationalDialingCode, bool isActive = true)
        {
            CountryTimeZones = new HashSet<TCountryTimeZone>();
            Regions = new HashSet<TCountryRegion>();
            CountrySystemLanguages = new HashSet<TCountrySystemLanguage>();
            CountryDateFormats = new HashSet<TCountryDateFormat>();

            Name = name;
            DisplayName = name;
            TwoLetterCode = twoLetterCode;
            ThreeLetterCode = threeLetterCode;
            NumericCode = numericCode;
            InternationalDialingCode = internationalDialingCode;
            IsActive = isActive;
        }

        /// <summary>
        /// The international dialing code used to call a number from outside the country.
        /// </summary>
        public string InternationalDialingCode { get; set; }

        /// <summary>
        /// The two-letter (alpha-2) ISO 3166 code of the country.
        /// </summary>
        public string TwoLetterCode { get; set; }

        /// <summary>
        /// The three-letter (alpha-3) ISO 3166 code of the country.
        /// </summary>
        public string ThreeLetterCode { get; set; }

        /// <summary>
        /// The numeric ISO 3166 code of the country.
        /// </summary>
        public int NumericCode { get; set; }

        /// <summary>
        /// The ID of the country's default currency.
        /// </summary>
        public TKey CurrencyId { get; set; }

        /// <summary>
        /// The ID of the country's default time zone.
        /// </summary>
        public TKey DefaultTimeZoneId { get; set; }

        /// <summary>
        /// The ID of the country's default date format.
        /// </summary>
        public TKey DefaultDateFormatId { get; set; }

        /// <summary>
        /// The ID of the country's default system language.
        /// </summary>
        public TKey DefaultSystemLanguageId { get; set; }

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
