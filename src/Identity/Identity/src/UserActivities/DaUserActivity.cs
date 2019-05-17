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
    public class DaUserActivity : DaUserActivity<int, int?, DaUserActivityCategory>
    {
        public DaUserActivity() : base()
        { }
    }

    public class DaUserActivity<TKey, TNullableKey, TUserActivityCategory> : DaEntityBase<TKey>, IDaUserActivity<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
        where TUserActivityCategory : IDaUserActivityCategory<TKey, TNullableKey>
    {
        public TKey UserId { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public TKey UserActivityCategoryId { get; set; }
        public virtual TUserActivityCategory UserActivityCategory { get; set; }
        public TKey UserSessionId { get; set; }
        public string IpAddress { get; set; }
        public string ActivityText { get; set; }
        public TNullableKey ObjectId { get; set; }
        public DaUserActivityType UserActivityType { get; set; }
        public string ActualObject { get; set; }
        public string UpdatedObject { get; set; }
    }
}
