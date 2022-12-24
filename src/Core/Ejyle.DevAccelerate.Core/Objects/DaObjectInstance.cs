// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Core.Objects
{
    public class DaObjectInstance : DaObjectInstance<string, DaObjectType, DaObjectHistoryItem, DaObjectDependency>
    {
        public DaObjectInstance() : base()
        { }
    }

    public class DaObjectInstance<TKey, TObjectType, TObjectHistoryItem, TObjectDependency>
        : DaAuditedEntityBase<TKey>, IDaObjectInstance<TKey>
        where TKey : IEquatable<TKey>
        where TObjectType : IDaObjectType<TKey>
        where TObjectHistoryItem : IDaObjectHistoryItem<TKey>
        where TObjectDependency : IDaObjectDependency<TKey>
    {
        public DaObjectInstance()
            : base()
        {
            ObjectHistoryItems = new HashSet<TObjectHistoryItem>();
            ObjectDependencies = new HashSet<TObjectDependency>();
        }

        public TKey ObjectTypeId { get; set; }

        public TKey SourceObjectId { get; set; }

        public virtual TObjectType ObjectType { get; set; }

        public virtual ICollection<TObjectHistoryItem> ObjectHistoryItems { get; set; }

        public virtual ICollection<TObjectDependency> ObjectDependencies { get; set; }
    }
}
