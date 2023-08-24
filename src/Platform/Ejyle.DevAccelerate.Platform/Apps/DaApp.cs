// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Platform.Features;
using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Platform.Apps
{
    public class DaApp : DaApp<string, DaAppAttribute, DaFeature, DaAppFeature>
    {
        public DaApp() : base()
        { }
    }

    public class DaApp<TKey, TAppAttribute, TFeature, TAppFeature> : DaEntityBase<TKey>, IDaApp<TKey>
        where TKey : IEquatable<TKey>
        where TAppAttribute : IDaAppAttribute<TKey>
        where TFeature : IDaFeature<TKey>
        where TAppFeature : IDaAppFeature<TKey>
    {
        public DaApp()
        {
            Attributes = new HashSet<TAppAttribute>();
            AppFeatures = new HashSet<TAppFeature>();
            Features = new HashSet<TFeature>();
        }

        public string Name { get; set; }

        public string Key { get; set; }

        public string Description { get; set; }

        public DaAppStatus Status { get; set; }

        public virtual ICollection<TAppAttribute> Attributes { get; set; }

        public virtual ICollection<TAppFeature> AppFeatures { get; set; }

        public virtual ICollection<TFeature> Features { get; set; }
    }
}
