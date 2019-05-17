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

namespace Ejyle.DevAccelerate.Facades.Security.Subscriptions
{
    public class DaSubscriptionFeatureAccessInfo : DaSubscriptionFeatureAccessInfo<int, DaSubscriptionFeatureAccessActionInfo>
    { }

    public class DaSubscriptionFeatureAccessInfo<TKey, TSubscriptionFeatureAccessActionInfo> : IDaSubscriptionFeatureAccessInfo<TKey, TSubscriptionFeatureAccessActionInfo>
        where TKey : IEquatable<TKey>
        where TSubscriptionFeatureAccessActionInfo : IDaSubscriptionFeatureAccessActionInfo<TKey>
    {
        public TKey Id {get; set;}
        public string Key {get; set;}
        public List<TSubscriptionFeatureAccessActionInfo> Actions {get; set;}
    }

    public class DaSubscriptionFeatureAccessActionInfo : DaSubscriptionFeatureAccessActionInfo<int>
    { }

    public class DaSubscriptionFeatureAccessActionInfo<TKey> : IDaSubscriptionFeatureAccessActionInfo<TKey>
        where TKey : IEquatable<TKey>
    {
        public string ActionName {get; set;}
        public bool? Allowed {get; set;}
    }
}
