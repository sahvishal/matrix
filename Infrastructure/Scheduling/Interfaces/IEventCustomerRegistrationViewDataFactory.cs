using System.Collections.Generic;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.Data.TypedViewClasses;

namespace Falcon.App.Infrastructure.Scheduling.Interfaces
{
    public interface IEventCustomerRegistrationViewDataFactory
    {
        List<EventCustomerRegistrationViewData> Create(IEnumerable<CustomerOrderBasicInfoRow> customerOrderBasicInfoTypedView, IEnumerable<AssignedPhysicianViewModel> assignedPhysicians);
        List<EventCustomerRegistrationViewData> Create(IEnumerable<EventSchedulingSlot> appointments, AppointmentSlotStatus appointmentSlotStatus);
    }
}