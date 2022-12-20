// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Lists.Custom
{

    /// <summary>
    /// Represents a custom list entity.
    /// </summary>
    public class DaCustomList : DaCustomList<string, DaCustomListItem>
    { }

    /// <summary>
    /// Represents a custom list entity.
    /// </summary>
    /// <typeparam name="TKey">Represents the type of an entity ID.</typeparam>
    /// <typeparam name="TCustomListItem">Represents the type of the items of the list.</typeparam>
    public class DaCustomList<TKey, TCustomListItem> : DaAuditedEntityBase<TKey>, IDaCustomList<TKey>
        where TKey : IEquatable<TKey>
        where TCustomListItem : IDaCustomListItem<TKey>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaCustomList{TKey, TCustomListItem}"/> entity.
        /// </summary>
        public DaCustomList()
        {
            ListItems = new HashSet<TCustomListItem>();
        }

        /// <summary>
        /// The standard name of the custom list.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the custom list.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The collection of list items of the custom list.
        /// </summary>
        public virtual ICollection<TCustomListItem> ListItems { get; set; }

        /// <summary>
        /// The unique string that represents the custom list.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The tenant ID associated with the custom list.
        /// </summary>
        public TKey TenantId { get; set; }
    }
}
