// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Lists.Industries
{
    /// <summary>
    /// Represents the basic interface of an industry entity.
    /// </summary>
    /// <typeparam name="TKey">Represents the type of an entity ID.</typeparam>
    public interface IDaIndustry<TKey> : IDaListItem<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// The main category of the industry.
        /// </summary>
        string Sector { get; set; }
    }
}
