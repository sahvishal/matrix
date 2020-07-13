using System.Collections.Generic;
using Falcon.App.Core.CallCenter.ViewModels;

namespace Falcon.App.Core.CallCenter.Interfaces
{
    public interface ICallCenterRepMetricFactory
    {
        CallCenterRepMetricViewData CreateCallCenterMetric(long callCenterCallCenterUserId, int numberOfCalls,
                                                           int numberOfBookings, int numberOfSpouseBookings,
                                                           int numberOfClosings, decimal averageSalesAmount);

        List<CallCenterRepMetricViewData> CreateCallCenterMetrics(List<OrderedPair<long, int>> listOfNumberOfCalls,
                                                                  List<OrderedPair<long, int>> listOfNumberOfBookings,
                                                                  List<OrderedPair<long, int>>
                                                                      listOfNumberOfSpouseBookings,
                                                                  List<OrderedPair<long, int>> listOfNumberOfClosings,
                                                                  List<OrderedPair<long, decimal>>
                                                                      listOfAverageSalesAmounts);
    }
}