// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

namespace Ejyle.DevAccelerate.Lists.Generic
{
    /// <summary>
    /// Represents a generic list item entity.
    /// </summary>
    public class DaGenericListItem : DaGenericListItem<int, DaGenericList>
    { }

    /// <summary>
    /// Represents a generic list item entity.
    /// </summary>
    /// <typeparam name="TKey">Represents a non-nullable type of an entity ID.</typeparam>
    /// <typeparam name="TGenericList">The type of the list to which the list item belongs.</typeparam>
    public class DaGenericListItem<TKey, TGenericList> : DaListItemBase<TKey>, IDaGenericListItem<TKey>
        where TKey : IEquatable<TKey>
        where TGenericList : IDaGenericList<TKey>
    {
        /// <summary>
        /// The ID of the list to which the list item belongs.
        /// </summary>
        [Required]
        public TKey ListId { get; set; }

        /// <summary>
        /// The list to which the list item belongs.
        /// </summary>
        public virtual TGenericList List { get; set; }
    }
}
