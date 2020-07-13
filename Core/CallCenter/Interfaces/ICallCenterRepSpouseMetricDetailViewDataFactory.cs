using System.Collections.Generic;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.CallCenter.Interfaces
{
    public interface ICallCenterRepSpouseMetricDetailViewDataFactory
    {
        CallCenterRepSpouseMetricDetailViewData CreateCenterRepSpouseMetricDetailViewDatum(
            CallCenterRepMetricDetailViewData callCenterRepMetricDetailViewData,
            List<CallCenterRepMetricDetailViewData> spouseCallCenterRepMetricDetailViewData, Address customerAddress);
    }
}