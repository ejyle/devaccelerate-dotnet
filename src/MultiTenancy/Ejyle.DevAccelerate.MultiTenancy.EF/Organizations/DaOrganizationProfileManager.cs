﻿// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.MultiTenancy.Organizations;

namespace Ejyle.DevAccelerate.MultiTenancy.EF.Organizations
{
    public class DaOrganizationProfileManager : DaOrganizationProfileManager<string, DaOrganizationProfile, DaOrganizationGroup>
    {
        public DaOrganizationProfileManager(DaOrganizationProfileRepository repository)
            : base(repository)
        { }
    }
}