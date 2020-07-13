using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Operations.Impl
{
    [DefaultImplementation]
    public class PatientWorksheetService : IPatientWorksheetService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IElectronicProductRepository _electronicProductRepository;
        private readonly ILabRepository _labRepository;
        private readonly IIcdCodesRepository _icdCodesRepository;
        private readonly ICustomerIcdCodesRepository _customerIcdCodesRepository;
        private readonly IEventCustomerPreApprovedTestRepository _preApprovedTestRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ITestRepository _testRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ICorporateCustomerCustomTagRepository _corporateCustomerCustomTagRepository;

        public PatientWorksheetService(ICustomerRepository customerRepository, IOrderRepository orderRepository, IEventPackageRepository eventPackageRepository,
            IEventTestRepository eventTestRepository, IElectronicProductRepository electronicProductRepository, ILabRepository labRepository,
            IIcdCodesRepository icdCodesRepository, ICustomerIcdCodesRepository customerIcdCodesRepository, IEventCustomerPreApprovedTestRepository preApprovedTestRepository,
            IEventCustomerRepository eventCustomerRepository, ITestRepository testRepository, IEventRepository eventRepository, ICorporateCustomerCustomTagRepository corporateCustomerCustomTagRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _electronicProductRepository = electronicProductRepository;
            _labRepository = labRepository;
            _icdCodesRepository = icdCodesRepository;
            _customerIcdCodesRepository = customerIcdCodesRepository;
            _preApprovedTestRepository = preApprovedTestRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _testRepository = testRepository;
            _eventRepository = eventRepository;
            _corporateCustomerCustomTagRepository = corporateCustomerCustomTagRepository;
        }

        public PatientWorksheet GetPatientWorksheetModel(long customerId, long eventId)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            var theEvent = _eventRepository.GetById(eventId);
            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
            return GetPatientWorksheetModel(customer, theEvent, eventCustomer);
        }

        public PatientWorksheet GetPatientWorksheetModel(Customer customer, Event theEvent,EventCustomer eventCustomer)
        {
            var customerId = customer.Id;
            var eventId = theEvent.Id;
            
            var order = _orderRepository.GetOrderByEventCustomerId(eventCustomer.Id);
            var eventPackage = _eventPackageRepository.GetPackageForOrder(order.Id);
            var eventTest = _eventTestRepository.GetTestsForOrder(order.Id);
            var products = _electronicProductRepository.GetAllProductsForEvent(eventId);
            var purchasedProduct = _electronicProductRepository.GetElectronicProductByOrderId(order.Id);
            var customerIcdCodes = _customerIcdCodesRepository.GetIcdByCustomerId(customerId);
            var customerTags = _corporateCustomerCustomTagRepository.GetByCustomerId(customerId);
            var preApporvedTestNames = _preApprovedTestRepository.GetPreApprovedTestNameByEventCustomerId(eventCustomer.Id);
            var testForTechnician = _eventTestRepository.GetTestsForEventByRole(eventId, (long)Roles.Technician);
            string[] customerRecentTags = null;

            var isCorporateEvent = theEvent.EventType == EventType.Corporate;

            if (customerTags != null && customerTags.Any() && isCorporateEvent)
            {
                customerTags = customerTags.OrderByDescending(x => x.DataRecorderMetaData.DateCreated).Take(4);
                customerRecentTags = customerTags.Select(x => x.Tag).ToArray();
            }

            var icdCodes = new List<string>();

            if (!customerIcdCodes.IsNullOrEmpty())
            {
                icdCodes = _icdCodesRepository.GetIcdByIds(customerIcdCodes.Select(x => x.IcdCodeId)).Select(x => x.CodeName.ToUpper()).ToList();
            }

            var labName = string.Empty;

            if (customer.LabId.HasValue)
            {
                var lab = _labRepository.GetById(customer.LabId.Value);
                labName = lab.Name;
            }

            return new PatientWorksheet
            {
                Name = customer.Name,
                CustomerId = customer.CustomerId,
                Dob = customer.DateOfBirth,
                Height = customer.Height,
                Weight = customer.Weight,
                Gender = customer.Gender,
                Package = eventPackage,
                Tests = eventTest,
                Lab = labName,
                AlaCarteTest = testForTechnician,
                AllProducts = products,
                ProductId = purchasedProduct != null ? purchasedProduct.Id : 0,
                IcdCodes = icdCodes,
                PreApporvedTestNames = preApporvedTestNames,
                EventDate = theEvent.EventDate,
                CustomTags = customerRecentTags,
                IsCorporateEvent = theEvent.EventType == EventType.Corporate
            };
        }


    }
}
