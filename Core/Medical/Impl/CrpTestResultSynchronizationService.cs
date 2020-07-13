using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class CrpTestResultSynchronizationService : TestResultSynchronizationService
    {
        private readonly bool _captureBloodTest;
        public CrpTestResultSynchronizationService(ReadingSource readingSource, bool captureBloodTest)
        {
            NewReadingSource = readingSource;
            _captureBloodTest = captureBloodTest;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var crpTestResult = newTestResult as CrpTestResult;
            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (crpTestResult.LCRP != null && crpTestResult.LCRP.Reading == null) crpTestResult.LCRP = null;
                SyncronizeTestResult(currentTestResult, newTestResult);

                return crpTestResult;
            }

            var currentCrpTestResult = (CrpTestResult)currentTestResult;
            crpTestResult.LCRP = SynchronizeResultReading(currentCrpTestResult.LCRP, crpTestResult.LCRP, newTestResult.DataRecorderMetaData);
            crpTestResult.Id = currentCrpTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                crpTestResult = (CrpTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentCrpTestResult, crpTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return crpTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var crpTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (crpTestResult.ResultStatus.Status == TestResultStatus.Complete && crpTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    crpTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return crpTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var crpTestResult = newTestResult as CrpTestResult;

            if (crpTestResult != null)
            {
                if (crpTestResult.TestPerformedExternally != null)
                {
                    if (crpTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && crpTestResult.TestPerformedExternally.EntryCompleted)
                    {
                        newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                    }
                    else
                    {
                        newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                    }
                    return crpTestResult;
                }
            }

            if (_captureBloodTest && crpTestResult.LCRP == null) crpTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            else crpTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return crpTestResult;
        }

        private TestResult OldResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var crpTestResult = newTestResult as CrpTestResult;

            bool returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.LCRP).ReadingSource, crpTestResult.LCRP);
            if (returnStatus) { crpTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return crpTestResult; }

            if (crpTestResult.UnableScreenReason != null && crpTestResult.UnableScreenReason.Count > 0)
            {
                crpTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return crpTestResult;
            }

            crpTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return crpTestResult;
        }

        private TestResult NewResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var crpTestResult = newTestResult as CrpTestResult;

            bool returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.LCRP).ReadingSource, crpTestResult.LCRP);
            if (returnStatus) { crpTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return crpTestResult; }

            if (crpTestResult.UnableScreenReason != null && crpTestResult.UnableScreenReason.Count > 0)
            {
                crpTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return crpTestResult;
            }

            crpTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return crpTestResult;
        }
    }
}