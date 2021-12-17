// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Identity.UserSettings;

namespace Ejyle.DevAccelerate.Identity.EF.UserSettings
{
    public class DaUserSettingManager : DaUserSettingManager<DaUserSetting>
    {
        public DaUserSettingManager(DaUserSettingRepository repository)
            : base(repository)
        { }
    }
}
