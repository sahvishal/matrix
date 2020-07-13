using System;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.UI.Controllers;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.UI.CallCenter
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class CallCenterRepMetricControllerTester
    {
        private readonly ICallCenterRepMetricController _callCenterRepMetricController = new CallCenterRepMetricController();
        private const long VALID_CALL_CENTER_CALL_CENTER_USER_ID = 105;

        //[Test]
        //public void GetMetricForUserReturnsMetric()
        //{
        //    CallCenterRepMetricViewData metric = _callCenterRepMetricController.
        //        GetMetricForUser(VALID_CALL_CENTER_CALL_CENTER_USER_ID, new DateTime(1900, 1, 1), DateTime.Now);

        //    Assert.IsNotNull(metric, "Null metric returned.");
        //}

        [Test]
        public void GetMetricsForAllUsersReturnsMetrics()
        {
            GlobalCallCenterRepMetricViewData metrics = _callCenterRepMetricController.GetMetricsForAllUsers(new DateTime(1900, 1, 1), DateTime.Now);

            Assert.IsNotNull(metrics, "Null metric collection returned.");
        }
    }
}