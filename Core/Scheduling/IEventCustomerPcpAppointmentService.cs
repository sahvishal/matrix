using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventCustomerPcpAppointmentService
    {
        EventCustomerPcpAppointmentEditModel GetEventCustomerPcpAppointment(long eventcustomerId);
        EventCustomerPcpAppointmentEditModel GetEventCustomerEventModel(long eventcustomerId);
        PrimaryCarePhysicianEditModel GetPrimaryCarePhysicianEditModel(long customerId);
        void UpdatePcpAppointmentTime(EventCustomerPcpAppointmentEditModel model, long orgRoleUserId);
        EventCustomerPcpAppointmentViewModel GetEventCustomerPcpAppointmentViewModel(long eventId, long customerId);

        EventCustomerPcpAppointmentViewModel GetEventCustomerPcpAppointmentViewModel(Event eventData, Customer customer, CorporateAccount account, PrimaryCarePhysician pcp, EventCustomer eventCustomer);
    }
}