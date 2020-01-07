// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Financials.Payment;

namespace Ejyle.DevAccelerate.Financials.EF.Payment
{
    public class DaAccountManager : DaAccountManager<int, int?, DaAccount, DaTransaction>
    {
        public DaAccountManager(DaAccountRepository repository)
            : base(repository)
        { }
    }
}
