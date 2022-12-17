// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.EnterpriseSecurity.Groups;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.EF.Groups
{
    public class DaGroupManager : DaGroupManager<string, DaGroup>
    {
        public DaGroupManager(DaGroupRepository repository)
            : base(repository)
        { }
    }
}
