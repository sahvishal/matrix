

using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Marketing.Domain
{
    public class PrintOrderItemShipping : DomainObjectBase
    {
        public string ShipToAttentionOf { get; set; }
        public string ShippedToAddress1 { get; set; }
        public string ShippedToAddress2 { get; set; }
        public string ShippedToCity { get; set; }
        public string ShippedToState { get; set; }
        public string ShippedToZip { get; set; }
        public string ShippedPhoneNumber { get; set; }

    }
}
