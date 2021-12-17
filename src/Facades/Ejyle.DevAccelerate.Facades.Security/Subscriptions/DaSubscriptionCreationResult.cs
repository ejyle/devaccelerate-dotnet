using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Facades.Security.Subscriptions
{
    public class DaSubscriptionCreationResult<TKey>
        where TKey : IEquatable<TKey>
    {
        public DaSubscriptionCreationResult(TKey subscriptionId)
        {
            Status = DaSubscriptionCreationStatus.Success;
            SubscriptionId = subscriptionId;
        }

        public DaSubscriptionCreationResult(DaSubscriptionCreationStatus status, IEnumerable<string> errors)
        {
            if (status == DaSubscriptionCreationStatus.Success)
            {
                throw new ArgumentException("The status cannot be Success.");
            }

            Status = status;
            Errors = errors;
        }

        public DaSubscriptionCreationStatus Status
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
