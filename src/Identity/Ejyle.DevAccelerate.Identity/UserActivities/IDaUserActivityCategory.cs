// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Identity.UserActivities
{
    public interface IDaUserActivityCategory<TKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey AppId { get; set; }
        string UserActivityCategoryName { get; set; }
        bool IsEnabled { get; set; }
    }
}