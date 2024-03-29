﻿// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Lists.Countries
{
    /// <summary>
    /// Represents the basic interface of a country region entity.
    /// </summary>
    /// <typeparam name="TKey">Represents a the type of an entity ID.</typeparam>
    public interface IDaCountryRegion<TKey> : IDaListItem<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// The ID of the parent region.
        /// </summary>
        TKey ParentId { get; set; }

        /// <summary>
        /// The ID of the region's country.
        /// </summary>
        TKey CountryId { get; set; }

        /// <summary>
        /// The region's code if any.
        /// </summary>
        string RegionCode { get; set; }
    }
}
