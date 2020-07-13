using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.CallCenter.Impl
{
    public class CallCenterRepSpouseMetricDetailViewDataFactory : ICallCenterRepSpouseMetricDetailViewDataFactory
    {

        public CallCenterRepSpouseMetricDetailViewData CreateCenterRepSpouseMetricDetailViewDatum(
            CallCenterRepMetricDetailViewData callCenterRepMetricDetailViewData,
            List<CallCenterRepMetricDetailViewData> spouseCallCenterRepMetricDetailViewData,
            Address customerAddress)
        {
            return new CallCenterRepSpouseMetricDetailViewData
                       {
                           OwnerDetail = callCenterRepMetricDetailViewData,
                           SpouseDetails = spouseCallCenterRepMetricDetailViewData,
                           CustomerAddress = customerAddress
                       };
        }

    }
}