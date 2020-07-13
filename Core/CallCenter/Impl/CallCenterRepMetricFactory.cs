using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallCenter.ViewModels;

namespace Falcon.App.Core.CallCenter.Impl
{
    public class CallCenterRepMetricFactory : ICallCenterRepMetricFactory
    {
        public CallCenterRepMetricViewData CreateCallCenterMetric(long callCenterCallCenterUserId,
            int numberOfCalls, int numberOfBookings, int numberOfSpouseBookings, int numberOfClosings, 
            decimal averageSalesAmount)
        {
            return new CallCenterRepMetricViewData
                       {
                           AverageSaleAmount = averageSalesAmount,
                           BookingCallCount = numberOfBookings,
                           SpouseBookingCallCount = numberOfSpouseBookings,
                           CallCenterRepId = callCenterCallCenterUserId,
                           ClosingCallCount = numberOfClosings,
                           TotalSignUpCallCount = numberOfCalls
                       };
        }

        public List<CallCenterRepMetricViewData> CreateCallCenterMetrics(List<OrderedPair<long, int>> listOfNumberOfCalls,
            List<OrderedPair<long, int>> listOfNumberOfBookings, List<OrderedPair<long, int>> listOfNumberOfSpouseBookings,
            List<OrderedPair<long, int>> listOfNumberOfClosings, 
            List<OrderedPair<long, decimal>> listOfAverageSalesAmounts)
        {
            var metrics = new List<CallCenterRepMetricViewData>();
            foreach (long callCenterCallCenterUserId in listOfNumberOfCalls.Select(lnc => lnc.FirstValue))
            {
                long id = callCenterCallCenterUserId;
                int numberOfCalls = listOfNumberOfCalls.Where(lnc => lnc.FirstValue == id).Select(lnc => lnc.SecondValue).DefaultIfEmpty(0).Single();
                int numberOfBookings = listOfNumberOfBookings.Where(lnb => lnb.FirstValue == id).Select(lnb => lnb.SecondValue).DefaultIfEmpty(0).Single();
                int numberOfSpouseBookings = listOfNumberOfSpouseBookings.Where(lnb => lnb.FirstValue == id).Select(lnb => lnb.SecondValue).DefaultIfEmpty(0).Single();
                int numberOfClosings = listOfNumberOfClosings.Where(lnc => lnc.FirstValue == id).Select(lnc => lnc.SecondValue).DefaultIfEmpty(0).Single();
                decimal averageSalesAmount = listOfAverageSalesAmounts.Where(ltsm => ltsm.FirstValue == id).Select(ltsm => ltsm.SecondValue).DefaultIfEmpty(0m).Single();
                metrics.Add(CreateCallCenterMetric(id, numberOfCalls, numberOfBookings, numberOfSpouseBookings,
                                                   numberOfClosings, averageSalesAmount));
            }
            return metrics;
        }
    }
}