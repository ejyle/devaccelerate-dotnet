// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Financials.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Financials.EF.Payment
{
    public class DaPaymentMethodManager : DaPaymentMethodManager<int, DaPaymentMethod>
    {
        public DaPaymentMethodManager(DaPaymentMethodRepository repository)
            : base(repository)
        { }
    }
}
