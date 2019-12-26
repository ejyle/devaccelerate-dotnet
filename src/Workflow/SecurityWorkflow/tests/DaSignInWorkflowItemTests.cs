using System;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Workflow.Security.Authentication;
using Ejyle.DevAccelerate.Workflow.SimpleWorkflow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ejyle.DevAccelerate.Workflow.Security.Tests
{
    [TestClass]
    public class DaSignInWorkflowItemTests
    {
        [TestMethod]
        public void SignInTest()
        {
            var service = new DaSimpleWorkflowService("C:\\data");

            var parameters = new Dictionary<string, object>();
            parameters.Add("signInInfo", new DaSignInWorkflowItemInfo(null, null, null, null));
            
            var result = service.Execute("SignInWorkflow", parameters);

            Assert.IsNotNull(result, "The workflow's result is null.");
            Assert.IsTrue(result.IsSuccess, "The workflow's success returned false.");
        }
    }
}
