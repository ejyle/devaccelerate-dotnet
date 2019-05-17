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
    public interface IDaSubscriptionFeatureInfo<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
        string Name { get; set; }
        string Key { get; set; }
        string Location { get; set; }
    }
}
