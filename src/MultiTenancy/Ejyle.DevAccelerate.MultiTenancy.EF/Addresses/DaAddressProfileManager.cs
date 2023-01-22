// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.MultiTenancy.Addresses;

namespace Ejyle.DevAccelerate.MultiTenancy.EF.Addresses
{
    public class DaAddressProfileManager : DaAddressProfileManager<string, DaAddressProfile>
    {
        public DaAddressProfileManager(DaAddressProfileRepository repository)
            : base(repository)
        { }
    }
}
