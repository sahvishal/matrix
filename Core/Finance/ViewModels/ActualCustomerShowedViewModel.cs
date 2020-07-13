using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class ActualCustomerShowedViewModel : ViewModelBase
    {
        [Hidden]
        public long CustomerId { get; set; }

        [DisplayName("Customer Id")]
        public string CustomerCode { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Registration Date")]
        [Format("MM/dd/yyyy hh:mm tt")]
        public DateTime RegistrationDate { get; set; }

        [DisplayName("Event Id")]
        public string EventId { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        [DisplayName("Appointment Time")]
        [Format("hh:mm tt")]
        public DateTime? AppointmentTime { get; set; }

        [DisplayName("Package + Test")]
        public string Package { get; set; }

         [DisplayName("Bonus Earned($)")]
        public decimal BonusOnCustomer { get; set; }
    }
}