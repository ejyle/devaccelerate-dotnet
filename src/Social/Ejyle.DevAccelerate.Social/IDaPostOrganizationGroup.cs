// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Social
{
    public interface IDaPostOrganizationGroup<TKey>
        : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string OrganizationGroupId { get; set; }
        TKey PostId { get; set; }
    }
}
