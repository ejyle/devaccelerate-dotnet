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
    public class DaSystemLanguage : DaSystemLanguage<int, int?, DaCountry>
    {
        public DaSystemLanguage()
            : base()
        { }
    }

    public class DaSystemLanguage<TKey, TNullableKey, TCountry> : DaListBase<TKey>, IDaSystemLanguage<TKey>
        where TKey : IEquatable<TKey>
        where TCountry : IDaCountry<TKey, TNullableKey>
    {
        public DaSystemLanguage()
        {
            Countries = new HashSet<TCountry>();
        }

        public string Name { get; set; }
        public string DisplayName { get; set; }
        public virtual ICollection<TCountry> Countries { get; set; }
    }
}
