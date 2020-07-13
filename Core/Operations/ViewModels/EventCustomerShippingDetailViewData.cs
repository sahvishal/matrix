using System;
using Falcon.App.Core.Operations.Enum;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class EventCustomerShippingDetailViewData
    {
        // Customer Data.
        public long UserId { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerStreetAddressLine1 { get; set; }
        public string CustomerStreetAddressLine2 { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        public string CustomerZip { get; set; }
        public string CustomerEmail { get; set; }

        // Event Data.
        public long EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }

        // Test Data.
        public bool IsPdfGenerated { get; set; }
        public bool IsResultPdfGenerated { get; set; }

        // Pod Data.
        public long PodId { get; set; }
        public string PodName { get; set; }

        // Package Data.
        public long PackageId { get; set; }
        public string PackageName { get; set; }
        public string AdditionalTest { get; set; }
        public string ProductName { get; set; }

        // Shipping Detail Data.
        public long ShippingDetailId { get; set; }
        public string ShippingOptionName { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public DateTime ShippingRequestedOn { get; set; }

        public bool IsExclusivelyRequested { get; set; }
        
        public ShipmentStatus Status { get; set; }
        public decimal ActualPrice { get; set; }

        public bool IsPaid { get; set; }


        public int TotalCount { get; set; }
    }
}