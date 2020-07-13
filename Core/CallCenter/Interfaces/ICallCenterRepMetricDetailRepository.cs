using System;
using System.Collections.Generic;
using Falcon.App.Core.CallCenter.ViewModels;

namespace Falcon.App.Core.CallCenter.Interfaces
{
    public interface ICallCenterRepMetricDetailRepository
    {
        List<long> GetBookedEventCustomersByCallCenterRep(long callCenterCallCenterUserId, DateTime startDate, DateTime endDate);

        List<OrderedPair<long, List<long>>> GetSpouseBookingEventCustomerPairs(long callCenterCallCenterUserId,
                                                                               DateTime startDate, DateTime endDate);

        List<OrderedPair<long, List<long>>> GetAllSpouseEventCustomerPairs(long callCenterCallCenterUserId,
                                                                           DateTime startDate, DateTime endDate);
        List<long> GetClosedEventCustomersByCallCenterRep(long callCenterCallCenterUserId, DateTime startDate, DateTime endDate);

        CallCenterRepStatisticsViewData GetBookedEventCustomerStatisticsForCallCenterRep(long callCenterCallCenterUserId, DateTime startDate,
                                                              DateTime endDate);

        CallCenterRepStatisticsViewData GetClosedEventCustomerStatisticsForCallCenterRep(long callCenterCallCenterUserId, DateTime startDate,
                                                              DateTime endDate);
    }
}