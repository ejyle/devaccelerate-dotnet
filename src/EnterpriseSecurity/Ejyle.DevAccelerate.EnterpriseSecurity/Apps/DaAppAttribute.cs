// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Apps
{
    public class DaAppAttribute : DaAppAttribute<string, DaApp>
    {
        public DaAppAttribute() : base()
        { }
    }

    public class DaAppAttribute<TKey, TApp> : DaEntityBase<TKey>, IDaAppAttribute<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey AppId { get; set; }
        public virtual TApp App { get; set; }
        public string AttributeName { get; set; } 
        public string AttributeValue { get; set; } 
    }
}
