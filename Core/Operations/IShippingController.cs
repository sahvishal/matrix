using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IShippingController
    {
        ShippingDetail OrderShipping( ShippingDetail shippingDetail);
    }
}
