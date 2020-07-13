using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class CustomerScheduleModel : ViewModelBase
    {
        [Hidden]
        public long CustomerId { get; set; }
        [DisplayName("Customer Id")]
        public string CustomerCode { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }


        [DisplayName("Phone(H)")]
        public string PhoneHome { get; set; }
        [DisplayName("Phone(C)")]
        public string PhoneCell { get; set; }
        [DisplayName("Phone(O)")]
        public string PhoneBusiness { get; set; }
        [DisplayName("Phone(O) Ext")]
        public string PhoneOfficeExtension { get; set; }

        [DisplayName("Appt. Time")]
        [Format("hh:mm tt")]
        public DateTime AppointmentTime { get; set; }

        [DisplayName("Test/Package")]
        public string Package { get; set; }
        [DisplayName("Add. Product")]
        public string AdditionalProduct { get; set; }

        [DisplayName("Price")]
        [Format("00.00")]
        public decimal TotalAmount { get; set; }

        [Hidden]
        public decimal AmountPaid { get; set; }

        [DisplayName("Amount Due")]
        [Format("00.00")]
        public decimal AmountDue
        {
            get { return TotalAmount - AmountPaid; }
        }

        [Hidden]
        public string ShippingOption { get; set; }
    }
}
