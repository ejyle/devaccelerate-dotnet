﻿// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.MultiTenancy.ApiManagement;

namespace Ejyle.DevAccelerate.MultiTenancy.EF.ApiManagement
{
    public class DaApiKeyManager : DaApiKeyManager<string, DaApiKey>
    {
        public DaApiKeyManager(DaApiKeyRepository repository)
            : base(repository)
        { }
    }
}
