using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class ThyroidTestResultSynchronizationService : TestResultSynchronizationService
    {
        private readonly bool _captureBloodTest;
        public ThyroidTestResultSynchronizationService(ReadingSource readingSource, bool captureBloodTest)
        {
            NewReadingSource = readingSource;
            _captureBloodTest = captureBloodTest;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var thyroidTestResult = (ThyroidTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (thyroidTestResult.TSHSCR != null && thyroidTestResult.TSHSCR.Reading == null) thyroidTestResult.TSHSCR = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return thyroidTestResult;
            }

            var currentThyroidTestResult = (ThyroidTestResult)currentTestResult;
            thyroidTestResult.TSHSCR = SynchronizeResultReading(currentThyroidTestResult.TSHSCR, thyroidTestResult.TSHSCR, newTestResult.DataRecorderMetaData);
            thyroidTestResult.Id = currentThyroidTestResult.Id;
            thyroidTestResult.ResultStatus.Id = currentThyroidTestResult.ResultStatus.Id;

            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                thyroidTestResult = (ThyroidTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentThyroidTestResult, thyroidTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return thyroidTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var thyroidTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (thyroidTestResult.ResultStatus.Status == TestResultStatus.Complete && thyroidTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    thyroidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return thyroidTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var thyroidTestResult = newTestResult as ThyroidTestResult;
            if (thyroidTestResult == null) return null;

            if (thyroidTestResult.TestPerformedExternally != null)
            {
                if (thyroidTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && thyroidTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return thyroidTestResult;
            }


            if (_captureBloodTest && thyroidTestResult.TSHSCR == null) thyroidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            else thyroidTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return thyroidTestResult;
        }

        private TestResult OldResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var thyroidTestResult = newTestResult as ThyroidTestResult;

            if (thyroidTestResult == null) return null;

            bool returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.TSHSCR).ReadingSource, thyroidTestResult.TSHSCR);
            if (returnStatus) { thyroidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return thyroidTestResult; }

            if (thyroidTestResult.UnableScreenReason != null && thyroidTestResult.UnableScreenReason.Count > 0)
            {
                thyroidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return thyroidTestResult;
            }

            thyroidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return thyroidTestResult;
        }

        private TestResult NewResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var thyroidTestResult = newTestResult as ThyroidTestResult;

            if (thyroidTestResult == null) return null;

            bool returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.TSHSCR).ReadingSource, thyroidTestResult.TSHSCR);
            if (returnStatus) { thyroidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return thyroidTestResult; }

            if (thyroidTestResult.UnableScreenReason != null && thyroidTestResult.UnableScreenReason.Count > 0)
            {
                thyroidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return thyroidTestResult;
            }

            thyroidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return thyroidTestResult;
        }
    }
}