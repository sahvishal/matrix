using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Domain.ViewData;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Scheduling.Repositories;

namespace Falcon.App.Infrastructure.Service
{
    public class EventCustomerPackageTestDetailService : IEventCustomerPackageTestDetailService
    {
        private readonly IElectronicProductRepository _electronicProductRepository = new ElectronicProductRepository();
        private readonly IOrderRepository _orderRepository = new OrderRepository();
        private readonly IEventTestRepository _eventTestRepository = new EventTestRepository();
        private readonly IEventPackageRepository _eventPackageRepository = new EventPackageRepository();
        
        public EventCustomerPackageTestDetailViewData GetEventPackageDetails(long eventId, long customerId)
        {
            var orderId = _orderRepository.GetOrderIdByEventIdCustomerId(eventId, customerId);
            var eventTests = _eventTestRepository.GetTestsForOrder(orderId);
            var eventPackage = _eventPackageRepository.GetPackageForOrder(orderId);

            var eventCustomerPackageTestDetailViewData = new EventCustomerPackageTestDetailViewData
                                                             {
                                                                 Tests = eventTests != null ? eventTests.Select(et => et.Test).ToList() : null,
                                                                 Package = eventPackage != null ? eventPackage.Package : null,
                                                                 ElectronicProduct = _electronicProductRepository.GetElectronicProductByOrderId(orderId)
                                                             };

            return eventCustomerPackageTestDetailViewData;
            
        }

        public List<Test> GetTestsPurchasedByCustomer(long eventId, long customerId)
        {
            var orderId = _orderRepository.GetOrderIdByEventIdCustomerId(eventId, customerId);
            if (orderId < 1) return null;
            var eventTests = _eventTestRepository.GetTestsForOrder(orderId);
            var eventPackage = _eventPackageRepository.GetPackageForOrder(orderId);

            var testsInPackages = eventTests != null ? eventTests.Select(et => et.Test).ToList() : new List<Test>();

            if(eventPackage != null)
                testsInPackages.AddRange(eventPackage.Package.Tests);

            return testsInPackages;
        }

        public string GetOrderPurchasedString(long eventId, long customerId)
        {
            var orderPurchased = GetEventPackageDetails(eventId, customerId);

            string orderPurchasedString = "";

            if (orderPurchased.Package != null)
                orderPurchasedString = orderPurchased.Package.Name;

            if (orderPurchased.Tests != null && orderPurchased.Tests.Count > 0)
            {
                string testsPurchased = "";
                orderPurchased.Tests.ForEach(test => testsPurchased += test.Name + " + ");

                testsPurchased = testsPurchased.Remove(testsPurchased.LastIndexOf(" + "));

                if (orderPurchasedString.Trim().Length > 0)
                    orderPurchasedString += " + " + testsPurchased;
                else
                    orderPurchasedString = testsPurchased;
            }

            return orderPurchasedString;
        }

        public List<Test> GetAlaCarteTestsPurchasedByCustomer(long eventId, long customerId)
        {
            var orderId = _orderRepository.GetOrderIdByEventIdCustomerId(eventId, customerId);
            if (orderId < 1) return null;
            var eventTests = _eventTestRepository.GetTestsForOrder(orderId);

            var testsInPackages = eventTests != null ? eventTests.Select(et => et.Test).ToList() : new List<Test>();

            return testsInPackages;
        }

        public EventCustomerPackageTestDetailViewData GetEventPackageDetails(long eventCustomerId)
        {
            var orderId = _orderRepository.GetOrderIdByEventCustomerId(eventCustomerId);
            var eventTests = _eventTestRepository.GetTestsForOrder(orderId);
            var eventPackage = _eventPackageRepository.GetPackageForOrder(orderId);

            var eventCustomerPackageTestDetailViewData = new EventCustomerPackageTestDetailViewData
            {
                Tests = eventTests != null ? eventTests.Select(et => et.Test).ToList() : null,
                Package = eventPackage != null ? eventPackage.Package : null,
                ElectronicProduct = _electronicProductRepository.GetElectronicProductByOrderId(orderId)
            };

            return eventCustomerPackageTestDetailViewData;
        }

        public List<Test> GetTestsPurchasedByEventCustomerId(long eventcustomerId)
        {
            var orderId = _orderRepository.GetOrderIdByEventCustomerId(eventcustomerId);

            if (orderId < 1) return null;
            var eventTests = _eventTestRepository.GetTestsForOrder(orderId);
            var eventPackage = _eventPackageRepository.GetPackageForOrder(orderId);

            var testsInPackages = eventTests != null ? eventTests.Select(et => et.Test).ToList() : new List<Test>();

            if (eventPackage != null)
                testsInPackages.AddRange(eventPackage.Package.Tests);

            return testsInPackages;
        }

        public List<Test> GetAlaCarteTestsPurchasedByCustomer(long orderId)
        {
           if (orderId < 1) return null;
            var eventTests = _eventTestRepository.GetTestsForOrder(orderId);

            var testsInPackages = eventTests != null ? eventTests.Select(et => et.Test).ToList() : new List<Test>();

            return testsInPackages;
        }

        public List<Test> GetTestsPurchasedByOrderId(long orderId)
        {
            if (orderId < 1) return null;
            var eventTests = _eventTestRepository.GetTestsForOrder(orderId);
            var eventPackage = _eventPackageRepository.GetPackageForOrder(orderId);

            var testsInPackages = eventTests != null ? eventTests.Select(et => et.Test).ToList() : new List<Test>();

            if (eventPackage != null)
                testsInPackages.AddRange(eventPackage.Package.Tests);

            return testsInPackages;
        }
    }
}
