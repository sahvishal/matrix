using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class MemberResultMailedReportService : IMemberResultMailedReportService
    {
        private readonly IShippingDetailRepository _shippingDetailRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IMemberResultMailedReportFactory _memberResultMailedReportFactory;
        private readonly IAddressRepository _addressRepository;

        public MemberResultMailedReportService(IShippingDetailRepository shippingDetailRepository, ICustomerRepository customerRepository, IEventCustomerRepository eventCustomerRepository,
            IMemberResultMailedReportFactory memberResultMailedReportFactory, IAddressRepository addressRepository)
        {
            _shippingDetailRepository = shippingDetailRepository;
            _customerRepository = customerRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _memberResultMailedReportFactory = memberResultMailedReportFactory;
            _addressRepository = addressRepository;
        }

        public ListModelBase<MemberResultMailedReportViewModel, MemberResultMailedReportFilter> GetMemberResultMailedReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var memberFilter = filter as MemberResultMailedReportFilter;

            var pcpResultMailedFilter = new PcpResultMailedReportModelFilter
            {
                CustomTags = memberFilter.CustomTags,
                ExcludeCustomerWithCustomTag = memberFilter.ExcludeCustomerWithCustomTag,
                DateTo = memberFilter.DateTo,
                DateFrom = memberFilter.DateFrom,
                HealthPlanId = memberFilter.HealthPlanId,
                Tag = memberFilter.Tag
            };
            var shippingDetails = _shippingDetailRepository.GetEventCustomerShippingDetailForFilter(pageNumber, pageSize, pcpResultMailedFilter, memberFilter.ShippingOptions, out totalRecords);
            if (shippingDetails.IsNullOrEmpty())
                return null;

            var shippingDetailIdEventCustomerIdPairs = _shippingDetailRepository.GetShippingDetailIdEventCustomerIdPairs(shippingDetails.Select(sd => sd.Id).ToArray());
            var addresses = _addressRepository.GetAddresses(shippingDetails.Select(sd => sd.ShippingAddress.Id).ToList());
            var eventCustomers = _eventCustomerRepository.GetByIds(shippingDetailIdEventCustomerIdPairs.Select(sdec => sdec.SecondValue).ToArray());

            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());

            return _memberResultMailedReportFactory.Create(shippingDetails, shippingDetailIdEventCustomerIdPairs, eventCustomers, customers, addresses);
        }

    }
}