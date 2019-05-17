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
    public class DaTimeZone : DaTimeZone<int, int?, DaCountry>
    {
        public DaTimeZone()
            : base()
        { }
    }

    public class DaTimeZone<TKey, TNullableKey, TCountry> : DaListBase<TKey>, IDaTimeZone<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
        where TCountry : IDaCountry<TKey, TNullableKey>
    {
        public DaTimeZone()
        {
            Countries = new HashSet<TCountry>();
        }

        public string Name { get; set; }
        public string SystemTimeZoneId { get; set; }
        public bool SupportsDaylightSavingTime { get; set; }
        public string DaylightName { get; set; }
        public string DisplayName { get; set; }
        public virtual ICollection<TCountry> Countries { get; set; }
    }
}
