using System;
using System.Linq;
using System.Transactions;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Mappers.Screening;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Collections.Generic;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Core.Application.Domain;

namespace Falcon.App.Infrastructure.Repositories.Screening
{
    [DefaultImplementation(Interface = typeof(IEventCustomerResultRepository))]
    public class EventCustomerResultRepository : PersistenceRepository, IEventCustomerResultRepository
    {
        private readonly IMapper<EventCustomerResult, EventCustomerResultEntity> _mapper;
        private readonly IOrganizationRoleUserRepository _orgRoleuserRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private const int CutOfDateForMediaCleanUpinDays = 180;

        private readonly DateTime _resultFlowChangeDate;

        public EventCustomerResultRepository()
            : this(new EventCustomerResultMapper(), new OrganizationRoleUserRepository(), new OrderRepository(), new EventPackageRepository(), new EventTestRepository(), new Settings())
        {

        }

        public EventCustomerResultRepository(IMapper<EventCustomerResult, EventCustomerResultEntity> mapper, IOrganizationRoleUserRepository orgRoleuserRepository, IOrderRepository orderRepository,
            IEventPackageRepository eventPackageRepository, IEventTestRepository eventTestRepository, ISettings settings)
        {
            _mapper = mapper;
            _orgRoleuserRepository = orgRoleuserRepository;
            _orderRepository = orderRepository;
            _eventTestRepository = eventTestRepository;
            _eventPackageRepository = eventPackageRepository;
            _resultFlowChangeDate = settings.ResultFlowChangeDate;
        }


        public EventCustomerResult GetByCustomerIdAndEventId(long customerId, long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var eventCustomerResult =
                    linqMetaData.EventCustomerResult.SingleOrDefault(
                        cet => cet.CustomerId == customerId && cet.EventId == eventId);

                return eventCustomerResult == null ? null : _mapper.Map(eventCustomerResult);
            }
        }

        public IEnumerable<EventCustomerResult> GetbyFilter(TechnicalLimitedScreeningCustomerListModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                if (filter == null)
                {
                    filter = new TechnicalLimitedScreeningCustomerListModelFilter();
                }

                bool isPartial = false;
                bool isChartSignedOff = false;
                int resultState = 0;

                if (filter.IsNewResultStateFlow)
                {
                    resultState = filter.ResultState > 0 ? (int)(((TestResultStateLabel)filter.ResultState).GetNewResultStatefromPresentation(out isPartial, out isChartSignedOff)) : 1;
                }
                else
                {
                    resultState = filter.ResultState > 0 ? (int)(((TestResultStateLabel)filter.ResultState).GetResultStatefromPresentation(out isPartial)) : 1;
                }


                IQueryable<EventCustomerResultEntity> query = from ecr in linqMetaData.EventCustomerResult where (filter.ResultState > 0 ? ecr.ResultState == resultState && ecr.IsPartial == isPartial : ecr.ResultState > 1) select ecr;
                if (!string.IsNullOrEmpty(filter.CustomerName))
                    query = from ecr in query
                            join c in linqMetaData.OrganizationRoleUser on ecr.CustomerId equals c.OrganizationRoleUserId
                            join u in linqMetaData.User on c.UserId equals u.UserId
                            where (u.FirstName + (u.MiddleName.Length > 0 ? " " + u.MiddleName + " " : " ") + u.LastName).Contains(filter.CustomerName)
                            select ecr;

                if (filter.FromDate.HasValue || filter.ToDate.HasValue || !string.IsNullOrEmpty(filter.Pod))
                {
                    var fromDate = filter.FromDate.HasValue ? filter.FromDate.Value.Date : DateTime.Now.Date;
                    var toDate = filter.ToDate.HasValue ? filter.ToDate.Value.Date : DateTime.Now.Date;
                    var podString = string.IsNullOrEmpty(filter.Pod) ? "" : filter.Pod;

                    query = from ecr in query
                            join e in linqMetaData.Events on ecr.EventId equals e.EventId
                            join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                            join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                            where ep.IsActive && e.IsActive &&
                                p.Name.Contains(podString) &&
                                (filter.FromDate != null ? e.EventDate >= fromDate : true) &&
                                (filter.ToDate != null ? e.EventDate <= toDate : true)
                            select ecr;
                }


                query = (from ecr in query
                         join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                         join cets in linqMetaData.CustomerEventTestState on cest.CustomerEventScreeningTestId equals cets.CustomerEventScreeningTestId
                         join ceus in linqMetaData.CustomerEventUnableScreenReason on cest.CustomerEventScreeningTestId equals ceus.CustomerEventScreeningTestId
                         where (filter.Test > 0 ? cest.TestId == filter.Test : true)
                         select ecr).Distinct();

                totalRecords = query.Count();
                var entities = query.TakePage(pageNumber, pageSize).ToArray();
                return _mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<EventCustomerResult> GetByCriticalDataFilter(CustomerEventCriticalDataListModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                if (filter == null)
                {
                    filter = new CustomerEventCriticalDataListModelFilter();
                }

                var query = (from ecr in linqMetaData.EventCustomerResult
                             join cest in linqMetaData.CustomerEventScreeningTests
                                 on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                             join cets in linqMetaData.CustomerEventTestState on cest.CustomerEventScreeningTestId equals
                                 cets.CustomerEventScreeningTestId
                             join e in linqMetaData.Events on ecr.EventId equals e.EventId
                             join cetp in linqMetaData.CustomerEventTestPhysicianEvaluation on cest.CustomerEventScreeningTestId equals cetp.CustomerEventScreeningTestId
                             into queryableEcr
                             from qe in queryableEcr.DefaultIfEmpty(new CustomerEventTestPhysicianEvaluationEntity { CreatedOn = e.EventDate, IsCritical = false })
                             join cect in linqMetaData.CustomerEventCriticalTestData on cest.CustomerEventScreeningTestId equals cect.CustomerEventScreeningTestId
                             into queryableCritical
                             from qc in queryableCritical.DefaultIfEmpty(new CustomerEventCriticalTestDataEntity { DateOfSubmission = e.EventDate })
                             where cets.SelfPresent || qe.IsCritical
                             select new { ecr, e.EventDate, DatePartial = qe.IsCritical ? qe.UpdatedOn ?? qe.CreatedOn : qc.DateOfSubmission }).Distinct();

                if (filter.EventId > 0 || filter.CustomerId > 0)
                {
                    if (filter.CustomerId > 0)
                    {
                        query = from q in query
                                where q.ecr.CustomerId == filter.CustomerId
                                select q;
                    }
                    if (filter.EventId > 0)
                    {
                        query = from q in query
                                where q.ecr.EventId == filter.EventId
                                select q;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(filter.CustomerName))
                        query = from q in query
                                join c in linqMetaData.OrganizationRoleUser on q.ecr.CustomerId equals c.OrganizationRoleUserId
                                join u in linqMetaData.User on c.UserId equals u.UserId
                                where (u.FirstName + (u.MiddleName.Length > 0 ? " " + u.MiddleName + " " : " ") + u.LastName).Contains(filter.CustomerName)
                                select q;

                    if (filter.FromDate.HasValue || filter.ToDate.HasValue)
                    {
                        var fromDate = filter.FromDate.HasValue ? filter.FromDate.Value.Date : DateTime.Now.Date;
                        var toDate = filter.ToDate.HasValue ? filter.ToDate.Value.Date : DateTime.Now.Date;

                        query = from q in query
                                where
                                    (filter.FromDate != null ? q.EventDate >= fromDate : true) &&
                                    (filter.ToDate != null ? q.EventDate <= toDate : true)
                                select q;
                    }
                }
                var ecrquery = from q in query
                               orderby q.DatePartial descending
                               select q.ecr;

                totalRecords = ecrquery.Distinct().Count();
                var entities = ecrquery.Distinct().TakePage(pageNumber, pageSize).ToArray();
                return _mapper.MapMultiple(entities);
            }
        }

        //public void ToggleFlagIsInterpretedforCustomer(long customerId, long eventId, bool turnOn)
        //{
        //    using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
        //    {
        //        var linqMetaData = new LinqMetaData(myAdapter);

        //        var entity = linqMetaData.EventCustomerResult.Where(ecr => ecr.CustomerId == customerId && ecr.EventId == eventId).FirstOrDefault();

        //        EventCustomerResultEntity updateCustomerEventTestEntity = null;

        //        if (!turnOn)
        //            updateCustomerEventTestEntity = new EventCustomerResultEntity { IsClinicalFormGenerated = false, IsResultPdfgenerated = false };
        //        else
        //            updateCustomerEventTestEntity = new EventCustomerResultEntity();

        //        IRelationPredicateBucket bucket = new RelationPredicateBucket(EventCustomerResultFields.EventCustomerResultId == entity.EventCustomerResultId);
        //        if (myAdapter.UpdateEntitiesDirectly(updateCustomerEventTestEntity, bucket) == 0)
        //        {
        //            throw new PersistenceFailureException();
        //        }
        //    }
        //}


        public EventCustomerResult Save(EventCustomerResult domainObject)
        {
            if (domainObject == null) throw new InvalidOperationException("Trying to save a null EventCustomerResult object.");

            var entity = _mapper.Map(domainObject);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                if (entity.EventCustomerResultId < 1)
                {
                    var id = (from ec in linqMetaData.EventCustomers
                              where ec.EventId == domainObject.EventId && ec.CustomerId == domainObject.CustomerId
                              select ec.EventCustomerId).SingleOrDefault();
                    entity.EventCustomerResultId = id;
                    entity.IsNew = true;
                }

                CreateHistory(domainObject);

                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException();
            }
            return _mapper.Map(entity);
        }

        public void Delete(EventCustomerResult domainObject)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(IEnumerable<EventCustomerResult> domainObjects)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Test> GetCustomerTests(long eventcustomerId)
        {
            var orderId = _orderRepository.GetOrderIdByEventCustomerId(eventcustomerId);

            var tests = _eventTestRepository.GetTestsForOrder(orderId);
            var package = _eventPackageRepository.GetPackageForOrder(orderId);

            var customerTests = new List<Test>();

            if (tests != null && tests.Count() > 0)
            {
                customerTests.AddRange(tests.Select(t => t.Test).ToArray());
            }

            if (package != null && package.Tests != null && package.Tests.Count() > 0)
            {
                customerTests.AddRange(package.Tests.Select(t => t.Test).ToArray());
            }

            return customerTests;
        }

        public void SetEventCustomerResultState(long eventId, long customerId, bool isChartSignedOff = true)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventCustomerResultId = (from ecr in linqMetaData.EventCustomerResult
                                             where ecr.CustomerId == customerId && ecr.EventId == eventId
                                             select ecr.EventCustomerResultId).SingleOrDefault();

                if (eventCustomerResultId == 0) return;

                var customerTests = GetCustomerTests(eventCustomerResultId);

                SetEventCustomerResultState(eventCustomerResultId, customerTests, isChartSignedOff);
            }
        }

        public void SetEventCustomerResultState(long eventCustomerResultId, IEnumerable<Test> customerTests, bool isChartSignedOff = true)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var screeningTestsAndState = (from cest in linqMetaData.CustomerEventScreeningTests
                                              join cets in linqMetaData.CustomerEventTestState on
                                                  cest.CustomerEventScreeningTestId equals
                                                  cets.CustomerEventScreeningTestId
                                              where cest.EventCustomerResultId == eventCustomerResultId
                                              select new { cest.TestId, cets.EvaluationState, cets.IsPartial }).ToArray();

                var customerTestIds = customerTests.Where(t => t.IsRecordable).Select(t => t.Id).Distinct().ToList();
                screeningTestsAndState = screeningTestsAndState.Where(t => customerTestIds.Contains(t.TestId)).Distinct().ToArray();

                if (screeningTestsAndState.Count() < 1)
                {
                    SetEventCustomerResultState(adapter, eventCustomerResultId, 1, false, isChartSignedOff);
                    return;
                }

                var maxState = screeningTestsAndState.Max(t => t.EvaluationState);
                if (screeningTestsAndState.Count() != customerTestIds.Count())
                {
                    if (maxState > 3)
                    {
                        SetEventCustomerResultState(adapter, eventCustomerResultId, 0, false, isChartSignedOff);
                        return;
                    }
                }

                var minState = screeningTestsAndState.Max(t => t.EvaluationState);
                var partialCount = screeningTestsAndState.Where(t => t.IsPartial).Count();

                if (minState == maxState)
                {
                    if (minState >= 1 && minState <= 3)
                    {
                        SetEventCustomerResultState(adapter, eventCustomerResultId, minState, false, isChartSignedOff);
                    }
                    else if (partialCount == 0 || partialCount == screeningTestsAndState.Count())
                    {
                        SetEventCustomerResultState(adapter, eventCustomerResultId, minState, partialCount > 0, isChartSignedOff);
                    }
                    else
                    {
                        SetEventCustomerResultState(adapter, eventCustomerResultId, 0, false, isChartSignedOff);
                    }
                    return;
                }
                if (minState > 0 && maxState < 4)
                {

                    SetEventCustomerResultState(adapter, eventCustomerResultId, maxState, false, isChartSignedOff);
                    return;
                }

                SetEventCustomerResultState(adapter, eventCustomerResultId, 0, false, isChartSignedOff);
            }

        }

        private void SetEventCustomerResultState(IDataAccessAdapter adapter, long eventCustomerResultId, int state, bool isPartial, bool isChartSignedOff)
        {
            var entity = new EventCustomerResultEntity(eventCustomerResultId)
            {
                ResultState = state,
                IsPartial = isPartial,
                DateModified = DateTime.Now
            };

            if (state < (int)(NewTestResultStateNumber.PreAudit) && isChartSignedOff == false)
            {
                entity = new EventCustomerResultEntity(eventCustomerResultId)
                {
                    ResultState = state,
                    IsPartial = isPartial,
                    DateModified = DateTime.Now,
                    SignedOffBy = null,
                    SignedOffOn = null
                };
            }

            CreateHistory(eventCustomerResultId);

            adapter.UpdateEntitiesDirectly(entity, new RelationPredicateBucket(EventCustomerResultFields.EventCustomerResultId == eventCustomerResultId));
        }

        public EventCustomerResult GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var eventCustomerResult =
                    linqMetaData.EventCustomerResult.SingleOrDefault(
                        cet => cet.EventCustomerResultId == id);

                return eventCustomerResult == null ? null : _mapper.Map(eventCustomerResult);
            }
        }

        public IEnumerable<EventCustomerResult> GetByIds(IEnumerable<long> ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var eventCustomerResults =
                    linqMetaData.EventCustomerResult.Where(
                        cet => ids.Contains(cet.EventCustomerResultId));

                return eventCustomerResults.Count() < 1 ? null : _mapper.MapMultiple(eventCustomerResults);
            }
        }

        public IEnumerable<EventCustomerResult> GetByEventId(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var eventCustomerResults =
                    linqMetaData.EventCustomerResult.Where(
                        cet => cet.EventId == eventId);

                return eventCustomerResults.Count() < 1 ? null : _mapper.MapMultiple(eventCustomerResults);
            }
        }

        public IEnumerable<EventCustomerResult> GetRecordsforRegeneration()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                //var eventCustomerResults =
                //    linqMetaData.EventCustomerResult.Where(
                //        ecr =>
                //            !ecr.IsPartial && !ecr.IsClinicalFormGenerated && !ecr.IsResultPdfgenerated &&
                //            ecr.ResultState >= 6
                //            ).ToArray();

                var eventCustomerResults = (from ecr in linqMetaData.EventCustomerResult
                                            join e in linqMetaData.Events on ecr.EventId equals e.EventId
                                            where (
                                                (!ecr.IsPartial && !ecr.IsClinicalFormGenerated && !ecr.IsResultPdfgenerated &&
                                                 ecr.ResultState >= (int)TestResultStateNumber.PostAudit && e.EventDate < _resultFlowChangeDate)
                                                || (!ecr.IsResultPdfgenerated && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered && e.EventDate >= _resultFlowChangeDate))
                                            select ecr).ToArray();

                return _mapper.MapMultiple(eventCustomerResults);
            }
        }

        public IEnumerable<CustomerResultStatusViewModel> GetTestResultStatusforEvent(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var eventCustomerIds = (from erc in linqMetaData.EventCustomerResult where erc.EventId == eventId select erc.EventCustomerResultId).ToArray();

                return GetTestResultStatus(eventCustomerIds);
            }

        }

        //TODO: Will be refactored when D.O. for test Results are refactored.
        public IEnumerable<CustomerResultStatusViewModel> GetTestResultStatus(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entites = (from ecr in linqMetaData.EventCustomerResult
                               join ces in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals ces.EventCustomerResultId
                               join cets in linqMetaData.CustomerEventTestState on ces.CustomerEventScreeningTestId equals cets.CustomerEventScreeningTestId
                               join cetp in linqMetaData.CustomerEventTestPhysicianEvaluation on ces.CustomerEventScreeningTestId equals cetp.CustomerEventScreeningTestId
                               into queryableEcr
                               from qe in queryableEcr.DefaultIfEmpty(new CustomerEventTestPhysicianEvaluationEntity { IsCritical = false })
                               where eventCustomerIds.Contains(ecr.EventCustomerResultId)
                               select new
                                   {
                                       ecr.EventCustomerResultId,
                                       ecr.CustomerId,
                                       ces.TestId,
                                       cets.EvaluationState,
                                       cets.IsPartial,
                                       cets.SelfPresent,
                                       cets.TestSummary,
                                       ConductedBy = cets.ConductedByOrgRoleUserId.HasValue ? cets.ConductedByOrgRoleUserId.Value : 0,
                                       EvaluatedBy = cets.EvaluatedByOrgRoleUserId.HasValue ? cets.EvaluatedByOrgRoleUserId.Value : 0,
                                       CriticalMarkedByPhysician = qe.IsCritical,
                                       IsChartSigned = ecr.SignedOffBy.HasValue,
                                       qe.PhysicianRemarks
                                   }).ToArray();

                if (entites.Count() > 0)
                {
                    var conductedByIds = entites.Where(e => e.ConductedBy > 0).Select(e => e.ConductedBy).ToArray();
                    var evaluatedByIds = entites.Where(e => e.EvaluatedBy > 0).Select(e => e.EvaluatedBy).ToArray();

                    var nameIdPair = _orgRoleuserRepository.GetNameIdPairofUsers(conductedByIds.Concat(evaluatedByIds).Distinct().ToArray());
                    var list = new List<CustomerResultStatusViewModel>();

                    foreach (var e in entites)
                    {
                        var testResultModel = new TestResultStatusViewModel
                        {
                            TestId = e.TestId,
                            EvaluatedBy = e.EvaluatedBy < 1 ? string.Empty : nameIdPair.Where(p => p.FirstValue == e.EvaluatedBy).SingleOrDefault().SecondValue,
                            ConductedBy = e.ConductedBy < 1 ? string.Empty : nameIdPair.Where(p => p.FirstValue == e.ConductedBy).SingleOrDefault().SecondValue,
                            IsPartial = e.IsPartial,
                            TestInterpretation = e.TestSummary,
                            IsCritical = e.SelfPresent,
                            ResultState = e.EvaluationState,
                            CriticalMarkedByPhysician = e.CriticalMarkedByPhysician,
                            PhysicianRemarks = e.PhysicianRemarks,
                        };

                        var temp = list.Where(l => l != null && l.EventCustomerId == e.EventCustomerResultId).Count() > 0
                                ? list.Where(l => l != null && l.EventCustomerId == e.EventCustomerResultId).SingleOrDefault()
                                : new CustomerResultStatusViewModel
                                {
                                    EventCustomerId = e.EventCustomerResultId,
                                    CustomerId = e.CustomerId,
                                    TestResults = new TestResultStatusViewModel[0],
                                    IsChartSigned = e.IsChartSigned
                                };

                        if (temp != null)
                        {
                            temp.TestResults = temp.TestResults.Concat(new[] { testResultModel });
                            if (list.Where(l => l != null && l.EventCustomerId == e.EventCustomerResultId).Count() < 1)
                                list.Add(temp);
                        }
                    }
                    return list;
                }
            }
            return null;
        }

        public IEnumerable<EventCustomerResult> GetEventCustomerResults(int resultState, bool isPartial, int newResultState)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var resultEntities = (from ecr in linqMetaData.EventCustomerResult
                                      join e in linqMetaData.Events on ecr.EventId equals e.EventId
                                      where ((ecr.ResultState == resultState && ecr.IsPartial == isPartial && e.EventDate < _resultFlowChangeDate) || (e.EventDate >= _resultFlowChangeDate && ecr.ResultState == newResultState))
                                      select ecr);
                return _mapper.MapMultiple(resultEntities).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, int>> GetEventIdMissingCustomerResultCountPairForEventIds(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from ec in linqMetaData.EventCustomers
                        join ecr in linqMetaData.EventCustomerResult on ec.EventCustomerId equals
                            ecr.EventCustomerResultId into ececr
                        from ee in ececr.DefaultIfEmpty()
                        where eventIds.Contains(ec.EventId)
                              && ec.AppointmentId.HasValue
                              && (!ec.NoShow && ec.LeftWithoutScreeningReasonId == null)
                              && (ee.ResultState == null || ee.ResultState == (int)TestResultStateNumber.NoResults)
                        group ec by ec.EventId
                            into g
                            select new OrderedPair<long, int>(g.Key, g.Count())).ToList();
            }
        }

        public IEnumerable<OrderedPair<long, int>> GetEventIdPreAuditPendingCountPairForEventIds(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ec in linqMetaData.EventCustomers
                        join ecr in linqMetaData.EventCustomerResult on ec.EventCustomerId equals ecr.EventCustomerResultId
                        where eventIds.Contains(ecr.EventId)
                              && ecr.ResultState > (int)TestResultStateNumber.NoResults
                              && ecr.ResultState < (int)TestResultStateNumber.PreAudit
                              && ec.AppointmentId.HasValue
                        group ecr by ecr.EventId
                            into g
                            select new OrderedPair<long, int>(g.Key, g.Count())).ToList();
            }
        }

        public IEnumerable<OrderedPair<long, int>> GetEventIdReviewPendingCountPairForEventIds(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ec in linqMetaData.EventCustomers
                        join ecr in linqMetaData.EventCustomerResult on ec.EventCustomerId equals ecr.EventCustomerResultId
                        where eventIds.Contains(ecr.EventId)
                            && ec.AppointmentId.HasValue
                            &&
                            (ecr.ResultState == (int)TestResultStateNumber.PreAudit
                            || (ecr.ResultState == (int)TestResultStateNumber.Evaluated && ecr.IsPartial))

                        group ecr by ecr.EventId
                            into g
                            select new OrderedPair<long, int>(g.Key, g.Count())).ToList();
            }
        }

        public IEnumerable<OrderedPair<long, int>> GetEventIdPostAuditPendingCountPairForEventIds(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ec in linqMetaData.EventCustomers
                        join ecr in linqMetaData.EventCustomerResult on ec.EventCustomerId equals ecr.EventCustomerResultId
                        where eventIds.Contains(ecr.EventId)
                            && ec.AppointmentId.HasValue
                            && ecr.ResultState == (int)TestResultStateNumber.Evaluated && (!ecr.IsPartial)
                        group ecr by ecr.EventId
                            into g
                            select new OrderedPair<long, int>(g.Key, g.Count())).ToList();
            }
        }

        public IEnumerable<OrderedPair<long, int>> GetEventIdResultsDeliveredCountPairForEventIds(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ec in linqMetaData.EventCustomers
                        join e in linqMetaData.Events on ec.EventId equals e.EventId
                        join ecr in linqMetaData.EventCustomerResult on ec.EventCustomerId equals ecr.EventCustomerResultId
                        where eventIds.Contains(ecr.EventId)
                            && ec.AppointmentId.HasValue
                            && ((e.EventDate < _resultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered)
                            || (e.EventDate >= _resultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                        group ecr by ecr.EventId
                            into g
                            select new OrderedPair<long, int>(g.Key, g.Count())).ToList();
            }
        }

        public IEnumerable<long> GetEventWithResultDeliveredRecords()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var cutofDate = DateTime.Now.AddDays(-CutOfDateForMediaCleanUpinDays).Date;

                return (from ecr in linqMetaData.EventCustomerResult
                        where ecr.ResultState == (int)TestResultStateNumber.ResultDelivered && ecr.DateCreated > cutofDate
                        select ecr.EventId).Distinct().ToList();
            }
        }

        public IEnumerable<OrderedPair<long, int>> GetEventIdUnStableStateCountPairForEventIds(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ec in linqMetaData.EventCustomers
                        join ecr in linqMetaData.EventCustomerResult on ec.EventCustomerId equals ecr.EventCustomerResultId
                        where eventIds.Contains(ecr.EventId)
                            && ecr.ResultState == 0
                            && ec.AppointmentId.HasValue
                        group ecr by ecr.EventId
                            into g
                            select new OrderedPair<long, int>(g.Key, g.Count())).ToList();
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetCriticalEventIdCustomerIdPairForPhysicianReview(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from ecr in linqMetaData.EventCustomerResult
                        where
                            eventIds.Contains(ecr.EventId)
                            && ecr.ResultSummary == (long)ResultInterpretation.Critical
                            &&
                            ((ecr.ResultState == (int)TestResultStateNumber.Evaluated && !ecr.IsPartial) ||
                             ecr.ResultState > (int)TestResultStateNumber.Evaluated)
                        //&& ecr.ResultState == (int)TestResultStateNumber.ResultDelivered
                        select new OrderedPair<long, long>(ecr.EventId, ecr.CustomerId)).ToList();

            }
        }

        public IEnumerable<OrderedPair<long, long>> GetPdfGeneraredEventIdCustomerIdPair(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from ecr in linqMetaData.EventCustomerResult
                        where
                            eventIds.Contains(ecr.EventId) &&
                            ecr.IsClinicalFormGenerated && ecr.IsResultPdfgenerated
                        select new OrderedPair<long, long>(ecr.EventId, ecr.CustomerId)).ToList();

            }
        }

        public void SetRecordforRegeneratingResultPacket(long eventId, long orgRoleId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var eventCustomerResults =
                    linqMetaData.EventCustomerResult.Where(ecr => ecr.EventId == eventId).ToArray();

                foreach (var eventCustomerResult in eventCustomerResults)
                {
                    SetRecordforRegeneratingResultPacket(eventCustomerResult.EventId, eventCustomerResult.CustomerId, orgRoleId);
                }
            }
        }

        public bool SetRecordforRegeneratingResultPacket(long eventId, long customerId, long orgRoleId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var eventCustomerResultId =
                    linqMetaData.EventCustomerResult.Where(
                        ecr =>
                        ecr.EventId == eventId && ecr.CustomerId == customerId &&
                        ecr.ResultState >= (int)TestResultStateNumber.PostAudit && !ecr.IsPartial).Select(
                            ecr => ecr.EventCustomerResultId).FirstOrDefault();

                if (eventCustomerResultId < 1) return false;

                CreateHistory(eventCustomerResultId);

                using (var scope = new TransactionScope())
                {
                    adapter.UpdateEntitiesDirectly(
                        new EventCustomerResultEntity { IsResultPdfgenerated = false, IsClinicalFormGenerated = false, RegenerationDate = DateTime.Now, RegeneratedBy = orgRoleId },
                        new RelationPredicateBucket(EventCustomerResultFields.EventCustomerResultId == eventCustomerResultId));

                    adapter.UpdateEntitiesDirectly(new CdcontentGeneratorTrackingEntity() { IsContentGenerated = false }, new RelationPredicateBucket(CdcontentGeneratorTrackingFields.EventCustomerResultId == eventCustomerResultId));

                    scope.Complete();
                    return true;
                }
            }
        }

        public IEnumerable<long> GetClinicalFormGeneratedEventIds(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventsWithRecordsinQueue = (from ecr in linqMetaData.EventCustomerResult
                                                where ecr.ResultState >= (int)TestResultStateNumber.PostAudit && eventIds.Contains(ecr.EventId)
                                                    && ecr.IsResultPdfgenerated == false && ecr.IsClinicalFormGenerated == false
                                                select ecr.EventId).ToArray(); // Most Prob. will be in queue

                eventIds = eventIds.Where(e => !eventsWithRecordsinQueue.Contains(e)).ToArray();

                if (eventIds.Count() < 1) return eventIds;

                return (from ecr in linqMetaData.EventCustomerResult
                        where eventIds.Contains(ecr.EventId) && ecr.IsClinicalFormGenerated
                        select ecr.EventId).Distinct().ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, int>> GetEventIdEvaluatedCustomersCountForEventIds(IEnumerable<long> eventIds, bool filterForHospitalPartner = false)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from ecr in linqMetaData.EventCustomerResult
                        join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                        where
                            eventIds.Contains(ecr.EventId)
                            && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered
                            && (filterForHospitalPartner == false || (ec.PartnerRelease == (int)RegulatoryState.Signed && ec.Hipaastatus == (int)RegulatoryState.Signed))
                            && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                        group ecr by ecr.EventId
                            into g
                            select new OrderedPair<long, int>(g.Key, g.Count())).ToList();

            }
        }

        public IEnumerable<OrderedPair<long, int>> GetResultSummaryIEventIdCustomersCountForEventIds(IEnumerable<long> eventIds, ResultInterpretation resultInterpretation, bool filterForHospitalPartner = false, int validityPeriod = 0)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from ecr in linqMetaData.EventCustomerResult
                        join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                        join e in linqMetaData.Events on ecr.EventId equals e.EventId
                        where eventIds.Contains(ecr.EventId)
                            && (validityPeriod < 1 || e.EventDate >= DateTime.Now.Date.AddDays(-1 * validityPeriod))
                            && ecr.ResultSummary == (long)resultInterpretation
                            && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered
                            && (filterForHospitalPartner == false || (ec.PartnerRelease == (int)RegulatoryState.Signed && ec.Hipaastatus == (int)RegulatoryState.Signed))
                            && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                        group ecr by ecr.EventId
                            into g
                            select new OrderedPair<long, int>(g.Key, g.Count())).ToList();
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetEvaluatedEventIdCustomerIdPair(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from ecr in linqMetaData.EventCustomerResult
                        where
                            eventIds.Contains(ecr.EventId)
                            && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered
                        select new OrderedPair<long, long>(ecr.EventId, ecr.CustomerId)).ToList();

            }
        }

        public IEnumerable<OrderedPair<long, long>> GetResultSummaryEventIdCustomerIdPair(IEnumerable<long> eventIds, ResultInterpretation resultInterpretation)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from ecr in linqMetaData.EventCustomerResult
                        join e in linqMetaData.Events on ecr.EventId equals e.EventId
                        where
                            eventIds.Contains(ecr.EventId)
                            && ecr.ResultSummary == (long)resultInterpretation
                            && ((e.EventDate < _resultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered)
                            || (e.EventDate >= _resultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                        select new OrderedPair<long, long>(ecr.EventId, ecr.CustomerId)).ToList();

            }
        }

        public void SetEventCustomerResultInterpPathwayRecomendation(long eventId, long customerId, long? resultInterpretation, long? pathwayRecommendation)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var eventCustomerResultId =
                    linqMetaData.EventCustomerResult.Where(ecr => ecr.EventId == eventId && ecr.CustomerId == customerId).Select(ecr => ecr.EventCustomerResultId).FirstOrDefault();

                if (eventCustomerResultId < 1) return;

                CreateHistory(eventCustomerResultId);

                adapter.UpdateEntitiesDirectly(new EventCustomerResultEntity { ResultSummary = resultInterpretation, PathwayRecommendation = pathwayRecommendation },
                    new RelationPredicateBucket(EventCustomerResultFields.EventCustomerResultId == eventCustomerResultId));
            }
        }

        public CustomerResultStatusViewModel GetTestResultStatusforEventCustomer(long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entites = (from erc in linqMetaData.EventCustomerResult
                               join ces in linqMetaData.CustomerEventScreeningTests on erc.EventCustomerResultId equals ces.EventCustomerResultId
                               join cets in linqMetaData.CustomerEventTestState on ces.CustomerEventScreeningTestId equals cets.CustomerEventScreeningTestId

                               where erc.EventId == eventId && erc.CustomerId == customerId
                               select
                                   new
                                   {
                                       erc.CustomerId,
                                       ces.TestId,
                                       cets.EvaluationState,
                                       cets.IsPartial,
                                       cets.SelfPresent,
                                       cets.IsPriorityInQueue,
                                       cets.TestSummary,
                                       ConductedBy = cets.ConductedByOrgRoleUserId.HasValue ? cets.ConductedByOrgRoleUserId.Value : 0,
                                       EvaluatedBy = cets.EvaluatedByOrgRoleUserId.HasValue ? cets.EvaluatedByOrgRoleUserId.Value : 0,
                                       IsChartSigned = erc.SignedOffBy.HasValue
                                   }).ToArray();

                if (entites.Count() > 0)
                {
                    var conductedByIds = entites.Where(e => e.ConductedBy > 0).Select(e => e.ConductedBy).ToArray();
                    var evaluatedByIds = entites.Where(e => e.EvaluatedBy > 0).Select(e => e.EvaluatedBy).ToArray();

                    var nameIdPair = _orgRoleuserRepository.GetNameIdPairofUsers(conductedByIds.Concat(evaluatedByIds).Distinct().ToArray());
                    var customerResultStatusViewModel = new CustomerResultStatusViewModel() { CustomerId = customerId, TestResults = new TestResultStatusViewModel[0] };

                    foreach (var e in entites)
                    {
                        var testResultModel = new TestResultStatusViewModel()
                        {
                            TestId = e.TestId,
                            EvaluatedBy = e.EvaluatedBy < 1 ? string.Empty : nameIdPair.Where(p => p.FirstValue == e.EvaluatedBy).SingleOrDefault().SecondValue,
                            ConductedBy = e.ConductedBy < 1 ? string.Empty : nameIdPair.Where(p => p.FirstValue == e.ConductedBy).SingleOrDefault().SecondValue,
                            IsPartial = e.IsPartial,
                            IsCritical = e.SelfPresent,
                            TestInterpretation = e.TestSummary,
                            ResultState = e.EvaluationState,
                            IsPriorityInQueue = e.IsPriorityInQueue,
                        };

                        customerResultStatusViewModel.TestResults = customerResultStatusViewModel.TestResults.Concat(new[] { testResultModel });
                        customerResultStatusViewModel.IsChartSigned = e.IsChartSigned;
                    }

                    return customerResultStatusViewModel;
                }
                return null;
            }


        }

        public IEnumerable<EventCustomerResult> GetRecentCriticalAndUrgentCustomersForHospitalPartner(long hospitalPartnerId, int pageNumber, int pageSize, int validityPeriod = 0)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from ecr in linqMetaData.EventCustomerResult
                             join e in linqMetaData.Events on ecr.EventId equals e.EventId
                             join ehp in linqMetaData.EventHospitalPartner on e.EventId equals ehp.EventId
                             join cest in linqMetaData.CustomerEventScreeningTests
                                 on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                             join cets in linqMetaData.CustomerEventTestState on cest.CustomerEventScreeningTestId equals
                                 cets.CustomerEventScreeningTestId
                             join cetp in linqMetaData.CustomerEventTestPhysicianEvaluation on cest.CustomerEventScreeningTestId equals cetp.CustomerEventScreeningTestId
                             into queryableEcr
                             from qe in queryableEcr.DefaultIfEmpty(new CustomerEventTestPhysicianEvaluationEntity { CreatedOn = e.EventDate, IsCritical = false })
                             join cect in linqMetaData.CustomerEventCriticalTestData on cest.CustomerEventScreeningTestId equals cect.CustomerEventScreeningTestId
                             into queryableCritical
                             from qc in queryableCritical.DefaultIfEmpty(new CustomerEventCriticalTestDataEntity { DateOfSubmission = e.EventDate })
                             where ehp.HospitalPartnerId == hospitalPartnerId
                                && (validityPeriod > 0 ? e.EventDate.AddDays(validityPeriod) >= DateTime.Now.Date : true)
                                 //&& (ecr.ResultSummary == (long)ResultInterpretation.Critical || ecr.ResultSummary == (long)ResultInterpretation.Urgent)
                                 //&& ecr.ResultState == (int)TestResultStateNumber.ResultDelivered
                                && (
                                        (ecr.ResultSummary == (long)ResultInterpretation.Urgent
                                        && ((e.EventDate < _resultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered) ||
                                        (e.EventDate >= _resultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered)))
                                        ||
                                        (ecr.ResultSummary == (long)ResultInterpretation.Critical)
                                        ||
                                        (qc.CustomerEventScreeningTestId > 0
                                            && (qc.IsActive.HasValue ? qc.IsActive.Value : true)
                                            && (ecr.ResultState <= (int)TestResultStateNumber.PreAudit)
                                        )
                                    )
                             select new { ecr, DatePartial = qe.IsCritical ? qe.UpdatedOn ?? qe.CreatedOn : qc.DateOfSubmission }).Distinct();

                var entities = (from q in query
                                join ec in linqMetaData.EventCustomers on q.ecr.EventCustomerResultId equals
                                    ec.EventCustomerId
                                join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                where
                                    ec.PartnerRelease == (int)RegulatoryState.Signed
                                    && ec.Hipaastatus == (int)RegulatoryState.Signed
                                    && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                                orderby q.DatePartial descending
                                select q.ecr).Distinct().TakePage(pageNumber, pageSize).ToArray();

                return _mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<EventCustomerResult> GetRecentCriticalAndUrgentCustomersForCorporateAccountCoordinator(long accountId, int pageNumber, int pageSize)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from ecr in linqMetaData.EventCustomerResult
                             join e in linqMetaData.Events on ecr.EventId equals e.EventId
                             join ehp in linqMetaData.EventHospitalPartner on e.EventId equals ehp.EventId
                             join cest in linqMetaData.CustomerEventScreeningTests
                                 on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                             join cets in linqMetaData.CustomerEventTestState on cest.CustomerEventScreeningTestId equals
                                 cets.CustomerEventScreeningTestId
                             join cetp in linqMetaData.CustomerEventTestPhysicianEvaluation on cest.CustomerEventScreeningTestId equals cetp.CustomerEventScreeningTestId
                             into queryableEcr
                             from qe in queryableEcr.DefaultIfEmpty(new CustomerEventTestPhysicianEvaluationEntity { CreatedOn = e.EventDate, IsCritical = false })
                             join cect in linqMetaData.CustomerEventCriticalTestData on cest.CustomerEventScreeningTestId equals cect.CustomerEventScreeningTestId
                             into queryableCritical
                             from qc in queryableCritical.DefaultIfEmpty(new CustomerEventCriticalTestDataEntity { DateOfSubmission = e.EventDate })
                             where ehp.HospitalPartnerId == accountId
                                && (
                                        (ecr.ResultSummary == (long)ResultInterpretation.Urgent
                                        && ((e.EventDate < _resultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered) ||
                                        (e.EventDate >= _resultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered)))
                                        ||
                                        (ecr.ResultSummary == (long)ResultInterpretation.Critical)
                                        ||
                                        (qc.CustomerEventScreeningTestId > 0
                                            && (!qc.IsActive.HasValue || qc.IsActive.Value)
                                            && (ecr.ResultState <= (int)TestResultStateNumber.PreAudit)
                                        )
                                    )
                             select new { ecr, DatePartial = qe.IsCritical ? qe.UpdatedOn ?? qe.CreatedOn : qc.DateOfSubmission }).Distinct();

                var entities = (from q in query
                                join ec in linqMetaData.EventCustomers on q.ecr.EventCustomerResultId equals
                                    ec.EventCustomerId
                                join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                where
                                    ec.PartnerRelease == (int)RegulatoryState.Signed
                                    && ec.Hipaastatus == (int)RegulatoryState.Signed
                                    && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                                orderby q.DatePartial descending
                                select q.ecr).Distinct().TakePage(pageNumber, pageSize).ToArray();

                return _mapper.MapMultiple(entities);
            }
        }

        //public IEnumerable<CustomerEventTestState> GetTestPerformed(TestPerformedListModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        //{
        //    using (var adapter = PersistenceLayer.GetDataAccessAdapter())
        //    {
        //        var linqMetaData = new LinqMetaData(adapter);

        //        filter.EventDateFrom = filter.EventDateFrom.HasValue ? filter.EventDateFrom.Value : DateTime.Now.AddMonths(-1).Date;
        //        filter.EventDateTo = filter.EventDateTo.HasValue ? filter.EventDateTo.Value : DateTime.Now;

        //        var testNotPerformedQuery = (from tnep in linqMetaData.TestNotPerformed select tnep.CustomerEventScreeningTestId);

        //        var query = (from ecr in linqMetaData.EventCustomerResult
        //                     join ces in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals ces.EventCustomerResultId
        //                     join cets in linqMetaData.CustomerEventTestState on ces.CustomerEventScreeningTestId equals cets.CustomerEventScreeningTestId
        //                     join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
        //                     join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
        //                     join e in linqMetaData.Events on ecr.EventId equals e.EventId
        //                     join op in EventRepository.GetALLEventEntityQuerywithIsCorporateField(linqMetaData) on
        //                             ecr.EventId equals op.FirstValue.EventId
        //                     where (filter.TechnicianId > 0 ? cets.ConductedByOrgRoleUserId == filter.TechnicianId : true)
        //                        && cets.ConductedByOrgRoleUserId.HasValue
        //                        && !ec.NoShow && ec.LeftWithoutScreeningReasonId == null
        //                        && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
        //                        && e.EventDate <= DateTime.Today.Date
        //                        && !testNotPerformedQuery.Contains(ces.CustomerEventScreeningTestId)
        //                     select new { ecr, cets, e.EventDate, op });

        //        if (filter.EventId > 0)
        //        {
        //            query = from q in query
        //                    where q.ecr.EventId == filter.EventId
        //                    select q;
        //        }
        //        else
        //        {
        //            if (filter.EventDateFrom.HasValue || filter.EventDateTo.HasValue)
        //            {
        //                var fromDate = filter.EventDateFrom.HasValue ? filter.EventDateFrom.Value.Date : DateTime.Now.Date;
        //                var toDate = filter.EventDateTo.HasValue ? filter.EventDateTo.Value.Date : DateTime.Now.Date;

        //                query = from q in query
        //                        where (filter.EventDateFrom != null ? q.EventDate >= fromDate : true) &&
        //                              (filter.EventDateTo != null ? q.EventDate <= toDate : true)
        //                        select q;
        //            }

        //            if (filter.HealthPlanId > 0)
        //            {
        //                var eventIds = (from ea in linqMetaData.EventAccount where ea.AccountId == filter.HealthPlanId select ea.EventId);

        //                query = (from q in query where eventIds.Contains(q.ecr.EventId) select q);
        //            }
        //            else
        //            {

        //                if (filter.IsRetailEvent && !filter.IsCorporateEvent && !filter.IsHealthPlanEvent)
        //                {
        //                    query = query.Where(a => !a.op.SecondValue);
        //                }
        //                else if (!filter.IsRetailEvent && filter.IsCorporateEvent && !filter.IsHealthPlanEvent)
        //                {
        //                    var healthPlanIds = (from h in linqMetaData.Account where h.IsHealthPlan == false select h.AccountId);

        //                    var eventIds = (from ea in linqMetaData.EventAccount where healthPlanIds.Contains(ea.AccountId) select ea.EventId);

        //                    query = query.Where(q => eventIds.Contains(q.ecr.EventId));
        //                }
        //                else if (!filter.IsRetailEvent && !filter.IsCorporateEvent && filter.IsHealthPlanEvent)
        //                {
        //                    var healthPlanIds = (from h in linqMetaData.Account where h.IsHealthPlan select h.AccountId);

        //                    var eventIds = (from ea in linqMetaData.EventAccount where healthPlanIds.Contains(ea.AccountId) select ea.EventId);

        //                    query = query.Where(q => eventIds.Contains(q.ecr.EventId));
        //                }
        //                else if (!filter.IsRetailEvent && filter.IsCorporateEvent && filter.IsHealthPlanEvent)
        //                {
        //                    query = query.Where(a => a.op.SecondValue);
        //                }
        //                else if (filter.IsRetailEvent && !filter.IsCorporateEvent && filter.IsHealthPlanEvent)
        //                {
        //                    var healthPlanIds = (from h in linqMetaData.Account where h.IsHealthPlan select h.AccountId);

        //                    var eventIds = (from ea in linqMetaData.EventAccount where healthPlanIds.Contains(ea.AccountId) select ea.EventId);

        //                    query = query.Where(q => !q.op.SecondValue || eventIds.Contains(q.ecr.EventId));
        //                }
        //                else if (filter.IsRetailEvent && filter.IsCorporateEvent && !filter.IsHealthPlanEvent)
        //                {
        //                    var healthPlanIds = (from h in linqMetaData.Account where h.IsHealthPlan == false select h.AccountId);

        //                    var eventIds = (from ea in linqMetaData.EventAccount where healthPlanIds.Contains(ea.AccountId) select ea.EventId);

        //                    query = query.Where(q => !q.op.SecondValue || eventIds.Contains(q.ecr.EventId));
        //                }

        //            }


        //            if (!string.IsNullOrEmpty(filter.Pod))
        //            {
        //                var podEventIds = (from ep in linqMetaData.EventPod
        //                                   join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
        //                                   where ep.IsActive && p.Name.Contains(filter.Pod)
        //                                   select ep.EventId);

        //                query = (from q in query where podEventIds.Contains(q.ecr.EventId) select q);
        //            }
        //        }
        //        var testPerformedQuery = from q in query
        //                                 orderby q.EventDate, q.ecr.EventId, q.ecr.CustomerId, q.cets.ConductedByOrgRoleUserId
        //                                 select q.cets;

        //        totalRecords = testPerformedQuery.Count();
        //        var entities = testPerformedQuery.TakePage(pageNumber, pageSize).ToArray();

        //        return AutoMapper.Mapper.Map<IEnumerable<CustomerEventTestStateEntity>, IEnumerable<CustomerEventTestState>>(entities);

        //    }
        //}

        public IEnumerable<VwGetTestPerformedReport> GetTestPerformed(TestPerformedListModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                filter.EventDateFrom = filter.EventDateFrom.HasValue ? filter.EventDateFrom.Value : DateTime.Now.AddMonths(-1).Date;
                filter.EventDateTo = filter.EventDateTo.HasValue ? filter.EventDateTo.Value : DateTime.Now;

                var query = (from tpr in linqMetaData.VwGetTestPerformedReport select tpr);

                if (filter.TechnicianId > 0)
                {
                    query = query.Where(q => q.ConductedByOrgRoleUserId == filter.TechnicianId);
                }

                if (filter.EventId > 0)
                {
                    query = from q in query
                            where q.EventId == filter.EventId
                            select q;
                }
                else
                {
                    if (filter.EventDateFrom.HasValue || filter.EventDateTo.HasValue)
                    {
                        var fromDate = filter.EventDateFrom.HasValue ? filter.EventDateFrom.Value.Date : DateTime.Now.Date;
                        var toDate = filter.EventDateTo.HasValue ? filter.EventDateTo.Value.Date : DateTime.Now.Date;

                        query = from q in query
                                where (filter.EventDateFrom != null ? q.EventDate >= fromDate : true) &&
                                      (filter.EventDateTo != null ? q.EventDate <= toDate : true)
                                select q;
                    }

                    if (filter.HealthPlanId > 0)
                    {
                        query = (from q in query where q.AccountId == filter.HealthPlanId select q);
                    }
                    else
                    {
                        if (filter.IsRetailEvent && !filter.IsCorporateEvent && !filter.IsHealthPlanEvent)
                        {
                            query = query.Where(a => a.AccountId <= 0);
                        }
                        else if (!filter.IsRetailEvent && filter.IsCorporateEvent && !filter.IsHealthPlanEvent)
                        {
                            query = query.Where(q => q.AccountId > 0 && q.IsHealthPlan == false);
                        }
                        else if (!filter.IsRetailEvent && !filter.IsCorporateEvent && filter.IsHealthPlanEvent)
                        {
                            query = query.Where(q => q.AccountId > 0 && q.IsHealthPlan == true);
                        }
                        else if (!filter.IsRetailEvent && filter.IsCorporateEvent && filter.IsHealthPlanEvent)
                        {
                            query = query.Where(q => q.AccountId > 0);
                        }
                        else if (filter.IsRetailEvent && !filter.IsCorporateEvent && filter.IsHealthPlanEvent)
                        {
                            query = query.Where(q => (q.AccountId <= 0 || q.IsHealthPlan == true));
                        }
                        else if (filter.IsRetailEvent && filter.IsCorporateEvent && !filter.IsHealthPlanEvent)
                        {
                            query = query.Where(q => (q.AccountId <= 0 || q.IsHealthPlan == false));
                        }
                    }

                    if (!string.IsNullOrEmpty(filter.Pod))
                    {
                        query = query.Where(q => q.Pod == filter.Pod);
                    }

                    if (filter.TestId > 0)
                    {
                        query = (from q in query
                                 where q.TestId == filter.TestId
                                 select q);
                    }
                    if (!string.IsNullOrWhiteSpace(filter.Tag))
                    {
                        var customerIds = (from cp in linqMetaData.CustomerProfile where cp.Tag == filter.Tag select cp.CustomerId);

                        query = (from q in query where customerIds.Contains(q.CustomerId) select q);
                    }
                }

                if (filter.IsPdfGenerated == (int)PdfGeneratedStatus.Yes)
                {
                    query = (from q in query
                             where q.IsPdfGenerated == true
                             select q);
                }
                else if (filter.IsPdfGenerated == (int)PdfGeneratedStatus.No)
                {
                    query = (from q in query
                             where q.IsPdfGenerated == false
                             select q);
                }
                var testPerformedQuery = from q in query
                                         orderby q.EventDate, q.EventId, q.CustomerId, q.ConductedByOrgRoleUserId
                                         select q;

                totalRecords = testPerformedQuery.Count();
                var entities = testPerformedQuery.TakePage(pageNumber, pageSize).ToArray();

                return AutoMapper.Mapper.Map<IEnumerable<VwGetTestPerformedReportEntity>, IEnumerable<VwGetTestPerformedReport>>(entities);

            }
        }

        public IEnumerable<CustomerEventScreeningTests> GetCustomerEventScreeningTestsByIds(IEnumerable<long> ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ces in linqMetaData.CustomerEventScreeningTests
                                where ids.Contains(ces.CustomerEventScreeningTestId)
                                select ces).ToArray();
                return AutoMapper.Mapper.Map<IEnumerable<CustomerEventScreeningTestsEntity>, IEnumerable<CustomerEventScreeningTests>>(entities);
            }
        }

        public IEnumerable<OrderedPair<long, int>> GetCriticalEventIdCustomersCountForEventIds(IEnumerable<long> eventIds, ResultInterpretation resultInterpretation, bool filterForHospitalPartner = false, int validityPeriod = 0)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var criticalEventCustomerResultIds = (from ecr in linqMetaData.EventCustomerResult
                                                      join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                                      join cect in linqMetaData.CustomerEventCriticalTestData on cest.CustomerEventScreeningTestId equals cect.CustomerEventScreeningTestId
                                                      where cect.CustomerEventScreeningTestId > 0
                                                            && (cect.IsActive.HasValue ? cect.IsActive.Value : true)
                                                            && (ecr.ResultState <= (int)TestResultStateNumber.PreAudit)
                                                      select ecr.EventCustomerResultId);

                return (from ecr in linqMetaData.EventCustomerResult
                        join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                        join e in linqMetaData.Events on ecr.EventId equals e.EventId
                        where eventIds.Contains(ecr.EventId)
                            && (validityPeriod > 0 ? e.EventDate.AddDays(validityPeriod) >= DateTime.Now.Date : true)
                            //&& ecr.ResultSummary == (long)resultInterpretation
                            //&& ecr.ResultState == (int)TestResultStateNumber.ResultDelivered
                            && (
                                    ecr.ResultSummary == (long)ResultInterpretation.Critical
                                    || criticalEventCustomerResultIds.Contains(ecr.EventCustomerResultId)
                                )
                            && (filterForHospitalPartner == false || (ec.PartnerRelease == (int)RegulatoryState.Signed && ec.Hipaastatus == (int)RegulatoryState.Signed))
                            && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                        group ecr by ecr.EventId
                            into g
                            select new OrderedPair<long, int>(g.Key, g.Count())).ToList();
            }
        }

        public IEnumerable<OrderedPair<long, int>> GetResultSummaryEventIdCustomersCountForHospitalPartner(long hospitalPartnerId, ResultInterpretation resultInterpretation, bool filterForHospitalPartner = false, int validityPeriod = 0)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from ecr in linqMetaData.EventCustomerResult
                        join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                        join e in linqMetaData.Events on ecr.EventId equals e.EventId
                        join ehp in linqMetaData.EventHospitalPartner on e.EventId equals ehp.EventId
                        where ehp.HospitalPartnerId == hospitalPartnerId
                            && (validityPeriod < 1 || e.EventDate >= DateTime.Now.Date.AddDays(-1 * validityPeriod))
                            && ecr.ResultSummary == (long)resultInterpretation
                            && ((e.EventDate < _resultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered) || (e.EventDate >= _resultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                            && (filterForHospitalPartner == false || (ec.PartnerRelease == (int)RegulatoryState.Signed && ec.Hipaastatus == (int)RegulatoryState.Signed))
                            && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                        group ecr by ecr.EventId
                            into g
                            select new OrderedPair<long, int>(g.Key, g.Count())).ToList();
            }
        }

        public IEnumerable<OrderedPair<long, int>> GetCriticalEventIdCustomersCountForHospitalPartner(long hospitalPartnerId, ResultInterpretation resultInterpretation, bool filterForHospitalPartner = false, int validityPeriod = 0)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var criticalEventCustomerResultIds = (from ecr in linqMetaData.EventCustomerResult
                                                      join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                                      join cect in linqMetaData.CustomerEventCriticalTestData on cest.CustomerEventScreeningTestId equals cect.CustomerEventScreeningTestId
                                                      where cect.CustomerEventScreeningTestId > 0
                                                            && (cect.IsActive.HasValue ? cect.IsActive.Value : true)
                                                            && (ecr.ResultState <= (int)TestResultStateNumber.PreAudit)
                                                      select ecr.EventCustomerResultId);

                return (from ecr in linqMetaData.EventCustomerResult
                        join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                        join e in linqMetaData.Events on ecr.EventId equals e.EventId
                        join ehp in linqMetaData.EventHospitalPartner on e.EventId equals ehp.EventId
                        where ehp.HospitalPartnerId == hospitalPartnerId
                            && (validityPeriod > 0 ? e.EventDate.AddDays(validityPeriod) >= DateTime.Now.Date : true)
                            //&& ecr.ResultSummary == (long)resultInterpretation
                            //&& ecr.ResultState == (int)TestResultStateNumber.ResultDelivered
                            && (
                                    ecr.ResultSummary == (long)ResultInterpretation.Critical
                                    || criticalEventCustomerResultIds.Contains(ecr.EventCustomerResultId)
                                )
                            && (filterForHospitalPartner == false || (ec.PartnerRelease == (int)RegulatoryState.Signed && ec.Hipaastatus == (int)RegulatoryState.Signed))
                            && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                        group ecr by ecr.EventId
                            into g
                            select new OrderedPair<long, int>(g.Key, g.Count())).ToList();
            }
        }

        public IEnumerable<EventCustomerResult> GetEventCustomerResultsForResultReadyNotification(int days)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ecr in linqMetaData.EventCustomerResult
                                join e in linqMetaData.Events on ecr.EventId equals e.EventId
                                where ((e.EventDate < _resultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered)
                                      || (e.EventDate >= _resultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                                      && ecr.DateModified.HasValue
                                      && ecr.DateModified.Value.Date == DateTime.Now.Date.AddDays(-1 * days)
                                select ecr
                                );
                return _mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<long> GetEventIdsForEventResultReadyNotiFication()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var list = new List<long>();
                var hospitalPartnerEventIds = (from ecr in linqMetaData.EventCustomerResult
                                               join e in linqMetaData.Events on ecr.EventId equals e.EventId
                                               join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                                               join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                               where ((e.EventDate < _resultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered)
                                                     || (e.EventDate >= _resultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                                                     && ecr.DateModified.HasValue
                                                     && ecr.DateModified.Value.Date == DateTime.Now.Date
                                                     && ec.Hipaastatus == (long)RegulatoryState.Signed
                                                     && ec.PartnerRelease == (long)RegulatoryState.Signed
                                                     && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                                               select ecr.EventId).Distinct().ToArray();

                //var corporateAccountEventIds = (from ecr in linqMetaData.EventCustomerResult
                //                                join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                //                                join eventAccount in linqMetaData.EventAccount on ecr.EventId equals eventAccount.EventId
                //                                join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                //                                where ecr.ResultState == (long)TestResultStateNumber.ResultDelivered
                //                                      && ecr.DateModified.HasValue
                //                                      && ecr.DateModified.Value.Date == DateTime.Now.Date
                //                                      && ec.Hipaastatus == (long)RegulatoryState.Signed
                //                                      && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                //                                select ecr.EventId).Distinct().ToArray();

                if (!hospitalPartnerEventIds.IsNullOrEmpty())
                {
                    list.AddRange(hospitalPartnerEventIds);
                }
                //if (!corporateAccountEventIds.IsNullOrEmpty())
                //{
                //    list.AddRange(corporateAccountEventIds);
                //}
                if (list.IsNullOrEmpty())
                    return list;

                return list.Distinct();
            }
        }

        public bool CheckAllCustomerResultsReadyForEvent(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventEntity = (from e in linqMetaData.Events where e.EventId == eventId select e).Single();
                var isNewResultFlow = eventEntity.EventDate >= _resultFlowChangeDate;

                var allResultsNotReady = (from ecr in linqMetaData.EventCustomerResult
                                          join e in linqMetaData.Events on ecr.EventId equals e.EventId
                                          join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                                          join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                          where ecr.EventId == eventId
                                                && ((!isNewResultFlow && ecr.ResultState >= (long)TestResultStateNumber.NoResults && ecr.ResultState < (long)TestResultStateNumber.ResultDelivered)
                                                || (isNewResultFlow && ecr.ResultState >= (long)NewTestResultStateNumber.NoResults && ecr.ResultState < (long)NewTestResultStateNumber.ResultDelivered))
                                                && ec.Hipaastatus == (long)RegulatoryState.Signed
                                                && ec.PartnerRelease == (long)RegulatoryState.Signed
                                                && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                                                && ec.LeftWithoutScreeningReasonId == null
                                          select ecr.EventCustomerResultId).Any();
                return !allResultsNotReady;
            }
        }

        public IEnumerable<EventCustomerResult> GetRecentCriticalAndUrgentCustomersForHospitalFacility(long hospitalFacilityId, int pageNumber, int pageSize, int validityPeriod = 0)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from ecr in linqMetaData.EventCustomerResult
                             join e in linqMetaData.Events on ecr.EventId equals e.EventId
                             join ehf in linqMetaData.EventHospitalFacility on e.EventId equals ehf.EventId
                             join cest in linqMetaData.CustomerEventScreeningTests
                                 on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                             join cets in linqMetaData.CustomerEventTestState on cest.CustomerEventScreeningTestId equals
                                 cets.CustomerEventScreeningTestId
                             join cetp in linqMetaData.CustomerEventTestPhysicianEvaluation on cest.CustomerEventScreeningTestId equals cetp.CustomerEventScreeningTestId
                             into queryableEcr
                             from qe in queryableEcr.DefaultIfEmpty(new CustomerEventTestPhysicianEvaluationEntity { CreatedOn = e.EventDate, IsCritical = false })
                             join cect in linqMetaData.CustomerEventCriticalTestData on cest.CustomerEventScreeningTestId equals cect.CustomerEventScreeningTestId
                             into queryableCritical
                             from qc in queryableCritical.DefaultIfEmpty(new CustomerEventCriticalTestDataEntity { DateOfSubmission = e.EventDate })
                             where ehf.HospitalFacilityId == hospitalFacilityId
                                && (validityPeriod > 0 ? e.EventDate.AddDays(validityPeriod) >= DateTime.Now.Date : true)
                                 //&& (ecr.ResultSummary == (long)ResultInterpretation.Critical || ecr.ResultSummary == (long)ResultInterpretation.Urgent)
                                 //&& ecr.ResultState == (int)TestResultStateNumber.ResultDelivered
                                && (
                                        (ecr.ResultSummary == (long)ResultInterpretation.Urgent
                                        && ((e.EventDate < _resultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered) ||
                                        (e.EventDate >= _resultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered)))
                                        ||
                                        (ecr.ResultSummary == (long)ResultInterpretation.Critical)
                                        ||
                                        (qc.CustomerEventScreeningTestId > 0
                                            && (qc.IsActive.HasValue ? qc.IsActive.Value : true)
                                            && (ecr.ResultState <= (int)TestResultStateNumber.PreAudit)
                                        )
                                    )
                             select new { ecr, DatePartial = qe.IsCritical ? qe.UpdatedOn ?? qe.CreatedOn : qc.DateOfSubmission }).Distinct();

                var entities = (from q in query
                                join ec in linqMetaData.EventCustomers on q.ecr.EventCustomerResultId equals ec.EventCustomerId
                                join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                where
                                    ec.PartnerRelease == (int)RegulatoryState.Signed
                                    && ec.Hipaastatus == (int)RegulatoryState.Signed
                                    && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                                    && ec.HospitalFacilityId == hospitalFacilityId
                                orderby q.DatePartial descending
                                select q.ecr).Distinct().TakePage(pageNumber, pageSize).ToArray();

                return _mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<OrderedPair<long, int>> GetResultSummaryEventIdCustomersCountForHospitalFacility(long hospitalFacilityId, ResultInterpretation resultInterpretation, bool filterForHospitalPartner = false, int validityPeriod = 0)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from ecr in linqMetaData.EventCustomerResult
                        join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                        join e in linqMetaData.Events on ecr.EventId equals e.EventId
                        join ehf in linqMetaData.EventHospitalFacility on e.EventId equals ehf.EventId
                        where ehf.HospitalFacilityId == hospitalFacilityId && ec.HospitalFacilityId == hospitalFacilityId
                            && (validityPeriod < 1 || e.EventDate >= DateTime.Now.Date.AddDays(-1 * validityPeriod))
                            && ecr.ResultSummary == (long)resultInterpretation
                            && ((e.EventDate < _resultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered) || (e.EventDate >= _resultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                            && (filterForHospitalPartner == false || (ec.PartnerRelease == (int)RegulatoryState.Signed && ec.Hipaastatus == (int)RegulatoryState.Signed))
                            && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                        group ecr by ecr.EventId
                            into g
                            select new OrderedPair<long, int>(g.Key, g.Count())).ToList();
            }
        }

        public IEnumerable<OrderedPair<long, int>> GetCriticalEventIdCustomersCountForHospitalFacility(long hospitalFacilityId, ResultInterpretation resultInterpretation, bool filterForHospitalPartner = false, int validityPeriod = 0)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var criticalEventCustomerResultIds = (from ecr in linqMetaData.EventCustomerResult
                                                      join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                                      join cect in linqMetaData.CustomerEventCriticalTestData on cest.CustomerEventScreeningTestId equals cect.CustomerEventScreeningTestId
                                                      where cect.CustomerEventScreeningTestId > 0
                                                            && (cect.IsActive.HasValue ? cect.IsActive.Value : true)
                                                            && (ecr.ResultState <= (int)TestResultStateNumber.PreAudit)
                                                      select ecr.EventCustomerResultId);

                return (from ecr in linqMetaData.EventCustomerResult
                        join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                        join e in linqMetaData.Events on ecr.EventId equals e.EventId
                        join ehf in linqMetaData.EventHospitalFacility on e.EventId equals ehf.EventId
                        where ehf.HospitalFacilityId == hospitalFacilityId && ec.HospitalFacilityId == hospitalFacilityId
                            && (validityPeriod > 0 ? e.EventDate.AddDays(validityPeriod) >= DateTime.Now.Date : true)
                            //&& ecr.ResultSummary == (long)resultInterpretation
                            //&& ecr.ResultState == (int)TestResultStateNumber.ResultDelivered
                            && (
                                    ecr.ResultSummary == (long)ResultInterpretation.Critical
                                    || criticalEventCustomerResultIds.Contains(ecr.EventCustomerResultId)
                                )
                            && (filterForHospitalPartner == false || (ec.PartnerRelease == (int)RegulatoryState.Signed && ec.Hipaastatus == (int)RegulatoryState.Signed))
                            && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                        group ecr by ecr.EventId
                            into g
                            select new OrderedPair<long, int>(g.Key, g.Count())).ToList();
            }
        }

        public IEnumerable<OrderedPair<long, int>> GetResultSummaryEventIdCustomersCountForEventIdsAndHospitalFacility(IEnumerable<long> eventIds, ResultInterpretation resultInterpretation, long hospitalFacilityId,
            bool filterForHospitalPartner = false, int validityPeriod = 0)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from ecr in linqMetaData.EventCustomerResult
                        join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                        join e in linqMetaData.Events on ecr.EventId equals e.EventId
                        join ehf in linqMetaData.EventHospitalFacility on e.EventId equals ehf.EventId
                        where eventIds.Contains(ecr.EventId) && ehf.HospitalFacilityId == hospitalFacilityId && ec.HospitalFacilityId == hospitalFacilityId
                            && (validityPeriod < 1 || e.EventDate >= DateTime.Now.Date.AddDays(-1 * validityPeriod))
                            && ecr.ResultSummary == (long)resultInterpretation
                            && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered
                            && (filterForHospitalPartner == false || (ec.PartnerRelease == (int)RegulatoryState.Signed && ec.Hipaastatus == (int)RegulatoryState.Signed))
                            && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                        group ecr by ecr.EventId
                            into g
                            select new OrderedPair<long, int>(g.Key, g.Count())).ToList();
            }
        }

        public IEnumerable<OrderedPair<long, int>> GetCriticalEventIdCustomersCountForEventIdsAndHospitalFacility(IEnumerable<long> eventIds, ResultInterpretation resultInterpretation, long hospitalFacilityId,
            bool filterForHospitalPartner = false, int validityPeriod = 0)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var criticalEventCustomerResultIds = (from ecr in linqMetaData.EventCustomerResult
                                                      join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                                      join cect in linqMetaData.CustomerEventCriticalTestData on cest.CustomerEventScreeningTestId equals cect.CustomerEventScreeningTestId
                                                      where cect.CustomerEventScreeningTestId > 0
                                                            && (cect.IsActive.HasValue ? cect.IsActive.Value : true)
                                                            && (ecr.ResultState <= (int)TestResultStateNumber.PreAudit)
                                                      select ecr.EventCustomerResultId);

                return (from ecr in linqMetaData.EventCustomerResult
                        join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                        join e in linqMetaData.Events on ecr.EventId equals e.EventId
                        join ehf in linqMetaData.EventHospitalFacility on e.EventId equals ehf.EventId
                        where eventIds.Contains(ecr.EventId) && ehf.HospitalFacilityId == hospitalFacilityId && ec.HospitalFacilityId == hospitalFacilityId
                            && (validityPeriod > 0 ? e.EventDate.AddDays(validityPeriod) >= DateTime.Now.Date : true)
                            //&& ecr.ResultSummary == (long)resultInterpretation
                            //&& ecr.ResultState == (int)TestResultStateNumber.ResultDelivered
                            && (
                                    ecr.ResultSummary == (long)ResultInterpretation.Critical
                                    || criticalEventCustomerResultIds.Contains(ecr.EventCustomerResultId)
                                )
                            && (filterForHospitalPartner == false || (ec.PartnerRelease == (int)RegulatoryState.Signed && ec.Hipaastatus == (int)RegulatoryState.Signed))
                            && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                        group ecr by ecr.EventId
                            into g
                            select new OrderedPair<long, int>(g.Key, g.Count())).ToList();
            }
        }

        public IEnumerable<EventCustomerResult> GetEventCustomerResultsToFax(int oldFlowResultState, int newFlowResultState, bool isPartial, DateTime toTime, DateTime? fromTime, long accountId, string corporateTag, bool considerRegeneration = false, string[] customTags = null,
            bool includeCustomerWithTag = false, bool considerEventDate = false, DateTime? eventDate = null, DateTime? toEventDate = null, DateTime? stopSendingPdftoHealthPlanDate = null)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var corporateEventIds = (from ea in linqMetaData.EventAccount where ea.AccountId == accountId select ea.EventId);
                var customerIds = (from cp in linqMetaData.CustomerProfile where cp.Tag == corporateTag select cp.CustomerId);

                var query = (from ecr in linqMetaData.EventCustomerResult
                             join e in linqMetaData.Events on ecr.EventId equals e.EventId
                             where //ecr.ResultState == oldFlowResultState
                                 ((e.EventDate < _resultFlowChangeDate && ecr.ResultState == oldFlowResultState) || (e.EventDate >= _resultFlowChangeDate && ecr.ResultState == newFlowResultState))
                                 && ecr.IsPartial == isPartial &&
                                 corporateEventIds.Contains(ecr.EventId)
                                 && customerIds.Contains(ecr.CustomerId)
                             select new { ecr, e });

                if (stopSendingPdftoHealthPlanDate.HasValue)
                {
                    query = (from q in query
                             where q.e.EventDate < stopSendingPdftoHealthPlanDate.Value
                             select new { q.ecr, q.e });
                }

                var resultEntities = (
                    from q in query
                    where ((q.ecr.DateModified.HasValue && (fromTime == null || q.ecr.DateModified > fromTime) &&
                          q.ecr.DateModified <= toTime) ||
                         (considerRegeneration && q.ecr.RegenerationDate > fromTime && q.ecr.RegenerationDate <= toTime))
                    select q.ecr);

                if (considerEventDate && eventDate.HasValue && toEventDate.HasValue)
                {
                    resultEntities = (
                        from q in query
                        where q.e.EventDate >= eventDate.Value
                            && (q.e.EventDate <= toEventDate.Value) &&
                            ((q.ecr.DateModified.HasValue && (fromTime == null || q.ecr.DateModified > fromTime) &&
                              q.ecr.DateModified <= toTime) ||
                             (considerRegeneration && q.ecr.RegenerationDate > fromTime && q.ecr.RegenerationDate <= toTime))
                        select q.ecr);
                }
                else if (considerEventDate && eventDate.HasValue)
                {
                    resultEntities = (
                    from q in query
                    where q.e.EventDate >= eventDate.Value &&
                        ((q.ecr.DateModified.HasValue && (fromTime == null || q.ecr.DateModified > fromTime) &&
                          q.ecr.DateModified <= toTime) ||
                         (considerRegeneration && q.ecr.RegenerationDate > fromTime && q.ecr.RegenerationDate <= toTime))
                    select q.ecr);
                }


                if (!customTags.IsNullOrEmpty())
                {
                    var customerwithCustomTag = (from customertag in linqMetaData.CustomerTag where customTags.Contains(customertag.Tag) select customertag.CustomerId);
                    resultEntities = includeCustomerWithTag
                        ? resultEntities.Where(x => customerwithCustomTag.Contains(x.CustomerId))
                        : resultEntities.Where(x => !customerwithCustomTag.Contains(x.CustomerId));
                }

                return _mapper.MapMultiple(resultEntities).ToArray();
            }
        }

        public bool IsCustomerScreeningTestResultExists(long eventCustomerResultId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cest in linqMetaData.CustomerEventScreeningTests
                                where cest.EventCustomerResultId == eventCustomerResultId
                                select cest).ToArray();

                return entities.Any();

            }
        }

        public bool CheckAnyCustomerResultsReadyAndSignedPartnerRelease(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ecr in linqMetaData.EventCustomerResult
                        join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                        join e in linqMetaData.Events on ecr.EventId equals e.EventId
                        where ((e.EventDate < _resultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered) || (e.EventDate >= _resultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                              && ecr.DateModified.HasValue
                              && ecr.EventId == eventId
                              && ecr.DateModified.Value.Date == DateTime.Now.Date
                              && ec.Hipaastatus == (long)RegulatoryState.Signed
                              && ec.PartnerRelease == (long)RegulatoryState.Signed
                              && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                        select ecr.EventId).Any();
            }
        }

        public IEnumerable<EventCustomerResult> GetEventCustomerResultsByEventIdTestId(long eventId, long testId, string tag)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ecr in linqMetaData.EventCustomerResult
                                join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                                join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                where cest.TestId == testId && ec.AppointmentId != null && ec.NoShow == false && !ec.LeftWithoutScreeningReasonId.HasValue && ec.EventId == eventId
                                select ecr);

                if (!string.IsNullOrWhiteSpace(tag))
                {
                    var customerIds = (from cp in linqMetaData.CustomerProfile where cp.Tag == tag select cp.CustomerId);

                    entities = (from q in entities where customerIds.Contains(q.CustomerId) select q);
                }

                return _mapper.MapMultiple(entities);
            }
        }

        public bool Update(long eventCustomerResultId, bool? isFasting)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                CreateHistory(eventCustomerResultId);

                var eventCustomerResultEntity = new EventCustomerResultEntity(eventCustomerResultId) { IsFasting = isFasting };
                var bucket = new RelationPredicateBucket(EventCustomerResultFields.EventCustomerResultId == eventCustomerResultId);
                return (myAdapter.UpdateEntitiesDirectly(eventCustomerResultEntity, bucket) > 0);
            }
        }

        public IEnumerable<long> GetEventIdsForCorporateAccountEventResultReadyNotiFication(DateTime cutOfDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var list = new List<long>();

                var allResultsNotReady = (from ecr in linqMetaData.EventCustomerResult
                                          join e in linqMetaData.Events on ecr.EventId equals e.EventId
                                          where ((e.EventDate < _resultFlowChangeDate && ecr.ResultState >= (long)TestResultStateNumber.NoResults && ecr.ResultState < (long)TestResultStateNumber.ResultDelivered)
                                          || (e.EventDate >= _resultFlowChangeDate && ecr.ResultState >= (long)NewTestResultStateNumber.NoResults && ecr.ResultState < (long)NewTestResultStateNumber.ResultDelivered))
                                                && e.EventDate >= cutOfDate
                                          select ecr.EventId).Distinct();

                var corporateAccountEventIds = (from ecr in linqMetaData.EventCustomerResult
                                                join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                                                join eventAccount in linqMetaData.EventAccount on ecr.EventId equals eventAccount.EventId
                                                join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                                join e in linqMetaData.Events on ecr.EventId equals e.EventId

                                                where ((e.EventDate < _resultFlowChangeDate && ecr.ResultState == (long)TestResultStateNumber.ResultDelivered)
                                                    || (e.EventDate >= _resultFlowChangeDate && ecr.ResultState == (long)NewTestResultStateNumber.ResultDelivered))
                                                      && ecr.DateModified.HasValue
                                                      && ecr.DateModified.Value.Date == DateTime.Now.Date.AddDays(-1)
                                                      && !allResultsNotReady.Contains(ecr.EventId)
                                                select ecr.EventId).Distinct().ToArray();

                if (!corporateAccountEventIds.IsNullOrEmpty())
                {
                    list.AddRange(corporateAccountEventIds);
                }

                if (list.IsNullOrEmpty())
                    return list;

                return list.Distinct();
            }
        }

        public IEnumerable<EventCustomerResult> GetForCrosswalkLabReport(int oldResultFlowResultState, int newResultFlowResultState, bool isPartial, DateTime toTime, DateTime? fromTime, long accountId, string corporateTag, bool considerRegeneration = false, string[] customTags = null)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var corporateEventIds = (from ea in linqMetaData.EventAccount where ea.AccountId == accountId select ea.EventId);
                var customerIds = (from cp in linqMetaData.CustomerProfile where cp.Tag == corporateTag select cp.CustomerId);

                var resultEntities = (from ecr in linqMetaData.EventCustomerResult
                                      join e in linqMetaData.Events on ecr.EventId equals e.EventId
                                      join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                      where ((e.EventDate < _resultFlowChangeDate && ecr.ResultState == oldResultFlowResultState) || (e.EventDate >= _resultFlowChangeDate && ecr.ResultState == newResultFlowResultState))
                                      && ecr.IsPartial == isPartial && corporateEventIds.Contains(ecr.EventId)
                                      && customerIds.Contains(ecr.CustomerId)
                                      && ((ecr.DateModified.HasValue && (fromTime == null || ecr.DateModified > fromTime) && ecr.DateModified <= toTime) || (considerRegeneration && ecr.RegenerationDate > fromTime && ecr.RegenerationDate <= toTime))
                                      && (cest.TestId == (long)TestType.IFOBT || cest.TestId == (long)TestType.UrineMicroalbumin)
                                      select ecr);

                if (!customTags.IsNullOrEmpty())
                {
                    var customTagCustomersIds = (from ct in linqMetaData.CustomerTag where ct.IsActive && customTags.Contains(ct.Tag) select ct.CustomerId);
                    resultEntities = (from q in resultEntities where customTagCustomersIds.Contains(q.CustomerId) select q);
                }

                return _mapper.MapMultiple(resultEntities).ToArray();
            }
        }

        public IEnumerable<CustomerEventScreeningTests> GetByEventCustomerResultAndTestIds(IEnumerable<long> eventCustomerIds, long[] testIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var testNotPerformedIds = (from tnp in linqMetaData.TestNotPerformed select tnp.CustomerEventScreeningTestId);
                var unableToScreenIds = (from uts in linqMetaData.CustomerEventUnableScreenReason select uts.CustomerEventScreeningTestId);

                var entities = (from ces in linqMetaData.CustomerEventScreeningTests
                                where eventCustomerIds.Contains(ces.EventCustomerResultId)
                                && testIds.Contains(ces.TestId)
                                && !testNotPerformedIds.Contains(ces.CustomerEventScreeningTestId)
                                && !unableToScreenIds.Contains(ces.CustomerEventScreeningTestId)
                                select ces).ToArray();

                return AutoMapper.Mapper.Map<IEnumerable<CustomerEventScreeningTestsEntity>, IEnumerable<CustomerEventScreeningTests>>(entities);
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetCustomerEventScreeningTestIdFileIdPairs(IEnumerable<long> customerEventScreeningTestIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from tm in linqMetaData.TestMedia
                        where customerEventScreeningTestIds.Contains(tm.CustomerEventScreeningTestId)
                        select new OrderedPair<long, long>(tm.CustomerEventScreeningTestId, tm.FileId)).ToArray();
            }
        }

        public IEnumerable<CustomerEventScreeningTests> GetCustomerEventScreeningTestsByEventCustomerResultIds(IEnumerable<long> eventCustomerResultIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var testNotPerformedQuery = (from tnep in linqMetaData.TestNotPerformed select tnep.CustomerEventScreeningTestId);

                var entities = (from ces in linqMetaData.CustomerEventScreeningTests
                                join cets in linqMetaData.CustomerEventTestState on ces.CustomerEventScreeningTestId equals cets.CustomerEventScreeningTestId
                                where cets.ConductedByOrgRoleUserId.HasValue
                                      && !testNotPerformedQuery.Contains(ces.CustomerEventScreeningTestId)
                                      && eventCustomerResultIds.Contains(ces.EventCustomerResultId)
                                select ces).ToArray();

                return AutoMapper.Mapper.Map<IEnumerable<CustomerEventScreeningTestsEntity>, IEnumerable<CustomerEventScreeningTests>>(entities);
            }
        }


        public IEnumerable<EventCustomerResult> GetEventCustomerResultsByCustomerIds(long oldResultFlowResultState, long newResultFlowResultState, bool isPartial, long accountId, IEnumerable<long> customerIds, DateTime cutOfDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var corporateEventIds = (from ea in linqMetaData.EventAccount where ea.AccountId == accountId select ea.EventId);

                var resultEntities = (
                    from ecr in linqMetaData.EventCustomerResult
                    join e in linqMetaData.Events on ecr.EventId equals e.EventId
                    join customer in linqMetaData.CustomerProfile on ecr.CustomerId equals customer.CustomerId
                    where e.EventDate >= cutOfDate && ((e.EventDate < _resultFlowChangeDate && ecr.ResultState == oldResultFlowResultState) || (e.EventDate >= _resultFlowChangeDate && ecr.ResultState == newResultFlowResultState))
                    && ecr.IsPartial == isPartial && corporateEventIds.Contains(ecr.EventId)
                        && customerIds.Contains(ecr.CustomerId) && customer.AdditionalField4 != null && customer.AdditionalField4 != string.Empty
                    select ecr);

                return _mapper.MapMultiple(resultEntities).ToArray();
            }
        }

        public IEnumerable<EventCustomerResult> GetEventCustomerResultsByMrnCustomerIds(long oldResultFlowResultState, long newResultFlowResultState, bool isPartial, long accountId, IEnumerable<long> customerIds, DateTime cutOfDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var corporateEventIds = (from ea in linqMetaData.EventAccount where ea.AccountId == accountId select ea.EventId);

                var resultEntities = (
                    from ecr in linqMetaData.EventCustomerResult
                    join e in linqMetaData.Events on ecr.EventId equals e.EventId
                    join customer in linqMetaData.CustomerProfile on ecr.CustomerId equals customer.CustomerId
                    where e.EventDate >= cutOfDate && ((e.EventDate < _resultFlowChangeDate && ecr.ResultState == oldResultFlowResultState) || (e.EventDate >= _resultFlowChangeDate && ecr.ResultState == newResultFlowResultState))
                    && ecr.IsPartial == isPartial && corporateEventIds.Contains(ecr.EventId)
                        && customerIds.Contains(ecr.CustomerId) && customer.Mrn != null && customer.Mrn != string.Empty
                    select ecr);

                return _mapper.MapMultiple(resultEntities).ToArray();
            }
        }

        public IEnumerable<EventCustomerResult> GetEventCustomerResultsbyEventDate(int resultState, bool isPartial, DateTime toDate, DateTime fromDate, long accountId, string tag)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var corporateEventIds = (from ea in linqMetaData.EventAccount
                                         join e in linqMetaData.Events on ea.EventId equals e.EventId
                                         where ea.AccountId == accountId
                                         && e.EventDate >= fromDate && e.EventDate < toDate.AddDays(1)
                                         select e.EventId);

                var resultEntities = (
                    from ecr in linqMetaData.EventCustomerResult
                    join customer in linqMetaData.CustomerProfile on ecr.CustomerId equals customer.CustomerId
                    where ecr.ResultState == resultState && ecr.IsPartial == isPartial && corporateEventIds.Contains(ecr.EventId)
                    select ecr);

                return _mapper.MapMultiple(resultEntities).ToArray();
            }
        }

        public IEnumerable<EventCustomerResult> GetPatientsByResultStateAndDate(long resultState, DateTime fromDate, DateTime toDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ecr in linqMetaData.EventCustomerResult
                                where ecr.DateModified >= fromDate && ecr.DateModified <= toDate
                                && ((ecr.ResultState == resultState && !ecr.IsPartial) || ecr.ResultState > resultState)
                                select ecr);

                return _mapper.MapMultiple(entities).ToArray();
            }
        }

        //public void SetEventCustomerRevertedToEvaluation(long eventId, long customerId, bool isRevertedToEvaluation)
        //{
        //    using (var adapter = PersistenceLayer.GetDataAccessAdapter())
        //    {
        //        var linqMetaData = new LinqMetaData(adapter);
        //        var eventCustomerResultId = (from ecr in linqMetaData.EventCustomerResult
        //                                     where ecr.EventId == eventId && ecr.CustomerId == customerId
        //                                     select ecr.EventCustomerResultId).Single();

        //        var entity = new EventCustomerResultEntity(eventCustomerResultId) { IsRevertedToEvaluation = isRevertedToEvaluation };

        //        adapter.UpdateEntitiesDirectly(entity, new RelationPredicateBucket(EventCustomerResultFields.EventCustomerResultId == eventCustomerResultId));
        //    }
        //}

        public void SetEventCustomerPennedBack(long eventId, long customerId, bool isPennedBack)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var eventCustomerResultId = (from ecr in linqMetaData.EventCustomerResult
                                             where ecr.EventId == eventId && ecr.CustomerId == customerId
                                             select ecr.EventCustomerResultId).Single();

                var entity = new EventCustomerResultEntity(eventCustomerResultId) { IsPennedBack = isPennedBack };

                adapter.UpdateEntitiesDirectly(entity, new RelationPredicateBucket(EventCustomerResultFields.EventCustomerResultId == eventCustomerResultId));
            }
        }

        public IEnumerable<EventCustomerResult> GetEventCustomerResultsForCustomerIds(int resultState, bool isPartial, DateTime toTime, DateTime? fromTime, long accountId, long[] customerIds, bool considerRegeneration = false, string[] customTags = null,
            bool includeCustomerWithTag = false, bool considerEventDate = false, DateTime? eventDate = null, DateTime? toEventDate = null)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var corporateEventIds = (from ea in linqMetaData.EventAccount where ea.AccountId == accountId select ea.EventId);
                var resultEntities = (
                    from ecr in linqMetaData.EventCustomerResult
                    where
                        ecr.ResultState == resultState && ecr.IsPartial == isPartial &&
                        corporateEventIds.Contains(ecr.EventId)
                        && customerIds.Contains(ecr.CustomerId)
                        &&
                        ((ecr.DateModified.HasValue && (fromTime == null || ecr.DateModified > fromTime) &&
                          ecr.DateModified <= toTime) ||
                         (considerRegeneration && ecr.RegenerationDate > fromTime && ecr.RegenerationDate <= toTime))
                    select ecr);

                if (considerEventDate && eventDate.HasValue)
                {
                    resultEntities = (
                    from ecr in linqMetaData.EventCustomerResult
                    join e in linqMetaData.Events on ecr.EventId equals e.EventId
                    where
                        ecr.ResultState == resultState && ecr.IsPartial == isPartial &&
                        corporateEventIds.Contains(ecr.EventId)
                        && customerIds.Contains(ecr.CustomerId)
                        && e.EventDate >= eventDate.Value
                        && (!toEventDate.HasValue || e.EventDate <= toEventDate.Value) &&
                        ((ecr.DateModified.HasValue && (fromTime == null || ecr.DateModified > fromTime) &&
                          ecr.DateModified <= toTime) ||
                         (considerRegeneration && ecr.RegenerationDate > fromTime && ecr.RegenerationDate <= toTime))

                    select ecr);
                }

                if (!customTags.IsNullOrEmpty())
                {
                    var customerwithCustomTag = (from customertag in linqMetaData.CustomerTag where customTags.Contains(customertag.Tag) select customertag.CustomerId);
                    resultEntities = includeCustomerWithTag
                        ? resultEntities.Where(x => customerwithCustomTag.Contains(x.CustomerId))
                        : resultEntities.Where(x => !customerwithCustomTag.Contains(x.CustomerId));
                }

                return _mapper.MapMultiple(resultEntities).ToArray();
            }
        }

        public IEnumerable<EventCustomerResult> GetEventCustomerResultsByIdsAndResultState(IEnumerable<long> eventCustomerResultIds, int oldFlowResultState, int newFlowResultState, bool isPartial)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var resultEntities = (
                    from ecr in linqMetaData.EventCustomerResult
                    join e in linqMetaData.Events on ecr.EventId equals e.EventId
                    where
                        //ecr.ResultState == oldFlowResultState 
                      ((e.EventDate < _resultFlowChangeDate && ecr.ResultState == oldFlowResultState) || (e.EventDate >= _resultFlowChangeDate && ecr.ResultState == newFlowResultState))
                        && ecr.IsPartial == isPartial &&
                        eventCustomerResultIds.Contains(ecr.EventCustomerResultId)
                    select ecr);

                return _mapper.MapMultiple(resultEntities).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetTestNotPerformedTestsByReason(long eventCustomerId, long testNotPerfomredReasonId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from tnp in linqMetaData.TestNotPerformed
                        join cest in linqMetaData.CustomerEventScreeningTests on tnp.CustomerEventScreeningTestId equals
                            cest.CustomerEventScreeningTestId
                        where
                            cest.EventCustomerResultId == eventCustomerId &&
                            tnp.TestNotPerformedReasonId == testNotPerfomredReasonId
                        select new OrderedPair<long, long>(cest.EventCustomerResultId, cest.TestId)).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetLabKitValueByEventCustomerResultId(IEnumerable<long> eventCustomerResultIds, long testId, long readingLableId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var customerUnableToScreen = (from ceusr in linqMetaData.CustomerEventUnableScreenReason select ceusr.CustomerEventScreeningTestId);
                var testNotPerformed = (from tnp in linqMetaData.TestNotPerformed select tnp.CustomerEventScreeningTestId);

                return (from cest in linqMetaData.CustomerEventScreeningTests
                        join cer in linqMetaData.CustomerEventReading on cest.CustomerEventScreeningTestId equals cer.CustomerEventScreeningTestId
                        join r in linqMetaData.TestReading on cer.TestReadingId equals r.TestReadingId
                        where eventCustomerResultIds.Contains(cest.EventCustomerResultId)
                        && !customerUnableToScreen.Contains(cest.CustomerEventScreeningTestId)
                        && !testNotPerformed.Contains(cest.CustomerEventScreeningTestId)
                        && (cest.TestId == testId)
                        && (r.ReadingId == readingLableId)

                        select new OrderedPair<long, string> { FirstValue = cest.EventCustomerResultId, SecondValue = cer.Value }).ToArray();
            }
        }

        public IEnumerable<EventCustomerResult> GetLabKitDistributionReport(BiWeeklyMicroAlbuminFobtReportModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var corporateEventIds = (from ea in linqMetaData.EventAccount where ea.AccountId == filter.AccountId select ea.EventId);
                var customerUnableToScreen = (from ceusr in linqMetaData.CustomerEventUnableScreenReason select ceusr.CustomerEventScreeningTestId);
                var testNotPerformed = (from tnp in linqMetaData.TestNotPerformed select tnp.CustomerEventScreeningTestId);
                var screenedEventCustomerIds = (from ec in linqMetaData.EventCustomers where ec.NoShow == false && ec.LeftWithoutScreeningReasonId == null select ec.EventCustomerId);

                var eventcustomerResultIds = (from cest in linqMetaData.CustomerEventScreeningTests
                                              where !customerUnableToScreen.Contains(cest.CustomerEventScreeningTestId)
                                                    && !testNotPerformed.Contains(cest.CustomerEventScreeningTestId)
                                                    && (cest.TestId == (long)TestType.IFOBT || cest.TestId == (long)TestType.UrineMicroalbumin)
                                              select cest.EventCustomerResultId);


                var query = (from ecr in linqMetaData.EventCustomerResult
                             join e in linqMetaData.Events on ecr.EventId equals e.EventId
                             where corporateEventIds.Contains(ecr.EventId)
                                   && e.EventDate >= filter.CutOffDate
                                   && (ecr.DateModified.HasValue && (ecr.DateModified >= filter.StartDate) &&
                                    ecr.DateModified < filter.EndDate.AddDays(1))
                                    && eventcustomerResultIds.Contains(ecr.EventCustomerResultId)
                                    && screenedEventCustomerIds.Contains(ecr.EventCustomerResultId)
                             select ecr);

                totalRecords = query.Count();
                var entities = query.TakePage(pageNumber, pageSize).ToArray();

                return _mapper.MapMultiple(entities).ToArray();
            }
        }

        private void CreateHistory(EventCustomerResult model)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                if (model.Id > 0)
                {
                    var eventCutomerResult = (from ec in linqMetaData.EventCustomerResult
                                              where ec.EventCustomerResultId == model.Id
                                              select ec).Single();
                    if (HasChanged(model, eventCutomerResult))
                    {
                        SaveEventCustomerResultHistory(eventCutomerResult, adapter);
                    }
                }
            }
        }

        public IEnumerable<EventCustomerResult> GetEventCustomerResultDelivered(DateTime toTime, DateTime fromTime, long accountId, string corporateTag,
             DateTime? eventDate, bool includeCustomerWithTag, string[] customTags = null, DateTime? stopSendingPdftoHealthPlanDate = null)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var corporateEventIds = (from ea in linqMetaData.EventAccount where ea.AccountId == accountId select ea.EventId);
                var customerIds = (from cp in linqMetaData.CustomerProfile where cp.Tag == corporateTag select cp.CustomerId);

                var resultEntities = (
                        from ecr in linqMetaData.EventCustomerResult
                        where (ecr.ResultState == (int)TestResultStateNumber.ResultDelivered || ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered) && ecr.IsPartial == false
                        && corporateEventIds.Contains(ecr.EventId)
                        && customerIds.Contains(ecr.CustomerId)
                        && ((ecr.DateModified.HasValue && ecr.DateModified > fromTime && ecr.DateModified <= toTime)
                            || (ecr.RegenerationDate > fromTime && ecr.RegenerationDate <= toTime))
                        select ecr);

                var query = (from ecr in resultEntities
                             join e in linqMetaData.Events on ecr.EventId equals e.EventId
                             select new { ecr, e });

                if (eventDate.HasValue)
                {
                    if (eventDate.HasValue)
                        query = query.Where(x => x.e.EventDate >= eventDate);

                    resultEntities = query.Select(x => x.ecr);
                }

                if (stopSendingPdftoHealthPlanDate.HasValue)
                {
                    query = query.Where(x => x.e.EventDate < stopSendingPdftoHealthPlanDate.Value);

                    resultEntities = query.Select(x => x.ecr);
                }

                if (!customTags.IsNullOrEmpty())
                {
                    var customerwithCustomTag = (from customertag in linqMetaData.CustomerTag where customTags.Contains(customertag.Tag) select customertag.CustomerId);
                    resultEntities = includeCustomerWithTag
                        ? resultEntities.Where(x => customerwithCustomTag.Contains(x.CustomerId))
                        : resultEntities.Where(x => !customerwithCustomTag.Contains(x.CustomerId));
                }
                return _mapper.MapMultiple(resultEntities.ToArray());
            }
        }

        private void SaveEventCustomerResultHistory(EventCustomerResultEntity eventCutomerResult, IDataAccessAdapter adapter)
        {
            var entity = Mapper.Map<EventCustomerResultEntity, EventCustomerResultHistoryEntity>(eventCutomerResult);

            if (!adapter.SaveEntity(entity, false))
            {
                throw new PersistenceFailureException();
            }
        }

        private void CreateHistory(long eventCustomerResultId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                if (eventCustomerResultId > 0)
                {
                    var eventCutomerResult = (from ec in linqMetaData.EventCustomerResult
                                              where ec.EventCustomerResultId == eventCustomerResultId
                                              select ec).Single();

                    SaveEventCustomerResultHistory(eventCutomerResult, adapter);
                }
            }
        }

        private bool HasChanged(EventCustomerResult model, EventCustomerResultEntity entity)
        {
            return model.IsClinicalFormGenerated != entity.IsClinicalFormGenerated
                   || model.IsResultPdfGenerated != entity.IsResultPdfgenerated
                   || model.ResultState != entity.ResultState
                   || model.IsPartial != entity.IsPartial
                   || model.ResultSummary != entity.ResultSummary
                   || model.PathwayRecommendation != entity.PathwayRecommendation
                   || model.RegeneratedBy != entity.RegeneratedBy
                   || model.IsFasting != entity.IsFasting
                   || model.IsRevertedToEvaluation != entity.IsRevertedToEvaluation
                   || model.IsPennedBack != entity.IsPennedBack
                   || model.SignedOffBy != entity.SignedOffBy
                   || model.VerifiedBy != entity.VerifiedBy
                   || model.VerifiedOn != entity.VerifiedOn
                   || model.CodedBy != entity.CodedBy
                   || model.CodedOn != entity.CodedOn
                   || model.AcesApprovedOn != entity.AcesApprovedOn
                   || model.InvoiceDateUpdatedBy != entity.InvoiceDateUpdatedBy
                   || model.IsIpResultGenerated != entity.IsIpResultGenerated
                   || model.ChatPdfReviewedByPhysicianId != entity.ChatPdfReviewedByPhysicianId
                   || model.ChatPdfReviewedByPhysicianDate != entity.ChatPdfReviewedByPhysicianDate
                   || model.ChatPdfReviewedByOverreadPhysicianId != entity.ChatPdfReviewedByOverreadPhysicianId
                   || model.ChatPdfReviewedByOverreadPhysicianDate != entity.ChatPdfReviewedByOverreadPhysicianDate;

        }

        public IEnumerable<EventCustomerResult> GetEventCustomerResultByResultState(int resultState, bool isPartial, DateTime resultFlowChangeDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var eventCustomerResults = (from ecr in linqMetaData.EventCustomerResult
                                            join e in linqMetaData.Events on ecr.EventId equals e.EventId
                                            where e.EventDate >= resultFlowChangeDate
                                            && ecr.ResultState == resultState && ecr.IsPartial == isPartial
                                            && ecr.SignedOffBy.HasValue
                                            select ecr).ToArray();

                return _mapper.MapMultiple(eventCustomerResults);
            }
        }

        public IEnumerable<EventCustomerResult> GetEventCustomerResultsForResultReadyNotification(int oldResultState, int newResultState, bool isPartial)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var resultEntities = (from ecr in linqMetaData.EventCustomerResult
                                      join e in linqMetaData.Events on ecr.EventId equals e.EventId
                                      where ((ecr.ResultState == oldResultState && ecr.IsPartial == isPartial && e.EventDate < _resultFlowChangeDate)
                                      || (ecr.ResultState == newResultState && ecr.IsPartial == isPartial && ecr.AcesApprovedOn.HasValue && ecr.AcesApprovedOn.Value <= DateTime.Now.Date && e.EventDate >= _resultFlowChangeDate
                                      && ecr.IsResultPdfgenerated == true))
                                      select ecr);
                return _mapper.MapMultiple(resultEntities).ToArray();
            }
        }

        public IEnumerable<EventCustomerResult> GetResultsNpVerified(int resultState, bool isPartial, DateTime resultFlowChangeDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var eventCustomerResults = (from ecr in linqMetaData.EventCustomerResult
                                            join e in linqMetaData.Events on ecr.EventId equals e.EventId
                                            where e.EventDate >= resultFlowChangeDate
                                            && ecr.ResultState == resultState && ecr.IsPartial == isPartial
                                            && ecr.VerifiedBy.HasValue && ecr.VerifiedOn < DateTime.Now.AddMinutes(-1)
                                            select ecr).ToArray();

                return _mapper.MapMultiple(eventCustomerResults);
            }
        }

        public IEnumerable<EventCustomerResult> GetEventCustomerResultForInvoicing(DateTime resultFlowChangeDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventCustomerResults = (from ecr in linqMetaData.EventCustomerResult
                                            join e in linqMetaData.Events on ecr.EventId equals e.EventId
                                            where e.EventDate >= resultFlowChangeDate
                                            && ecr.ResultState >= (int)NewTestResultStateNumber.ArtifactSynced && ecr.ResultState <= (int)NewTestResultStateNumber.ResultDelivered
                                            && ecr.SignedOffBy.HasValue
                                            select ecr).ToArray();

                return _mapper.MapMultiple(eventCustomerResults);
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetEawvTestNotPerformedReason(IEnumerable<long> eventCustomerResultIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from tnp in linqMetaData.TestNotPerformed
                        join cest in linqMetaData.CustomerEventScreeningTests on tnp.CustomerEventScreeningTestId equals cest.CustomerEventScreeningTestId
                        where eventCustomerResultIds.Contains(cest.EventCustomerResultId)
                        && (cest.TestId == (long)TestType.eAWV)

                        select new OrderedPair<long, long> { FirstValue = cest.EventCustomerResultId, SecondValue = tnp.TestNotPerformedReasonId }).ToArray();
            }
        }

        public IEnumerable<EventCustomerResult> GetEvaluatedByPhysicianEventCustomerResult()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                int resultState = (int)NewTestResultStateNumber.PostAuditNew;

                var resultEntities = (from ecr in linqMetaData.EventCustomerResult
                                      join ea in linqMetaData.EventAccount on ecr.EventId equals ea.EventId
                                      join a in linqMetaData.Account on ea.AccountId equals a.AccountId
                                      where a.IsHealthPlan == true && ecr.IsIpResultGenerated == false
                                          && ecr.ResultState == resultState
                                      select ecr);

                return _mapper.MapMultiple(resultEntities).ToArray();
            }
        }

        public bool UpdateIsIpResultGenerated(long eventCustomerResultId, bool isIpResultGenerated)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                CreateHistory(eventCustomerResultId);

                var eventCustomerResultEntity = new EventCustomerResultEntity(eventCustomerResultId) { IsIpResultGenerated = isIpResultGenerated, DateModified = DateTime.Now };
                var bucket = new RelationPredicateBucket(EventCustomerResultFields.EventCustomerResultId == eventCustomerResultId);
                return (myAdapter.UpdateEntitiesDirectly(eventCustomerResultEntity, bucket) > 0);
            }
        }

        public IEnumerable<EventCustomerResult> GetEventCustomerResultByTestIds(IEnumerable<long> testIds, DateTime startDate, DateTime endDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var resultEntities = (from ecr in linqMetaData.EventCustomerResult
                                      join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                      join ea in linqMetaData.EventAccount on ecr.EventId equals ea.EventId
                                      join a in linqMetaData.Account on ea.AccountId equals a.AccountId
                                      where a.IsHealthPlan == true && ecr.ResultState >= (int)NewTestResultStateNumber.PostAuditNew && ecr.ResultState < (int)NewTestResultStateNumber.ResultDelivered
                                      && ecr.DateModified >= startDate && ecr.DateModified < endDate
                                      && testIds.Contains(cest.TestId)
                                      select ecr);

                return _mapper.MapMultiple(resultEntities).ToArray();
            }
        }

        public IEnumerable<string> GetMediaByEventIdAndCustomerId(long eventId, long customerId, IEnumerable<long> testIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var fileType = new List<long>();
                fileType.Add((long)FileType.Image);
                fileType.Add((long)FileType.Pdf);

                var linqMetaData = new LinqMetaData(adapter);
                var unableToScreenId = (from ceusr in linqMetaData.CustomerEventUnableScreenReason select ceusr.CustomerEventScreeningTestId);
                var testNotPerfomedId = (from tnp in linqMetaData.TestNotPerformed where tnp.TestNotPerformedReasonId > 0 select tnp.CustomerEventScreeningTestId);

                var resultMedia = (from ecr in linqMetaData.EventCustomerResult
                                   join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                   join tm in linqMetaData.TestMedia on cest.CustomerEventScreeningTestId equals tm.CustomerEventScreeningTestId
                                   join f in linqMetaData.File on tm.FileId equals f.FileId
                                   where ecr.EventId == eventId && ecr.CustomerId == customerId
                                   && testIds.Contains(cest.TestId)
                                   && fileType.Contains(f.Type)
                                   && !unableToScreenId.Contains(cest.CustomerEventScreeningTestId)
                                   && !testNotPerfomedId.Contains(cest.CustomerEventScreeningTestId)
                                   select f.Path).ToList();

                return resultMedia;
            }
        }

        public IEnumerable<OrderedPair<string, long>> GetMediaAndTestIdByEventIdAndCustomerId(long eventId, long customerId, IEnumerable<long> testIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var fileType = new List<long>();
                fileType.Add((long)FileType.Image);
                fileType.Add((long)FileType.Pdf);
                fileType.Add((long)FileType.Video);

                var linqMetaData = new LinqMetaData(adapter);
                var unableToScreenId = (from ceusr in linqMetaData.CustomerEventUnableScreenReason select ceusr.CustomerEventScreeningTestId);
                var testNotPerfomedId = (from tnp in linqMetaData.TestNotPerformed where tnp.TestNotPerformedReasonId > 0 select tnp.CustomerEventScreeningTestId);

                var resultMedia = (from ecr in linqMetaData.EventCustomerResult
                                   join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                   join tm in linqMetaData.TestMedia on cest.CustomerEventScreeningTestId equals tm.CustomerEventScreeningTestId
                                   join f in linqMetaData.File on tm.FileId equals f.FileId
                                   where ecr.EventId == eventId && ecr.CustomerId == customerId
                                   && testIds.Contains(cest.TestId)
                                   && fileType.Contains(f.Type)
                                   && !unableToScreenId.Contains(cest.CustomerEventScreeningTestId)
                                   && !testNotPerfomedId.Contains(cest.CustomerEventScreeningTestId)
                                   select new OrderedPair<string, long>(f.Path, cest.TestId)).ToList();

                return resultMedia;
            }
        }
    }
}