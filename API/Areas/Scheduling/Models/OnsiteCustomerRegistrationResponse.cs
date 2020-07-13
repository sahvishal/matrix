using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.ViewModels;

namespace API.Areas.Scheduling.Models
{
    [NoValidationRequired]
    public class OnsiteCustomerRegistrationResponse : ResponseBaseModel
    {
        public EventCustomerAppointmentViewModel AppointmentViewModel { get; set; }
    }
}