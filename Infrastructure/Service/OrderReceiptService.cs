using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Infrastructure.Factories.Screening;
using Falcon.App.Infrastructure.Medical.Interfaces;

namespace Falcon.App.Infrastructure.Service
{
    public class OrderReceiptService : IOrderReceiptService
    {
        private readonly ITestViewDataFactory _testViewDataFactory;
        private readonly IEventCustomerPackageTestDetailService _eventCustomerPackageTestDetailService;

        public OrderReceiptService()
            : this(new TestViewDataFactory(), new EventCustomerPackageTestDetailService())
        { }

        public OrderReceiptService(ITestViewDataFactory testViewDataFactory, IEventCustomerPackageTestDetailService eventCustomerPackageTestDetailService)
        {

            _testViewDataFactory = testViewDataFactory;
            _eventCustomerPackageTestDetailService = eventCustomerPackageTestDetailService;
        }


        public List<TestViewData> GetOrderTestViewData(long eventId, long customerId)
        {
            var eventCustomerPackageTestDetailViewData =
                _eventCustomerPackageTestDetailService.GetEventPackageDetails(eventId, customerId);
            
            var selectedTest = new List<Test>();
            
            if (eventCustomerPackageTestDetailViewData.Package != null)
            {
                selectedTest.AddRange(eventCustomerPackageTestDetailViewData.Package.Tests);
            }
            if (eventCustomerPackageTestDetailViewData.Tests != null)
            {
                selectedTest.AddRange(eventCustomerPackageTestDetailViewData.Tests);
            }

            var selectedTestIds = selectedTest.Select(t => t.Id).ToList();
            var testViewData = _testViewDataFactory.Create(eventCustomerPackageTestDetailViewData.Package, selectedTestIds,
                selectedTest);
            return testViewData;
        }

    }
}