using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IElectronicProductRepository : IUniqueItemRepository<ElectronicProduct>
    {
        List<ElectronicProduct> GetAllProducts();
        ElectronicProduct GetElectronicProductForOrder(long eventId, long customerId);
        IEnumerable<ElectronicProduct> GetElectronicProductForOrder(long orderId);
        string GetElectronicProductNameForOrder(long orderItemId);
        IEnumerable<OrderedPair<long, string>> GetProductNameForOrderItems(long[] orderItemIds);
        IEnumerable<OrderedPair<long, long>> GetProductIdsForOrderItems(long[] orderItemIds);
        bool IsProductPurchased(long eventId, long customerId, Core.Enum.Product productType);
        IEnumerable<long> GetExcludedProductIdsForEventId(long eventId);
        List<ElectronicProduct> GetAllProductsForEvent(long eventId);
        IEnumerable<OrderedPair<long, string>> GetProductNamesForOrder(IEnumerable<long> orderIds);
        ElectronicProduct GetElectronicProductByOrderId(long orderId);
    }
}
