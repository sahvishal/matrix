using System;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.PrintOrder.Enum;

namespace Falcon.App.Core.Marketing.Domain
{
    public class PrintOrderItem : DomainObjectBase
    {
        public long PrintOrderItemId { get; set; }
       
        public Boolean IsActive { get; set; }
        public string SourceCode { get; set; }
        public PrintOrderItemTracking TrackingInfo { get; set; }
        public long  Quantity { get; set; }
        public long AffiliateId { get; set;}
        public ItemStatus Status { get; set; }
        public PrintOrderItemShipping Shipping { get; set; }
        
        public PrintOrderItem() { }
        public PrintOrderItem(long printOrderItemId) : base(printOrderItemId) { }
    }
}
