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
    public class DaFeatureAction : DaFeatureAction<int, int?, DaFeature>
    {
        public DaFeatureAction() : base()
        { }
    }

    public class DaFeatureAction<TKey, TNullableKey, TFeature> : DaEntityBase<TKey>, IDaFeatureAction<TKey>
        where TKey : IEquatable<TKey>
        where TFeature : IDaFeature<TKey, TNullableKey>
    {
        public TKey FeatureId { get; set; }

        public string Name { get; set; }

        public virtual TFeature Feature { get; set; }
    }
}
