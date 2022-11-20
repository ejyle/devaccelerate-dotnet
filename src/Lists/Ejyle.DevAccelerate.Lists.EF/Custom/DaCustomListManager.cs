// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Lists.Custom;

namespace Ejyle.DevAccelerate.Lists.EF.Custom
{
    public class DaCustomListManager : DaCustomListManager<int, int?, DaCustomList>
    {
        public DaCustomListManager(DaCustomListRepository repository)
            : base(repository)
        { }
    }
}
