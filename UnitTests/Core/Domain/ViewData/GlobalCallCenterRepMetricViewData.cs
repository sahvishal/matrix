using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Users.Domain;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Domain.ViewData
{
    [TestFixture]
    public class GlobalCallCenterRepMetricViewData
    {
        [Test]
        public void BookingPercentageViewDataReturnsEmptyListWhenViewDataGivenEmptyList()
        {
            var globalMetrics = new List<OrderedPair<CallCenterRep, CallCenterRepMetricViewData>>();

            var globalMetricViewData = new Falcon.App.Core.CallCenter.ViewModels.GlobalCallCenterRepMetricViewData(globalMetrics);

            Assert.IsEmpty(globalMetricViewData.BookingPercentageViewData, "Non-empty collection of Booking Percentage View Data returned.");
        }

        [Test]
        public void BookingPercentageViewDataReturnsTwoMetricsWithHigherBookingPercentageAsFirstItem()
        {
            const decimal expectedBookingPercentage = 25m;
            var globalMetrics = new List<OrderedPair<CallCenterRep, CallCenterRepMetricViewData>>
            {
                new OrderedPair<CallCenterRep, CallCenterRepMetricViewData>
                    (null, new CallCenterRepMetricViewData { BookingCallCount = 100, TotalSignUpCallCount = 5}),
                new OrderedPair<CallCenterRep, CallCenterRepMetricViewData>
                    (null, new CallCenterRepMetricViewData { BookingCallCount = 100, TotalSignUpCallCount = 4 })
            };

            var globalMetricViewData = new Falcon.App.Core.CallCenter.ViewModels.GlobalCallCenterRepMetricViewData(globalMetrics);

            Assert.AreEqual(expectedBookingPercentage, globalMetricViewData.BookingPercentageViewData.First().SecondValue.BookingPercentage,
                "Incorrect Booking Percentage returned as first value of Global Metric View Data.");
        }

        [Test]
        public void ClosingPercentageViewDataReturnsTwoMetricsWithHigherClosingPercentageAsFirstItem()
        {
            const decimal expectedClosingPercentage = 15m;
            var globalMetrics = new List<OrderedPair<CallCenterRep, CallCenterRepMetricViewData>>
            {
                new OrderedPair<CallCenterRep, CallCenterRepMetricViewData>
                    (null, new CallCenterRepMetricViewData { BookingCallCount = 10, ClosingCallCount = 100 }),
                new OrderedPair<CallCenterRep, CallCenterRepMetricViewData>
                    (null, new CallCenterRepMetricViewData { BookingCallCount = 10, ClosingCallCount = 150 })
            };

            var globalMetricViewData = new Falcon.App.Core.CallCenter.ViewModels.GlobalCallCenterRepMetricViewData(globalMetrics);

            Assert.AreEqual(expectedClosingPercentage, globalMetricViewData.ClosingPercentageViewData.First().SecondValue.ClosingPercentage,
                "Incorrect Closing Percentage returned as first value of Global Metric View Data.");
        }

        [Test]
        public void AverageSaleAmountViewDataReturnsTwoMetricsWithHigherAverageSaleAmountAsFirstItem()
        {
            const decimal expectedAverageSaleAmount = 25m;
            var globalMetrics = new List<OrderedPair<CallCenterRep, CallCenterRepMetricViewData>>
            {
                new OrderedPair<CallCenterRep, CallCenterRepMetricViewData>
                    (null, new CallCenterRepMetricViewData { AverageSaleAmount = 20m }),
                new OrderedPair<CallCenterRep, CallCenterRepMetricViewData>
                    (null, new CallCenterRepMetricViewData { AverageSaleAmount = expectedAverageSaleAmount })
            };

            var globalMetricViewData = new Falcon.App.Core.CallCenter.ViewModels.GlobalCallCenterRepMetricViewData(globalMetrics);

            Assert.AreEqual(expectedAverageSaleAmount, globalMetricViewData.AverageSaleAmountViewData.First().SecondValue.AverageSaleAmount,
                "Incorrect Average Sale Amount returned as first value of Global Metric View Data.");
        }

        [Test]
        public void ClosingPercentageViewDataReturnsEmptyLIstWhenViewDataGivenEmptyList()
        {
            var globalMetrics = new List<OrderedPair<CallCenterRep, CallCenterRepMetricViewData>>();

            var globalMetricViewData = new Falcon.App.Core.CallCenter.ViewModels.GlobalCallCenterRepMetricViewData(globalMetrics);

            Assert.IsEmpty(globalMetricViewData.ClosingPercentageViewData, "Non-empty collection of Closing Percentage View Data returned.");
        }

        [Test]
        public void AverageSaleAmountViewDataReturnsEmptyLIstWhenViewDataGivenEmptyList()
        {
            var globalMetrics = new List<OrderedPair<CallCenterRep, CallCenterRepMetricViewData>>();

            var globalMetricViewData = new Falcon.App.Core.CallCenter.ViewModels.GlobalCallCenterRepMetricViewData(globalMetrics);

            Assert.IsEmpty(globalMetricViewData.AverageSaleAmountViewData, "Non-empty collection of Average Sale Amount View Data returned.");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GlobalMetricViewDataThrowsExceptionWhenGivenNullCollectionOfViewData()
        {
            new Falcon.App.Core.CallCenter.ViewModels.GlobalCallCenterRepMetricViewData(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GlobalMetricViewDataThrowsExceptionWhenGivenViewDataWithNullMetrics()
        {
            var globalMetrics = new List<OrderedPair<CallCenterRep, CallCenterRepMetricViewData>>
            {
                new OrderedPair<CallCenterRep, CallCenterRepMetricViewData>(new CallCenterRep(), null)
            };

            new Falcon.App.Core.CallCenter.ViewModels.GlobalCallCenterRepMetricViewData(globalMetrics);
        }
    }
}