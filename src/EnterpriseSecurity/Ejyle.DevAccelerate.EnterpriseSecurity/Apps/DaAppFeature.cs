// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.Apps
{
    public class DaAppFeature : DaAppFeature<int, DaApp, DaFeature>
    {
        public DaAppFeature() : base()
        { }
    }

    public class DaAppFeature<TKey, TApp, TFeature> : DaAuditedEntityBase<TKey>, IDaAppFeature<TKey>
        where TKey : IEquatable<TKey>
    {
        [Required]
        public TKey AppId { get; set; }

        [Required]
        public TKey FeatureId { get; set; }

        public virtual TApp App { get; set; }

        public virtual TFeature Feature { get; set; }
    }
}
