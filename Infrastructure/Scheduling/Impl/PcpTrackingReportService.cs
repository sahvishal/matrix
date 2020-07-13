using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class PcpTrackingReportService : IPcpTrackingReportService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IPcpTrackingReportFactory _pcpTrackingReportFactory;

        public PcpTrackingReportService(ICustomerRepository customerRepository, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, ICorporateAccountRepository corporateAccountRepository, IOrganizationRepository organizationRepository, IPcpTrackingReportFactory pcpTrackingReportFactory)
        {
            _customerRepository = customerRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _organizationRepository = organizationRepository;
            _pcpTrackingReportFactory = pcpTrackingReportFactory;
        }

        public ListModelBase<PcpTrackingReportViewModel, PcpTrackingReportFilter> GetPcpTrackingReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var pcpTrackingFilter = filter as PcpTrackingReportFilter ?? new PcpTrackingReportFilter();

            var collection = new List<PcpTrackingReportViewModel>();

            var customers = _customerRepository.GetForPcpTrackingReport(pageNumber, pageSize, pcpTrackingFilter, out totalRecords);

            if (customers.IsNullOrEmpty())
            {
                return new PcpTrackingReportListModel
                {
                    Collection = collection,
                    Filter = pcpTrackingFilter
                };
            }

            var customerIds = customers.Select(x => x.CustomerId).ToArray();
            var primaryCarePhysicians = _primaryCarePhysicianRepository.GetAllByCustomerIds(customerIds);

            var tags = customers.Select(x => x.Tag).ToArray();
            var healthPlans = _corporateAccountRepository.GetByTags(tags);
            var organizations = _organizationRepository.GetOrganizations(healthPlans.Select(hp => hp.Id).ToArray());

            collection = _pcpTrackingReportFactory.Create(customers, primaryCarePhysicians, healthPlans, organizations).ToList();

            return new PcpTrackingReportListModel
            {
                Collection = collection,
                Filter = pcpTrackingFilter
            };
        }
    }
}
