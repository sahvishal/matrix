using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical.Impl
{
    public class ChlamydiaTestResultSynchronizationService : TestResultSynchronizationService
    {
        public ChlamydiaTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newChlamydiaTestResult = (ChlamydiaTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newChlamydiaTestResult.ResultImage != null)
                {
                    if (newChlamydiaTestResult.ResultImage.File == null) newChlamydiaTestResult.ResultImage = null;
                }

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newChlamydiaTestResult;
            }

            var currentChlamydiaTestResult = (ChlamydiaTestResult)currentTestResult;
            newChlamydiaTestResult.Id = currentChlamydiaTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (currentChlamydiaTestResult.ResultImage != null && newChlamydiaTestResult.ResultImage != null)
            {
                if (newChlamydiaTestResult.ResultImage.File != null && currentChlamydiaTestResult.ResultImage.File != null && currentChlamydiaTestResult.ResultImage.File.Path == newChlamydiaTestResult.ResultImage.File.Path)
                    newChlamydiaTestResult.ResultImage = currentChlamydiaTestResult.ResultImage;

                if (currentChlamydiaTestResult.ResultImage.ReadingSource == ReadingSource.Manual && newChlamydiaTestResult.ResultImage.ReadingSource == ReadingSource.Automatic)
                    newChlamydiaTestResult.ResultImage = currentChlamydiaTestResult.ResultImage;
            }

            if (newChlamydiaTestResult.ResultImage != null)
            {
                if (newChlamydiaTestResult.ResultImage.File == null) newChlamydiaTestResult.ResultImage = null;
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newChlamydiaTestResult.Finding = currentChlamydiaTestResult.Finding;
                newChlamydiaTestResult = (ChlamydiaTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentChlamydiaTestResult, newChlamydiaTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newChlamydiaTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newChlamydiaTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newChlamydiaTestResult.ResultStatus.Status == TestResultStatus.Complete && newChlamydiaTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newChlamydiaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newChlamydiaTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var ChlamydiaTestResult = newTestResult as ChlamydiaTestResult;
            if (ChlamydiaTestResult == null) return null;

            if (ChlamydiaTestResult.TestPerformedExternally != null)
            {
                if (ChlamydiaTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && ChlamydiaTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return ChlamydiaTestResult;
            }


            if (ChlamydiaTestResult.Finding == null)
            {
                ChlamydiaTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                return ChlamydiaTestResult;
            }

            if (ChlamydiaTestResult.ResultImage == null || ChlamydiaTestResult.ResultImage.File == null)
            {
                ChlamydiaTestResult.ResultStatus.Status = TestResultStatus.Incomplete;

                return ChlamydiaTestResult;
            }

            ChlamydiaTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return ChlamydiaTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
            var newChlamydiaTestResult = (ChlamydiaTestResult)newTestResult;

            if (newChlamydiaTestResult.UnableScreenReason != null && newChlamydiaTestResult.UnableScreenReason.Count > 0)
            {
                newChlamydiaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newChlamydiaTestResult;
            }

            if (newChlamydiaTestResult.ResultImage != null && newChlamydiaTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newChlamydiaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newChlamydiaTestResult;
            }

            newChlamydiaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newChlamydiaTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            var newChlamydiaTestResult = (ChlamydiaTestResult)newTestResult;

            if (newChlamydiaTestResult.UnableScreenReason != null && newChlamydiaTestResult.UnableScreenReason.Count > 0)
            {
                newChlamydiaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newChlamydiaTestResult;
            }

            if (newChlamydiaTestResult.ResultImage != null && newChlamydiaTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newChlamydiaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newChlamydiaTestResult;
            }

            newChlamydiaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newChlamydiaTestResult;
        }
    }
}
