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
    public interface IDaSubscriptionFeatureAccessInfo<TKey, TSubscriptionFeatureAccessActionInfo>
        where TKey : IEquatable<TKey>
        where TSubscriptionFeatureAccessActionInfo : IDaSubscriptionFeatureAccessActionInfo<TKey>
    {
        TKey Id { get; set; }
        string Key { get; set; }
        List<TSubscriptionFeatureAccessActionInfo> Actions { get; set; }
    }

    public interface IDaSubscriptionFeatureAccessActionInfo<TKey>
        where TKey : IEquatable<TKey>
    {
        string ActionName { get; set; }
        bool? Allowed { get; set; }
    }
}
