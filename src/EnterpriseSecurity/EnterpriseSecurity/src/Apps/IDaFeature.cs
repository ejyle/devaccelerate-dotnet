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
    public interface IDaFeature<TKey, TNullableKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TNullableKey AppId { get; set; }
        string Name { get; set; }
        string Key { get; set; }
        string Location { get; set; }
        DaEntityWorkflowStatus Status { get; set; }
        DateTime LastUpdatedDateUtc { get; set; }
    }
}
