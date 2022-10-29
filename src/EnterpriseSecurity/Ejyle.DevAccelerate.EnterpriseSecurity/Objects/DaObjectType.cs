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
    public class DaObjectType : DaObjectType<int, DaApp, DaObjectInstance>
    {
        public DaObjectType() : base()
        { }
    }

    public class DaObjectType<TKey, TApp, TObjectInstance>
        : DaEntityBase<TKey>, IDaObjectType<TKey>
        where TKey : IEquatable<TKey>
        where TApp : IDaApp<TKey>
        where TObjectInstance : IDaObjectInstance<TKey>
    {
        public DaObjectType()
            : base()
        {
            ObjectInstances = new HashSet<TObjectInstance>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public TKey AppId { get; set; }

        public virtual TApp App { get; set; }

        public virtual ICollection<TObjectInstance> ObjectInstances { get; set; }
    }
}
