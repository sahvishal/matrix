using System;
using System.Collections.Generic;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Marketing.Domain
{
    public class PrintOrder : DomainObjectBase
    {
        public long PrintOrderId { get; set; }
        public DateTime PrintOrderDate { get; set; }
        public Boolean IsActive { get; set; }

        public List<PrintOrderItem> PrintOrderItem { get; set; }
      
        public PrintOrder() { }
        public PrintOrder(long printOrderId) : base(printOrderId) { }
    }
}
