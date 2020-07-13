using Falcon.App.Core.Domain;
using Falcon.App.Core.Operations.Enum;

namespace Falcon.App.Core.Operations.Domain
{
    public class ShippingOption : DomainObjectBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ShippingType Type { get; set; }  
        public Carrier Carrier { get; set; }
        public decimal Price { get; set; }
        public decimal CostToCompany { get; set; }
        public string Disclaimer { get; set; }

        public ShippingOption()
        {}

        public ShippingOption(long shippingOptionId)
            :base(shippingOptionId)
        {}

        public override string ToString()
        {
            return Name;
        }
    }
}
