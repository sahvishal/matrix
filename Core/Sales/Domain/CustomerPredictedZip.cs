using Falcon.App.Core.Domain;
using System;

namespace Falcon.App.Core.Sales.Domain
{
    public class CustomerPredictedZip : DomainObjectBase
    {
        public long CustomerId { get; set; }
        public string PredictedZip { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
    }
}
