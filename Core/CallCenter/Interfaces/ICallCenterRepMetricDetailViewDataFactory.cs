using System.Collections.Generic;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.CallCenter.Interfaces
{
    public interface ICallCenterRepMetricDetailViewDataFactory
    {
        List<CallCenterRepMetricDetailViewData> CreateCallCenterRepMetricDetailViewData(
            List<EventCustomerRegistrationViewData> eventCustomers, List<Order> orders, CallCenterRep callCenterRep);

        CallCenterRepMetricDetailViewData CreateCallCenterRepMetricDetailViewDatum(EventCustomerRegistrationViewData eventCustomer,
                                                                                   Order order,
                                                                                   CallCenterRep callCenterRep);
    }
}
