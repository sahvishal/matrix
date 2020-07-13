using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class Phq9TestResultSynchronizationService : TestResultSynchronizationService
    {
        public Phq9TestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newPhq9TestResult = newTestResult as Phq9TestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newPhq9TestResult.Phq9Score != null && newPhq9TestResult.Phq9Score.Reading == null) newPhq9TestResult.Phq9Score = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newPhq9TestResult;
            }

            var currentPhq9TestResult = (Phq9TestResult)currentTestResult;
            newPhq9TestResult.Id = currentPhq9TestResult.Id;
            newPhq9TestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            newPhq9TestResult.Phq9Score = SynchronizeResultReading(currentPhq9TestResult.Phq9Score, newPhq9TestResult.Phq9Score, newTestResult.DataRecorderMetaData);

            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                newPhq9TestResult = (Phq9TestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentPhq9TestResult, newPhq9TestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newPhq9TestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newPhq9TestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newPhq9TestResult.ResultStatus.Status == TestResultStatus.Complete && newPhq9TestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newPhq9TestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newPhq9TestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var phq9PanelTestResult = newTestResult as Phq9TestResult;
            if (phq9PanelTestResult == null) return null;

            if (phq9PanelTestResult.TestPerformedExternally != null)
            {
                if (phq9PanelTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && phq9PanelTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return phq9PanelTestResult;
            }

            phq9PanelTestResult.ResultStatus.Status = phq9PanelTestResult.Phq9Score == null
                ? TestResultStatus.Incomplete : TestResultStatus.Complete;

            return phq9PanelTestResult;
        }

        private TestResult OldResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newPhq9TestResult = newTestResult as Phq9TestResult;

            var returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.Phq9Score).ReadingSource, newPhq9TestResult.Phq9Score);
            if (returnStatus) { newPhq9TestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newPhq9TestResult; }

            if (newPhq9TestResult.UnableScreenReason != null && newPhq9TestResult.UnableScreenReason.Count > 0)
            {
                newPhq9TestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newPhq9TestResult;
            }

            newPhq9TestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newPhq9TestResult;
        }

        private TestResult NewResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newPhq9TestResult = newTestResult as Phq9TestResult;

            var returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.Phq9Score).ReadingSource, newPhq9TestResult.Phq9Score);
            if (returnStatus) { newPhq9TestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newPhq9TestResult; }

            if (newPhq9TestResult.UnableScreenReason != null && newPhq9TestResult.UnableScreenReason.Count > 0)
            {
                newPhq9TestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newPhq9TestResult;
            }

            newPhq9TestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newPhq9TestResult;
        }
    }
}