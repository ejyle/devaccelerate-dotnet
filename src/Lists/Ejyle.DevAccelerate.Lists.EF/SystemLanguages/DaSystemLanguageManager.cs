// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Lists.SystemLanguages;

namespace Ejyle.DevAccelerate.Lists.EF.SystemLanguages
{
    public class DaSystemLanguageManager : DaSystemLanguageManager<int, DaSystemLanguage>
    {
        public DaSystemLanguageManager(DaSystemLanguageRepository repository)
            : base(repository)
        { }
    }
}
