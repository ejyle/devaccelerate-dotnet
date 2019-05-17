// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.List.Culture
{
    public class DaCountry : DaCountry<int, int?, DaCurrency, DaTimeZone, DaCountryRegion, DaSystemLanguage>
    {
        public DaCountry()
            : base()
        {
        }

        public DaCountry(string name, string twoLetterCode, string threeLetterCode, int numericCode, string[] dialingCodes = null, bool isActive = true)
            : base(name, twoLetterCode, threeLetterCode, numericCode, dialingCodes, isActive)
        {
        }
    }

    public class DaCountry<TKey, TNullableKey, TCurrency, TTimeZone, TCountryRegion, TSystemLanguage> : DaListBase<TKey>, IDaCountry<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
        where TCurrency : IDaCurrency<TKey>
        where TTimeZone : IDaTimeZone<TKey, TNullableKey>
        where TCountryRegion : IDaCountryRegion<TKey, TNullableKey>
        where TSystemLanguage : IDaSystemLanguage<TKey>
    {
        public DaCountry()
        {
            TimeZones = new HashSet<TTimeZone>();
            Regions = new HashSet<TCountryRegion>();
            SystemLanguages = new HashSet<TSystemLanguage>();
        }

        public DaCountry(string name, string twoLetterCode, string threeLetterCode, int numericCode, string[] dialingCodes = null, bool isActive = true)
        {
            TimeZones = new HashSet<TTimeZone>();
            Regions = new HashSet<TCountryRegion>();
            SystemLanguages = new HashSet<TSystemLanguage>();

            this.Name = name;
            this.TwoLetterCode = twoLetterCode;
            this.ThreeLetterCode = threeLetterCode;
            this.NumericCode = numericCode;
            this.IsActive = isActive;

            if (dialingCodes != null)
            {
                this.DialingCode = dialingCodes[0];
            }
        }

        public string Name { get; set; }
        public string DialingCode { get; set; }
        public string TwoLetterCode { get; set; }
        public TNullableKey CurrencyId { get; set; }
        public bool HasRegions { get; set; }
        public virtual ICollection<TTimeZone> TimeZones { get; set; }
        public virtual ICollection<TSystemLanguage> SystemLanguages { get; set; }
        public virtual TCurrency Currency { get; set; }
        public virtual ICollection<TCountryRegion> Regions { get; set; }
        public string ThreeLetterCode { get; set; }
        public int NumericCode { get; set; }
    }
}
