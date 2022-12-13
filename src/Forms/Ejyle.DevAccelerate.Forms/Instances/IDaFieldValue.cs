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

namespace Ejyle.DevAccelerate.Forms.Instances
{
    public interface IDaFieldValue<TKey> : IDaAuditedEntity<TKey>
        where TKey: IEquatable<TKey>
    {
        TKey FormInstanceId { get; set; }
        TKey FieldId { get; set; }
        string Value { get; set; }
    }
}
