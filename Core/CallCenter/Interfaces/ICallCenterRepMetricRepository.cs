using System;
using System.Collections.Generic;

namespace Falcon.App.Core.CallCenter.Interfaces
{
    public interface ICallCenterRepMetricRepository
    {
        int GetNumberOfCallsForRep(long callCenterCallCenterUserId, DateTime startDate, DateTime endDate);
        int GetNumberOfBookingsForRep(long callCenterCallCenterUserId, DateTime startDate, DateTime endDate);
        int GetNumberOfSpouseBookingsForRep(long callCenterCallCenterUserId, DateTime startDate, DateTime endDate);
        int GetNumberOfClosingsForRep(long callCenterCallCenterUserId, DateTime startDate, DateTime endDate);
        decimal GetAverageSaleAmountForRep(long callCenterCallCenterUserId, DateTime startDate, DateTime endDate);

        List<OrderedPair<long, int>> GetListOfNumberOfCalls(DateTime startDate, DateTime endDate);
        List<OrderedPair<long, int>> GetListOfNumberOfBookings(DateTime startDate, DateTime endDate);
        List<OrderedPair<long, int>> GetListOfNumberOfSpouseBookings(DateTime startDate, DateTime endDate);
        List<OrderedPair<long, int>> GetListOfNumberOfClosings(DateTime startDate, DateTime endDate);
        List<OrderedPair<long, decimal>> GetListOfAverageSaleAmounts(DateTime startDate, DateTime endDate);
    }
}