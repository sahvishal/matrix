using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class PotentialPcpChangeReportService : IPotentialPcpChangeReportService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly IPotentialPcpChangeReportFactory _potentialPcpChangeReportFactory;
        private readonly ILogger _logger;

        private const string EmptyString = "";

        public PotentialPcpChangeReportService(ICustomerRepository customerRepository, ILogManager logManager, IEventCustomerRepository eventCustomerRepository,
            IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, IPotentialPcpChangeReportFactory potentialPcpChangeReportFactory)
        {
            _customerRepository = customerRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _potentialPcpChangeReportFactory = potentialPcpChangeReportFactory;
            _logger = logManager.GetLogger("PcpChangeReport");
        }

        public ListModelBase<PotentialPcpChangeReportViewModel, PotentialPcpChangeReportModelFilter> GetPotentialPcpChangeData(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventCustomers = _eventCustomerRepository.GetEventCustomerForPcpChangeReport(pageNumber, pageSize, filter as PotentialPcpChangeReportModelFilter, out totalRecords);
            return GetNonTargetableReportModel(eventCustomers);
        }

        private PotentialPcpChangeReportListModel GetNonTargetableReportModel(IEnumerable<EventCustomer> eventCustomers)
        {
            if (eventCustomers.IsNullOrEmpty())
            {
                _logger.Info("eventCustomers provided is null or empty");
                return null;
            }

            var listModel = new PotentialPcpChangeReportListModel();
            var collection = new List<PotentialPcpChangeReportViewModel>();

            var customerIds = eventCustomers.Select(x => x.CustomerId).ToArray();
            var customers = _customerRepository.GetCustomers(customerIds);
            var customerPcpCollection = (IReadOnlyCollection<PrimaryCarePhysician>)_primaryCarePhysicianRepository.GetForPcpChangeReport(customerIds);

            foreach (var eventCustomer in eventCustomers)
            {
                var currentCustomerId = eventCustomer.CustomerId;
                var customer = customers.FirstOrDefault(x => x.CustomerId == currentCustomerId);
                var customerPrimaryCarePhysicians = customerPcpCollection.Where(x => x.CustomerId == currentCustomerId);

                PrimaryCarePhysician newPcpDetail = null;
                PrimaryCarePhysician oldPcpDetail = null;

                if (!customerPrimaryCarePhysicians.IsNullOrEmpty())
                {
                    newPcpDetail = customerPrimaryCarePhysicians.SingleOrDefault(x => x.IsActive);

                    if (newPcpDetail != null)
                    {
                        var orderCpcp = (from cpcp in customerPrimaryCarePhysicians
                                         where cpcp.Id != newPcpDetail.Id
                                         orderby cpcp.DataRecorderMetaData.DateCreated
                                         select cpcp).ToArray();
                        if (!orderCpcp.IsNullOrEmpty())
                        {
                            oldPcpDetail = orderCpcp.LastOrDefault(x => x.Source.HasValue && x.Source.Value == (long)CustomerPcpUpdateSource.CorporateUpload);
                            if (oldPcpDetail == null)
                            {
                                oldPcpDetail = orderCpcp.FirstOrDefault();
                            }
                        }
                    }

                }
                var viewModel = _potentialPcpChangeReportFactory.CreateModel(oldPcpDetail, newPcpDetail, customer);
                collection.Add(viewModel);
            }

            listModel.Collection = collection;
            return listModel;
        }
    }
}
