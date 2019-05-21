// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Facades.Security.Authorization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ejyle.DevAccelerate.Facades.Security.Tests
{
    [TestClass]
    public class DaAuthorizationFacadeTests : DaSecurityFacadeTestClassBase
    {
        [TestMethod]
        public void GetAuthorizedFeatures()
        {
            var facade = GetAuthorizationFacade();
            var features = facade.GetAuthorizedFeatures(1, 1);
            Assert.IsTrue(features.Count > 0);
        }

        [TestMethod]
        public void Authorize()
        {
            var facade = GetAuthorizationFacade();
            var authorizationInfo = facade.Authorize(1, 1, "feature-a");
            Assert.IsNotNull(authorizationInfo, $"{nameof(DaAuthorizationInfo)} object is null.");
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
