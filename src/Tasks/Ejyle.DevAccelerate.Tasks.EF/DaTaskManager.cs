// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Tasks;
using System.Xml.Linq;

namespace Ejyle.DevAccelerate.Tasks.EF
{
    public class DaTaskManager : DaTaskManager<int, int?, DaTask>
    {
        public DaTaskManager(DaTaskRepository repository)
            : base(repository)
        { }
    }
}
