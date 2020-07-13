using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Mappers.Events;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    public class EventTestRepository : PersistenceRepository, IEventTestRepository
    {

        private readonly IUniqueItemRepository<Test> _testRepository;
        private readonly IMapper<EventTest, EventTestEntity> _mapper;
        private readonly ISettings _settings;

        public EventTestRepository()
            : this(new EventTestMapper(), new TestRepository(), new Settings())
        {

        }

        public EventTestRepository(IMapper<EventTest, EventTestEntity> mapper, IUniqueItemRepository<Test> testRepository, ISettings settings)
        {
            _testRepository = testRepository;
            _mapper = mapper;
            _settings = settings;
        }

        public List<EventTest> GetByEventAndTestIds(long eventId, IEnumerable<long> testIds)
        {
            var bucket =
                new RelationPredicateBucket(EventTestFields.EventId == eventId);
            bucket.PredicateExpression.AddWithAnd(EventTestFields.TestId == testIds.ToArray());
            return Get(bucket).ToList();
        }

        public EventTest GetByEventAndTestId(long eventId, long testId)
        {
            var bucket = new RelationPredicateBucket(EventTestFields.EventId == eventId);
            bucket.PredicateExpression.AddWithAnd(EventTestFields.TestId == testId);
            return Get(bucket).SingleOrDefault();
        }

        public EventTest GetbyId(long id)
        {
            return Get(new RelationPredicateBucket(EventTestFields.EventTestId == id)).SingleOrDefault();
        }

        public IEnumerable<EventTest> GetTestsForOrder(long orderId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var eventTestIds = (from od in linqMetaData.OrderDetail
                                    join oi in linqMetaData.OrderItem on od.OrderItemId equals oi.OrderItemId
                                    join etoi in linqMetaData.EventTestOrderItem on oi.OrderItemId equals
                                        etoi.OrderItemId
                                    where
                                        od.Status == (short)OrderStatusState.FinalSuccess &&
                                        oi.Type == (short)OrderItemType.EventTestItem && od.OrderId == orderId
                                    select etoi.EventTestId).ToArray();

                return Get(new RelationPredicateBucket(EventTestFields.EventTestId == eventTestIds)).ToArray();
            }
        }

        private IEnumerable<EventTest> Get(IRelationPredicateBucket expression)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var eventTestEntities = new EntityCollection<EventTestEntity>();
                adapter.FetchEntityCollection(eventTestEntities, expression);
                var eventTests = _mapper.MapMultiple(eventTestEntities);

                var tests = _testRepository.GetByIds(eventTests.Select(et => et.TestId).Distinct().ToArray());

                var linqMetaData = new LinqMetaData(adapter);

                var eventIds = eventTestEntities.Select(et => et.EventId).Distinct().ToArray();

                var eventIdEventDatePairs = (from e in linqMetaData.Events where eventIds.Contains(e.EventId) select new OrderedPair<long, DateTime>(e.EventId, e.EventDate)).ToArray();

                foreach (var entity in eventTestEntities)
                {
                    var eventDate = eventIdEventDatePairs.First(x => x.FirstValue == entity.EventId).SecondValue;
                    var isNewResultFlow = eventDate >= _settings.ResultFlowChangeDate;

                    var test = tests.Single(t => t.Id == entity.TestId);
                    var eventTest = eventTests.Single(et => et.Id == entity.EventTestId);

                    test.Price = entity.Price;
                    test.RefundPrice = entity.RefundPrice;
                    test.ShowInAlaCarte = entity.ShowInAlaCarte;
                    test.ScreeningTime = entity.ScreeningTime ?? -1;
                    test.HealthAssessmentTemplateId = entity.HafTemplateId;
                    test.WithPackagePrice = entity.WithPackagePrice;
                    test.GroupId = entity.GroupId;
                    test.Gender = entity.Gender;
                    test.ReimbursementRate = entity.ReimbursementRate;
                    test.PreQualificationQuestionTemplateId = entity.PreQualificationQuestionTemplateId;
                    test.ResultEntryTypeId = entity.ResultEntryTypeId;
                    //if (isNewResultFlow)
                    //    test.IsReviewable = TestGroup.TestReviewableByPhysician.Contains(entity.TestId);

                    if (entity.IsTestReviewableByPhysician.HasValue)
                        test.IsReviewable = entity.IsTestReviewableByPhysician.Value;



                    //TODO:Take oste reading from particular date
                    if (test.Id == (long)TestType.Osteoporosis && _settings.OsteoChangeDate.HasValue && test.IsRecordable)
                    {

                        if (eventDate < _settings.OsteoChangeDate.Value)
                        {
                            test.IsRecordable = false;
                            test.ResultEntryTypeId = null;
                        }

                    }

                    //TODO:Take phq9 reading from particular date
                    if (test.Id == (long)TestType.PHQ9 && _settings.Phq9ChangeDate.HasValue && test.IsRecordable)
                    {
                        if (eventDate < _settings.Phq9ChangeDate.Value)
                        {
                            test.IsRecordable = false;
                            test.IsReviewable = false;
                            test.ShowinCustomerPdf = false;
                            test.ResultEntryTypeId = null;
                        }
                    }

                    //TODO:Take QualityMeasures reading from particular date
                    if (test.Id == (long)TestType.QualityMeasures && _settings.QualityMeasuresChangeDate.HasValue && test.IsRecordable)
                    {
                        if (eventDate < _settings.QualityMeasuresChangeDate.Value)
                        {
                            test.IsRecordable = false;
                            test.IsReviewable = false;
                            test.ShowinCustomerPdf = false;
                            test.ResultEntryTypeId = null;
                        }

                    }

                    if (test.Id == (long)TestType.Hemoglobin && _settings.HemoglobinChangeDate.HasValue)
                    {
                        if (eventDate < _settings.HemoglobinChangeDate.Value)
                        {
                            test.IsRecordable = false;
                            test.IsReviewable = false;
                            test.ShowinCustomerPdf = false;
                            test.ResultEntryTypeId = null;
                        }

                    }

                    if (test.Id == (long)TestType.Mammogram && _settings.MammogramChangeDate.HasValue)
                    {
                        if (eventDate < _settings.MammogramChangeDate.Value)
                        {
                            test.IsRecordable = false;
                            test.IsReviewable = false;
                            test.ShowinCustomerPdf = false;
                            test.ResultEntryTypeId = null;
                        }
                    }

                    if (test.Id == (long)TestType.IFOBT && _settings.IFobtChangeDate.HasValue)
                    {
                        if (eventDate < _settings.IFobtChangeDate.Value)
                        {
                            test.IsRecordable = false;
                            test.IsReviewable = false;
                            test.ShowinCustomerPdf = false;
                            test.ResultEntryTypeId = null;
                        }
                    }

                    if (test.Id == (long)TestType.UrineMicroalbumin && _settings.UrineMicroalbuminChangeDate.HasValue)
                    {
                        if (eventDate < _settings.UrineMicroalbuminChangeDate.Value)
                        {
                            test.IsRecordable = false;
                            test.IsReviewable = false;
                            test.ShowinCustomerPdf = false;
                            test.ResultEntryTypeId = null;
                        }
                    }

                    if (test.Id == (long)TestType.FluShot && _settings.FluShotChangeDate.HasValue)
                    {
                        if (eventDate < _settings.FluShotChangeDate.Value)
                        {
                            test.IsRecordable = false;
                            test.IsReviewable = false;
                            test.ShowinCustomerPdf = false;
                            test.ResultEntryTypeId = null;
                        }
                    }

                    if (test.Id == (long)TestType.AwvFluShot && _settings.AwvFluShotChangeDate.HasValue)
                    {
                        if (eventDate < _settings.AwvFluShotChangeDate.Value)
                        {
                            test.IsRecordable = false;
                            test.IsReviewable = false;
                            test.ShowinCustomerPdf = false;
                            test.ResultEntryTypeId = null;
                        }
                    }

                    if (test.Id == (long)TestType.Pneumococcal && _settings.PneumococcalChangeDate.HasValue)
                    {
                        if (eventDate < _settings.PneumococcalChangeDate.Value)
                        {
                            test.IsRecordable = false;
                            test.IsReviewable = false;
                            test.ShowinCustomerPdf = false;
                            test.ResultEntryTypeId = null;
                        }
                    }

                    if (test.Id == (long)TestType.Chlamydia && _settings.ChlamydiaChangeDate.HasValue)
                    {
                        if (eventDate < _settings.ChlamydiaChangeDate.Value)
                        {
                            test.IsRecordable = false;
                            test.IsReviewable = false;
                            test.ShowinCustomerPdf = false;
                            test.ResultEntryTypeId = null;
                        }
                    }

                    if (test.Id == (long)TestType.DPN && _settings.DpnChangeDate.HasValue)
                    {
                        if (eventDate < _settings.DpnChangeDate.Value)
                        {
                            test.IsRecordable = false;
                            test.IsReviewable = false;
                            test.ShowinCustomerPdf = false;
                            test.ResultEntryTypeId = null;
                        }
                    }

                    eventTest.Test = test;
                }

                return eventTests;
            }
        }


        public IEnumerable<EventTest> GetbyIds(IEnumerable<long> ids)
        {
            return Get(new RelationPredicateBucket(EventTestFields.EventTestId == ids.ToArray()));
        }

        public IEnumerable<EventTest> GetTestsForEventByRole(long eventId, long roleId, long gender = (long)Gender.Unspecified)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var eventTests = GetTestsForEvent(eventId, gender);

                var parentRoleId = linqMetaData.Role.Where(r => r.RoleId == roleId && r.IsActive).Select(r => r.ParentId).SingleOrDefault();

                var testIds = eventTests.Select(et => et.TestId).ToArray();

                if (parentRoleId.HasValue)
                {
                    testIds = linqMetaData.TestAvailabilityToRoles.Where(ta => (ta.RoleId == roleId || (ta.RoleId == parentRoleId)) && testIds.Contains(ta.TestId)).Select(ta => ta.TestId).Distinct().ToArray();
                }
                else
                {
                    testIds = linqMetaData.TestAvailabilityToRoles.Where(ta => (ta.RoleId == roleId) && testIds.Contains(ta.TestId)).Select(ta => ta.TestId).Distinct().ToArray();
                }

                return eventTests.Where(et => testIds.Contains(et.TestId)).ToArray();
            }
        }

        public IEnumerable<EventTest> GetTestsForEvent(long eventId, long gender = (long)Gender.Unspecified)
        {
            if (Gender.Unspecified == (Gender)gender)
            {
                return Get(new RelationPredicateBucket(EventTestFields.EventId == eventId)).ToArray();
            }

            IRelationPredicateBucket predicateBucket = new RelationPredicateBucket(EventTestFields.EventId == eventId);
            predicateBucket.PredicateExpression.AddWithAnd(EventTestFields.Gender == gender | EventTestFields.Gender == (long)Gender.Unspecified);

            return Get(predicateBucket).ToArray();
            //return Get(new RelationPredicateBucket(EventTestFields.EventId == eventId));
        }

        public IEnumerable<OrderedPair<long, long>> GetEventTestIdForOrders(IEnumerable<long> orderIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var successOrderIds = (from tod in linqMetaData.OrderDetail
                                       join oi in linqMetaData.OrderItem on tod.OrderItemId equals oi.OrderItemId
                                       where tod.Status == (int)OrderStatusState.FinalSuccess &&
                                             oi.Type != (int)OrderItemType.CancellationFee && orderIds.Contains(tod.OrderId)
                                       select tod.OrderId).Distinct().ToArray();

                var cancelledOrderIds = orderIds.Except(successOrderIds);

                var pairs = (from tod in linqMetaData.OrderDetail
                             join etoi in linqMetaData.EventTestOrderItem on tod.OrderItemId equals
                                 etoi.OrderItemId
                             where successOrderIds.Contains(tod.OrderId) && (tod.Status == (int)OrderStatusState.FinalSuccess)
                             select new OrderedPair<long, long>(tod.OrderId, etoi.EventTestId)).ToList();

                if (cancelledOrderIds.IsNullOrEmpty()) return pairs;

                var query = from od in linqMetaData.OrderDetail
                            join oi in linqMetaData.OrderItem on od.OrderItemId equals oi.OrderItemId
                            where cancelledOrderIds.Contains(od.OrderId) && (od.Status == (int)OrderStatusState.FinalFailure)
                            group od by od.OrderId into g
                            select new { OrderId = g.Key, DateCreated = g.Max(od => od.DateCreated) };

                pairs.AddRange(from o in query
                               join tod in linqMetaData.OrderDetail on o.OrderId equals tod.OrderId
                               join etoi in linqMetaData.EventTestOrderItem on tod.OrderItemId equals
                                   etoi.OrderItemId
                               where o.DateCreated == tod.DateCreated
                               select new OrderedPair<long, long>(o.OrderId, etoi.EventTestId));

                return pairs;
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetTestNamesForOrders(IEnumerable<long> orderIds)
        {
            var pairs = GetEventTestIdForOrders(orderIds);
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var eventTestIds = pairs.Select(p => p.SecondValue).Distinct().ToArray();

                var linqMetaData = new LinqMetaData(adapter);
                var eventTestIdAndName = (from et in linqMetaData.EventTest
                                          join t in linqMetaData.Test on et.TestId equals t.TestId
                                          where eventTestIds.Contains(et.EventTestId)
                                          select new OrderedPair<long, string>(et.EventTestId, t.Name)).ToArray();

                return (from p in pairs
                        join ep in eventTestIdAndName on p.SecondValue equals ep.FirstValue
                        select new OrderedPair<long, string>(p.FirstValue, ep.SecondValue)).ToArray();

            }
        }

        public IEnumerable<OrderedPair<long, string>> GetTestIdNamePairs(IEnumerable<long> eventTestIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {

                var linqMetaData = new LinqMetaData(adapter);
                return (from et in linqMetaData.EventTest
                        join t in linqMetaData.Test on et.TestId equals t.TestId
                        where eventTestIds.Contains(et.EventTestId)
                        select new OrderedPair<long, string>(et.EventTestId, t.Name)).ToArray();

            }
        }

        public EventTest Save(EventTest domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = _mapper.Map(domainObject);
                entity.IsNew = domainObject.Id <= 0;

                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException();

                return _mapper.Map(entity);
            }
        }

        public void Delete(EventTest domainObject)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<EventTest> domainObjects)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventTest> GetByEventIds(IEnumerable<long> eventIds)
        {
            return Get(new RelationPredicateBucket(EventTestFields.EventId == eventIds.ToArray())).ToArray();
        }

        public IEnumerable<OrderedPair<long, long>> GetOrderIdTestIdPairsForOrders(IEnumerable<long> orderIds)
        {
            var pairs = GetEventTestIdForOrders(orderIds);
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var eventTestIds = pairs.Select(p => p.SecondValue).Distinct().ToArray();

                var linqMetaData = new LinqMetaData(adapter);
                var eventTestIdAndTestId = (from et in linqMetaData.EventTest
                                            where eventTestIds.Contains(et.EventTestId)
                                            select new OrderedPair<long, long>(et.EventTestId, et.TestId)).ToArray();

                return (from p in pairs
                        join ep in eventTestIdAndTestId on p.SecondValue equals ep.FirstValue
                        select new OrderedPair<long, long>(p.FirstValue, ep.SecondValue)).ToArray();

            }
        }

        public IEnumerable<MedicareEventTestModel> GetTestAliasesByEventIds(IEnumerable<long> eventIds)
        {
            var evet = new List<MedicareEventTestModel>();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                foreach (var eventId in eventIds)
                {
                    var theEvent = new MedicareEventTestModel { EventId = eventId };
                    long id = eventId;
                    theEvent.TestAliases = (from et in linqMetaData.EventTest
                                            join t in linqMetaData.Test on et.TestId equals
                                                t.TestId
                                            where
                                                et.EventId == id
                                            select new OrderedPair<string, string>(t.Alias, Regex.Replace(t.Name, "[^0-9A-Za-z ()-,]", " "))).ToList();
                    evet.Add(theEvent);
                }
            }
            return evet;
        }

        public IEnumerable<EventTest> GetEventTestsByEventIds(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventTestEntities = (from et in linqMetaData.EventTest
                                         where eventIds.Contains(et.EventId)
                                         select et);
                return _mapper.MapMultiple(eventTestEntities);
            }
        }

        public IEnumerable<long> GetMammoEnableEventIds(IEnumerable<long> eventids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var testIds = TestGroup.BreastCancer;

                var eventIdTestIdPair = (from et in linqMetaData.EventTest
                                         where eventids.Contains(et.EventId) && testIds.Contains(et.TestId)
                                         select et.EventId).ToArray();
                return eventIdTestIdPair;
            }
        }

        public bool EventHasMammoTests(long eventid)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var testIds = TestGroup.BreastCancer;

                return (from et in linqMetaData.EventTest
                        where et.EventId == eventid && testIds.Contains(et.TestId)
                        select et.EventId).Any();
            }
        }
    }
}