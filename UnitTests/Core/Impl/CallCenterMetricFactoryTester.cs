using Falcon.App.Core.CallCenter.Impl;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Domain.ViewData;
using Falcon.App.Core.Interfaces;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Impl
{
    [TestFixture]
    public class CallCenterMetricFactoryTester
    {
        private readonly ICallCenterRepMetricFactory _callCenterRepMetricFactory = new CallCenterRepMetricFactory();

        [Test]
        public void CreateCallCenterMetricSetsBookingPercentageTo0When0GivenAsNumberOfCalls()
        {
            const decimal expectedBookingPercentage = 0m;
            const int numberOfCalls = 0;

            CallCenterRepMetricViewData callCenterRepMetric = _callCenterRepMetricFactory.
                CreateCallCenterMetric(0, numberOfCalls, 0, 0, 0, 0m);

            Assert.AreEqual(expectedBookingPercentage, callCenterRepMetric.BookingPercentage, "Incorrect Booking Percentage returned.");
        }

        [Test]
        public void CreateCallCenterMetricSetsBookingPercentageTo0When0GivenAsNumberOfBookings()
        {
            const decimal expectedBookingPercentage = 0m;
            const int numberOfBookings = 0;

            CallCenterRepMetricViewData callCenterRepMetric = _callCenterRepMetricFactory.
                CreateCallCenterMetric(0, 0, numberOfBookings, 0, 0, 0m);

            Assert.AreEqual(expectedBookingPercentage, callCenterRepMetric.BookingPercentage, "Incorrect Booking Percentage returned.");
        }

        [Test]
        public void CreateCallCenterMetricSetsBookingPercentageTo100When1Book1CallGiven()
        {
            const decimal expectedBookingPercentage = 1m;
            const int numberOfBookings = 1;
            const int numberOfCalls = 1;

            CallCenterRepMetricViewData callCenterRepMetric = _callCenterRepMetricFactory.
                CreateCallCenterMetric(0, numberOfCalls, numberOfBookings, 0, 0, 0m);

            Assert.AreEqual(expectedBookingPercentage, callCenterRepMetric.BookingPercentage, "Incorrect Booking Percentage returned.");
        }

        [Test]
        public void CreateCallCenterMetricSetsClosingPercentageTo0When0GivenAsNumberOfCalls()
        {
            const decimal expectedClosingPercentage = 0m;
            const int numberOfBookings = 0;

            CallCenterRepMetricViewData callCenterRepMetric = _callCenterRepMetricFactory.
                CreateCallCenterMetric(0, 0, numberOfBookings, 0, 0, 0m);

            Assert.AreEqual(expectedClosingPercentage, callCenterRepMetric.ClosingPercentage, "Incorrect Closing Percentage returned.");
        }

        [Test]
        public void CreateCallCenterMetricSetsClosingPercentageTo100When1Book1CallGiven()
        {
            const decimal expectedClosingPercentage = 1m;
            const int numberOfClosings = 1;
            const int numberOfBookings = 1;

            CallCenterRepMetricViewData callCenterRepMetric = _callCenterRepMetricFactory.
                CreateCallCenterMetric(0, 0, numberOfBookings, 0, numberOfClosings, 0m);

            Assert.AreEqual(expectedClosingPercentage, callCenterRepMetric.ClosingPercentage, "Incorrect Closing Percentage returned.");
        }

        [Test]
        public void CreateCallCenterMetricSetsAverageSaleAmountTo0WhenGiven0()
        {
            const decimal expectedAverageSaleAmount = 0m;
            const int numberOfCalls = 0;

            CallCenterRepMetricViewData callCenterRepMetric = _callCenterRepMetricFactory.
                CreateCallCenterMetric(0, numberOfCalls, 0, 0, 0, 0m);

            Assert.AreEqual(expectedAverageSaleAmount, callCenterRepMetric.AverageSaleAmount, "Incorrect Average Sale Amount returned.");
        }

        [Test]
        public void CreateCallCenterMetricSetsCallCenterCallCenterUserIdToGivenCCCUId()
        {
            const long expectedCallCenterCallCenterUserId = 283;

            CallCenterRepMetricViewData callCenterRepMetric = _callCenterRepMetricFactory.
                CreateCallCenterMetric(expectedCallCenterCallCenterUserId, 0, 0, 0, 0, 0m);

            Assert.AreEqual(expectedCallCenterCallCenterUserId, callCenterRepMetric.CallCenterRepId,
                "Incorrect Call Center Call Center User ID returned.");
        }
    }
}