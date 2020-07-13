using System.Collections.Generic;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling.Interfaces
{
    public interface IEventCustomerService
    {
        EventCustomerAggregate GetEventCustomerAggregate(long eventCustomerId);
        IEnumerable<EventCustomerAggregate> GetEventCustomerAggregates(IEnumerable<long> eventCustomerIds);

        List<EventCustomerRegistrationViewData> GetEventCustomerRegistrationViewData(long eventId,
                                                                                EventCustomerFilterMode
                                                                                    eventCustomerFilterMode);
        bool IsCustomerRegisteredfortheGivenEvent(long customerId, long eventId);

        void CancelAppointment(long eventId, long customerId, PaymentEditModel paymentEditModel,
                               long dataRecorderOrgRoleUserId, bool chargeCancellation = true);
    }
}