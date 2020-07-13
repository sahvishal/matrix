using System;
using System.Collections.Generic;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventCustomerOrderSummaryModel
    {
        public long? EventId { get; set; }
        public DateTime? EventDate { get; set; }
        public string Host { get; set; }
        public AddressViewModel Address { get; set; }
        public EventType EventType { get; set; }
        public bool CaptureInsuranceId { get; set; }

        public DateTime? AppointmentTime { get; set; }
        public OrderedPair<string, decimal> Package { get; set; }
        public IEnumerable<string> PackageTest { get; set; }
        public IEnumerable<OrderedPair<string, decimal>> AdditionalTests { get; set; }

        public IEnumerable<OrderedPair<string, decimal>> Product { get; set; }
        public OrderedPair<string, decimal> ShippingOption { get; set; }
        public long? ShippingOptionId { get; set; }

        public decimal? TotalPrice { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? AmountDue
        {
            get
            {
                if (TotalPrice == null) return null;

                var totalAmount = TotalPrice.Value;
                if(DiscountAmount != null)
                {
                    totalAmount = totalAmount - DiscountAmount.Value;
                }

                if(AmountPaid != null)
                {
                    totalAmount = totalAmount - AmountPaid.Value;
                }

                return totalAmount;
            }
        }

        public string SourceCode { get; set; }
    }
}