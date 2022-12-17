// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Identity.UserActivities
{
    public class DaUserActivityCategory : DaUserActivityCategory<string, DaUserActivity>
    {
        public DaUserActivityCategory() : base()
        { }
    }

    public class DaUserActivityCategory<TKey, TUserActivity> : DaEntityBase<TKey>, IDaUserActivityCategory<TKey>
        where TKey : IEquatable<TKey>
        where TUserActivity : IDaUserActivity<TKey>
    {
        public DaUserActivityCategory() : base()
        {
            UserActivities = new HashSet<TUserActivity>();
        }

        public TKey AppId { get; set; }
        public string UserActivityCategoryName { get; set; }
        public bool IsEnabled { get; set; }
        public virtual ICollection<TUserActivity> UserActivities { get; set; }
    }
}
