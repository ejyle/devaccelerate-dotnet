// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Files;
using System.Xml.Linq;

namespace Ejyle.DevAccelerate.Files.EF
{
    public class DaFileCollectionManager : DaFileCollectionManager<int, int?, DaFileCollection>
    {
        public DaFileCollectionManager(DaFileCollectionRepository repository)
            : base(repository)
        { }
    }
}
