// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Platform.Apps;
using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Platform.Features
{
    public class DaFeature : DaFeature<string, DaApp, DaAppFeature, DaFeatureAction>
    {
        public DaFeature() : base()
        { }
    }

    public class DaFeature<TKey, TApp, TAppFeature, TFeatureAction>
        : DaEntityBase<TKey>, IDaFeature<TKey>
        where TKey : IEquatable<TKey>
        where TApp : IDaApp<TKey>
        where TAppFeature : IDaAppFeature<TKey>
        where TFeatureAction : IDaFeatureAction<TKey>
    {
        public DaFeature()
            : base()
        {
            AppFeatures = new HashSet<TAppFeature>();
            FeatureActions = new HashSet<TFeatureAction>();
        }

        public string Name { get; set; }

        public string Key { get; set; }

        public TKey AppId { get; set; }

        public DaFeatureStatus Status { get; set; }

        public virtual TApp App { get; set; }

        public virtual ICollection<TAppFeature> AppFeatures { get; set; }

        public virtual ICollection<TFeatureAction> FeatureActions { get; set; }
    }
}
