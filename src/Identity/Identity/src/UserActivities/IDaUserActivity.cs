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
    public interface IDaUserActivity<TKey, TNullableKey> : IDaEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey UserId { get; set; }
        TKey UserSessionId { get; set; }
        string IpAddress { get; set; }
        string UserName { get; set; }
        string ActivityText { get; set; }
        TNullableKey ObjectId { get; set; }
        TKey UserActivityCategoryId { get; set; }
        DaUserActivityType UserActivityType { get; set; }
        string ActualObject { get; set; }
        string UpdatedObject { get; set; }
        DateTime CreatedDateUtc { get; set; }
    }
}
