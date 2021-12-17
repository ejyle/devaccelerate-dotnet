// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Identity
{
    public interface IDaPasswordHistory<TKey>
    {
        TKey UserId { get; set; }
        string PasswordHash { get; set; }
        DateTime CreatedDateUtc { get; set; }
    }
}
