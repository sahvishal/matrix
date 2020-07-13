
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System;
using System.ComponentModel;
namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class CorporateEventCustomersModel : ViewModelBase
    {
        [DisplayName("Appt. Time")]
        [Format("hh:mm tt")]
        public DateTime AppointmentTime { get; set; }

        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }
        
        [DisplayName("Member Id")]
        public string MemberId { get; set; }

        [DisplayName("Package/Test")]
        public string Package { get; set; }

        [DisplayName("Phone(H)")]
        public string PhoneHome { get; set; }
        
        [DisplayName("Phone(C)")]
        public string PhoneCell { get; set; }
       
        [DisplayName("Phone(O)")]
        public string PhoneBusiness { get; set; }
    }
}
