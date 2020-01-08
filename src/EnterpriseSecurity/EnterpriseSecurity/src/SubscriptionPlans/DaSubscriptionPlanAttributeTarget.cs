using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.SubscriptionPlans
{
    public enum DaSubscriptionPlanAttributeTarget
    {
        NoCopy = 0,
        CopyToSubscription = 1,
        CopyToBillingCycle = 2,
        CopyToSubscriptionAndBillingCycle = 3
    }
}
