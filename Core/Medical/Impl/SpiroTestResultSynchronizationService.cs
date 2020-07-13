using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class SpiroTestResultSynchronizationService : TestResultSynchronizationService
    {
        public SpiroTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newSpiroTestResult = (SpiroTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newSpiroTestResult;
            }

            var currentSpiroTestResult = (SpiroTestResult)currentTestResult;
            newSpiroTestResult.Id = currentSpiroTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (currentSpiroTestResult.ResultImage != null && newSpiroTestResult.ResultImage != null)
            {
                if (newSpiroTestResult.ResultImage.File != null && currentSpiroTestResult.ResultImage.File != null && currentSpiroTestResult.ResultImage.File.Path == newSpiroTestResult.ResultImage.File.Path)
                    newSpiroTestResult.ResultImage = currentSpiroTestResult.ResultImage;

                if (currentSpiroTestResult.ResultImage.ReadingSource == ReadingSource.Manual
                    && newSpiroTestResult.ResultImage.ReadingSource == ReadingSource.Automatic)
                    newSpiroTestResult.ResultImage = currentSpiroTestResult.ResultImage;

            }

            if (newSpiroTestResult.ResultImage != null)
            {
                if (newSpiroTestResult.ResultImage.File == null) newSpiroTestResult.ResultImage = null;
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newSpiroTestResult.Finding = currentSpiroTestResult.Finding;
                newSpiroTestResult = (SpiroTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentSpiroTestResult, newSpiroTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newSpiroTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newSpiroTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newSpiroTestResult.ResultStatus.Status == TestResultStatus.Complete && newSpiroTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newSpiroTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newSpiroTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var spiroTestResult = newTestResult as SpiroTestResult;
            if (spiroTestResult == null) return null;

            if (spiroTestResult.TestPerformedExternally != null)
            {
                if (spiroTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && spiroTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return spiroTestResult;
            }


            if (spiroTestResult.Finding == null || spiroTestResult.ResultImage == null)
                spiroTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            else
                spiroTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return spiroTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
            var newSpiroTestResult = (SpiroTestResult)newTestResult;

            if (newSpiroTestResult.UnableScreenReason != null && newSpiroTestResult.UnableScreenReason.Count > 0)
            {
                newSpiroTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newSpiroTestResult;
            }

            newSpiroTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newSpiroTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            var newSpiroTestResult = (SpiroTestResult)newTestResult;

            if (newSpiroTestResult.UnableScreenReason != null && newSpiroTestResult.UnableScreenReason.Count > 0)
            {
                newSpiroTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newSpiroTestResult;
            }

            newSpiroTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newSpiroTestResult;
        }
    }
}
