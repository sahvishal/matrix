using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.CallCenter.Impl
{
    [DefaultImplementation]
    public class CallSkippedReportService : ICallSkippedReportService
    {
        private readonly ICustomerCallQueueCallAttemptRepository _customerCallQueueCallAttemptRepository;
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICallSkippedReportFactory _callSkippedReportFactory;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;

        public CallSkippedReportService(ICustomerCallQueueCallAttemptRepository customerCallQueueCallAttemptRepository, ICallQueueRepository callQueueRepository,
            ICorporateAccountRepository corporateAccountRepository, ICallSkippedReportFactory callSkippedReportFactory, IOrganizationRoleUserRepository organizationRoleUserRepository)
        {
            _customerCallQueueCallAttemptRepository = customerCallQueueCallAttemptRepository;
            _callQueueRepository = callQueueRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _callSkippedReportFactory = callSkippedReportFactory;
            _organizationRoleUserRepository = organizationRoleUserRepository;
        }

        public ListModelBase<CallSkippedReportViewModel, CallSkippedReportFilter> GetCallSkippedReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var callSkippedFilter = filter as CallSkippedReportFilter ?? new CallSkippedReportFilter();
            var model = (IReadOnlyCollection<CallSkippedReportEditModel>)_customerCallQueueCallAttemptRepository.GetForCallSkippedReport(pageNumber, pageSize, callSkippedFilter, out totalRecords);

            List<long> orgRoleUserIds = model.Select(x => x.CustomerId).ToList();
            orgRoleUserIds.AddRange(model.Select(x => x.AgentId));

            var agentAndCustomerDetailsIdNamePair = (IReadOnlyCollection<OrderedPair<long, string>>)_organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds.ToArray());
            var callQueues = (IReadOnlyCollection<CallQueue>)_callQueueRepository.GetAll(isManual: false, isHealthPlan: true);
            var accounts = (IReadOnlyCollection<CorporateAccount>)_corporateAccountRepository.GetAllHealthPlan();

            var collection = _callSkippedReportFactory.Create(agentAndCustomerDetailsIdNamePair, callQueues, accounts, model);

            return new CallSkippedReportListModel
            {
                Collection = collection,
                Filter = callSkippedFilter
            };

        }
    }
}
