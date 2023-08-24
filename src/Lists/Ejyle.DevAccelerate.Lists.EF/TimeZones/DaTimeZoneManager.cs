// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Lists.TimeZones;

namespace Ejyle.DevAccelerate.Lists.EF.TimeZones
{
    public class DaTimeZoneManager : DaTimeZoneManager<string, DaTimeZone>
    {
        public DaTimeZoneManager(DaTimeZoneRepository repository)
            : base(repository)
        { }
    }
}
