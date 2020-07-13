using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Impl;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Infrastructure.Factories.Screening;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Medical.Interfaces;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Repositories.Screening
{
    public class QuantaFloABITestRepository : TestResultRepository
    {
        private readonly ITestResultFactory _testResultFactory;
        private readonly ITestResultSynchronizationService _testResultSynchronizationService;

        public QuantaFloABITestRepository()
            : this(ReadingSource.Manual)
        {
        }

        public QuantaFloABITestRepository(ReadingSource callingSource)
        {
            _testResultFactory = new QuantaFloABITestResultFactory();
            _testResultSynchronizationService = new QuantaFloABITestResultSynchronizationService(callingSource);
            _callingSource = callingSource;
        }

        public QuantaFloABITestRepository(IPersistenceLayer persistenceLayer, ITestResultFactory testResultFactory, ITestResultSynchronizationService testResultSynchronizationService)
            : base(persistenceLayer)
        {
            _testResultFactory = testResultFactory;
            _testResultSynchronizationService = testResultSynchronizationService;
            _callingSource = ReadingSource.Manual;
        }

        public override TestResult GetTestResults(long customerId, long eventId, bool isNewResultFlow)
        {
            List<CustomerEventScreeningTestsEntity> customerEventScreeningTests = GetTestResultsByTestId(customerId, eventId, (int)TestType.QuantaFloABI);

            var testResult = _testResultFactory.CreateTestResults(customerEventScreeningTests).SingleOrDefault();
            if (testResult == null) return null;

            var quantaFloABITestResult = (QuantaFloABITestResult)testResult;
            if (quantaFloABITestResult.ResultImage != null) GetFileDataforResultmedia(quantaFloABITestResult.ResultImage);
            testResult.IsNewResultFlow = isNewResultFlow;

            return testResult;
        }

        public override bool SaveTestResults(TestResult currentTestResult, long customerId, long eventId, long technicianId)
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

            CustomerEventScreeningTestsEntity customerEventScreeningEntity =
                _testResultFactory.CreateTestResultEntity(synchronizedTestResult, GetListOfTestReadingAndReadingId((int)TestType.QuantaFloABI));

            using (var scope = new TransactionScope())
            {
                var result = PersistTestResults(customerEventScreeningEntity, (int)TestType.QuantaFloABI, customerId, eventId, technicianId);

                var eventCustomerResultRepository = new EventCustomerResultRepository();
                var eventCustomerResult = eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);

                var customerEventScreeningTestId = GetCustomerEventScreeningTestId((int)TestType.QuantaFloABI, eventCustomerResult.Id);

                var resultMedia = new List<ResultMedia>();
                if (((QuantaFloABITestResult)synchronizedTestResult).ResultImage != null)
                    resultMedia.Add(((QuantaFloABITestResult)synchronizedTestResult).ResultImage);

                SaveTestMedia(resultMedia, customerEventScreeningTestId, synchronizedTestResult.DataRecorderMetaData);

                scope.Complete();
                return result;
            }
        }

        public override List<ResultReading<int>> GetReadingsForTest()
        {
            return GetAllReadings((int)TestType.QuantaFloABI);
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
                var compareToResultReadings = GetAllReadings((int)TestType.QuantaFloABI);
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
                if (existingTestResult != null && existingTestResult.ResultStatus != null && existingTestResult.ResultStatus.StateNumber >= (int)NewTestResultStateNumber.PreAudit
                    && !(existingTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit && existingTestResult.ResultStatus.Status == TestResultStatus.Incomplete)) return true;

                synchronizedTestResult = _testResultSynchronizationService.SynchronizeTestResult(existingTestResult, currentTestResult, currentTestResult.IsNewResultFlow);
                var compareToResultReadings = GetAllReadings((int)TestType.QuantaFloABI);
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
                else
                {
                    synchronizedTestResult = currentTestResult;
                }
            }
            return false;
        }
    }
}