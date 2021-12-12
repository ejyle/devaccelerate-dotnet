// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Lists.Generic;

namespace Ejyle.DevAccelerate.Lists.EF.Generic
{
    public class DaGenericListManager : DaGenericListManager<int, DaGenericList>
    {
        public DaGenericListManager(DaGenericListRepository repository)
            : base(repository)
        { }
    }
}
