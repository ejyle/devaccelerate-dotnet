// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Facades.Security.Registration
{
    public class DaRegistrationCreationResult<TKey>
        where TKey : IEquatable<TKey>
    {
        public DaRegistrationCreationResult(TKey subscriptionId)
        {
            Status = DaRegistrationCreationStatus.Success;
            SubscriptionId = subscriptionId;
        }

        public DaRegistrationCreationResult(DaRegistrationCreationStatus status, IEnumerable<string> errors)
        {
            if (status == DaRegistrationCreationStatus.Success)
            {
                throw new ArgumentException("The status cannot be Success.");
            }

            Status = status;
            Errors = errors;
        }

        public DaRegistrationCreationStatus Status
        {
            get;
            private set;
        }

        public TKey SubscriptionId
        {
            get;
            private set;
        }

        public IEnumerable<string> Errors
        {
            get;
            private set;
        }
    }
}
