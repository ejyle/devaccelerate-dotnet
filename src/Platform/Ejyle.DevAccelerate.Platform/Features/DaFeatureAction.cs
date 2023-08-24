// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Platform.Features
{
    public class DaFeatureAction : DaFeatureAction<string, DaFeature>
    {
        public DaFeatureAction() : base()
        { }
    }

    public class DaFeatureAction<TKey, TFeature> : DaEntityBase<TKey>, IDaFeatureAction<TKey>
        where TKey : IEquatable<TKey>
        where TFeature : IDaFeature<TKey>
    {
        public TKey FeatureId { get; set; }

        public string Name { get; set; }

        public virtual TFeature Feature { get; set; }
    }
}
