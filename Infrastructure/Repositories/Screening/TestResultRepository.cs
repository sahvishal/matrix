using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Falcon.App.Core;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Impl;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Factories.Screening;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Mappers.Screening;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.App.Core.Domain;
using Falcon.App.Infrastructure.Medical.Interfaces;
using Falcon.App.Infrastructure.Medical.Repositories;

namespace Falcon.App.Infrastructure.Repositories.Screening
{
    public class TestResultRepository : PersistenceRepository, ITestResultRepository
    {
        private ITestResultFactory _testResultFacotry;
        private ITestResultSynchronizationService _testResultSynchronizationService;
        private ITestPerformedExternallyRepository _testPerformedExternallyRepository;

        public TestResultRepository(ReadingSource readingSource)
        {
            _testResultFacotry = new TestResultFactory();
            _testResultSynchronizationService = new TestResultSynchronizationService(readingSource);
        }

        public TestResultRepository()
        {
            _testResultFacotry = new TestResultFactory();
            _testResultSynchronizationService = new TestResultSynchronizationService();
            _testPerformedExternallyRepository = new TestPerformedExternallyRepository();
        }

        protected TestResultRepository(IPersistenceLayer persistenceLayer)
            : base(persistenceLayer)
        {
            _testResultFacotry = new TestResultFactory();
        }

        protected ReadingSource _callingSource = ReadingSource.Manual;

        public virtual List<ResultReading<int>> GetReadingsForTest()
        {
            throw new NotImplementedException();
        }

        //Modified for NewResultFlow
        public virtual TestResult GetTestResults(long customerId, long eventId, bool isNewResultFlow)
        {
            return null;
        }

        public TestResult GetTestResult(long customerId, long eventId, int testId, bool isNewResultFlow)
        {
            var entity = GetTestResultsByTestId(customerId, eventId, testId).FirstOrDefault();
            if (entity != null)
            {
                var testResult = _testResultFacotry.CreateTestResult(entity);
                testResult.IsNewResultFlow = isNewResultFlow;
                return testResult;
            }


            return null;
        }

        //Modified for NewResultFlow
        public virtual bool SaveTestResults(TestResult currentTestResult, long customerId, long eventId, long organizationRoleUserId)
        {
            if (currentTestResult == null) return true;

            if (currentTestResult.ResultStatus != null && currentTestResult.ResultStatus.StateNumber < (int)TestResultStateNumber.Evaluated)
            {
                TestResult existingTestResult = null;
                lock (CentralLocker.Locker)
                {
                    existingTestResult = GetTestResult(customerId, eventId, (int)currentTestResult.TestType, currentTestResult.IsNewResultFlow);
                }

                if (existingTestResult != null && existingTestResult.ResultStatus != null && existingTestResult.ResultStatus.StateNumber >= (int)TestResultStateNumber.PreAudit
                        && !(existingTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit && existingTestResult.ResultStatus.Status == TestResultStatus.Incomplete)) return true;

                currentTestResult = _testResultSynchronizationService.SynchronizeTestResult(existingTestResult, currentTestResult, currentTestResult.IsNewResultFlow);
            }
            else if (currentTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated)
            {
                TestResult existingTestResult = null;
                lock (CentralLocker.Locker)
                {
                    existingTestResult = GetTestResults(customerId, eventId, currentTestResult.IsNewResultFlow);
                }
                currentTestResult = _testResultSynchronizationService.SynchronizePhysicianEvaluation(currentTestResult, existingTestResult);
            }


            var entity = _testResultFacotry.CreateTestResultEntity(currentTestResult, null);
            return PersistTestResults(entity, (int)currentTestResult.TestType, customerId, eventId, organizationRoleUserId);
        }

        public virtual bool DeleteCustomerTestReadingResult(long customerEventReadingId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                IRelationPredicateBucket bucket = new RelationPredicateBucket(CustomerEventReadingFields.CustomerEventReadingId == customerEventReadingId);

                if (myAdapter.DeleteEntitiesDirectly(typeof(CustomerEventReadingEntity), bucket) == 0)
                {
                    throw new PersistenceFailureException();
                }
            }
            return true;
        }

        public virtual List<OrderedPair<int, int>> GetListOfTestReadingAndReadingId(int testId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                IQueryable<OrderedPair<int, int>> testReadingEntities = from testReadings in linqMetaData.TestReading
                                                                        where testReadings.TestId == testId
                                                                        select new OrderedPair<int, int>
                                                                            (testReadings.ReadingId, testReadings.TestReadingId);
                return testReadingEntities.ToList();
            }
        }

        public virtual bool UpdateTestResultState(int state, bool isPartial, long customerEventScreeningTestId, long updateByOrgRoleUserId)
        {
            var customerEventTestStateEntity = new CustomerEventTestStateEntity { EvaluationState = Convert.ToByte(state), IsPartial = isPartial, UpdatedByOrgRoleUserId = updateByOrgRoleUserId, UpdatedOn = DateTime.Now };
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                IRelationPredicateBucket bucket = new RelationPredicateBucket(CustomerEventTestStateFields.CustomerEventScreeningTestId == customerEventScreeningTestId);
                if (myAdapter.UpdateEntitiesDirectly(customerEventTestStateEntity, bucket) == 0)
                {
                    throw new PersistenceFailureException();
                }
            }
            return true;
        }

        public bool UpdateTestResultStatusForCorrection(long customerEventScreeningTestId)
        {
            var customerEventTestStateEntity = new CustomerEventTestStateEntity { EvaluationState = Convert.ToByte(TestResultStateNumber.PreAudit), IsPartial = true };
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                IRelationPredicateBucket bucket = new RelationPredicateBucket(CustomerEventTestStateFields.CustomerEventScreeningTestId == customerEventScreeningTestId);
                if (myAdapter.UpdateEntitiesDirectly(customerEventTestStateEntity, bucket) == 0)
                {
                    throw new PersistenceFailureException();
                }
            }
            return true;
        }

        public void DeleteTestData(long eventId, long customerId, long testId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var customerEventScreeningTestId = (from ecr in linqMetaData.EventCustomerResult
                                                    join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                                    where ecr.EventId == eventId && ecr.CustomerId == customerId && cest.TestId == testId
                                                    select cest.CustomerEventScreeningTestId).SingleOrDefault();

                if (customerEventScreeningTestId < 1) return;

                var ifIds = linqMetaData.CustomerEventTestIncidentalFinding.Where(cetf => cetf.CustomerEventScreeningTestId == customerEventScreeningTestId).Select(cetf => cetf.CustomerEventTestIncidentalFindingId).ToArray();

                adapter.DeleteEntitiesDirectly("CustomerEventTestIncidentalFindingDetailEntity", new RelationPredicateBucket(CustomerEventTestIncidentalFindingDetailFields.CustomerEventTestIncidentalFindingId == ifIds));
                adapter.DeleteEntitiesDirectly("CustomerEventTestIncidentalFindingEntity", new RelationPredicateBucket(CustomerEventTestIncidentalFindingFields.CustomerEventScreeningTestId == customerEventScreeningTestId));
                adapter.DeleteEntitiesDirectly("CustomerEventReadingEntity", new RelationPredicateBucket(CustomerEventReadingFields.CustomerEventScreeningTestId == customerEventScreeningTestId));
                adapter.DeleteEntitiesDirectly("CustomerEventCriticalTestDataEntity", new RelationPredicateBucket(CustomerEventCriticalTestDataFields.CustomerEventScreeningTestId == customerEventScreeningTestId));
                adapter.DeleteEntitiesDirectly("CustomerEventPriorityInQueueDataEntity", new RelationPredicateBucket(CustomerEventPriorityInQueueDataFields.CustomerEventScreeningTestId == customerEventScreeningTestId));
                adapter.DeleteEntitiesDirectly("CustomerEventTestPhysicianEvaluationEntity", new RelationPredicateBucket(CustomerEventTestPhysicianEvaluationFields.CustomerEventScreeningTestId == customerEventScreeningTestId));
                adapter.DeleteEntitiesDirectly("CustomerEventTestStandardFindingEntity", new RelationPredicateBucket(CustomerEventTestStandardFindingFields.CustomerEventScreeningTestId == customerEventScreeningTestId));
                adapter.DeleteEntitiesDirectly("CustomerEventTestStateEntity", new RelationPredicateBucket(CustomerEventTestStateFields.CustomerEventScreeningTestId == customerEventScreeningTestId));
                adapter.DeleteEntitiesDirectly("TestMediaEntity", new RelationPredicateBucket(TestMediaFields.CustomerEventScreeningTestId == customerEventScreeningTestId));
                adapter.DeleteEntitiesDirectly("CustomerEventUnableScreenReasonEntity", new RelationPredicateBucket(CustomerEventUnableScreenReasonFields.CustomerEventScreeningTestId == customerEventScreeningTestId));
                adapter.DeleteEntitiesDirectly("TestNotPerformedEntity", new RelationPredicateBucket(TestNotPerformedFields.CustomerEventScreeningTestId == customerEventScreeningTestId));
                adapter.DeleteEntitiesDirectly("TestPerformedExternallyEntity", new RelationPredicateBucket(TestPerformedExternallyFields.CustomerEventScreeningTestId == customerEventScreeningTestId));
                adapter.DeleteEntitiesDirectly("CustomerEventScreeningTestsEntity", new RelationPredicateBucket(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId == customerEventScreeningTestId));
            }
        }

        public virtual bool DeleteIncidentalFinding(long customerEventTestIncidentalFindingId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                IRelationPredicateBucket bucket = new RelationPredicateBucket(CustomerEventTestIncidentalFindingFields.CustomerEventTestIncidentalFindingId == customerEventTestIncidentalFindingId);

                if (myAdapter.DeleteEntitiesDirectly(typeof(CustomerEventTestIncidentalFindingEntity), bucket) == 0)
                {
                    throw new PersistenceFailureException();
                }
            }
            return true;
        }

        protected bool SaveEntity(IEntity2 entityToSave, bool refetchAfterSave, bool recurse)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                using (var transactionScope = new TransactionScope())
                {
                    if (!myAdapter.SaveEntity(entityToSave, refetchAfterSave, recurse))
                    {
                        throw new PersistenceFailureException();
                    }
                    transactionScope.Complete();
                }
                return true;
            }
        }

        protected List<CustomerEventScreeningTestsEntity> GetTestResultsByTestId(long customerId, long eventId, int testId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    var linqMetaData = new LinqMetaData(myAdapter);

                    var customerEventScreeningQuery = linqMetaData.CustomerEventScreeningTests.
                        Join(linqMetaData.EventCustomerResult,
                             customerEventScreeningTest => customerEventScreeningTest.EventCustomerResultId,
                             ecr => ecr.EventCustomerResultId,
                             (customerEventScreeningTest, customerEventTest) =>
                             new { customerEventScreeningTest, customerEventTest }).
                        Where(
                        @t =>
                        @t.customerEventScreeningTest.TestId == testId &&
                        @t.customerEventTest.CustomerId == customerId && @t.customerEventTest.EventId == eventId).
                        Select(@t => @t.customerEventScreeningTest);

                    var customerEventScreening = customerEventScreeningQuery.WithPath(
                        prefetchPath =>
                        prefetchPath.Prefetch(customerEventScreeningTest => customerEventScreeningTest.CustomerEventReading).
                            Prefetch(
                            customerEventScreeningTest =>
                            customerEventScreeningTest.TestReadingCollectionViaCustomerEventReading).
                            Prefetch(customerEventScreeningTest => customerEventScreeningTest.StandardFindingTestReadingCollectionViaCustomerEventReading).
                            Prefetch(
                            customerEventScreeningTest => customerEventScreeningTest.CustomerEventTestStandardFinding).
                            Prefetch(customerEventScreeningTest => customerEventScreeningTest.StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding).
                            Prefetch(customerEventScreeningTest => customerEventScreeningTest.CustomerEventTestState).
                            Prefetch(customerEventScreeningTest => customerEventScreeningTest.CustomerEventTestIncidentalFinding).
                            Prefetch(customerEventScreeningTest => customerEventScreeningTest.IncidentalFindingsCollectionViaCustomerEventTestIncidentalFinding).
                            Prefetch(customerEventScreeningTest => customerEventScreeningTest.CustomerEventTestPhysicianEvaluation).
                            Prefetch(customerEventScreeningTest => customerEventScreeningTest.TestMedia).
                            Prefetch(customerEventScreeningTest => customerEventScreeningTest.FileCollectionViaTestMedia).
                            Prefetch(customerEventScreeningTest => customerEventScreeningTest.CustomerEventUnableScreenReason).
                            Prefetch(customerEventScreeningTest => customerEventScreeningTest.TestUnableScreenReasonCollectionViaCustomerEventUnableScreenReason).
                            Prefetch(customerEventScreeningTest => customerEventScreeningTest.TestNotPerformed).
                            Prefetch(customerEventScreeningTest => customerEventScreeningTest.TestPerformedExternally)
                        ).ToList();


                    customerEventScreening.ForEach(customerEventScreeningData => customerEventScreeningData.CustomerEventReading.ToList().ForEach(customerEventReading =>
                    {
                        customerEventReading.TestReading =
                            customerEventScreeningData.
                                TestReadingCollectionViaCustomerEventReading
                                .ToList().Find(
                                testReading =>
                                testReading.TestReadingId ==
                                customerEventReading.TestReadingId);
                    }));

                    customerEventScreening.ForEach(
                        customerEventScreeningData =>
                        customerEventScreeningData.CustomerEventTestIncidentalFinding.ToList().ForEach(
                            customerEventIncidentalFinding =>
                            customerEventIncidentalFinding.CustomerEventTestIncidentalFindingDetail.AddRange(
                                linqMetaData.CustomerEventTestIncidentalFindingDetail.
                                WithPath(prefetchPath => prefetchPath.Prefetch(incidentalFindingDetail => incidentalFindingDetail.IncidentalFindingReadingGroupItem)).
                                Where(
                                    incidentalFindingDetail =>
                                    incidentalFindingDetail.CustomerEventTestIncidentalFindingId ==
                                    customerEventIncidentalFinding.CustomerEventTestIncidentalFindingId).ToArray())));
                    scope.Complete();
                    return customerEventScreening;
                }
            }
        }

        protected bool PersistTestResults(CustomerEventScreeningTestsEntity customerEventScreeningEntity, int testId, long customerId, long eventId, long orgRoleUserId)
        {

            var eventCustomerResultRepository = new EventCustomerResultRepository();
            var eventCustomerResult = eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);

            eventCustomerResult.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(orgRoleUserId);
            eventCustomerResult.DataRecorderMetaData.DateModified = DateTime.Now;
            eventCustomerResultRepository.Save(eventCustomerResult);

            long customerEventScreeningTestId = GetCustomerEventScreeningTestId(testId, eventCustomerResult.Id);

            SynchronizeTestResults(customerId, eventId, testId, customerEventScreeningEntity);

            if (eventCustomerResult.Id > 0)
            {
                customerEventScreeningEntity.CustomerEventScreeningTestId = customerEventScreeningTestId;
                customerEventScreeningEntity.IsNew = customerEventScreeningEntity.CustomerEventScreeningTestId > 0 ? false : true;
                customerEventScreeningEntity.CustomerEventReading.ToList().ForEach(
                    customerEventReading =>
                    {
                        customerEventReading.IsNew = customerEventReading.CustomerEventReadingId > 0 ? false : true;
                        customerEventReading.CustomerEventScreeningTestId = customerEventScreeningEntity.CustomerEventScreeningTestId;
                    });

                customerEventScreeningEntity.EventCustomerResultId = eventCustomerResult.Id;
                customerEventScreeningEntity.CustomerEventTestState.ToList().ForEach(
                    customerEventTestState =>
                    {
                        customerEventTestState.IsNew = customerEventTestState.CustomerEventTestStateId > 0 ? false : true;
                        customerEventTestState.CustomerEventScreeningTestId = customerEventScreeningEntity.CustomerEventScreeningTestId;

                        if (customerEventTestState.EvaluationState == 4)
                            customerEventTestState.IsPartial = false;
                    });
                customerEventScreeningEntity.CustomerEventTestIncidentalFinding.ToList().ForEach(
                    customerEventTestIncidentalFinding =>
                    {
                        customerEventTestIncidentalFinding.IsNew = customerEventTestIncidentalFinding.CustomerEventTestIncidentalFindingId > 0 ? false : true;
                        customerEventTestIncidentalFinding.CustomerEventScreeningTestId = customerEventScreeningEntity.CustomerEventScreeningTestId;
                        customerEventTestIncidentalFinding.CustomerEventTestIncidentalFindingDetail.ToList().
                            ForEach(incidentalFindingDetail =>
                            {
                                incidentalFindingDetail.IsNew = incidentalFindingDetail.CustomerEventTestIncidentalFindingDetailId > 0 ? false : true;
                                incidentalFindingDetail.CustomerEventTestIncidentalFindingId = customerEventTestIncidentalFinding.CustomerEventTestIncidentalFindingId;
                            });
                    });
                customerEventScreeningEntity.CustomerEventTestStandardFinding.ToList().ForEach(
                    customerEventTestStandardFinding =>
                    {
                        customerEventTestStandardFinding.IsNew = customerEventTestStandardFinding.CustomerEventScreeningTestId > 0 && customerEventTestStandardFinding.CustomerEventTestStandardFindingId > 0 ? false : true;
                        customerEventTestStandardFinding.CustomerEventScreeningTestId = customerEventScreeningEntity.CustomerEventScreeningTestId;
                    });

                customerEventScreeningEntity.CustomerEventUnableScreenReason.ToList().ForEach(unableScreenReason =>
                                                                                                  {
                                                                                                      unableScreenReason.IsNew = unableScreenReason.CustomerEventUnableScreenReasonId > 0 ? false : true;
                                                                                                      unableScreenReason.CustomerEventScreeningTestId = customerEventScreeningEntity.CustomerEventScreeningTestId;
                                                                                                  });

                customerEventScreeningEntity.CustomerEventTestPhysicianEvaluation.ToList().ForEach(
                    physicianEvaluation =>
                    {
                        physicianEvaluation.IsNew = physicianEvaluation.CustomerEventTestPhysicianEvaluationId <= 0;
                        physicianEvaluation.CustomerEventScreeningTestId = customerEventScreeningEntity.CustomerEventScreeningTestId;
                    });

                customerEventScreeningEntity.TestNotPerformed.ToList().ForEach(
                    testNotPerformed =>
                    {
                        testNotPerformed.IsNew = testNotPerformed.Id <= 0;
                        testNotPerformed.CustomerEventScreeningTestId = customerEventScreeningEntity.CustomerEventScreeningTestId;
                    });

                customerEventScreeningEntity.TestPerformedExternally.ToList().ForEach(
                       tpe =>
                       {
                           tpe.IsNew = tpe.Id <= 0;
                           tpe.CustomerEventScreeningTestId = customerEventScreeningEntity.CustomerEventScreeningTestId;
                       });

                return SaveEntity(customerEventScreeningEntity, false, true);
            }

            return false;

        }

        public List<ResultReading<int>> GetAllReadings(int testId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var listReadings = (from readings in linqMetaData.Reading
                                    join testReadings in linqMetaData.TestReading
                                        on readings.ReadingId equals testReadings.ReadingId
                                    where testReadings.TestId == testId
                                    select readings).AsEnumerable();
                return new ResultReadingMapper<int>().MapMultiple(listReadings).ToList();
            }
        }

        private bool SynchronizeTestResults(long customerId, long eventId, int testId, CustomerEventScreeningTestsEntity customerEventScreeningEntity)
        {
            List<CustomerEventReadingEntity> customerEventReadingEntities = customerEventScreeningEntity.CustomerEventReading.ToList();
            List<CustomerEventTestIncidentalFindingEntity> customerEventTestIncidentalFindingEntities =
                customerEventScreeningEntity.CustomerEventTestIncidentalFinding.ToList();

            var customerEventScreenings = GetTestResultsByTestId(customerId, eventId, testId).FirstOrDefault();

            var customerEventUnableScreenReasonEntity = customerEventScreeningEntity.CustomerEventUnableScreenReason.ToList();
            var customerEventUnableScreenReasons = customerEventScreenings == null
                                                ? null
                                                : customerEventScreenings.CustomerEventUnableScreenReason;

            if (customerEventUnableScreenReasons != null && customerEventUnableScreenReasons.Count > 0)
            {
                var deletedUnableScreenReasons = customerEventUnableScreenReasons.Where(unableScreenReason =>
                    {
                        if (customerEventUnableScreenReasonEntity.Count < 1) return true;

                        if (customerEventUnableScreenReasonEntity.Find(unableScreenReasonEntity => unableScreenReasonEntity.CustomerEventUnableScreenReasonId == unableScreenReason.CustomerEventUnableScreenReasonId) == null) return true;

                        return false;
                    }).ToList();

                deletedUnableScreenReasons.ForEach(unableScreenReason => DeleteCustomerEventUnableScreenReason(unableScreenReason.CustomerEventUnableScreenReasonId));
            }

            if (customerEventScreenings != null && customerEventScreenings.TestPerformedExternally.Count() > 0)
            {
                customerEventScreeningEntity.TestPerformedExternally.ToList().ForEach(
                        tpe =>
                        {
                            tpe.Id = customerEventScreenings.TestPerformedExternally.Select(x => x.Id).FirstOrDefault();
                        });
            }

            if (customerEventScreenings != null && customerEventScreenings.CustomerEventTestStandardFinding.Count() > 0)
            {
                IEnumerable<long> ids = null;
                if (customerEventScreeningEntity.CustomerEventTestStandardFinding.Count < 1)
                {
                    ids = customerEventScreenings.CustomerEventTestStandardFinding.Select(cs => cs.CustomerEventTestStandardFindingId).ToArray();
                }
                else
                {
                    ids = customerEventScreenings.CustomerEventTestStandardFinding.Where(
                        cs =>
                        !customerEventScreeningEntity.CustomerEventTestStandardFinding.Select(
                            c => c.CustomerEventTestStandardFindingId).Contains(cs.CustomerEventTestStandardFindingId)).Select(cs => cs.CustomerEventTestStandardFindingId).ToArray();
                }
                if (ids.Count() > 0)
                    DeleteCustomerEventStandardFinding(ids);
            }

            var customerEventReadingTests = customerEventScreenings == null
                                                ? null
                                                : customerEventScreenings.CustomerEventReading;

            if (customerEventReadingTests != null && customerEventReadingEntities != null)
            {
                var deletedCustomerEventReadings =
                    customerEventReadingTests.Where(
                        customerEventReadingTest =>
                        customerEventReadingEntities.Find(
                            customerEventReadingEntity =>
                            customerEventReadingEntity.CustomerEventReadingId ==
                            customerEventReadingTest.CustomerEventReadingId) == null
                            ? true
                            : false);

                deletedCustomerEventReadings.ToList().ForEach(deletedCustomerEventReading => DeleteCustomerTestReadingResult(deletedCustomerEventReading.CustomerEventReadingId));
            }

            var customerEventIncidentalFindings = customerEventScreenings == null
                                                ? null
                                                : customerEventScreenings.CustomerEventTestIncidentalFinding;

            if (customerEventIncidentalFindings != null)
            {
                customerEventIncidentalFindings.ToList().ForEach(finding =>
                {
                    finding.CustomerEventTestIncidentalFindingDetail.ToList().ForEach(
                        findingDetail =>
                        {
                            var selectedFinding = customerEventTestIncidentalFindingEntities.Find(findingEntity =>
                            {
                                var selectedDetail = findingEntity.CustomerEventTestIncidentalFindingDetail.ToList().Find(findingDetailEntity =>
                                    findingDetailEntity.CustomerEventTestIncidentalFindingDetailId == findingDetail.CustomerEventTestIncidentalFindingDetailId);

                                if (selectedDetail == null)
                                    return false;
                                return true;
                            });

                            if (selectedFinding == null)
                            {
                                DeleteCustomerEventIncidentalDetails(findingDetail.CustomerEventTestIncidentalFindingDetailId);
                                return;
                            }
                            return;

                        });
                });

                var deletedIncidentalFindings = customerEventIncidentalFindings.Where(
                        customerEventIncidentalFinding =>
                        customerEventTestIncidentalFindingEntities.Find(
                            customerEventTestIncidentalFindingEntity =>
                            customerEventTestIncidentalFindingEntity.CustomerEventTestIncidentalFindingId ==
                            customerEventIncidentalFinding.CustomerEventTestIncidentalFindingId) == null
                            ? true
                            : false);
                deletedIncidentalFindings.ToList().ForEach(deletedIncidentalFinding => DeleteIncidentalFinding(deletedIncidentalFinding.CustomerEventTestIncidentalFindingId));


                var testNotPerformed = customerEventScreenings == null ? null : customerEventScreenings.TestNotPerformed;
                var testNotPerformedEntity = customerEventScreeningEntity.TestNotPerformed.ToList();
                if (testNotPerformed != null && testNotPerformed.Count > 0)
                {
                    var deletedTestNotPerformed = testNotPerformed.Where(tnp =>
                    {
                        if (testNotPerformedEntity.Count < 1) return true;

                        if (testNotPerformedEntity.Find(t => t.Id == tnp.Id) == null) return true;

                        return false;
                    }).ToList();

                    deletedTestNotPerformed.ForEach(unableScreenReason => DeleteCustomerTestNotPerformed(unableScreenReason.Id));
                }
            }

            return true;
        }

        protected long GetCustomerEventScreeningTestId(int testId, long eventCustomerResultId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    var linqMetaData = new LinqMetaData(myAdapter);
                    var customerEventScreeningTestData =
                        linqMetaData.CustomerEventScreeningTests.Where(
                            customerEventScreeningTest =>
                            customerEventScreeningTest.EventCustomerResultId == eventCustomerResultId &&
                            customerEventScreeningTest.TestId == testId).SingleOrDefault();

                    scope.Complete();

                    return customerEventScreeningTestData == null ? 0 : customerEventScreeningTestData.CustomerEventScreeningTestId;
                }
            }
        }

        private bool DeleteCustomerEventIncidentalDetails(long customerEventTestIncidentalFindingDetailId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                IRelationPredicateBucket bucket = new RelationPredicateBucket(CustomerEventTestIncidentalFindingDetailFields.CustomerEventTestIncidentalFindingDetailId == customerEventTestIncidentalFindingDetailId);

                myAdapter.DeleteEntitiesDirectly(typeof(CustomerEventTestIncidentalFindingDetailEntity), bucket);

            }
            return true;
        }

        protected bool DeleteCustomerEventTestImage(long testMediaId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                IRelationPredicateBucket bucket = new RelationPredicateBucket(TestMediaFields.MediaId == testMediaId);
                myAdapter.DeleteEntitiesDirectly(typeof(TestMediaEntity), bucket);
            }
            return true;
        }

        private bool DeleteCustomerEventUnableScreenReason(long customerEventUnableScreenReasonId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                IRelationPredicateBucket bucket = new RelationPredicateBucket(CustomerEventUnableScreenReasonFields.CustomerEventUnableScreenReasonId == customerEventUnableScreenReasonId);
                myAdapter.DeleteEntitiesDirectly(typeof(CustomerEventUnableScreenReasonEntity), bucket);
            }
            return true;
        }

        private bool DeleteCustomerTestNotPerformed(long testNotPerformedId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                IRelationPredicateBucket bucket = new RelationPredicateBucket(TestNotPerformedFields.Id == testNotPerformedId);
                myAdapter.DeleteEntitiesDirectly(typeof(TestNotPerformedEntity), bucket);
            }
            return true;
        }

        private bool DeleteCustomerEventStandardFinding(IEnumerable<long> customerEventtestStandardFindingIds)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                IRelationPredicateBucket bucket = new RelationPredicateBucket(CustomerEventTestStandardFindingFields.CustomerEventTestStandardFindingId == customerEventtestStandardFindingIds.ToArray());
                myAdapter.DeleteEntitiesDirectly(typeof(CustomerEventTestStandardFindingEntity), bucket);
            }
            return true;
        }

        protected void SaveTestMedia(IEnumerable<ResultMedia> resultMedia, long customerEventScreeningTestId, DataRecorderMetaData recorderData)
        {
            if (resultMedia == null) resultMedia = new List<ResultMedia>();

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var mediaIds = (from media in resultMedia where media.Id > 0 select media.Id).ToList();
                var testMediaalreadyinDbToDelete = (from media in linqMetaData.TestMedia
                                                    where media.CustomerEventScreeningTestId == customerEventScreeningTestId
                                                        && !mediaIds.Contains(media.MediaId)
                                                    select media).ToList();

                testMediaalreadyinDbToDelete.ForEach(media => DeleteCustomerEventTestImage(media.MediaId));
            }

            foreach (var media in resultMedia)
            {
                media.File.Id = SaveFile(media.File, recorderData);
                if (media.Thumbnail != null)
                    media.Thumbnail.Id = SaveFile(media.Thumbnail, recorderData);

                SaveTestMedia(media, customerEventScreeningTestId, recorderData);
            }

        }

        private static long SaveFile(File file, DataRecorderMetaData recorderData)
        {
            var fileRepository = new FileRepository();
            file.UploadedBy = recorderData.DataRecorderCreator;
            file.UploadedOn = recorderData.DateCreated;
            return fileRepository.Save(file).Id;
        }

        private void SaveTestMedia(ResultMedia media, long customerEventScreeningTestId, DataRecorderMetaData recorderData)
        {
            var testMediaEntity = new TestMediaEntity(media.Id)
            {
                CustomerEventScreeningTestId = customerEventScreeningTestId,
                FileId = media.File.Id,
                ThumbnailFileId = media.Thumbnail != null ? (long?)media.Thumbnail.Id : null,
                IsManual = media.ReadingSource == ReadingSource.Manual ? true : false,
                IsNew = media.Id > 0 ? false : true
            };

            if (media.Id <= 0)
            {
                testMediaEntity.CreatedByOrgRoleUserId = recorderData.DataRecorderCreator.Id;
                testMediaEntity.CreatedOn = recorderData.DateCreated;

            }

            SaveEntity(testMediaEntity, true, false);
        }

        protected void GetFileDataforResultmedia(List<ResultMedia> testMedia)
        {
            testMedia.ForEach(GetFileDataforResultmedia);
        }

        protected void GetFileDataforResultmedia(ResultMedia testMedia)
        {
            var fileRepository = new FileRepository();
            testMedia.File = fileRepository.GetById(testMedia.File.Id);

            if (testMedia.Thumbnail == null || testMedia.Thumbnail.Id < 1) return;
            testMedia.Thumbnail = fileRepository.GetById(testMedia.Thumbnail.Id);
        }


        public long GetNextCustomerPostAudit(long eventId, long customerId, bool isNewResultFlow)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var query = (from ecr in linqMetaData.EventCustomerResult
                             join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                             join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId

                             where ecr.EventId == eventId && (ecr.CustomerId == customerId || (ecr.ResultState == (int)TestResultStateNumber.Evaluated && ecr.IsPartial == false))
                             orderby ea.StartTime
                             select ecr.CustomerId);//.ToList();

                if (isNewResultFlow)
                {
                    query = (from ecr in linqMetaData.EventCustomerResult
                             join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                             join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId

                             where ecr.EventId == eventId && (ecr.CustomerId == customerId || (ecr.ResultState == (int)NewTestResultStateNumber.ArtifactSynced))
                             orderby ea.StartTime
                             select ecr.CustomerId);
                }

                var ecOrderbyAppTime = query.ToList();

                if (ecOrderbyAppTime.Count() > 1)
                {
                    if (ecOrderbyAppTime.Last() == customerId)
                        return ecOrderbyAppTime.First();

                    ecOrderbyAppTime = ecOrderbyAppTime.SkipWhile(t => t != customerId).ToList();
                    return ecOrderbyAppTime.ElementAt(1);
                }
                return 0;
            }
        }

        public long GetNextCustomerEntryandAudit(long eventId, long customerId, bool isNewResultFlow)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                IQueryable<long> query = null;

                if (isNewResultFlow)
                {

                    query = (from ec in linqMetaData.EventCustomers
                             join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                             where
                                 ec.EventId == eventId && !ec.NoShow && !ec.LeftWithoutScreeningReasonId.HasValue &&
                                 (ec.CustomerId == customerId ||
                                    !(
                                        from ecr in linqMetaData.EventCustomerResult
                                        where ecr.EventId == eventId
                                        select ecr.CustomerId
                                     ).Contains(ec.CustomerId)

                                    || (
                                        from ecr in linqMetaData.EventCustomerResult
                                        where ecr.EventId == eventId &&
                                            (
                                                ecr.ResultState == (int)NewTestResultStateNumber.NoResults
                                             || ecr.ResultState == (int)NewTestResultStateNumber.ResultEntryPartial
                                             || ecr.ResultState == (int)NewTestResultStateNumber.ResultEntryCompleted
                                            )
                                        select ecr.CustomerId
                                      ).Contains(ec.CustomerId)
                                )
                             orderby ea.StartTime
                             select ec.CustomerId);
                }
                else
                {
                    query = (from ec in linqMetaData.EventCustomers
                             join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                             where
                                 ec.EventId == eventId && !ec.NoShow && !ec.LeftWithoutScreeningReasonId.HasValue &&
                                 (ec.CustomerId == customerId ||
                                    !(
                                        from ecr in linqMetaData.EventCustomerResult
                                        where ecr.EventId == eventId
                                        select ecr.CustomerId
                                     ).Contains(ec.CustomerId)

                                    || (
                                        from ecr in linqMetaData.EventCustomerResult
                                        where ecr.EventId == eventId &&
                                            (
                                                ecr.ResultState == (int)TestResultStateNumber.NoResults
                                                || ecr.ResultState == (int)TestResultStateNumber.ManualEntry
                                                || ecr.ResultState == (int)TestResultStateNumber.ResultsUploaded
                                            )
                                        select ecr.CustomerId
                                      ).Contains(ec.CustomerId)
                                )
                             orderby ea.StartTime
                             select ec.CustomerId);
                }

                IList<long> ecOrderbyAppTime = query.ToList();

                if (ecOrderbyAppTime.Count() > 1)
                {
                    if (ecOrderbyAppTime.Last() == customerId)
                        return 0;

                    ecOrderbyAppTime = ecOrderbyAppTime.SkipWhile(t => t != customerId).ToList();
                    return ecOrderbyAppTime.ElementAt(1);
                }

                return 0;
            }
        }

        public IEnumerable<long> GetCustomerEventScreeningTestIds(long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var customerEventScreeningTestIds = (from cest in linqMetaData.CustomerEventScreeningTests
                                                     join ecr in linqMetaData.EventCustomerResult
                                                     on cest.EventCustomerResultId equals ecr.EventCustomerResultId
                                                     where ecr.EventId == eventId && ecr.CustomerId == customerId
                                                     select cest.CustomerEventScreeningTestId).ToArray();

                return customerEventScreeningTestIds;
            }
        }

        public void SetResultstoState(long eventId, long customerId, int number, bool isPartial, long updatedBy)
        {
            var customerEventScreeningTestIds = GetCustomerEventScreeningTestIds(eventId, customerId);
            SetResultstoState(number, isPartial, updatedBy, customerEventScreeningTestIds);
        }

        public void SetResultstoState(int number, bool isPartial, long updatedBy, IEnumerable<long> customerEventScreeningTestIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.UpdateEntitiesDirectly(new CustomerEventTestStateEntity
                 {
                     EvaluationState = (byte)number,
                     IsPartial = isPartial,
                     UpdatedByOrgRoleUserId = updatedBy,
                     UpdatedOn = DateTime.Now
                 },
                 new RelationPredicateBucket(CustomerEventTestStateFields.CustomerEventScreeningTestId == customerEventScreeningTestIds.ToArray()));
            }
        }

        public void UpdateStateforSkipEvaluation(long eventCustomerResultId, long? evaluatedby)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var customerEventScreeningTestIds = (from cest in linqMetaData.CustomerEventScreeningTests
                                                     where cest.EventCustomerResultId == eventCustomerResultId
                                                     select cest.CustomerEventScreeningTestId).ToArray();

                adapter.UpdateEntitiesDirectly(new CustomerEventTestStateEntity()
                {
                    EvaluatedByOrgRoleUserId = evaluatedby,
                    EvaluationState = (int)TestResultStateNumber.Evaluated,
                    IsPartial = false
                },
                                               new RelationPredicateBucket(
                                                   CustomerEventTestStateFields.CustomerEventScreeningTestId ==
                                                   customerEventScreeningTestIds));

            }
        }

        public void UpdateStateforCustomerNotification(long eventCustomerResultId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var customerEventScreeningTestIds = (from cest in linqMetaData.CustomerEventScreeningTests
                                                     where cest.EventCustomerResultId == eventCustomerResultId
                                                     select cest.CustomerEventScreeningTestId).ToArray();

                adapter.UpdateEntitiesDirectly(new CustomerEventTestStateEntity
                {
                    EvaluationState = (int)TestResultStateNumber.ResultDelivered,
                    IsPartial = false
                },
                new RelationPredicateBucket(
                    CustomerEventTestStateFields.CustomerEventScreeningTestId ==
                    customerEventScreeningTestIds));

            }
        }

        public void UpdateStateforPacketGenerated(long eventCustomerResultId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var customerEventScreeningTestIds = (from cest in linqMetaData.CustomerEventScreeningTests
                                                     where cest.EventCustomerResultId == eventCustomerResultId
                                                     select cest.CustomerEventScreeningTestId).ToArray();

                adapter.UpdateEntitiesDirectly(new CustomerEventTestStateEntity
                {
                    EvaluationState = (byte)TestResultStateNumber.PostAudit,
                    IsPartial = false
                },
                new RelationPredicateBucket(
                    CustomerEventTestStateFields.CustomerEventScreeningTestId ==
                    customerEventScreeningTestIds));

            }
        }

        public void UpdateStateforNotReviewableTests(long eventId, long customerId, bool isPartial, bool isNewResultFlow)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var notReviewableTestIds = (from et in linqMetaData.EventTest
                                            where et.EventId == eventId && ((et.IsTestReviewableByPhysician.HasValue && !et.IsTestReviewableByPhysician.Value)
                                            || (et.ResultEntryTypeId.HasValue && et.ResultEntryTypeId.Value == (long)ResultEntryType.Chat))
                                            select et.TestId).ToArray();

                //long[] customerEventScreeningTestIds;

                //if (isNewResultFlow)
                //{
                //    customerEventScreeningTestIds = (from ecr in linqMetaData.EventCustomerResult
                //                                     join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                //                                     join t in linqMetaData.Test on cest.TestId equals t.TestId
                //                                     where ecr.EventId == eventId && ecr.CustomerId == customerId && t.IsRecordable
                //                                     && (!TestGroup.TestReviewableByPhysician.Contains(t.TestId) || notReviewableTestIds.Contains(t.TestId))
                //                                     select cest.CustomerEventScreeningTestId).ToArray();
                //}
                //else
                //{
                //customerEventScreeningTestIds = (from ecr in linqMetaData.EventCustomerResult
                //                                 join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                //                                 join t in linqMetaData.Test on cest.TestId equals t.TestId
                //                                 where ecr.EventId == eventId && ecr.CustomerId == customerId && t.IsRecordable
                //                                 && (!t.IsTestReviewableByPhysician || notReviewableTestIds.Contains(t.TestId))
                //                                 select cest.CustomerEventScreeningTestId).ToArray();
                //}

                var customerEventScreeningTestIds = (from ecr in linqMetaData.EventCustomerResult
                                                     join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                                     join t in linqMetaData.Test on cest.TestId equals t.TestId
                                                     where ecr.EventId == eventId && ecr.CustomerId == customerId && t.IsRecordable
                                                     && (!t.IsTestReviewableByPhysician || notReviewableTestIds.Contains(t.TestId))
                                                     select cest.CustomerEventScreeningTestId).ToArray();


                adapter.UpdateEntitiesDirectly(new CustomerEventTestStateEntity
                {
                    EvaluationState = (int)TestResultStateNumber.Evaluated,
                    IsPartial = isPartial
                },
                new RelationPredicateBucket(
                    CustomerEventTestStateFields.CustomerEventScreeningTestId ==
                    customerEventScreeningTestIds));

            }
        }

        public IEnumerable<OrderedPair<string, string>> GetTestMedia(long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaDaata = new LinqMetaData(adapter);
                var mediaFiles = (from ecr in linqMetaDaata.EventCustomerResult
                                  join cset in linqMetaDaata.CustomerEventScreeningTests
                                  on ecr.EventCustomerResultId equals cset.EventCustomerResultId
                                  join tm in linqMetaDaata.TestMedia on cset.CustomerEventScreeningTestId equals
                                      tm.CustomerEventScreeningTestId
                                  join f in linqMetaDaata.File on tm.FileId equals f.FileId
                                  join tmnF in linqMetaDaata.File on tm.ThumbnailFileId equals tmnF.FileId
                                      into fileMedia
                                  from i in fileMedia.DefaultIfEmpty()
                                  where ecr.EventId == eventId && ecr.CustomerId == customerId
                                  select new OrderedPair<string, string>(f.Path, i.Path)).ToArray();

                return mediaFiles;
            }
        }

        public void DeleteTestDataByEventIdAndCustomerId(long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventCustomerresultId = (from ecr in linqMetaData.EventCustomerResult
                                             where ecr.EventId == eventId && ecr.CustomerId == customerId
                                             select ecr.EventCustomerResultId).FirstOrDefault();

                var customerEventScreeningTestIds = (from ecr in linqMetaData.EventCustomerResult
                                                     join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                                     where ecr.EventId == eventId && ecr.CustomerId == customerId
                                                     select cest.CustomerEventScreeningTestId).ToArray();

                if (customerEventScreeningTestIds.Count() < 1) return;

                var ifIds = linqMetaData.CustomerEventTestIncidentalFinding.Where(cetf => customerEventScreeningTestIds.Contains(cetf.CustomerEventScreeningTestId)).Select(cetf => cetf.CustomerEventTestIncidentalFindingId).ToArray();

                adapter.DeleteEntitiesDirectly("CustomerEventTestIncidentalFindingDetailEntity", new RelationPredicateBucket(CustomerEventTestIncidentalFindingDetailFields.CustomerEventTestIncidentalFindingId == ifIds));
                adapter.DeleteEntitiesDirectly("CustomerEventTestIncidentalFindingEntity", new RelationPredicateBucket(CustomerEventTestIncidentalFindingFields.CustomerEventScreeningTestId == customerEventScreeningTestIds));
                adapter.DeleteEntitiesDirectly("CustomerEventReadingEntity", new RelationPredicateBucket(CustomerEventReadingFields.CustomerEventScreeningTestId == customerEventScreeningTestIds));
                adapter.DeleteEntitiesDirectly("CustomerEventCriticalTestDataEntity", new RelationPredicateBucket(CustomerEventCriticalTestDataFields.CustomerEventScreeningTestId == customerEventScreeningTestIds));
                adapter.DeleteEntitiesDirectly("CustomerEventTestPhysicianEvaluationEntity", new RelationPredicateBucket(CustomerEventTestPhysicianEvaluationFields.CustomerEventScreeningTestId == customerEventScreeningTestIds));
                adapter.DeleteEntitiesDirectly("CustomerEventTestStandardFindingEntity", new RelationPredicateBucket(CustomerEventTestStandardFindingFields.CustomerEventScreeningTestId == customerEventScreeningTestIds));
                adapter.DeleteEntitiesDirectly("CustomerEventTestStateEntity", new RelationPredicateBucket(CustomerEventTestStateFields.CustomerEventScreeningTestId == customerEventScreeningTestIds));
                adapter.DeleteEntitiesDirectly("TestMediaEntity", new RelationPredicateBucket(TestMediaFields.CustomerEventScreeningTestId == customerEventScreeningTestIds));
                adapter.DeleteEntitiesDirectly("CustomerEventUnableScreenReasonEntity", new RelationPredicateBucket(CustomerEventUnableScreenReasonFields.CustomerEventScreeningTestId == customerEventScreeningTestIds));
                adapter.DeleteEntitiesDirectly("CustomerEventScreeningTestsEntity", new RelationPredicateBucket(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId == customerEventScreeningTestIds));

                adapter.DeleteEntitiesDirectly("KynLabValuesEntity", new RelationPredicateBucket(KynLabValuesFields.EventCustomerResultId == eventCustomerresultId));
                adapter.DeleteEntitiesDirectly("EventCustomerResultBloodLabEntity", new RelationPredicateBucket(EventCustomerResultBloodLabFields.EventCustomerResultId == eventCustomerresultId));

                var bucket = new RelationPredicateBucket(EventCustomerResultFields.EventId == eventId);
                bucket.PredicateExpression.AddWithAnd(EventCustomerResultFields.CustomerId == customerId);
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerResultEntity), bucket);
            }
        }

        public void RemoveSelfPresent(long eventId, long customerId, long testId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var id = (from ecr in linqMetaData.EventCustomerResult
                          join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                          where ecr.EventId == eventId && ecr.CustomerId == customerId && cest.TestId == testId
                          select cest.CustomerEventScreeningTestId).SingleOrDefault();

                adapter.UpdateEntitiesDirectly(new CustomerEventTestStateEntity { SelfPresent = false }, new RelationPredicateBucket(CustomerEventTestStateFields.CustomerEventScreeningTestId == id));
            }
        }

        public void RemovePriorityInQueue(long eventId, long customerId, long testId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var id = (from ecr in linqMetaData.EventCustomerResult
                          join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                          where ecr.EventId == eventId && ecr.CustomerId == customerId && cest.TestId == testId
                          select cest.CustomerEventScreeningTestId).SingleOrDefault();

                adapter.UpdateEntitiesDirectly(new CustomerEventTestStateEntity { IsPriorityInQueue = false }, new RelationPredicateBucket(CustomerEventTestStateFields.CustomerEventScreeningTestId == id));
            }
        }


        public void RemovePriorityInQueueByEventCustomerResultId(long eventCustomerResultId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var ids = (from ecr in linqMetaData.EventCustomerResult
                           join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                           where ecr.EventCustomerResultId == eventCustomerResultId
                           select cest.CustomerEventScreeningTestId).ToArray();

                adapter.UpdateEntitiesDirectly(new CustomerEventTestStateEntity { IsPriorityInQueue = false }, new RelationPredicateBucket(CustomerEventTestStateFields.CustomerEventScreeningTestId == ids.ToArray()));
            }
        }

        public long GetEventIdbySerialKeyAndTestId(int testId, string serialKey)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var readingId = (from r in linqMetaData.Reading
                                 join tr in linqMetaData.TestReading on r.ReadingId equals tr.ReadingId
                                 where r.Label == "Serial Key" && tr.TestId == testId
                                 select r.ReadingId
                                    ).First();

                var eventId = (from cer in linqMetaData.CustomerEventReading
                               join cest in linqMetaData.CustomerEventScreeningTests on cer.CustomerEventScreeningTestId equals cest.CustomerEventScreeningTestId
                               join tr in linqMetaData.TestReading on cer.TestReadingId equals tr.TestReadingId
                               join ecr in linqMetaData.EventCustomerResult on cest.EventCustomerResultId equals ecr.EventCustomerResultId
                               where tr.TestId == testId && tr.ReadingId == readingId && cer.Value == serialKey
                               select ecr.EventId).FirstOrDefault();

                return eventId;
            }

        }

        public long GetNextCustomerForPreAudit(long eventId, long customerId, bool isHraQuestionnaire)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IQueryable<long> query = null;

                var customerChartSigned = (from ecr in linqMetaData.EventCustomerResult
                                           where
                                               ecr.EventId == eventId && ecr.SignedOffBy.HasValue &&
                                               (ecr.CustomerId == customerId || (ecr.ResultState == (int)NewTestResultStateNumber.NoResults
                                                           || ecr.ResultState == (int)NewTestResultStateNumber.ResultEntryPartial
                                                           || ecr.ResultState == (int)NewTestResultStateNumber.ResultEntryCompleted))
                                           select ecr.EventCustomerResultId).ToArray();
                if (isHraQuestionnaire)
                {
                    var customerHaveEawvInOrderQuery = (from v in linqMetaData.VwGetEventCustomerEawvTestInOrder
                                                        where v.EventId == eventId
                                                        select v.EventCustomerId);
                    var tnpquery = (from tnp in linqMetaData.TestNotPerformed select tnp.CustomerEventScreeningTestId);

                    var customerMarkedTnpForEawv = (from cest in linqMetaData.CustomerEventScreeningTests
                                                    join ecr in linqMetaData.EventCustomerResult on cest.EventCustomerResultId equals ecr.EventCustomerResultId
                                                    where ecr.EventId == eventId && cest.TestId == (long)TestType.eAWV
                                                     && tnpquery.Contains(cest.CustomerEventScreeningTestId)
                                                    select ecr.EventCustomerResultId).ToArray();


                    var customerNothavingEawvInOrder = (from ec in linqMetaData.EventCustomers
                                                        where
                                                            ec.EventId == eventId && !ec.NoShow && !ec.LeftWithoutScreeningReasonId.HasValue &&
                                                            (ec.CustomerId == customerId ||
                                                               !(
                                                                   from ecr in linqMetaData.EventCustomerResult
                                                                   where ecr.EventId == eventId
                                                                   select ecr.CustomerId
                                                                ).Contains(ec.CustomerId)
                                                               || (
                                                                   from ecr in linqMetaData.EventCustomerResult
                                                                   where ecr.EventId == eventId &&
                                                                       (
                                                                           ecr.ResultState == (int)NewTestResultStateNumber.NoResults
                                                                        || ecr.ResultState == (int)NewTestResultStateNumber.ResultEntryPartial
                                                                        || ecr.ResultState == (int)NewTestResultStateNumber.ResultEntryCompleted
                                                                       )
                                                                   select ecr.CustomerId
                                                                 ).Contains(ec.CustomerId)
                                                           )
                                                        && !customerHaveEawvInOrderQuery.Contains(ec.EventCustomerId)

                                                        select ec.EventCustomerId).ToArray();

                    query = (from ec in linqMetaData.EventCustomers
                             join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                             where
                                 ec.EventId == eventId && !ec.NoShow && !ec.LeftWithoutScreeningReasonId.HasValue
                                 && (customerChartSigned.Contains(ec.EventCustomerId) || customerNothavingEawvInOrder.Contains(ec.EventCustomerId) || customerMarkedTnpForEawv.Contains(ec.EventCustomerId))

                             orderby ea.StartTime
                             select ec.CustomerId);
                }
                else
                {

                    query = (from ec in linqMetaData.EventCustomers
                             join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                             where
                                 ec.EventId == eventId && !ec.NoShow && !ec.LeftWithoutScreeningReasonId.HasValue
                                 && (customerChartSigned.Contains(ec.EventCustomerId))

                             orderby ea.StartTime
                             select ec.CustomerId);
                }

                IList<long> ecOrderbyAppTime = query.ToList();

                if (ecOrderbyAppTime.Count() > 1)
                {
                    if (ecOrderbyAppTime.Last() == customerId)
                        return 0;

                    ecOrderbyAppTime = ecOrderbyAppTime.SkipWhile(t => t != customerId).ToList();
                    return ecOrderbyAppTime.ElementAt(1);
                }

                return 0;
            }
        }

        public void UpdateStateforSkipEvaluationForNewResultFlow(long eventCustomerResultId, long? evaluatedby, bool isPartial)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var customerEventScreeningTestIds = (from cest in linqMetaData.CustomerEventScreeningTests
                                                     where cest.EventCustomerResultId == eventCustomerResultId
                                                     select cest.CustomerEventScreeningTestId).ToArray();

                adapter.UpdateEntitiesDirectly
                    (
                        new CustomerEventTestStateEntity()
                        {
                            EvaluatedByOrgRoleUserId = evaluatedby,
                            EvaluationState = (int)NewTestResultStateNumber.NpSigned,
                            IsPartial = isPartial
                        },
                        new RelationPredicateBucket(CustomerEventTestStateFields.CustomerEventScreeningTestId == customerEventScreeningTestIds)
                    );

            }
        }
    }
}
