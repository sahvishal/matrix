using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CallCenterRepSpouseMetricDetailViewData
    {
        public CallCenterRepMetricDetailViewData OwnerDetail { get; set; }
        public List<CallCenterRepMetricDetailViewData> SpouseDetails { get; set; }
        public Address CustomerAddress { get; set; }
    }
}