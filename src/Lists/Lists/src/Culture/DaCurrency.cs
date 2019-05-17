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
    public class DaCurrency : DaCurrency<int, int?, DaCountry>
    {
        public DaCurrency()
            : base()
        { }
    }

    public class DaCurrency<TKey, TNullableKey, TCountry> : DaListBase<TKey>, IDaCurrency<TKey>
        where TKey : IEquatable<TKey>
        where TCountry : IDaCountry<TKey, TNullableKey>
    {
        public DaCurrency()
        {
            Countries = new HashSet<TCountry>();
        }

        public string NativeName { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencyCode { get; set; }
        public virtual ICollection<TCountry> Countries { get; set; }
        public string Name { get; set; }
    }
}
