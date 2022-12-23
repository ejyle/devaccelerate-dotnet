// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Lists.Custom
{
    /// <summary>
    /// Represents a custom list item entity.
    /// </summary>
    public class DaCustomListItem : DaCustomListItem<string, DaCustomList, DaCustomListItem>
    { }

    /// <summary>
    /// Represents a custom list item entity.
    /// </summary>
    /// <typeparam name="TKey">Represents the type of an entity ID.</typeparam>
    /// <typeparam name="TCustomList">The type of the list to which the list item belongs.</typeparam>
    /// <typeparam name="TCustomListItem">The type of the parent or child list items.</typeparam>
    public class DaCustomListItem<TKey, TCustomList, TCustomListItem> : DaListItemBase<TKey>, IDaCustomListItem<TKey>
        where TKey : IEquatable<TKey>
        where TCustomList : IDaCustomList<TKey>
        where TCustomListItem : IDaCustomListItem<TKey>
    {
        /// <summary>
        /// The ID of the list to which the list item belongs.
        /// </summary>
        public TKey ListId { get; set; }

        /// <summary>
        /// The list to which the list item belongs.
        /// </summary>
        public virtual TCustomList List { get; set; }

        /// <summary>
        /// The ID of the parent list item.
        /// </summary>
        public TKey ParentId { get; set; }

        /// <summary>
        /// Gets or sets the color that best reprsents the list item.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets a numeric weightage of the list item if applicable.
        /// </summary>
        public double? Weightage { get; set; }

        /// <summary>
        /// Used to track the use of the list item in the system.
        /// </summary>
        public long? UsageCount { get; set; }

        /// <summary>
        /// The parent of the list item.
        /// </summary>
        public virtual TCustomListItem Parent { get; set; }

        /// <summary>
        /// Gets or sets the collection of child list items.
        /// </summary>
        public virtual ICollection<TCustomListItem> Children { get; set; }
    }
}
