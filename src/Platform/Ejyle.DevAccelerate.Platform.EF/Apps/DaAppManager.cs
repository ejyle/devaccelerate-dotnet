// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Platform.Apps;
using Microsoft.Extensions.Options;

namespace Ejyle.DevAccelerate.Platform.EF.Apps
{
    public class DaAppManager : DaAppManager<string, DaApp>
    {
        public DaAppManager(IOptions<DaAppSettings> options, DaAppRepository repository)
            : base(options, repository)
        { }

        public DaAppManager(DaAppRepository repository)
            : base(repository)
        { }
    }
}
