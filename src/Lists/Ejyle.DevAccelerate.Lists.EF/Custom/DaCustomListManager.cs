// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Lists.Custom;
using System.Collections.Generic;
using System.Linq;

namespace Ejyle.DevAccelerate.Lists.EF.Custom
{
    public class DaCustomListManager : DaCustomListManager<string, DaCustomList>
    {
        public DaCustomListManager(DaCustomListRepository repository)
            : base(repository)
        { }

        protected override bool IsListNameUnique(DaCustomList customList)
        {
            var duplicates = customList.ListItems.GroupBy(x => x.Name)
                    .Where(g => g.Count() > 1).ToList();

            return (duplicates.Count() > 0);
        }

        protected override bool IsWeightageDuplicate(DaCustomList customList)
        {
            var duplicates = customList.ListItems.GroupBy(x => x.Weightage)
                    .Where(g => g.Count() > 1).ToList();

            return (duplicates.Count() > 0 && duplicates.Where(m => m != null).Count() >= 1);
        }
    }
}
