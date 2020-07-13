using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class TestNotPerformedService : ITestNotPerformedService
    {
        private readonly ITestNotPerformedRepository _testNotPerformedRepository;
        private readonly ITestNotPerformedFactory _testNotPerformedFactory;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ITestRepository _testRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventCustomerPreApprovedTestRepository _preApprovedTestRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly ICustomerEventTestStateRepository _customerEventTestStateRepository;
        private readonly IEventStaffAssignmentRepository _eventStaffAssignmentRepository;
        private readonly IEventRoleRepository _eventRoleRepository;
        private readonly IHostRepository _hostRepository;
        private readonly IUniqueItemRepository<Pod> _podRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly string _awvNpEventStaffRole;

        public TestNotPerformedService(ITestNotPerformedRepository testNotPerformedRepository, ITestNotPerformedFactory testNotPerformedFactory, IEventCustomerResultRepository eventCustomerResultRepository,
            IEventRepository eventRepository, ITestRepository testRepository, ICustomerRepository customerRepository, IUniqueItemRepository<Pod> podRepository, IEventCustomerPreApprovedTestRepository preApprovedTestRepository,
            ICorporateAccountRepository corporateAccountRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, ICustomerEventTestStateRepository customerEventTestStateRepository,
            IEventStaffAssignmentRepository eventStaffAssignmentRepository, IEventRoleRepository eventRoleRepository, ISettings settings, IHostRepository hostRepository, IEventCustomerRepository eventCustomerRepository)
        {
            _testNotPerformedRepository = testNotPerformedRepository;
            _testNotPerformedFactory = testNotPerformedFactory;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _eventRepository = eventRepository;
            _testRepository = testRepository;
            _customerRepository = customerRepository;

            _preApprovedTestRepository = preApprovedTestRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _customerEventTestStateRepository = customerEventTestStateRepository;
            _eventStaffAssignmentRepository = eventStaffAssignmentRepository;
            _eventRoleRepository = eventRoleRepository;
            _hostRepository = hostRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _podRepository = podRepository;
            _awvNpEventStaffRole = settings.EventStaffRole;
        }

        public ListModelBase<TestNotPerformedViewModel, TestNotPerformedListModelFilter> GetTestNotPerformed(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var testNotPerformFilter = filter as TestNotPerformedListModelFilter;
            var testNotPerformed = _testNotPerformedRepository.GetTestNotPerformedForHealthPlan(testNotPerformFilter, pageNumber, pageSize, out totalRecords);

            if (testNotPerformed == null || !testNotPerformed.Any())
                return null;

            var customerEventScreeningTestIds = testNotPerformed.Select(x => x.CustomerEventScreeningTestId).ToArray();

            var customerEventScreeningTests = _eventCustomerResultRepository.GetCustomerEventScreeningTestsByIds(customerEventScreeningTestIds);

            var customerEventTestStates = _customerEventTestStateRepository.GetCustomerEventTestState(customerEventScreeningTestIds);

            var orgRoleUserIds = customerEventTestStates.Where(cets => cets.ConductedByOrgRoleUserId.HasValue).Select(cets => cets.ConductedByOrgRoleUserId.Value).Distinct().ToArray();
            var idNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds);

            var eventCustomerResults = _eventCustomerResultRepository.GetByIds(customerEventScreeningTests.Select(ces => ces.EventCustomerResultId).Distinct().ToArray());
            var eventIds = eventCustomerResults.Select(ecr => ecr.EventId).Distinct().ToArray();

            var events = _eventRepository.GetEventswithPodbyIds(eventIds);
            var hosts = _hostRepository.GetEventHosts(events.Select(x => x.Id));
            IEnumerable<OrderedPair<long, long>> staffOrgRoleUserEventsPair = null;
            IEnumerable<OrderedPair<long, string>> staffNamePair = null;

            var npRoles = _eventRoleRepository.GetByName(_awvNpEventStaffRole);

            if (npRoles != null && npRoles.Any())
            {
                var eventStaffs = _eventStaffAssignmentRepository.GetForEvents(eventIds);
                var npRoleIds = npRoles.Select(x => x.Id);

                if (eventStaffs != null && eventStaffs.Any())
                    eventStaffs = eventStaffs.Where(x => npRoleIds.Contains(x.StaffEventRoleId)).ToArray();

                staffOrgRoleUserEventsPair = eventStaffs.Select(p => new OrderedPair<long, long>(p.ScheduledStaffOrgRoleUserId, p.EventId)).ToArray();

                staffNamePair = _organizationRoleUserRepository.GetNameIdPairofUsers(staffOrgRoleUserEventsPair.Select(x => x.FirstValue).ToArray());
            }

            var customers = _customerRepository.GetCustomers(eventCustomerResults.Select(ecr => ecr.CustomerId).Distinct().ToArray());

            //var tags = customers.Select(x => x.Tag).Distinct().ToArray();

            //var corporateAccount = _corporateAccountRepository.GetByTags(tags);

            var accountIds = events.Where(x => x.AccountId.HasValue && x.AccountId > 0).Select(x => x.AccountId.Value).Distinct().ToArray();

            var corporateAccount = _corporateAccountRepository.GetByIds(accountIds);

            if (corporateAccount != null && corporateAccount.Any())
                corporateAccount = corporateAccount.Where(x => x.IsHealthPlan);

            var tests = ((IUniqueItemRepository<Test>)_testRepository).GetByIds(customerEventScreeningTests.Select(ces => ces.TestId).Distinct().ToArray());

            var customersPreApprovedTest = _preApprovedTestRepository.GetPreApprovedTestIdsByCustomerIds(eventCustomerResults.Select(x => x.Id));
            var pods = _podRepository.GetByIds(events.SelectMany(e => e.PodIds).Distinct());

            var eventCustomers = _eventCustomerRepository.GetByIds(customerEventScreeningTests.Select(ces => ces.EventCustomerResultId).Distinct().ToArray());

            return _testNotPerformedFactory.Create(testNotPerformed, customerEventScreeningTests, eventCustomerResults, events, customers, tests,
                            customersPreApprovedTest, corporateAccount, pods, customerEventTestStates, idNamePairs, staffOrgRoleUserEventsPair, staffNamePair, hosts, eventCustomers);
        }

    }
}