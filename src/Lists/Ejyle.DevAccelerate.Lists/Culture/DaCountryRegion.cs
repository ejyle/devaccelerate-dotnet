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
    /// Represents a region or a sub-region of a country entity.
    /// </summary>
    public class DaCountryRegion : DaCountryRegion<int, int?, DaCountryRegion, DaCountry>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaCountryRegion"/> entity.
        /// </summary>
        public DaCountryRegion()
            : base()
        { }
    }

    /// <summary>
    /// Represents a region or a sub-region of a country entity.
    /// </summary>
    /// <typeparam name="TKey">Represents a non-nullable type of an entity ID.</typeparam>
    /// <typeparam name="TNullableKey">Represents a nullable type for an entity ID.</typeparam>
    /// <typeparam name="TCountryRegion">Represents the type of the region's sub-regions.</typeparam>
    /// <typeparam name="TCountry">Represents the type of the region's country.</typeparam>
    public class DaCountryRegion<TKey, TNullableKey, TCountryRegion, TCountry> : DaListItemBase<TKey>, IDaCountryRegion<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
        where TCountryRegion : IDaCountryRegion<TKey, TNullableKey>
        where TCountry : IDaCountry<TKey, TNullableKey>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaCountryRegion{TKey, TNullableKey, TCountryRegion, TCountry}"/> entity.
        /// </summary>
        public DaCountryRegion()
        {
            Children = new HashSet<TCountryRegion>();
        }

        /// <summary>
        /// The ID of the region's country.
        /// </summary>
        public TKey CountryId { get; set; }

        /// <summary>
        /// The region's code if any.
        /// </summary>        
        public string RegionCode { get; set; }

        /// <summary>
        /// The region's country.
        /// </summary>
        public virtual TCountry Country { get; set; }

        /// <summary>
        /// The ID of the parent region.
        /// </summary>
        public TNullableKey ParentId { get; set; }

        /// <summary>
        /// The region's parent entity.
        /// </summary>
        public virtual TCountryRegion Parent { get; set; }

        /// <summary>
        /// The list of region's sub-regions.
        /// </summary>
        public virtual ICollection<TCountryRegion> Children { get; set; }
    }
}
