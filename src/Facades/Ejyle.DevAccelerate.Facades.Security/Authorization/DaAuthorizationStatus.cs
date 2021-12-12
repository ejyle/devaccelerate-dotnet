using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Facades.Security.Authorization
{
    public enum DaAuthorizationStatus
    {
        Success = 0,
        UserAccountNotActive = 1,
        SubscriptionNotActive = 2,
        NotAssociatedWithAnActiveTenant = 3,
        FeatureNotFoundInSubscription = 4,
        FeatureDenidToUser = 5
    }
}
