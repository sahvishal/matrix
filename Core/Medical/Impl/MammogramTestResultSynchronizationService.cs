using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class MammogramTestResultSynchronizationService : TestResultSynchronizationService
    {
        public MammogramTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newMammogramTestResultTestResult = (MammogramTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newMammogramTestResultTestResult.ResultImage != null)
                {
                    if (newMammogramTestResultTestResult.ResultImage.File == null) newMammogramTestResultTestResult.ResultImage = null;
                }

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newMammogramTestResultTestResult;
            }

            var currentMammogramTestResultTestResult = (MammogramTestResult)currentTestResult;
            newMammogramTestResultTestResult.Id = currentMammogramTestResultTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (currentMammogramTestResultTestResult.ResultImage != null && newMammogramTestResultTestResult.ResultImage != null)
            {
                if (newMammogramTestResultTestResult.ResultImage.File != null && currentMammogramTestResultTestResult.ResultImage.File != null && currentMammogramTestResultTestResult.ResultImage.File.Path == newMammogramTestResultTestResult.ResultImage.File.Path)
                    newMammogramTestResultTestResult.ResultImage = currentMammogramTestResultTestResult.ResultImage;

                if (currentMammogramTestResultTestResult.ResultImage.ReadingSource == ReadingSource.Manual && newMammogramTestResultTestResult.ResultImage.ReadingSource == ReadingSource.Automatic)
                    newMammogramTestResultTestResult.ResultImage = currentMammogramTestResultTestResult.ResultImage;
            }

            if (newMammogramTestResultTestResult.ResultImage != null)
            {
                if (newMammogramTestResultTestResult.ResultImage.File == null) newMammogramTestResultTestResult.ResultImage = null;
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newMammogramTestResultTestResult.Finding = currentMammogramTestResultTestResult.Finding;
                newMammogramTestResultTestResult = (MammogramTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentMammogramTestResultTestResult, newMammogramTestResultTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newMammogramTestResultTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newMammogramTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newMammogramTestResult.ResultStatus.Status == TestResultStatus.Complete && newMammogramTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newMammogramTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newMammogramTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var mammogramTestResult = newTestResult as MammogramTestResult;
            if (mammogramTestResult == null) return null;

            if (mammogramTestResult.TestPerformedExternally != null)
            {
                if (mammogramTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && mammogramTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return mammogramTestResult;
            }


            if (mammogramTestResult.ResultImage == null || mammogramTestResult.ResultImage.File == null)
            {
                mammogramTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                return mammogramTestResult;
            }

            if (mammogramTestResult.Finding == null)
            {
                mammogramTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                return mammogramTestResult;
            }

            mammogramTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return mammogramTestResult;
        }

        private TestResult OldResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;

            newTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
            var newMammogramTestResult = (MammogramTestResult)newTestResult;

            if (newMammogramTestResult.UnableScreenReason != null && newMammogramTestResult.UnableScreenReason.Count > 0)
            {
                newMammogramTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newMammogramTestResult;
            }

            if (newMammogramTestResult.ResultImage != null && newMammogramTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newMammogramTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newMammogramTestResult;
            }

            newMammogramTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;

            return newMammogramTestResult;
        }

        private TestResult NewResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;

            newTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            var newMammogramTestResult = (MammogramTestResult)newTestResult;

            if (newMammogramTestResult.UnableScreenReason != null && newMammogramTestResult.UnableScreenReason.Count > 0)
            {
                newMammogramTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newMammogramTestResult;
            }

            if (newMammogramTestResult.ResultImage != null && newMammogramTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newMammogramTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newMammogramTestResult;
            }

            newMammogramTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;

            return newMammogramTestResult;
        }
    }
}
