using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class PcpResultMailedReportService : IPcpResultMailedReportService
    {
        private readonly IShippingDetailRepository _shippingDetailRepository;
        private readonly IUniqueItemRepository<EventCustomer> _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPcpResultMailedReportListModelFactory _pcpResultMailedReportListModelFactory;
        private readonly IShippingOptionRepository _shippingOptionRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;

        public PcpResultMailedReportService(IShippingDetailRepository shippingDetailRepository, IUniqueItemRepository<EventCustomer> eventCustomerRepository,
            ICustomerRepository customerRepository, IPcpResultMailedReportListModelFactory pcpResultMailedReportListModelFactory, 
            IShippingOptionRepository shippingOptionRepository, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository)
        {
            _shippingDetailRepository = shippingDetailRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _customerRepository = customerRepository;
            _pcpResultMailedReportListModelFactory = pcpResultMailedReportListModelFactory;
            _shippingOptionRepository = shippingOptionRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
        }

        public ListModelBase<PcpResultMailedReportModel, PcpResultMailedReportModelFilter> GetPcpResultMailedResultReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var shippingOption = _shippingOptionRepository.GetShippingOptionByProductId((long)Product.UltraSoundImages, true);

            var shippingDetails = _shippingDetailRepository.GetEventCustomerShippingDetailForFilter(pageNumber, pageSize, filter as PcpResultMailedReportModelFilter, new[] { shippingOption.Id }, out totalRecords);
            if (shippingDetails.IsNullOrEmpty())
                return null;

            var shippingDetailIdEventCustomerIdPairs = _shippingDetailRepository.GetShippingDetailIdEventCustomerIdPairs(shippingDetails.Select(sd => sd.Id).ToArray());

            var eventCustomers = _eventCustomerRepository.GetByIds(shippingDetailIdEventCustomerIdPairs.Select(sdec => sdec.SecondValue).ToArray());

            var customerIds = eventCustomers.Select(ec => ec.CustomerId).Distinct().ToArray();

            var customers = _customerRepository.GetCustomers(customerIds);

            var primaryCarePhysicians = _primaryCarePhysicianRepository.GetByCustomerIds(customerIds);

            return _pcpResultMailedReportListModelFactory.Create(shippingDetails, shippingDetailIdEventCustomerIdPairs, eventCustomers, customers, primaryCarePhysicians);
        }
    }
}
