using System;
using System.Collections.Generic;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventCustomerSummaryModel
    {
        public long EventId { get; set; }
        public DateTime EventDate { get; set; }
        public string Host { get; set; }
        public AddressViewModel Address { get; set; }

        public EventStatus EventStatus { get; set; }

        public long CustomerId { get; set; }

        public string CustomerName { get; set; }
        public string HomePhoneNumber { get; set; }
        public string OfficePhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        public string Email { get; set; }

        public DateTime? AppointmentTime { get; set; }
        public string Package { get; set; }

        public long OrderId { get; set; }
        public long EventCustomerId { get; set; }

        public string AdditionalProduct { get; set; }

        public IEnumerable<OrderedPair<string, decimal>> ShippingOptions { get; set; }

        public string SourceCode { get; set; }
        public decimal SourceCodeAmount { get; set; }

        public decimal Cost { get; set; }

        public decimal AmountPaid { get; set; }
        public decimal AmountDue { get; set; }

        public IEnumerable<OrderedPair<string, decimal>> Payments { get; set; }

    }
}