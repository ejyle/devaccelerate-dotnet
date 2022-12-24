// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Core.Objects
{
    public class DaObjectDependency : DaObjectDependency<string, DaObjectInstance>
    {
        public DaObjectDependency() : base()
        { }
    }

    public class DaObjectDependency<TKey, TObjectInstance>
        : DaAuditedEntityBase<TKey>, IDaObjectDependency<TKey>
        where TKey : IEquatable<TKey>
        where TObjectInstance : IDaObjectInstance<TKey>
    {
        public TKey ObjectInstanceId { get; set; }

        public TKey PrimaryObjectId { get; set; }

        public TKey DependentObjectId { get; set; }

        public virtual TObjectInstance ObjectInstance { get; set; }
    }
}
