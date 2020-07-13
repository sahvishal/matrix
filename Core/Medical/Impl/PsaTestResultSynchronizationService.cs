using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class PsaTestResultSynchronizationService : TestResultSynchronizationService
    {
        private readonly bool _captureBloodTest;
        public PsaTestResultSynchronizationService(ReadingSource readingSource, bool captureBloodTest)
        {
            NewReadingSource = readingSource;
            _captureBloodTest = captureBloodTest;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var psaTestResult = newTestResult as PsaTestResult;
            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (psaTestResult.PSASCR != null && psaTestResult.PSASCR.Reading == null) psaTestResult.PSASCR = null;
                SyncronizeTestResult(currentTestResult, newTestResult);

                return psaTestResult;
            }

            var currentPsaTestResult = (PsaTestResult)currentTestResult;
            psaTestResult.PSASCR = SynchronizeResultReading(currentPsaTestResult.PSASCR, psaTestResult.PSASCR, newTestResult.DataRecorderMetaData);
            psaTestResult.Id = currentPsaTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                psaTestResult = (PsaTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentPsaTestResult, psaTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return psaTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var psaTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (psaTestResult.ResultStatus.Status == TestResultStatus.Complete && psaTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    psaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return psaTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var psaTestResult = newTestResult as PsaTestResult;
            if (psaTestResult == null) return null;

            if (psaTestResult.TestPerformedExternally != null)
            {
                if (psaTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && psaTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return psaTestResult;
            }


            if (_captureBloodTest && psaTestResult.PSASCR == null) psaTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            else psaTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return psaTestResult;
        }

        private TestResult OldResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var psaTestResult = newTestResult as PsaTestResult;

            bool returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.PSASCR).ReadingSource, psaTestResult.PSASCR);
            if (returnStatus) { psaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return psaTestResult; }

            if (psaTestResult.UnableScreenReason != null && psaTestResult.UnableScreenReason.Count > 0)
            {
                psaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return psaTestResult;
            }

            psaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return psaTestResult;
        }

        private TestResult NewResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var psaTestResult = newTestResult as PsaTestResult;

            bool returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.PSASCR).ReadingSource, psaTestResult.PSASCR);
            if (returnStatus) { psaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return psaTestResult; }

            if (psaTestResult.UnableScreenReason != null && psaTestResult.UnableScreenReason.Count > 0)
            {
                psaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return psaTestResult;
            }

            psaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return psaTestResult;
        }
    }
}