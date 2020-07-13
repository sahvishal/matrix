using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Impl;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Infrastructure.Factories.Screening;
using Falcon.App.Infrastructure.Medical.Factories;
using Falcon.App.Infrastructure.Medical.Interfaces;
using Falcon.App.Infrastructure.Medical.Repositories;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.Data.EntityClasses;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Falcon.App.Infrastructure.Repositories.Screening
{
    public class CsTestRepository : TestResultRepository
    {
        private ITestResultFactory _testResultFactory;
        private readonly ITestResultSynchronizationService _testResultSynchronizationService;
        private readonly ITestPerformedExternallyRepository _testPerformedExternallyRepository;
        private readonly ITestPerformedExternallyFactory _testPerformedExternallyFactory;

        public CsTestRepository()
            : this(ReadingSource.Manual)
        {
        }

        public CsTestRepository(ReadingSource callingSource)
        {
            _testResultFactory = new CsTestResultFactory(true);
            _testResultSynchronizationService = new CsTestResultSynchronizationService(callingSource);
            _testPerformedExternallyRepository = new TestPerformedExternallyRepository();
            _testPerformedExternallyFactory = new TestPerformedExternallyFactory();
            _callingSource = callingSource;
        }

        public override TestResult GetTestResults(long customerId, long eventId, bool isNewResultFlow)
        {
            var customer = new CustomerRepository().GetCustomer(customerId);
            _testResultFactory = new CsTestResultFactory(customer.Gender == Gender.Female ? false : true);
            List<CustomerEventScreeningTestsEntity> customerEventScreeningTests = GetTestResultsByTestId(customerId, eventId, (int)TestType.Cs);

            var testResult = _testResultFactory.CreateTestResults(customerEventScreeningTests).SingleOrDefault();
            if (testResult == null) return null;

            var csTestResult = (CsTestResult)testResult;
            if (csTestResult.ResultImage != null) GetFileDataforResultmedia(csTestResult.ResultImage);
            testResult.IsNewResultFlow = isNewResultFlow;
            return testResult;
        }

        public override bool SaveTestResults(TestResult currentTestResult, long customerId, long eventId, long orgRoleUserId)
        {
            var customer = new CustomerRepository().GetCustomer(customerId);
            _testResultFactory = new CsTestResultFactory(customer.Gender == Gender.Female ? false : true);
            TestResult synchronizedTestResult = null;

            if (currentTestResult.IsNewResultFlow)
            {
                if (SaveNewTestResult(currentTestResult, customerId, eventId, ref synchronizedTestResult)) return true;
            }
            else
            {
                if (SaveOldTestResult(currentTestResult, customerId, eventId, ref synchronizedTestResult)) return true;
            }

            var customerEventScreeningEntity = _testResultFactory.CreateTestResultEntity(synchronizedTestResult, GetListOfTestReadingAndReadingId((int)TestType.Cs));

            using (var scope = new TransactionScope())
            {
                var result = PersistTestResults(customerEventScreeningEntity, (int)TestType.Cs, customerId, eventId, orgRoleUserId);

                var eventCustomerResultRepository = new EventCustomerResultRepository();
                var eventCustomerResult = eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);

                var customerEventScreeningTestId = GetCustomerEventScreeningTestId((int)TestType.Cs, eventCustomerResult.Id);


                var resultMedia = new List<ResultMedia>();
                if (((CsTestResult)synchronizedTestResult).ResultImage != null)
                    resultMedia.Add(((CsTestResult)synchronizedTestResult).ResultImage);

                SaveTestMedia(resultMedia, customerEventScreeningTestId, synchronizedTestResult.DataRecorderMetaData);

                scope.Complete();
                return result;
            }
        }

        public override List<ResultReading<int>> GetReadingsForTest()
        {
            return GetAllReadings((int)TestType.Cs);
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
                //&& !(existingTestResult.ResultStatus.StateNumber == TestResultStateNumber.PreAudit && existingTestResult.ResultStatus.Status == TestResultStatus.Incomplete)
                if (existingTestResult != null && existingTestResult.ResultStatus != null && existingTestResult.ResultStatus.StateNumber > (int)TestResultStateNumber.PreAudit)
                    return true;

                synchronizedTestResult = _testResultSynchronizationService.SynchronizeTestResult(existingTestResult, currentTestResult, currentTestResult.IsNewResultFlow);
                var compareToResultReadings = GetAllReadings((int)TestType.Cs);
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
                    synchronizedTestResult = _testResultSynchronizationService.SynchronizeTestResult(existingTestResult, currentTestResult, currentTestResult.IsNewResultFlow);
                    synchronizedTestResult = _testResultSynchronizationService.SynchronizePhysicianEvaluation(synchronizedTestResult, existingTestResult);
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
                //&& !(existingTestResult.ResultStatus.StateNumber == TestResultStateNumber.PreAudit && existingTestResult.ResultStatus.Status == TestResultStatus.Incomplete)
                if (existingTestResult != null && existingTestResult.ResultStatus != null && existingTestResult.ResultStatus.StateNumber > (int)NewTestResultStateNumber.PreAudit)
                    return true;

                synchronizedTestResult = _testResultSynchronizationService.SynchronizeTestResult(existingTestResult, currentTestResult, currentTestResult.IsNewResultFlow);
                var compareToResultReadings = GetAllReadings((int)TestType.Cs);
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
                    synchronizedTestResult = _testResultSynchronizationService.SynchronizeTestResult(existingTestResult, currentTestResult, currentTestResult.IsNewResultFlow);
                    synchronizedTestResult = _testResultSynchronizationService.SynchronizePhysicianEvaluation(synchronizedTestResult, existingTestResult);
                }
                else if (currentTestResult.ResultStatus.StateNumber < (int)NewTestResultStateNumber.PostAuditNew)
                {
                    TestResult existingTestResult = null;
                    lock (CentralLocker.Locker)
                    {
                        existingTestResult = GetTestResults(customerId, eventId, currentTestResult.IsNewResultFlow);
                    }
                    synchronizedTestResult = _testResultSynchronizationService.SynchronizeTestResult(existingTestResult, currentTestResult, currentTestResult.IsNewResultFlow);
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
