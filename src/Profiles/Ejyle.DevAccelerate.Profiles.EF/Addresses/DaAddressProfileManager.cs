// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Profiles.Addresses;

namespace Ejyle.DevAccelerate.Profiles.EF.Addresses
{
    public class DaAddressProfileManager : DaAddressProfileManager<int, int?, DaAddressProfile>
    {
        public DaAddressProfileManager(DaAddressProfileRepository repository)
            : base(repository)
        { }
    }
}
