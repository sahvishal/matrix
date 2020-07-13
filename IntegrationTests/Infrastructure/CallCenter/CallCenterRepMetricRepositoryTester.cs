using System;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Infrastructure.CallCenter.Repositories;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.CallCenter
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class CallCenterRepMetricRepositoryTester
    {
        private readonly ICallCenterRepMetricRepository _callCenterRepRepository = new CallCenterRepMetricRepository();

        [Test]
        public void GetCallCenterRepBookingsTester()
        {
            DateTime startDate = DateTime.Today.AddDays(-120);
            DateTime endDate = DateTime.Today;
            var result = _callCenterRepRepository.GetListOfNumberOfBookings(startDate, endDate);
            Assert.IsNotEmpty(result);
        }
    }
}
