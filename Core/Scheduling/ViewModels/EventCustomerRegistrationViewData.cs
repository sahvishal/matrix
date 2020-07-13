using System;
using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventCustomerRegistrationViewData : EventCustomerViewData
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email1 { get; set; }

        public AppointmentSlotStatus AppointmentSlotStatus { get; set; }

        
        public decimal SourceCodeDiscount { get { return SourceCodeAmount; } }

        public decimal CashPayment { get; set; }
        public decimal CheckPayment { get; set; }
        public decimal ChargeCardPayment { get; set; }
        public decimal ECheckPayment { get; set; }
        public decimal GiftCertificatePayment { get; set; }
        public decimal InsurancePayment { get; set; }

        public long EventCount { get; set; }
        public long ScheduleById { get; set; }
        public string AppointmentBlockReason { get; set; }
        public DateTime UserCreatedOn { get; set; }
        
        public bool CustomerHealthInfo { get; set; }

        public string RegisteredBy
        {
            get 
            {
                return SignUpMode.ToString();
            }
        }
    }
}