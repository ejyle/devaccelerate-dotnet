// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Identity.UserActivities
{
    public class DaUserActivityCategory : DaUserActivityCategory<int, int?, DaUserActivity>
    {
        public DaUserActivityCategory() : base()
        { }
    }

    public class DaUserActivityCategory<TKey, TNullableKey, TUserActivity> : DaEntityBase<TKey>, IDaUserActivityCategory<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
        where TUserActivity : IDaUserActivity<TKey, TNullableKey>
    {
        public DaUserActivityCategory() : base()
        {
            UserActivities = new HashSet<TUserActivity>();
        }

        public TNullableKey AppId { get; set; }
        public string UserActivityCategoryName { get; set; }
        public bool IsEnabled { get; set; }
        public virtual ICollection<TUserActivity> UserActivities { get; set; }
    }
}
