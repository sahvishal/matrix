using System.Collections.Generic;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling.Interfaces
{
    public interface IEventCustomerRegistrationViewDataRepository
    {
        List<EventCustomerRegistrationViewData> GetEventCustomerOrders(List<long> eventCustomerIds);
        EventCustomerRegistrationViewData GetEventCustomerOrders(long customerId, long eventId);
        List<EventCustomerRegistrationViewData> GetEventCustomerOrdersForEvent(long eventId);
        List<EventCustomerRegistrationViewData> GetEventCustomerOrdersForEvent(
            EventCustomerFilterMode eventCustomerFilterMode, long eventId);
    }
}