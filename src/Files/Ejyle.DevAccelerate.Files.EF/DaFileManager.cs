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
    public class DaFileManager : DaFileManager<int, int?, DaFile>
    {
        public DaFileManager(DaFileRepository repository)
            : base(repository)
        { }
    }
}
