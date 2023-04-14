// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Social;

namespace Ejyle.DevAccelerate.Social.EF
{
    public class DaPostManager : DaPostManager<string, DaPost>
    {
        public DaPostManager(DaPostRepository repository)
            : base(repository)
        { }
    }
}
