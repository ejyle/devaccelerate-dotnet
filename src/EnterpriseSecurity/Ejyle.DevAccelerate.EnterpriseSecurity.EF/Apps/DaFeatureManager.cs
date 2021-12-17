// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.EnterpriseSecurity.Apps;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.EF.Apps
{
    public class DaFeatureManager : DaFeatureManager<int, int?, DaFeature>
    {
        public DaFeatureManager(DaFeatureRepository repository)
            : base(repository)
        { }
    }
}
