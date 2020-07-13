using System;
using Falcon.App.Core.Marketing.Domain;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class PrintOrderItemViewData
    {
        public long EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public long PrintOrderId { get; set; }
        public PrintOrderItem PrintOrderItem { get; set; }
        public string PrintVendor { get; set; }
        public string OrderPlacedBy { get; set; }
        public string MarketingMaterialType { get; set; }
        public string MarketingMaterialName { get; set; }
    }
}
