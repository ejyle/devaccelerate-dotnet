// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF.Subscriptions;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF.Tenants;
using Ejyle.DevAccelerate.EnterpriseSecurity.Subscriptions;
using Ejyle.DevAccelerate.EnterpriseSecurity.Tenants;
using Ejyle.DevAccelerate.List.Culture;
using Ejyle.DevAccelerate.List.EF.Culture;
using Ejyle.DevAccelerate.Profiles.Addresses;
using Ejyle.DevAccelerate.Profiles.EF.Addresses;
using Ejyle.DevAccelerate.Financials.EF.Payment;

namespace Ejyle.DevAccelerate.Financials.Payment.Stripe.EF
{
    public class DaStripePaymentMethod : DaStripePaymentMethod<int, int?, DaPaymentMethod, DaPaymentMethodAttribute, DaTransaction, DaTenant, DaTenantUser, DaTenantAttribute, DaSubscription, DaAddressProfile, DaUserAddress, DaCountry, DaCountryRegion>
    {
        public DaStripePaymentMethod(
            DaPaymentMethodManager paymentMethodManager,
            DaTenantManager tenantManager,
            DaAddressProfileManager addressProfileManager,
            DaSubscriptionManager subscriptionManager,
            DaCountryManager countryManager) : base(paymentMethodManager,tenantManager, addressProfileManager, subscriptionManager, countryManager)
        { }
    }
}
