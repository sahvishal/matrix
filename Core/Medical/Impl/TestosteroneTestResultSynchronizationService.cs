using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class TestosteroneTestResultSynchronizationService : TestResultSynchronizationService
    {
        private readonly bool _captureBloodTest;
        public TestosteroneTestResultSynchronizationService(ReadingSource readingSource, bool captureBloodTest)
        {
            NewReadingSource = readingSource;
            _captureBloodTest = captureBloodTest;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var testosteroneTestResult = newTestResult as TestosteroneTestResult;
            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (testosteroneTestResult.TESTSCRE != null && testosteroneTestResult.TESTSCRE.Reading == null) testosteroneTestResult.TESTSCRE = null;
                SyncronizeTestResult(currentTestResult, newTestResult);

                return testosteroneTestResult;
            }

            var currentTestosteroneTestResult = (TestosteroneTestResult)currentTestResult;
            testosteroneTestResult.TESTSCRE = SynchronizeResultReading(currentTestosteroneTestResult.TESTSCRE, testosteroneTestResult.TESTSCRE, newTestResult.DataRecorderMetaData);
            testosteroneTestResult.Id = currentTestosteroneTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                testosteroneTestResult = (TestosteroneTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentTestosteroneTestResult, testosteroneTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return testosteroneTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var testosteroneTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (testosteroneTestResult.ResultStatus.Status == TestResultStatus.Complete && testosteroneTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    testosteroneTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return testosteroneTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var testosteroneTestResult = newTestResult as TestosteroneTestResult;

            if (testosteroneTestResult != null)
            {
                if (testosteroneTestResult.TestPerformedExternally != null)
                {
                    if (testosteroneTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && testosteroneTestResult.TestPerformedExternally.EntryCompleted)
                    {
                        newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                    }
                    else
                    {
                        newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                    }
                    return testosteroneTestResult;
                }
            }

            if (_captureBloodTest && testosteroneTestResult.TESTSCRE == null) testosteroneTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            else testosteroneTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return testosteroneTestResult;
        }

        private TestResult OldResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var testosteroneTestResult = newTestResult as TestosteroneTestResult;

            bool returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.TESTSCRE).ReadingSource, testosteroneTestResult.TESTSCRE);
            if (returnStatus) { testosteroneTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return testosteroneTestResult; }

            if (testosteroneTestResult.UnableScreenReason != null && testosteroneTestResult.UnableScreenReason.Count > 0)
            {
                testosteroneTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return testosteroneTestResult;
            }

            testosteroneTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return testosteroneTestResult;
        }

        private TestResult NewResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var testosteroneTestResult = newTestResult as TestosteroneTestResult;

            bool returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.TESTSCRE).ReadingSource, testosteroneTestResult.TESTSCRE);
            if (returnStatus) { testosteroneTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return testosteroneTestResult; }

            if (testosteroneTestResult.UnableScreenReason != null && testosteroneTestResult.UnableScreenReason.Count > 0)
            {
                testosteroneTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return testosteroneTestResult;
            }

            testosteroneTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return testosteroneTestResult;
        }
    }
}