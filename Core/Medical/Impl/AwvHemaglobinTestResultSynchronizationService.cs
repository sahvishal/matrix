using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class AwvHemaglobinTestResultSynchronizationService : TestResultSynchronizationService
    {
        public AwvHemaglobinTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var awvA1CTestResult = newTestResult as AwvHemaglobinTestResult;
            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (awvA1CTestResult.Hba1c != null && awvA1CTestResult.Hba1c.Reading == null) awvA1CTestResult.Hba1c = null;
                SyncronizeTestResult(currentTestResult, newTestResult);

                return awvA1CTestResult;
            }

            var currentAwvA1CTestResult = (AwvHemaglobinTestResult)currentTestResult;
            awvA1CTestResult.Hba1c = SynchronizeResultReading(currentAwvA1CTestResult.Hba1c, awvA1CTestResult.Hba1c, newTestResult.DataRecorderMetaData);
            awvA1CTestResult.Id = currentAwvA1CTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                awvA1CTestResult = (AwvHemaglobinTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentAwvA1CTestResult, awvA1CTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return awvA1CTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var awvA1CTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (awvA1CTestResult.ResultStatus.Status == TestResultStatus.Complete && awvA1CTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    awvA1CTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return awvA1CTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var awvA1CTestResult = newTestResult as AwvHemaglobinTestResult;

            if (awvA1CTestResult != null)
            {
                if (awvA1CTestResult.TestPerformedExternally != null)
                {
                    if (awvA1CTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && awvA1CTestResult.TestPerformedExternally.EntryCompleted)
                    {
                        newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                    }
                    else
                    {
                        newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                    }
                    return awvA1CTestResult;
                }
            }

            if (awvA1CTestResult.Hba1c == null) awvA1CTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            else awvA1CTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return awvA1CTestResult;
        }

        private TestResult OldResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var awvA1CTestResult = newTestResult as AwvHemaglobinTestResult;

            bool returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.Hba1c).ReadingSource, awvA1CTestResult.Hba1c);
            if (returnStatus) { awvA1CTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return awvA1CTestResult; }

            if (awvA1CTestResult.UnableScreenReason != null && awvA1CTestResult.UnableScreenReason.Count > 0)
            {
                awvA1CTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return awvA1CTestResult;
            }

            awvA1CTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return awvA1CTestResult;
        }

        private TestResult NewResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var awvA1CTestResult = newTestResult as AwvHemaglobinTestResult;

            bool returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.Hba1c).ReadingSource, awvA1CTestResult.Hba1c);
            if (returnStatus) { awvA1CTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return awvA1CTestResult; }

            if (awvA1CTestResult.UnableScreenReason != null && awvA1CTestResult.UnableScreenReason.Count > 0)
            {
                awvA1CTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return awvA1CTestResult;
            }

            awvA1CTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return awvA1CTestResult;
        }
    }
}
