// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Profiles.UserProfiles
{
    public class DaUserProfileAttribute : DaUserProfileAttribute<DaUserProfile>
    {
        public DaUserProfileAttribute() : base()
        { }
    }

    public class DaUserProfileAttribute<TUserProfile> : DaUserProfileAttribute<string, TUserProfile>
        where TUserProfile : IDaUserProfile<string>
    { 
        public DaUserProfileAttribute() : base()
        { }
    }

    public class DaUserProfileAttribute<TKey, TUserProfile> : DaEntityBase<TKey>, IDaUserProfileAttribute<TKey>
        where TKey : IEquatable<TKey>
        where TUserProfile : IDaUserProfile<TKey>
    {
        public DaUserProfileAttribute() : base()
        { }

        public TKey UserProfileId { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public virtual TUserProfile UserProfile { get; set; }
    }
}
