using System;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class ShippingDetailViewModel
    {
        public ShippingOption ShippingOption { get; set; }
        public DateTime? ShipmentDate { get; set; }

        public ShipmentStatus Status { get; set; }
        public decimal ActualPrice { get; set; }
        
        public string ShippedByName { get; set; }
    }
}