using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Facades.Security.Subscriptions
{
    public class DaRegistrationResult<TKey>
        where TKey : IEquatable<TKey>
    {
        public DaRegistrationResult(TKey subscriptionId)
        {
            Status = DaRegistrationStatus.Success;
            SubscriptionId = subscriptionId;
        }

        public DaRegistrationResult(DaRegistrationStatus status, IEnumerable<IdentityError> errors)
        {
            if(status == DaRegistrationStatus.Success)
            {
                throw new ArgumentException("The status cannot be Success.");
            }

            Status = status;
            Errors = errors;
        }

        public DaRegistrationStatus Status
        {
            get;
            private set;
        }

        public TKey SubscriptionId
        {
            get;
            set;
        }

        public IEnumerable<IdentityError> Errors
        {
            get;
            private set;
        }
    }
}
