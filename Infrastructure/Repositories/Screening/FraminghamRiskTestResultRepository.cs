using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Impl;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Infrastructure.Factories.Screening;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Medical.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Screening
{
    [DefaultImplementation(Interface = typeof(IFraminghamTestResultRepository))]
    public class FraminghamRiskTestResultRepository : TestResultRepository, IFraminghamTestResultRepository
    {

        private const long SmokerId = 1025;
        private const long DiabeticId = 1030;

        private readonly ITestResultFactory _testResultFactory;
        private readonly ITestResultSynchronizationService _testResultSynchronizationService;

        public FraminghamRiskTestResultRepository()
            : this(ReadingSource.Manual)
        {
        }

        public FraminghamRiskTestResultRepository(ReadingSource callingSource)
        {
            _testResultFactory = new FraminghamRiskTestResultFactory();
            _testResultSynchronizationService = new FraminghamRiskTestResultSynchronizationService(callingSource);
            _callingSource = callingSource;
        }

        public FraminghamRiskTestResultRepository(IPersistenceLayer persistenceLayer, ITestResultFactory testResultFactory, ITestResultSynchronizationService testResultSynchronizationService)
            : base(persistenceLayer)
        {
            _testResultFactory = testResultFactory;
            _testResultSynchronizationService = testResultSynchronizationService;
            _callingSource = ReadingSource.Manual;
        }

        public override List<ResultReading<int>> GetReadingsForTest()
        {
            return GetAllReadings((int)TestType.FraminghamRisk);
        }

        public override TestResult GetTestResults(long customerId, long eventId, bool isNewResultFlow)
        {
            List<CustomerEventScreeningTestsEntity> customerEventScreeningTests = GetTestResultsByTestId(customerId,
                                                                                                         eventId,
                                                                                                         (int)
                                                                                                         TestType.
                                                                                                             FraminghamRisk);

            long customerEventScreeningTestId = 0;

            if (customerEventScreeningTests == null || customerEventScreeningTests.Count <= 0)
            {
                customerEventScreeningTests = new List<CustomerEventScreeningTestsEntity>();
                var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(0);
                customerEventScreeningTestsEntity.CustomerEventTestState.Add(new CustomerEventTestStateEntity
                                                                                 {
                                                                                     SelfPresent = false,
                                                                                     EvaluationState =
                                                                                         (byte)
                                                                                         TestResultStateNumber.NoResults
                                                                                 });
                customerEventScreeningTests.Add(customerEventScreeningTestsEntity);
            }
            else
            {
                customerEventScreeningTestId = customerEventScreeningTests.First().CustomerEventScreeningTestId;
            }

            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            customerEventScreeningTests.ForEach(
                customerEventScreening => customerEventReadingEntities.AddRange(
                                              customerEventScreening.CustomerEventReading.Where(
                                                  customerEventReading =>
                                                  customerEventReading.TestReading.ReadingId ==
                                                  (int)ReadingLabels.Age ||
                                                  customerEventReading.TestReading.ReadingId ==
                                                  (int)ReadingLabels.Gender ||
                                                  customerEventReading.TestReading.ReadingId ==
                                                  (int)ReadingLabels.Smoker ||
                                                  customerEventReading.TestReading.ReadingId ==
                                                  (int)ReadingLabels.Diabetes)));

            if (customerEventReadingEntities.Count > 0)
            {
                customerEventScreeningTests.ForEach(
                    customerEventScreening =>
                    customerEventReadingEntities.ForEach(
                        customerEventReading => customerEventScreening.CustomerEventReading.Remove(customerEventReading)));
            }

            customerEventScreeningTests.ForEach(
                customerEventScreening =>
                customerEventScreening.CustomerEventReading.AddRange(
                    GetAgeGenderReading(customerId, customerEventReadingEntities)));


            customerEventScreeningTests.ForEach(
                customerEventScreening =>
                customerEventScreening.CustomerEventReading.AddRange(
                    GetLipidReading(customerId, eventId)));

            customerEventScreeningTests.ForEach(
                customerEventScreening =>
                customerEventScreening.CustomerEventReading.AddRange(
                    GetSmokerDiabeticReading(customerId, customerEventReadingEntities)));

            long eventCustomerResultId = 0;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var customerEventtest = linqMetaData.EventCustomerResult.Where(customerEvent => customerEvent.CustomerId == customerId && customerEvent.EventId == eventId).ToList().SingleOrDefault();

                if (customerEventtest != null)
                    eventCustomerResultId = customerEventtest.EventCustomerResultId;
            }

            var customerEventReadingEntitiesForSystolicDiastolic = eventCustomerResultId > 0 ? GetSystolicDiastolicReading(eventCustomerResultId).ToList() : null;

            if (customerEventReadingEntitiesForSystolicDiastolic != null && customerEventReadingEntitiesForSystolicDiastolic.Count > 0)
            {
                customerEventReadingEntities = new List<CustomerEventReadingEntity>();

                customerEventReadingEntitiesForSystolicDiastolic.ForEach(entity =>
                {
                    entity.CustomerEventReadingId = 0;
                    entity.CustomerEventScreeningTestId = customerEventScreeningTestId;
                });

                customerEventScreeningTests.ForEach(
                customerEventScreening => customerEventReadingEntities.AddRange(
                                              customerEventScreening.CustomerEventReading.Where(
                                                  customerEventReading =>
                                                  customerEventReading.TestReading.ReadingId ==
                                                  (int)ReadingLabels.SystolicRight ||
                                                  customerEventReading.TestReading.ReadingId ==
                                                  (int)ReadingLabels.DiastolicRight)));

                if (customerEventReadingEntities.Count > 0)
                {
                    customerEventScreeningTests.ForEach(
                        customerEventScreening =>
                        customerEventReadingEntities.ForEach(
                            customerEventReading => customerEventScreening.CustomerEventReading.Remove(customerEventReading)));
                }

                customerEventScreeningTests.ForEach(
                    customerEventScreening =>
                    customerEventScreening.CustomerEventReading.AddRange(customerEventReadingEntitiesForSystolicDiastolic));
            }


            var testResult = _testResultFactory.CreateTestResults(customerEventScreeningTests).SingleOrDefault();
            if (testResult == null) return null;
            testResult.IsNewResultFlow = isNewResultFlow;
            return testResult;
        }

        public override bool SaveTestResults(TestResult currentTestResult, long customerId, long eventId, long orgRoleUserId)
        {
            TestResult synchronizedTestResult = null;
            if (currentTestResult.IsNewResultFlow)
            {
                if (SaveNewTestResult(currentTestResult, customerId, eventId, ref synchronizedTestResult)) return true;
            }
            else
            {
                if (SaveOldTestResult(currentTestResult, customerId, eventId, ref synchronizedTestResult)) return true;
            }

            var customerEventScreeningEntity = _testResultFactory.CreateTestResultEntity(synchronizedTestResult, GetListOfTestReadingAndReadingId((int)TestType.FraminghamRisk));

            lock (CentralLocker.Locker)
            {
                return PersistTestResults(customerEventScreeningEntity, (int)TestType.FraminghamRisk, customerId, eventId, orgRoleUserId);
            }
        }

        public List<FraminghamRiskTestResult> GetTestResults(long customerId)
        {
            var framinghamRiskTestResults = new List<FraminghamRiskTestResult>();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var customerEventIds = from ecr in linqMetaData.EventCustomerResult
                                       join customerEventScreeningTests in linqMetaData.CustomerEventScreeningTests on
                                           ecr.EventCustomerResultId equals
                                           customerEventScreeningTests.EventCustomerResultId
                                       join customerEventTestState in linqMetaData.CustomerEventTestState on
                                           customerEventScreeningTests.CustomerEventScreeningTestId equals
                                           customerEventTestState.CustomerEventScreeningTestId
                                       where
                                           ecr.CustomerId == customerId &&
                                           customerEventScreeningTests.TestId == (long)TestType.FraminghamRisk
                                       select
                                           new
                                               {
                                                   ecr.EventId,
                                               };

                foreach (var eventIds in customerEventIds.ToList())
                {
                    if (eventIds != null)
                    {
                        framinghamRiskTestResults.Add(
                            GetTestResults(customerId, eventIds.EventId, false) as FraminghamRiskTestResult);
                    }
                }
                return framinghamRiskTestResults;
            }
        }

        public bool UpdateFraminghamValue(long customerEventScreeningTestId, decimal framinghamValue)
        {
            var testReadingId = GetListOfTestReadingAndReadingId((int)TestType.FraminghamRisk).Find(testReadingReadingPair =>
                                                                                            (testReadingReadingPair.
                                                                                                 FirstValue ==
                                                                                             (int)
                                                                                             ReadingLabels.
                                                                                                 FraminghamRisk)).
                SecondValue;
            var customerEventReadingEntity = new CustomerEventReadingEntity
                                                 {
                                                     Value = framinghamValue.ToString(),
                                                     TestReadingId = testReadingId,
                                                     CustomerEventScreeningTestId =
                                                         customerEventScreeningTestId
                                                 };

            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var framinghamCustomerReading = linqMetaData.CustomerEventReading.Where(customerEventReading => customerEventReading.CustomerEventScreeningTestId == customerEventScreeningTestId
                    && customerEventReading.TestReadingId == testReadingId).SingleOrDefault();

                if (framinghamCustomerReading != null && framinghamCustomerReading.CustomerEventReadingId > 0)
                {
                    IRelationPredicateBucket bucket = new RelationPredicateBucket(CustomerEventReadingFields.TestReadingId == testReadingId);
                    bucket.PredicateExpression.AddWithAnd(CustomerEventReadingFields.CustomerEventScreeningTestId ==
                                                          customerEventScreeningTestId);

                    if (myAdapter.UpdateEntitiesDirectly(customerEventReadingEntity, bucket) == 0)
                    {
                        throw new PersistenceFailureException();
                    }
                }
                else
                {
                    if (!myAdapter.SaveEntity(customerEventReadingEntity))
                    {
                        throw new PersistenceFailureException();
                    }
                }
                return true;
            }
        }

        private IEnumerable<CustomerEventReadingEntity> GetSmokerDiabeticReading(long customerId, IEnumerable<CustomerEventReadingEntity> eventReadingEntities)
        {
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var smokerDiabeticData = from healthInformation in linqMetaData.CustomerHealthInfo
                                         where healthInformation.CustomerId == customerId
                                         select new
                                         {
                                             Id = healthInformation.CustomerHealthQuestionId,
                                             Value = healthInformation.HealthQuestionAnswer
                                         };

                smokerDiabeticData =
                    smokerDiabeticData.Where(
                        smokerDiabetic => smokerDiabetic.Id == SmokerId || smokerDiabetic.Id == DiabeticId);

                var smokerData =
                    customerEventReadingEntities.Where(
                        customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.Smoker).
                        SingleOrDefault();

                var diabeticData =
                    customerEventReadingEntities.Where(
                        customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.Diabetes).
                        SingleOrDefault();

                foreach (var data in smokerDiabeticData)
                {
                    var customerEventReadingEntity = new CustomerEventReadingEntity()
                                                         {
                                                             CustomerEventReadingId =
                                                                 data.Id == SmokerId
                                                                     ? smokerData != null
                                                                           ? smokerData.CustomerEventReadingId
                                                                           : 0
                                                                     : diabeticData != null
                                                                           ? diabeticData.CustomerEventReadingId
                                                                           : 0,
                                                             Value =
                                                                 data.Value == "Yes"
                                                                     ? true.ToString()
                                                                     : false.ToString(),
                                                             TestReading = new TestReadingEntity
                                                                               {
                                                                                   ReadingId =
                                                                                       data.Id == SmokerId
                                                                                           ? (int)ReadingLabels.Smoker
                                                                                           : (int)
                                                                                             ReadingLabels.Diabetes
                                                                               }
                                                         };
                    customerEventReadingEntities.Add(customerEventReadingEntity);
                }

            }
            return customerEventReadingEntities;
        }

        private IEnumerable<CustomerEventReadingEntity> GetLipidReading(long customerId, long eventId)
        {
            List<CustomerEventScreeningTestsEntity> customerEventScreeningTests = GetTestResultsByTestId(customerId,
                                                                                                         eventId,
                                                                                                         (int)
                                                                                                         TestType.
                                                                                                             Lipid);

            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            customerEventScreeningTests.ForEach(
                customerEventScreening =>
                customerEventReadingEntities.AddRange(
                    customerEventScreening.CustomerEventReading.Where(
                        testReading => testReading.TestReading.ReadingId == (long)ReadingLabels.TotalCholestrol ||
                                       testReading.TestReading.ReadingId == (long)ReadingLabels.HDL ||
                                       testReading.TestReading.ReadingId == (long)ReadingLabels.LDL)));

            return customerEventReadingEntities;
        }

        private IEnumerable<CustomerEventReadingEntity> GetSystolicDiastolicReading(long eventCustomerResultId)
        {
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var listPadPair = GetListOfTestReadingAndReadingId((int)TestType.PAD);
                var listAsiPair = GetListOfTestReadingAndReadingId((int)TestType.ASI);

                var selectedPadPair = listPadPair.FindAll(padPair => padPair.FirstValue == (int)ReadingLabels.SystolicRight || padPair.FirstValue == (int)ReadingLabels.DiastolicRight);
                var selectedAsiPair = listAsiPair.FindAll(asiPair => asiPair.FirstValue == (int)ReadingLabels.SystolicRight || asiPair.FirstValue == (int)ReadingLabels.DiastolicRight);

                string systolicVal, diastolicVal;
                systolicVal = diastolicVal = string.Empty;

                var recordForSystolicDiastolic = linqMetaData.CustomerEventScreeningTests.Where(customerEventScreeningTest =>
                    customerEventScreeningTest.EventCustomerResultId == eventCustomerResultId &&
                    (customerEventScreeningTest.TestId == (long)TestType.PAD || customerEventScreeningTest.TestId == (long)TestType.ASI)).ToList();

                if (recordForSystolicDiastolic == null || recordForSystolicDiastolic.Count < 1) return customerEventReadingEntities;

                recordForSystolicDiastolic.ForEach(record =>
                {
                    if (record.TestId == (long)TestType.PAD)
                    {
                        var customerEventReadings = linqMetaData.CustomerEventReading.Where(eventReading => eventReading.CustomerEventScreeningTestId == record.CustomerEventScreeningTestId).ToList();

                        if (string.IsNullOrEmpty(systolicVal))
                        {
                            var systolicReadingFromPad = customerEventReadings.Find(eventReading => selectedPadPair.Where(padpair => padpair.FirstValue == (int)ReadingLabels.SystolicRight).SingleOrDefault().SecondValue == eventReading.TestReadingId);
                            if (systolicReadingFromPad != null)
                                systolicVal = systolicReadingFromPad.Value;
                        }

                        if (string.IsNullOrEmpty(diastolicVal))
                        {
                            var diastolicReadingFromPad = customerEventReadings.Find(eventReading => selectedPadPair.Where(padpair => padpair.FirstValue == (int)ReadingLabels.DiastolicRight).SingleOrDefault().SecondValue == eventReading.TestReadingId);
                            if (diastolicReadingFromPad != null)
                                diastolicVal = diastolicReadingFromPad.Value;
                        }
                    }
                    else if (record.TestId == (long)TestType.ASI)
                    {
                        var customerEventReadings = linqMetaData.CustomerEventReading.Where(eventReading => eventReading.CustomerEventScreeningTestId == record.CustomerEventScreeningTestId).ToList();

                        if (string.IsNullOrEmpty(systolicVal))
                        {
                            var systolicReadingFromAsi = customerEventReadings.Find(eventReading => selectedAsiPair.Where(asiPair => asiPair.FirstValue == (int)ReadingLabels.SystolicRight).SingleOrDefault().SecondValue == eventReading.TestReadingId);
                            if (systolicReadingFromAsi != null)
                                systolicVal = systolicReadingFromAsi.Value;
                        }

                        if (string.IsNullOrEmpty(diastolicVal))
                        {
                            var diastolicReadingFromAsi = customerEventReadings.Find(eventReading => selectedAsiPair.Where(asiPair => asiPair.FirstValue == (int)ReadingLabels.DiastolicRight).SingleOrDefault().SecondValue == eventReading.TestReadingId);
                            if (diastolicReadingFromAsi != null)
                                diastolicVal = diastolicReadingFromAsi.Value;
                        }
                    }
                });

                if (!string.IsNullOrEmpty(diastolicVal))
                {
                    var customerEventReadingEntity = new CustomerEventReadingEntity(0)
                    {
                        Value = diastolicVal,
                        TestReading = new TestReadingEntity
                        {
                            ReadingId =
                                (int)ReadingLabels.DiastolicRight
                        }
                    };
                    customerEventReadingEntities.Add(customerEventReadingEntity);
                }

                if (!string.IsNullOrEmpty(systolicVal))
                {
                    var customerEventReadingEntity = new CustomerEventReadingEntity(0)
                    {
                        Value = systolicVal,
                        TestReading = new TestReadingEntity
                        {
                            ReadingId =
                                (int)ReadingLabels.SystolicRight
                        }
                    };
                    customerEventReadingEntities.Add(customerEventReadingEntity);
                }
            }
            return customerEventReadingEntities;
        }

        private IEnumerable<CustomerEventReadingEntity> GetAgeGenderReading(long customerId, IEnumerable<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            var eventReadingEntities = new List<CustomerEventReadingEntity>();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var customerInformation = from users in linqMetaData.User
                                          join oru in linqMetaData.OrganizationRoleUser on users.UserId equals oru.UserId
                                          join customers in linqMetaData.CustomerProfile on oru.OrganizationRoleUserId equals
                                              customers.CustomerId
                                          where customers.CustomerId == customerId
                                          select new { users.Dob, customers.Gender };

                var customerData = customerInformation.SingleOrDefault();

                var userBirthDateYear = customerData.Dob.Value.Year;

                var customerEventReadingEntity =
                    customerEventReadingEntities.Where(
                        customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.Age).
                        SingleOrDefault();

                eventReadingEntities.Add(
                    new CustomerEventReadingEntity(customerEventReadingEntity != null
                                                       ? customerEventReadingEntity.CustomerEventReadingId
                                                       : 0)
                        {
                            Value = (DateTime.Today.Year - userBirthDateYear).ToString(),
                            TestReading = new TestReadingEntity() { ReadingId = (int)ReadingLabels.Age }
                        });

                customerEventReadingEntity =
                    customerEventReadingEntities.Where(
                        customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.Gender)
                        .
                        SingleOrDefault();
                eventReadingEntities.Add(
                    new CustomerEventReadingEntity(customerEventReadingEntity != null
                                                       ? customerEventReadingEntity.CustomerEventReadingId
                                                       : 0)
                        {
                            Value = customerData.Gender,
                            TestReading = new TestReadingEntity() { ReadingId = (int)ReadingLabels.Gender }
                        });

                return eventReadingEntities;
            }
        }

        private bool SaveOldTestResult(TestResult currentTestResult, long customerId, long eventId, ref TestResult synchronizedTestResult)
        {
            if (currentTestResult != null && currentTestResult.ResultStatus != null && currentTestResult.ResultStatus.StateNumber < (int)TestResultStateNumber.Evaluated)
            {
                TestResult existingTestResult = null;
                lock (CentralLocker.Locker)
                {
                    existingTestResult = this.GetTestResults(customerId, eventId, currentTestResult.IsNewResultFlow);
                }

                // TODO: need to throw an exception that records are already being audited. Will not be updated.
                if (existingTestResult != null && existingTestResult.ResultStatus != null && existingTestResult.ResultStatus.StateNumber >= (int)TestResultStateNumber.PreAudit
                    && !(existingTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated && existingTestResult.ResultStatus.Status == TestResultStatus.Incomplete)) return true;
                synchronizedTestResult = _testResultSynchronizationService.SynchronizeTestResult(existingTestResult, currentTestResult, currentTestResult.IsNewResultFlow);
                var compareToResultReadings = GetAllReadings((int)TestType.FraminghamRisk);
                synchronizedTestResult = _testResultSynchronizationService.IsTestIncomplete(compareToResultReadings, synchronizedTestResult, currentTestResult.IsNewResultFlow);
                synchronizedTestResult = _testResultSynchronizationService.GetManualEntryUploadStatus(compareToResultReadings, synchronizedTestResult, currentTestResult.IsNewResultFlow);
            }
            else
            {
                synchronizedTestResult = currentTestResult;
            }
            return false;
        }

        private bool SaveNewTestResult(TestResult currentTestResult, long customerId, long eventId, ref TestResult synchronizedTestResult)
        {
            if (currentTestResult != null && currentTestResult.ResultStatus != null && currentTestResult.ResultStatus.StateNumber < (int)NewTestResultStateNumber.Evaluated)
            {
                TestResult existingTestResult = null;
                lock (CentralLocker.Locker)
                {
                    existingTestResult = this.GetTestResults(customerId, eventId, currentTestResult.IsNewResultFlow);
                }

                // TODO: need to throw an exception that records are already being audited. Will not be updated.
                if (existingTestResult != null && existingTestResult.ResultStatus != null && existingTestResult.ResultStatus.StateNumber >= (int)NewTestResultStateNumber.PreAudit
                    && !(existingTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated && existingTestResult.ResultStatus.Status == TestResultStatus.Incomplete)) return true;
                synchronizedTestResult = _testResultSynchronizationService.SynchronizeTestResult(existingTestResult, currentTestResult, currentTestResult.IsNewResultFlow);
                var compareToResultReadings = GetAllReadings((int)TestType.FraminghamRisk);
                synchronizedTestResult = _testResultSynchronizationService.IsTestIncomplete(compareToResultReadings, synchronizedTestResult, currentTestResult.IsNewResultFlow);
                synchronizedTestResult = _testResultSynchronizationService.GetManualEntryUploadStatus(compareToResultReadings, synchronizedTestResult, currentTestResult.IsNewResultFlow);
            }
            else
            {
                synchronizedTestResult = currentTestResult;
            }
            return false;
        }
    }
}