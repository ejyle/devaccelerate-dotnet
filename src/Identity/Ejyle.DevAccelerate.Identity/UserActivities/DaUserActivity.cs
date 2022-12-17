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
    public class DaUserActivity : DaUserActivity<string, DaUserActivityCategory>
    {
        public DaUserActivity() : base()
        { }
    }

    public class DaUserActivity<TKey, TUserActivityCategory> : DaEntityBase<TKey>, IDaUserActivity<TKey>
        where TKey : IEquatable<TKey>
        where TUserActivityCategory : IDaUserActivityCategory<TKey>
    {
        public TKey UserId { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public TKey UserActivityCategoryId { get; set; }
        public virtual TUserActivityCategory UserActivityCategory { get; set; }
        public TKey UserSessionId { get; set; }
        public string IpAddress { get; set; }
        public string ActivityText { get; set; }
        public TKey ObjectId { get; set; }
        public DaUserActivityType UserActivityType { get; set; }
        public string ActualObject { get; set; }
        public string UpdatedObject { get; set; }
    }
}
