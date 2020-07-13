using System;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    // TODO: This class needs refactoring since now it will be mapped to new order system data.
    // TODO: Some fields will be nuked from this as they make no relevance in new order system.
    public class EventCustomerAggregate 
    {
        //customer
        public long CustomerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SignUpMarketingSource { get; set; }
        public DateTime CustomerSignupDate { get; set; }
        public Address CustomerAddress { get; set; }

        public CustomerEventSignUpMode SignUpMode { get; set; }

        public long EventId { get; set; }
        public string EventName { get; set; }
        public EventStatus EventStatus { get; set; }
        public DateTime EventDate { get; set; }
        public Address EventAddress { get; set; }

        public long AppointmentId { get; set; }
        public DateTime AppointmentTime { get; set; }

        public string PackageName { get; set; }
        public decimal PackageCost { get; set; }
        public long EventCustomerId { get; set; }

        public string SourceCode { get; set; }

        public string PaymentType { get; set; }
        public decimal PaymentAmount { get; set; }

        public decimal PaymentNet { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal UnpaidAmount { get; set; }

        public string MarketingSource { get; set; }

        public DateTime EventSignupDate { get; set; }
        public string PodName { get; set; }

        public bool IsPaid { get; set; }

        public string IncomingPhoneNumber { get; set; }        
        

        // Used in asynchronous call.
        public string SignUpModeName { get { return SignUpMode.ToString(); } }
    }
}