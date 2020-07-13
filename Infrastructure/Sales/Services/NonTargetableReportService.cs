using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Sales.Services
{
    [DefaultImplementation]
    public class NonTargetableReportService : INonTargetableReportService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ILogger _logger;

        private const string EmptyString = "";

        public NonTargetableReportService(ICustomerRepository customerRepository, ILogManager logManager, IEventCustomerRepository eventCustomerRepository)
        {
            _customerRepository = customerRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _logger = logManager.GetLogger("NonTargetableCustomerReport");
        }

        public ListModelBase<NonTargetableReportModel, NonTargetableReportModelFilter> GetCustomersForNonTargetableService(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var customerIds = _eventCustomerRepository.GetCustomerIdsForNonTargetableReport(pageNumber, pageSize, filter as NonTargetableReportModelFilter, out totalRecords);
            return GetNonTargetableReportModel(customerIds);
        }

        private NonTargetableReportListModel GetNonTargetableReportModel(IEnumerable<long> customerIds)
        {
            if (customerIds.IsNullOrEmpty())
            {
                _logger.Info("No CustomerIds present to get customers for NonTargetableReport");
                return null;
            }
            var listModel = new NonTargetableReportListModel();

            var customers = _customerRepository.GetCustomers(customerIds.ToArray());
            var collection = customers.Select(customer => new NonTargetableReportModel
            {
                MemberId = string.IsNullOrEmpty(customer.InsuranceId) ? EmptyString : customer.InsuranceId,
                Gmpi = string.IsNullOrEmpty(customer.AdditionalField3) ? EmptyString : customer.AdditionalField3,
                FirstName = customer.Name.FirstName,
                LastName = customer.Name.LastName,
                Phone = customer.HomePhoneNumber.ToString(),
                AddressLine1 = customer.Address.StreetAddressLine1,
                AddressLine2 = customer.Address.StreetAddressLine2,
                City = customer.Address.City,
                State = customer.Address.State,
                Zip = customer.Address.ZipCode.ToString(),
                Market = string.IsNullOrEmpty(customer.Market) ? EmptyString : customer.Market,
                HfComment = EmptyString
            }).ToArray();

            listModel.Collection = collection;
            return listModel;
        }
    }
}
