// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Lists.Custom
{
    /// <summary>
    /// Represents a custom list item entity.
    /// </summary>
    public class DaCustomListItem : DaCustomListItem<int, int?, DaCustomList>
    { }

    /// <summary>
    /// Represents a custom list item entity.
    /// </summary>
    /// <typeparam name="TKey">Represents a non-nullable type of an entity ID.</typeparam>
    /// <typeparam name="TNullableKey">Represents a non-nullable type of an entity ID.</typeparam>
    /// <typeparam name="TCustomList">The type of the list to which the list item belongs.</typeparam>
    public class DaCustomListItem<TKey, TNullableKey, TCustomList> : DaListItemBase<TKey>, IDaCustomListItem<TKey>
        where TKey : IEquatable<TKey>
        where TCustomList : IDaCustomList<TKey, TNullableKey>
    {
        /// <summary>
        /// The ID of the list to which the list item belongs.
        /// </summary>
        public TKey ListId { get; set; }

        /// <summary>
        /// The list to which the list item belongs.
        /// </summary>
        public virtual TCustomList List { get; set; }
    }
}
