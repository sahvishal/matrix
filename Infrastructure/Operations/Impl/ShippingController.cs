using System.Transactions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Repositories.Shipping;

namespace Falcon.App.Infrastructure.Operations.Impl
{
    public class ShippingController : IShippingController
    {
        private readonly IAddressService _addressService;
        private readonly IShippingDetailRepository _shippingDetailRepository;

        public ShippingController()
            : this(new ShippingDetailRepository(), new AddressService())
        { }

        public ShippingController(IShippingDetailRepository shippingDetailRepository, IAddressService addressService)
        {
            _shippingDetailRepository = shippingDetailRepository;
            _addressService = addressService;
        }

        public ShippingDetail OrderShipping(ShippingDetail shippingDetail)
        {
            using (var transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                if (shippingDetail.ShippingAddress != null && shippingDetail.ShippingAddress.Id >=0
                ? _addressService.SaveAfterSanitizing(shippingDetail.ShippingAddress).Id > 0
                : true)
                {
                    shippingDetail = _shippingDetailRepository.Save(shippingDetail);
                }
                transaction.Complete();
                return shippingDetail;
            }
        }

    }
}
