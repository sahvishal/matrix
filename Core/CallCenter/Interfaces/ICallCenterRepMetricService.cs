using System;
using System.Collections.Generic;
using Falcon.App.Core.CallCenter.ViewModels;

namespace Falcon.App.Core.CallCenter.Interfaces
{
    public interface ICallCenterRepMetricService
    {
        List<CallCenterRepMetricDetailViewData> GetBookingCallCenterRepMetricDetailsViewData(long callCenterCallCenterUserId,
                                                                                             DateTime startDate,
                                                                                             DateTime endDate,
                                                                                             int pageIndex, int pageSize,
                                                                                             out int totalCount);

        List<CallCenterRepMetricDetailViewData> GetClosingCallCenterRepMetricDetailsViewData(long callCenterCallCenterUserId,
                                                                                             DateTime startDate,
                                                                                             DateTime endDate,
                                                                                             int pageIndex, int pageSize,
                                                                                             out int totalCount);

        List<CallCenterRepMetricDetailViewData> GetAsrCallCenterRepMetricDetailsViewData(long callCenterCallCenterUserId,
                                                                                         DateTime startDate,
                                                                                         DateTime endDate, int pageIndex,
                                                                                         int pageSize,
                                                                                         out int totalCount);

        CallCenterRepSpouseStatisticsViewData GetSpouseBookingStatistics(long callCenterCallCenterUserId,
                                                                         DateTime startDate, DateTime endDate);

    }
}