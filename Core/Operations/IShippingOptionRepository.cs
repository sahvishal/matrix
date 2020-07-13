using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IShippingOptionRepository : IUniqueItemRepository<ShippingOption>
    {
        List<ShippingOption> GetAllShippingOptions();
        List<ShippingOption> GetShippingOptionsByShippingDetailIds(IEnumerable<long> shippingDetailIds);
        ShippingOption GetShippingOptionByProductId(long productId, bool isForPcp = false);
        List<ShippingOption> GetAllShippingOptionsForBuyingProcess();
        ShippingOption GetOnlineShippingOption();
        List<ShippingOption> GetAllShippingOptionsForTracking();
        List<ShippingOption> GetAllShippingOptionForCorporate(long accountId);
        List<ShippingOption> GetAllShippingOptionForHospitalPartner(long hospitalPartnerId);
    }
}
