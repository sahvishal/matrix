using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical.Impl
{
    public class FocTestResultSynchronizationService : TestResultSynchronizationService
    {
        public FocTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newFocTestResult = (FocTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newFocTestResult.ResultImage != null)
                {
                    if (newFocTestResult.ResultImage.File == null) newFocTestResult.ResultImage = null;
                }

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newFocTestResult;
            }

            var currentFocTestResult = (FocTestResult)currentTestResult;
            newFocTestResult.Id = currentFocTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (currentFocTestResult.ResultImage != null && newFocTestResult.ResultImage != null)
            {
                if (newFocTestResult.ResultImage.File != null && currentFocTestResult.ResultImage.File != null && currentFocTestResult.ResultImage.File.Path == newFocTestResult.ResultImage.File.Path)
                    newFocTestResult.ResultImage = currentFocTestResult.ResultImage;

                if (currentFocTestResult.ResultImage.ReadingSource == ReadingSource.Manual && newFocTestResult.ResultImage.ReadingSource == ReadingSource.Automatic)
                    newFocTestResult.ResultImage = currentFocTestResult.ResultImage;
            }

            if (newFocTestResult.ResultImage != null)
            {
                if (newFocTestResult.ResultImage.File == null) newFocTestResult.ResultImage = null;
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newFocTestResult = (FocTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentFocTestResult, newFocTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newFocTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newFocTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newFocTestResult.ResultStatus.Status == TestResultStatus.Complete && newFocTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newFocTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newFocTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var focTestResult = newTestResult as FocTestResult;
            if (focTestResult == null) return null;

            if (focTestResult.TestPerformedExternally != null)
            {
                if (focTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && focTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return focTestResult;
            }

            if (focTestResult.ResultImage == null || focTestResult.ResultImage.File == null)
            {
                focTestResult.ResultStatus.Status = TestResultStatus.Incomplete;

                return focTestResult;
            }

            newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return focTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newFocTestResult = (FocTestResult)newTestResult;

            if (newFocTestResult.ResultImage != null && newFocTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newFocTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newFocTestResult;
            }


            if (newFocTestResult.UnableScreenReason != null && newFocTestResult.UnableScreenReason.Count > 0)
            {
                newFocTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newFocTestResult;
            }

            newFocTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newFocTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {

            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newFocTestResult = (FocTestResult)newTestResult;

            if (newFocTestResult.ResultImage != null && newFocTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newFocTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newFocTestResult;
            }


            if (newFocTestResult.UnableScreenReason != null && newFocTestResult.UnableScreenReason.Count > 0)
            {
                newFocTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newFocTestResult;
            }

            newFocTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newFocTestResult;
        }
    }
}
