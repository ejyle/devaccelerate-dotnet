// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Apps
{
    public class DaAppFeature : DaAppFeature<int, DaApp, DaFeature>
    {
        public DaAppFeature() : base()
        { }
    }

    public class DaAppFeature<TKey, TApp, TFeature> : DaEntityBase<TKey>, IDaAppFeature<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey AppId { get; set; }

        public TKey FeatureId { get; set; }

        public virtual TApp App { get; set; }

        public virtual TFeature Feature { get; set; }
    }
}
