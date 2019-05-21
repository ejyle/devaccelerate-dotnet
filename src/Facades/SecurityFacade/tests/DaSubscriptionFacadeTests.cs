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
    }
}
