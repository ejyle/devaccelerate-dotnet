﻿// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Subscriptions.SubscriptionPlans
{
    public class DaDuplicateSubscriptionPlanCodeException : ApplicationException
    {
        public DaDuplicateSubscriptionPlanCodeException(string message)
            : base(message)
        { }
    }
}
