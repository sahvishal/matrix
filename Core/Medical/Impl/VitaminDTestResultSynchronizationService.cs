using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class VitaminDTestResultSynchronizationService : TestResultSynchronizationService
    {
        public VitaminDTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newVitaminDTestResult = newTestResult as VitaminDTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newVitaminDTestResult.VitD != null && newVitaminDTestResult.VitD.Reading == null) newVitaminDTestResult.VitD = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newVitaminDTestResult;
            }

            var currentVitaminDTestResult = (VitaminDTestResult)currentTestResult;
            newVitaminDTestResult.Id = currentVitaminDTestResult.Id;
            newVitaminDTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            newVitaminDTestResult.VitD = SynchronizeResultReading(currentVitaminDTestResult.VitD, newVitaminDTestResult.VitD, newTestResult.DataRecorderMetaData);

            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                newVitaminDTestResult = (VitaminDTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentVitaminDTestResult, newVitaminDTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newVitaminDTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newVitaminDTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newVitaminDTestResult.ResultStatus.Status == TestResultStatus.Complete && newVitaminDTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newVitaminDTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newVitaminDTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var vitaminDPanelTestResult = newTestResult as VitaminDTestResult;
            if (vitaminDPanelTestResult == null) return null;

            if (vitaminDPanelTestResult.TestPerformedExternally != null)
            {
                if (vitaminDPanelTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && vitaminDPanelTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return vitaminDPanelTestResult;
            }


            vitaminDPanelTestResult.ResultStatus.Status = vitaminDPanelTestResult.VitD == null
                ? TestResultStatus.Incomplete : TestResultStatus.Complete;

            return vitaminDPanelTestResult;
        }

        private TestResult OldResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newVitaminDTestResult = newTestResult as VitaminDTestResult;

            var returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.VitD).ReadingSource, newVitaminDTestResult.VitD);
            if (returnStatus) { newVitaminDTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newVitaminDTestResult; }

            if (newVitaminDTestResult.UnableScreenReason != null && newVitaminDTestResult.UnableScreenReason.Count > 0)
            {
                newVitaminDTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newVitaminDTestResult;
            }

            newVitaminDTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newVitaminDTestResult;
        }

        private TestResult NewResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newVitaminDTestResult = newTestResult as VitaminDTestResult;

            var returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.VitD).ReadingSource, newVitaminDTestResult.VitD);
            if (returnStatus) { newVitaminDTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newVitaminDTestResult; }

            if (newVitaminDTestResult.UnableScreenReason != null && newVitaminDTestResult.UnableScreenReason.Count > 0)
            {
                newVitaminDTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newVitaminDTestResult;
            }

            newVitaminDTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newVitaminDTestResult;
        }
    }
}