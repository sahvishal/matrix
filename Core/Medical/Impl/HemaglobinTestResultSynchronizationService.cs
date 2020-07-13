using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class HemaglobinTestResultSynchronizationService : TestResultSynchronizationService
    {
        public HemaglobinTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var a1CTestResult = newTestResult as HemaglobinA1CTestResult;
            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (a1CTestResult.Hba1c != null && a1CTestResult.Hba1c.Reading == null) a1CTestResult.Hba1c = null;
                SyncronizeTestResult(currentTestResult, newTestResult);

                return a1CTestResult;
            }

            var currentA1CTestResult = (HemaglobinA1CTestResult)currentTestResult;
            a1CTestResult.Hba1c = SynchronizeResultReading(currentA1CTestResult.Hba1c, a1CTestResult.Hba1c, newTestResult.DataRecorderMetaData);
            a1CTestResult.Id = currentA1CTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                a1CTestResult = (HemaglobinA1CTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentA1CTestResult, a1CTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return a1CTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var a1CTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (a1CTestResult.ResultStatus.Status == TestResultStatus.Complete && a1CTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    a1CTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return a1CTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var a1CTestResult = newTestResult as HemaglobinA1CTestResult;

            if (a1CTestResult != null)
            {

                if (a1CTestResult.TestPerformedExternally != null)
                {
                    if (a1CTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && a1CTestResult.TestPerformedExternally.EntryCompleted)
                    {
                        newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                    }
                    else
                    {
                        newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                    }
                    return a1CTestResult;
                }
            }

            if (a1CTestResult.Hba1c == null) a1CTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            else a1CTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return a1CTestResult;
        }

        private TestResult OldResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var a1CTestResult = newTestResult as HemaglobinA1CTestResult;

            bool returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.Hba1c).ReadingSource, a1CTestResult.Hba1c);
            if (returnStatus) { a1CTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return a1CTestResult; }

            if (a1CTestResult.UnableScreenReason != null && a1CTestResult.UnableScreenReason.Count > 0)
            {
                a1CTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return a1CTestResult;
            }

            a1CTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return a1CTestResult;
        }

        private TestResult NewResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var a1CTestResult = newTestResult as HemaglobinA1CTestResult;

            bool returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.Hba1c).ReadingSource, a1CTestResult.Hba1c);
            if (returnStatus) { a1CTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return a1CTestResult; }

            if (a1CTestResult.UnableScreenReason != null && a1CTestResult.UnableScreenReason.Count > 0)
            {
                a1CTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return a1CTestResult;
            }

            a1CTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return a1CTestResult;
        }
    }
}