// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Lists.Currencies;

namespace Ejyle.DevAccelerate.Lists.EF.Currencies
{
    public class DaCurrencyManager : DaCurrencyManager<string, DaCurrency>
    {
        public DaCurrencyManager(DaCurrencyRepository repository)
            : base(repository)
        { }
    }
}
