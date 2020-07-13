﻿using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Impl;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Infrastructure.Factories.Screening;
using Falcon.App.Infrastructure.Medical.Interfaces;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Screening
{
    public class CholesterolTestRepository : TestResultRepository
    {
        private ITestResultFactory _testResultFactory;
        private readonly ITestResultSynchronizationService _testResultSynchronizationService;

        public CholesterolTestRepository()
            : this(ReadingSource.Manual)
        {
        }

        public CholesterolTestRepository(ReadingSource callingSource)
        {
            _testResultFactory = new CholesterolTestResultFactory(true);
            _testResultSynchronizationService = new CholesterolTestResultSynchronizationService(callingSource);
            _callingSource = callingSource;
        }

        public override TestResult GetTestResults(long customerId, long eventId, bool isNewResultFlow)
        {
            var customer = new CustomerRepository().GetCustomer(customerId);
            _testResultFactory = new CholesterolTestResultFactory(customer.Gender != Gender.Female);
            List<CustomerEventScreeningTestsEntity> customerEventScreeningTests = GetTestResultsByTestId(customerId, eventId, (int)TestType.Cholesterol);

            var testResult = _testResultFactory.CreateTestResults(customerEventScreeningTests).SingleOrDefault();
            if (testResult == null) return null;
            testResult.IsNewResultFlow = isNewResultFlow;
            return testResult;
        }

        public override bool SaveTestResults(TestResult currentTestResult, long customerId, long eventId, long orgRoleUserId)
        {
            var customer = new CustomerRepository().GetCustomer(customerId);
            _testResultFactory = new CholesterolTestResultFactory(customer.Gender != Gender.Female);
            TestResult synchronizedTestResult = null;

            if (currentTestResult.IsNewResultFlow)
            {
                if (SaveNewTestResult(currentTestResult, customerId, eventId, ref synchronizedTestResult)) return true;
            }
            else
            {
                if (SaveOldTestResult(currentTestResult, customerId, eventId, ref synchronizedTestResult)) return true;
            }

            var customerEventScreeningEntity =
                _testResultFactory.CreateTestResultEntity(synchronizedTestResult, GetListOfTestReadingAndReadingId((int)TestType.Cholesterol));

            using (var scope = new TransactionScope())
            {
                var result = PersistTestResults(customerEventScreeningEntity, (int)TestType.Cholesterol, customerId, eventId, orgRoleUserId);
                scope.Complete();
                return result;
            }
        }

        public override List<ResultReading<int>> GetReadingsForTest()
        {
            return GetAllReadings((int)TestType.Cholesterol);
        }

        public bool UpdateFraminghamValue(long customerEventScreeningTestId, decimal framinghamValue)
        {
            var testReadingId = GetListOfTestReadingAndReadingId((int)TestType.Cholesterol).Find(testReadingReadingPair =>
                                                                                            (testReadingReadingPair.
                                                                                                 FirstValue ==
                                                                                             (int)
                                                                                             ReadingLabels.
                                                                                                 FraminghamRisk)).SecondValue;
            var customerEventReadingEntity = new CustomerEventReadingEntity
                                                                        {
                                                                            Value = framinghamValue.ToString(),
                                                                            TestReadingId = testReadingId,
                                                                            CustomerEventScreeningTestId =
                                                                                customerEventScreeningTestId
                                                                        };
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                IRelationPredicateBucket bucket = new RelationPredicateBucket(CustomerEventReadingFields.TestReadingId == testReadingId);
                bucket.PredicateExpression.AddWithAnd(CustomerEventReadingFields.CustomerEventScreeningTestId ==
                                                      customerEventScreeningTestId);
                if (myAdapter.UpdateEntitiesDirectly(customerEventReadingEntity, bucket) == 0)
                {
                    throw new PersistenceFailureException();
                }
                return true;
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
                    && !(existingTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit && existingTestResult.ResultStatus.Status == TestResultStatus.Incomplete)) return true;

                synchronizedTestResult = _testResultSynchronizationService.SynchronizeTestResult(existingTestResult, currentTestResult, currentTestResult.IsNewResultFlow);
                var compareToResultReadings = GetAllReadings((int)TestType.Cholesterol);
                synchronizedTestResult = _testResultSynchronizationService.IsTestIncomplete(compareToResultReadings, synchronizedTestResult, currentTestResult.IsNewResultFlow);
                synchronizedTestResult = _testResultSynchronizationService.GetManualEntryUploadStatus(compareToResultReadings, synchronizedTestResult, currentTestResult.IsNewResultFlow);
            }
            else
            {
                if (currentTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated)
                {
                    TestResult existingTestResult = null;
                    lock (CentralLocker.Locker)
                    {
                        existingTestResult = GetTestResults(customerId, eventId, currentTestResult.IsNewResultFlow);
                    }
                    synchronizedTestResult = _testResultSynchronizationService.SynchronizePhysicianEvaluation(currentTestResult, existingTestResult);
                }
                else
                {
                    synchronizedTestResult = currentTestResult;
                }
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
                    && !(existingTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit && existingTestResult.ResultStatus.Status == TestResultStatus.Incomplete)) return true;

                synchronizedTestResult = _testResultSynchronizationService.SynchronizeTestResult(existingTestResult, currentTestResult, currentTestResult.IsNewResultFlow);
                var compareToResultReadings = GetAllReadings((int)TestType.Cholesterol);
                synchronizedTestResult = _testResultSynchronizationService.IsTestIncomplete(compareToResultReadings, synchronizedTestResult, currentTestResult.IsNewResultFlow);
                synchronizedTestResult = _testResultSynchronizationService.GetManualEntryUploadStatus(compareToResultReadings, synchronizedTestResult, currentTestResult.IsNewResultFlow);
            }
            else
            {
                if (currentTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated)
                {
                    TestResult existingTestResult = null;
                    lock (CentralLocker.Locker)
                    {
                        existingTestResult = GetTestResults(customerId, eventId, currentTestResult.IsNewResultFlow);
                    }
                    synchronizedTestResult = _testResultSynchronizationService.SynchronizePhysicianEvaluation(currentTestResult, existingTestResult);
                }
                else
                {
                    synchronizedTestResult = currentTestResult;
                }
            }
            return false;
        }
    }
}
