using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.Medical.Interfaces;

namespace Falcon.App.Core.Medical.Impl
{
    public class PhysicianEvaluationService : IPhysicianEvaluationService
    {
        private readonly IPhysicianRepository _physicianRepository;
        private readonly IPhysicianEvaluationRepository _physicianEvaluationRepository;
        private readonly IUniqueItemRepository<Test> _uniqueItemTestRepository;
        private readonly IStateRepository _stateRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IPhysicianReviewSummaryListFactory _physicianReviewSummaryListFactory;
        private readonly IUniqueItemRepository<EventCustomer> _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IPhysicianReviewListFactory _physicianReviewListFactory;
        private readonly IPhysicianQueueListFactory _physicianQueueListFactory;
        private readonly IPhysicianEventQueueListFactory _physicianEventQueueListFactory;
        private readonly IPodRepository _podRepository;
        private readonly IPhysicianTestReviewListFactory _physicianTestReviewListFactory;
        private readonly IPriorityInQueueRepository _priorityInQueueRepository;

        public PhysicianEvaluationService(IPhysicianRepository physicianRepository, IPhysicianEvaluationRepository physicianEvaluationRepository, IUniqueItemRepository<Test> uniqueItemTestRepository, IStateRepository stateRepository,
            IMediaRepository mediaRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, IPhysicianReviewSummaryListFactory physicianReviewSummaryListFactory, IUniqueItemRepository<EventCustomer> eventCustomerRepository,
            ICustomerRepository customerRepository, IOrderRepository orderRepository, IEventTestRepository eventTestRepository, IEventCustomerResultRepository eventCustomerResultRepository, IPhysicianQueueListFactory physicianQueueListFactory,
            IEventRepository eventRepository, IPhysicianReviewListFactory physicianReviewListFactroy, IPodRepository podRepository, IEventPackageRepository eventPackageRepository, IPhysicianEventQueueListFactory physicianEventQueueListFactory,
            IPhysicianTestReviewListFactory physicianTestReviewListFactory, IPriorityInQueueRepository priorityInQueueRepository
)
        {
            _physicianRepository = physicianRepository;
            _uniqueItemTestRepository = uniqueItemTestRepository;
            _stateRepository = stateRepository;
            _mediaRepository = mediaRepository;
            _physicianEvaluationRepository = physicianEvaluationRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _physicianReviewSummaryListFactory = physicianReviewSummaryListFactory;
            _eventCustomerRepository = eventCustomerRepository;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _eventTestRepository = eventTestRepository;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _eventRepository = eventRepository;
            _physicianReviewListFactory = physicianReviewListFactroy;
            _physicianQueueListFactory = physicianQueueListFactory;
            _podRepository = podRepository;
            _eventPackageRepository = eventPackageRepository;
            _physicianEventQueueListFactory = physicianEventQueueListFactory;
            _physicianTestReviewListFactory = physicianTestReviewListFactory;
            _priorityInQueueRepository = priorityInQueueRepository;
        }

        public PhysicianDashboardViewModel GetPhysicianStats(long physicianId)
        {
            var overReadEvaluationPair = _physicianRepository.GetEventCustomerIdForOverReadPhysicianEvaluation(physicianId);
            var evaluationPair = _physicianRepository.GetEventCustomerIdForPhysicianEvaluation(physicianId);

            var physician = _physicianRepository.GetPhysician(physicianId);
            var specializations = _physicianRepository.GetPhysicianSpecilizationIdNamePairs();
            var tests = _uniqueItemTestRepository.GetByIds(physician.PermittedTests);
            var physicianEvaluations = _physicianEvaluationRepository.GetPhysicianEvaluationbyPhysician(physicianId);
            var count = physicianEvaluations == null ? 0 : physicianEvaluations.Where(pe => pe.EvaluationEndTime != null).Count();

            IEnumerable<PhysicianLicesneViewModel> licenses = null;
            if (physician.AuthorizedStateLicenses != null && physician.AuthorizedStateLicenses.Count() > 0)
            {
                var states =
                    _stateRepository.GetStates(physician.AuthorizedStateLicenses.Select(p => p.StateId).ToArray());

                licenses = physician.AuthorizedStateLicenses.Select(asl => new PhysicianLicesneViewModel()
                                                                    {
                                                                        ExpiryDate = asl.Expirydate,
                                                                        LicenseNumber = asl.LicenseNumber,
                                                                        State = states.Where(s => asl.StateId == s.Id).First().Name,
                                                                        Id = asl.Id
                                                                    }).ToArray();
            }

            var mediaLocation = _mediaRepository.GetPhysicianSignatureMediaFileLocation();

            return new PhysicianDashboardViewModel
                       {
                           //TotalEvaluationsDone = count,
                           PhysicianId = physicianId,
                           Name = physician.NameAsString,
                           Specialization = physician.SpecializationId > 0 ? specializations.Where(sp => sp.FirstValue == physician.SpecializationId).Single().SecondValue : "",
                           PermittedTests = tests,
                           Licenses = licenses,
                           SignaturePath = physician.SignatureFile != null ? mediaLocation.Url + physician.SignatureFile.Path : "",
                           //TotalEvaluationsAvailable = evaluationPair != null ? evaluationPair.SecondValue : 0,
                           //TotalOverreadsAvailable = overReadEvaluationPair != null ? overReadEvaluationPair.SecondValue : 0
                           PhysicianEvaluationsQueue = new PhysicianEvaluationQueueSummary
                           {
                               ItemsDone = count, 
                               CriticalsInQueue = evaluationPair.CriticalsInQueue, 
                               PriorityInQueueCount = evaluationPair.PriorityInQueueCount,
                               ItemsAvailable = evaluationPair.ItemsAvailable, 
                               FirstItemInTheQueue = evaluationPair.FirstItemInTheQueue
                           },
                           PhysicianOverReadsQueue = new PhysicianEvaluationQueueSummary
                           {
                               CriticalsInQueue = overReadEvaluationPair.CriticalsInQueue,
                               PriorityInQueueCount = overReadEvaluationPair.PriorityInQueueCount,
                               FirstItemInTheQueue = overReadEvaluationPair.FirstItemInTheQueue, 
                               ItemsAvailable = overReadEvaluationPair.ItemsAvailable
                           }
                       };
        }

        public ListModelBase<PhysicianReviewSummaryViewModel, PhysicianReviewSummaryListModelFilter> GetPhysicianReviewSummary(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var physicianIds = _physicianEvaluationRepository.GetPhysicianIds(pageNumber, pageSize,
                                                                             filter as
                                                                             PhysicianReviewSummaryListModelFilter,
                                                                             out totalRecords);
            if (physicianIds.IsNullOrEmpty()) return null;

            var physicianIdNamePair = _organizationRoleUserRepository.GetNameIdPairofUsers(physicianIds.ToArray());

            var physicianIdReviewCountPair = new List<OrderedPair<long, int>>();
            var physicianIdReEvaluationCountPair = new List<OrderedPair<long, int>>();
            var physicianIdOverReadsCountPair = new List<OrderedPair<long, int>>();
            var physicianIdReOverReadsCountPair = new List<OrderedPair<long, int>>();
            var physicianIdAvailableEvalutionCountPair = new List<OrderedPair<long, int>>();
            var physicianIdAvaliableOverReadCountPair = new List<OrderedPair<long, int>>();
            var physicianIdPriorityEvalutionCountPair = new List<OrderedPair<long, int>>();
            var physicianIdPriorityOverReadCountPair = new List<OrderedPair<long, int>>();

            foreach (var physicianId in physicianIds)
            {
                physicianIdReviewCountPair.Add(new OrderedPair<long, int>(physicianId, _physicianRepository.GetReviewsCountByPhysicianId(physicianId, filter as PhysicianReviewSummaryListModelFilter, false)));

                physicianIdReEvaluationCountPair.Add(new OrderedPair<long, int>(physicianId, _physicianRepository.GetReviewsCountByPhysicianId(physicianId, filter as PhysicianReviewSummaryListModelFilter, true)));

                physicianIdOverReadsCountPair.Add(new OrderedPair<long, int>(physicianId, _physicianRepository.GetOverReadsCountByPhysicianId(physicianId, filter as PhysicianReviewSummaryListModelFilter, false)));

                physicianIdReOverReadsCountPair.Add(new OrderedPair<long, int>(physicianId, _physicianRepository.GetOverReadsCountByPhysicianId(physicianId, filter as PhysicianReviewSummaryListModelFilter, true)));

                physicianIdAvailableEvalutionCountPair.Add(new OrderedPair<long, int>(physicianId, _physicianRepository.GetAvailablePrimaryEvaluationCountByPhysicianId(physicianId)));

                physicianIdAvaliableOverReadCountPair.Add(new OrderedPair<long, int>(physicianId, _physicianRepository.GetAvailableOverReadEvaluationCountByPhysicianId(physicianId)));

                physicianIdPriorityEvalutionCountPair.Add(new OrderedPair<long, int>(physicianId, _physicianRepository.GetPriorityPrimaryEvaluationCountByPhysicianId(physicianId)));

                physicianIdPriorityOverReadCountPair.Add(new OrderedPair<long, int>(physicianId, _physicianRepository.GetPriorityOverReadEvaluationCountByPhysicianId(physicianId)));
            }

            var physicianIdAverageReviewTimePair =
                _physicianEvaluationRepository.GetPhysicianIdAverageReviewTimePair(physicianIds, filter as PhysicianReviewSummaryListModelFilter);

            return _physicianReviewSummaryListFactory.Create(physicianIds, physicianIdNamePair, physicianIdReviewCountPair, physicianIdOverReadsCountPair, physicianIdAvailableEvalutionCountPair, physicianIdAvaliableOverReadCountPair,
                                                             physicianIdAverageReviewTimePair, physicianIdReEvaluationCountPair, physicianIdReOverReadsCountPair, physicianIdPriorityEvalutionCountPair, physicianIdPriorityOverReadCountPair);

        }

        public ListModelBase<PhysicianReviewViewModel, PhysicianReviewListModelFilter> GetPhysicianReviews(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var evaluations = _physicianEvaluationRepository.GetEvaluations(pageNumber, pageSize, filter as PhysicianReviewListModelFilter, out totalRecords);
            if (evaluations.IsNullOrEmpty()) return null;

            var physiciansIdNamePair = _organizationRoleUserRepository.GetNameIdPairofUsers(evaluations.Select(e => e.PhysicianId).ToArray());

            var eventCustomerIds = evaluations.Select(e => e.EventCustomerId).ToArray();

            var eventCustomers = _eventCustomerRepository.GetByIds(eventCustomerIds);

            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());

            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomerIds, true);

            var orderIds = orders.Select(o => o.Id).ToArray();
            var orderPackageIdNamePair = _eventPackageRepository.GetPackageNamesForOrder(orderIds);
            var orderTestIdNamePair = _eventTestRepository.GetTestNamesForOrders(orderIds);

            var eventIds = eventCustomers.Select(ec => ec.EventId).ToArray();

            var eventCustomerResults = _eventCustomerResultRepository.GetByIds(eventCustomerIds).ToArray();

            //var criticalEventIdCustomerIdPair = _eventCustomerResultRepository.GetCriticalEventIdCustomerIdPairForPhysicianReview(eventIds);

            var criticalEventIdCustomerIdPair = (from ecr in eventCustomerResults
                                                    where ecr.ResultSummary == (long)ResultInterpretation.Critical
                                                    && 
                                                    (
                                                        (ecr.ResultState == (int)TestResultStateNumber.Evaluated && !ecr.IsPartial) 
                                                        ||ecr.ResultState > (int)TestResultStateNumber.Evaluated
                                                    )
                                                    select new OrderedPair<long, long>(ecr.EventId, ecr.CustomerId)).ToList();

            //var pdfGeneratedEventIdCustomerIdPair = _eventCustomerResultRepository.GetPdfGeneraredEventIdCustomerIdPair(eventIds);

            var pdfGeneratedEventIdCustomerIdPair = (from ecr in eventCustomerResults
                                                     where ecr.IsClinicalFormGenerated && ecr.IsResultPdfGenerated
                                                     select new OrderedPair<long, long>(ecr.EventId, ecr.CustomerId)).ToList();

            var events = _eventRepository.GetEventswithPodbyIds(eventIds);
            var pods = _podRepository.GetPodsForEvents(events.Select(e => e.Id).ToArray());

            var halfStudyEventCustomerIds = _physicianEvaluationRepository.GetEventCustomerIdsForHalfStudy(eventCustomerIds);

            var evaluationPendingEventCustomerIds = (from ecr in eventCustomerResults
                                                        where ecr.ResultState == (int) TestResultStateNumber.Evaluated && ecr.IsPartial
                                                        select ecr.Id).ToList();

            return _physicianReviewListFactory.Create(evaluations, physiciansIdNamePair, eventCustomers, customers, orders, orderPackageIdNamePair, orderTestIdNamePair,
                                                      criticalEventIdCustomerIdPair, events, pdfGeneratedEventIdCustomerIdPair, pods, halfStudyEventCustomerIds, evaluationPendingEventCustomerIds);
        }

        public ListModelBase<PhysicianQueueViewModel, PhysicianQueueListModelFilter> GetPhysicianQueue(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var queue = _physicianRepository.GetQueueforFilter(pageNumber, pageSize, filter as PhysicianQueueListModelFilter, out totalRecords);
            if (queue.IsNullOrEmpty()) return null;

            var physiciansIdNamePair = _organizationRoleUserRepository.GetNameIdPairofUsers(queue.Select(e => e.PhysicianId).ToArray());

            var eventCustomers = _eventCustomerRepository.GetByIds(queue.Select(e => e.EventCustomerId).ToArray());

            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());

            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToArray(), true);

            var orderIds = orders.Select(o => o.Id).ToArray();
            var orderPackageIdNamePair = _eventPackageRepository.GetPackageNamesForOrder(orderIds);
            var orderTestIdNamePair = _eventTestRepository.GetTestNamesForOrders(orderIds);

            var eventIds = eventCustomers.Select(ec => ec.EventId).ToArray();

            var events = _eventRepository.GetEventswithPodbyIds(eventIds);
            var pods = _podRepository.GetPodsForEvents(events.Select(e => e.Id).ToArray());
            var priorityInQueues = _priorityInQueueRepository.GetByEventIds(events.Select(e => e.Id).ToArray());

            return _physicianQueueListFactory.Create(queue, physiciansIdNamePair, eventCustomers, !(filter as PhysicianQueueListModelFilter).RecordsforPrimaryEval, customers, orders,
                                                     orderPackageIdNamePair, orderTestIdNamePair, events, pods, priorityInQueues);
        }

        public ListModelBase<PhysicianEventQueueViewModel, PhysicianEventQueueListModelFilter> GetPhysicianEventQueue(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var queue = _physicianRepository.GetEventQueueforFilter(pageNumber, pageSize, filter as PhysicianEventQueueListModelFilter, out totalRecords);
            if (queue.IsNullOrEmpty())
                return null;

            var physiciansIdNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(queue.Select(e => e.PhysicianId).Distinct().ToArray());
            var eventIds = queue.Select(q => q.EventId).Distinct().ToArray();
            var events = _eventRepository.GetEventswithPodbyIds(eventIds);
            var pods = _podRepository.GetPodsForEvents(eventIds);

            return _physicianEventQueueListFactory.Create(queue, physiciansIdNamePairs, events, pods);
        }

        public ListModelBase<PhysicianTestReviewViewModel, PhysicianTestReviewListModelFilter> GetPhysicianTestReview(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var physicianIds = _physicianEvaluationRepository.GetPhysicianIdsForTestReviewed(pageNumber, pageSize, filter as PhysicianTestReviewListModelFilter, out totalRecords);

            if (physicianIds.IsNullOrEmpty()) return null;

            var physicianIdNamePair = _organizationRoleUserRepository.GetNameIdPairofUsers(physicianIds.ToArray());
            var physicianTestReviewedStats = physicianIds.Select(physicianId => _physicianRepository.GetTestReviewedCountPairsByPhysicianId(physicianId, filter as PhysicianTestReviewListModelFilter)).ToList();

            return _physicianTestReviewListFactory.Create(physicianIds, physicianIdNamePair, physicianTestReviewedStats);
        }

    }
}