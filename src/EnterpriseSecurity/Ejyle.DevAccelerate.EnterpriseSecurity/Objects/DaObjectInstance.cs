// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.EnterpriseSecurity.Apps;
using Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans;
using Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions;
using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Objects
{
    public class DaObjectInstance : DaObjectInstance<string, DaObjectType, DaObjectHistoryItem>
    {
        public DaObjectInstance() : base()
        { }
    }

    public class DaObjectInstance<TKey, TObjectType, TObjectHistoryItem>
        : DaAuditedEntityBase<TKey>, IDaObjectInstance<TKey>
        where TKey : IEquatable<TKey>
        where TObjectType : IDaObjectType<TKey>
        where TObjectHistoryItem : IDaObjectHistoryItem<TKey>
    {
        public DaObjectInstance()
            : base()
        {
            ObjectHistoryItems = new HashSet<TObjectHistoryItem>();
        }

        public TKey ObjectTypeId { get; set; }

        public TKey SourceObjectId { get; set; }

        public virtual TObjectType ObjectType { get; set; }

        public virtual ICollection<TObjectHistoryItem> ObjectHistoryItems { get; set; }
    }
}
