// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

namespace Ejyle.DevAccelerate.MultiTenancy.EF
{
    public class DaTenantManager : DaTenantManager<string, DaTenant, DaTenantUser>
    {
        public DaTenantManager(DaTenantRepository repository)
            : base(repository)
        { }
    }
}
