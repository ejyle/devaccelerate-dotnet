// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Platform.Features;

namespace Ejyle.DevAccelerate.Platform.EF.Features
{
    public class DaFeatureManager : DaFeatureManager<string, DaFeature>
    {
        public DaFeatureManager(DaFeatureRepository repository)
            : base(repository)
        { }
    }
}
