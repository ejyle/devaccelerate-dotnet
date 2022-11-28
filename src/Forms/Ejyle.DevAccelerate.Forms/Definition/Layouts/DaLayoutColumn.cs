// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Forms.Definition.Layouts
{
    public class DaLayoutColumn<TKey, TNullableKey, TLayout> : DaAuditedEntityBase<TKey>, IDaLayoutColumn<TKey>
        where TKey : IEquatable<TKey>
        where TLayout : IDaLayout<TKey, TNullableKey>
    {
        public TKey LayoutId { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public virtual TLayout Layout { get; set; }
    }
}
