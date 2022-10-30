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
    public class DaObjectHistoryItem : DaObjectHistoryItem<int, DaObjectInstance>
    {
        public DaObjectHistoryItem() : base()
        { }
    }

    public class DaObjectHistoryItem<TKey, TObjectInstance>
        : DaAuditedEntityBase<TKey>, IDaObjectHistoryItem<TKey>
        where TKey : IEquatable<TKey>
        where TObjectInstance : IDaObjectInstance<TKey>
    {
        public TKey ObjectInstanceId { get; set; }
        public DaObjectActionType Action { get; set; }
        public string Note { get; set; }
        public bool IsNoteHtml { get; set; }
        public DateTime? DeleteDateUtc { get; set; }

        public virtual TObjectInstance ObjectInstance { get; set; }
    }
}
