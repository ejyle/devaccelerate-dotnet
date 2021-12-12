// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Lists.Culture;

namespace Ejyle.DevAccelerate.Lists.EF.Culture
{
    public class DaDateFormatManager : DaDateFormatManager<int, DaDateFormat>
    {
        public DaDateFormatManager(DaDateFormatRepository repository)
            : base(repository)
        { }
    }
}
