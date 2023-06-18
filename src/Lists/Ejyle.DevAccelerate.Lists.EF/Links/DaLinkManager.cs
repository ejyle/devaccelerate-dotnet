// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Lists.Links;

namespace Ejyle.DevAccelerate.Lists.EF.Links
{
    public class DaLinkManager : DaLinkManager<string, DaLink>
    {
        public DaLinkManager(DaLinkRepository repository)
            : base(repository)
        { }
    }
}
