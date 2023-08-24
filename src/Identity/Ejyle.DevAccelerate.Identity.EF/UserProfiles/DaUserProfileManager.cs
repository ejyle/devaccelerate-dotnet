// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Identity.UserProfiles;

namespace Ejyle.DevAccelerate.Identity.EF.UserProfiles
{
    public class DaUserProfileManager : DaUserProfileManager<string, DaUserProfile>
    {
        public DaUserProfileManager(DaUserProfileRepository repository)
            : base(repository)
        { }
    }
}
