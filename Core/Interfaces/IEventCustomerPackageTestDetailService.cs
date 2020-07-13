using System.Collections.Generic;
using Falcon.App.Core.Domain.ViewData;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Interfaces
{
    public interface IEventCustomerPackageTestDetailService
    {
        List<Test> GetTestsPurchasedByCustomer(long eventId, long customerId);
        EventCustomerPackageTestDetailViewData GetEventPackageDetails(long eventId, long customerId);
        string GetOrderPurchasedString(long eventId, long customerId);
        List<Test> GetAlaCarteTestsPurchasedByCustomer(long eventId, long customerId);
        EventCustomerPackageTestDetailViewData GetEventPackageDetails(long eventCustomerId);
        List<Test> GetTestsPurchasedByEventCustomerId(long eventcustomerId);
        List<Test> GetAlaCarteTestsPurchasedByCustomer(long orderId);
        List<Test> GetTestsPurchasedByOrderId(long orderId);
    }
}
