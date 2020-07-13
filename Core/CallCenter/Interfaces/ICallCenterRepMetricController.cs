using System;
using Falcon.App.Core.CallCenter.ViewModels;

namespace Falcon.App.Core.CallCenter.Interfaces
{
    public interface ICallCenterRepMetricController
    {
        //CallCenterRepMetricViewData GetMetricForUser(long callCenterCallCenterUserId, DateTime startDate, DateTime endDate);
        GlobalCallCenterRepMetricViewData GetMetricsForAllUsers(DateTime startDate, DateTime endDate);
    }
}