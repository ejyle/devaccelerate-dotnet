// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Messages;
using System.Xml.Linq;

namespace Ejyle.DevAccelerate.Messages.EF
{
    public class DaMessageManager : DaMessageManager<int, DaMessage>
    {
        public DaMessageManager(DaMessageRepository repository)
            : base(repository)
        { }
    }
}
