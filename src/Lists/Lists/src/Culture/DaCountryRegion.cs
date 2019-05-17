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
    public class DaCountryRegion : DaCountryRegion<int, int?, DaCountryRegion, DaCountry>
    {
        public DaCountryRegion()
            : base()
        {
        }
    }

    public class DaCountryRegion<TKey, TNullableKey, TCountryRegion, TCountry> : DaListBase<TKey>, IDaCountryRegion<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
        where TCountryRegion : IDaCountryRegion<TKey, TNullableKey>
        where TCountry : IDaCountry<TKey, TNullableKey>

    {
        public DaCountryRegion()
        {
            Children = new HashSet<TCountryRegion>();
        }

        public string Name { get; set; }

        public TKey CountryId { get; set; }

        public string RegionCode { get; set; }

        public bool IsVerified { get; set; }

        public virtual TCountry Country { get; set; }

        public TNullableKey ParentId { get; set; }

        public virtual ICollection<TCountryRegion> Children { get; set; }

        public virtual TCountryRegion Parent { get; set; }
    }
}
