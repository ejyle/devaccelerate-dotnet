// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Lists.Generic
{

    /// <summary>
    /// Represents a generic list entity.
    /// </summary>
    public class DaGenericList : DaGenericList<int, DaGenericListItem>
    { }

    /// <summary>
    /// Represents a generic list entity.
    /// </summary>
    /// <typeparam name="TKey">Represents a non-nullable type of an entity ID.</typeparam>
    /// <typeparam name="TGenericListItem">Represents the type of the items of the list.</typeparam>
    public class DaGenericList<TKey, TGenericListItem> : DaAuditedEntityBase<TKey>, IDaGenericList<TKey>
        where TKey : IEquatable<TKey>
        where TGenericListItem : IDaGenericListItem<TKey>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaGenericList{TKey, TGenericListItem}"/> entity.
        /// </summary>
        public DaGenericList()
        {
            ListItems = new HashSet<TGenericListItem>();
        }

        /// <summary>
        /// The standard name of the generic list.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the generic list.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The collection of list items of the generic list.
        /// </summary>
        public virtual ICollection<TGenericListItem> ListItems { get; set; }
    }
}
