// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Facades.Security.Subscriptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ejyle.DevAccelerate.Facades.Security.Tests
{
    [TestClass]
    public class DaSubscriptionFacadeTests : DaSecurityFacadeTestClassBase
    {
        [TestMethod]
        public void GetFeatures()
        {
            var facade = GetSubscriptionFacade();
            var features = DaAsyncHelper.RunSync<List<DaSubscriptionFeatureInfo>>(() => facade.GetFeatures(1, 1));
            Assert.IsTrue(features.Count > 0);
        }

        [TestMethod]
        public void GetAccessInfo()
        {
            var facade = GetSubscriptionFacade();
            var accessInfo = DaAsyncHelper.RunSync<DaSubscriptionFeatureAccessInfo>(() => facade.GetAccessInfoAsync(1, 1, "feature-a"));
            Assert.IsNotNull(accessInfo, $"{nameof(DaSubscriptionFeatureAccessInfo)} object is null.");
        }

        #region Cleanup / Teardown Operations
        [TestInitialize]
        public virtual void Initialize()
        {
        }

        [TestCleanup]
        public virtual void Cleanup()
        {

        }
        #endregion Cleanup / Teardown Operations
    }
}
