using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class FocAttestationTestResultSynchronizationService : TestResultSynchronizationService
    {
        public FocAttestationTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newFocAttestationTestResult = (FocAttestationTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newFocAttestationTestResult.ResultImage != null)
                {
                    if (newFocAttestationTestResult.ResultImage.File == null) newFocAttestationTestResult.ResultImage = null;
                }

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newFocAttestationTestResult;
            }

            var currentFocAttestationTestResultTestResult = (FocAttestationTestResult)currentTestResult;
            newFocAttestationTestResult.Id = currentFocAttestationTestResultTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (currentFocAttestationTestResultTestResult.ResultImage != null && newFocAttestationTestResult.ResultImage != null)
            {
                if (newFocAttestationTestResult.ResultImage.File != null && currentFocAttestationTestResultTestResult.ResultImage.File != null && currentFocAttestationTestResultTestResult.ResultImage.File.Path == newFocAttestationTestResult.ResultImage.File.Path)
                    newFocAttestationTestResult.ResultImage = currentFocAttestationTestResultTestResult.ResultImage;

                if (currentFocAttestationTestResultTestResult.ResultImage.ReadingSource == ReadingSource.Manual && newFocAttestationTestResult.ResultImage.ReadingSource == ReadingSource.Automatic)
                    newFocAttestationTestResult.ResultImage = currentFocAttestationTestResultTestResult.ResultImage;
            }

            if (newFocAttestationTestResult.ResultImage != null)
            {
                if (newFocAttestationTestResult.ResultImage.File == null) newFocAttestationTestResult.ResultImage = null;
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newFocAttestationTestResult = (FocAttestationTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentFocAttestationTestResultTestResult, newFocAttestationTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newFocAttestationTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newFocAttestationTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newFocAttestationTestResult.ResultStatus.Status == TestResultStatus.Complete && newFocAttestationTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newFocAttestationTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newFocAttestationTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var focAttestationTestResult = newTestResult as FocAttestationTestResult;
            if (focAttestationTestResult == null) return null;

            if (focAttestationTestResult.TestPerformedExternally != null)
            {
                if (focAttestationTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && focAttestationTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return focAttestationTestResult;
            }


            if (focAttestationTestResult.ResultImage == null || focAttestationTestResult.ResultImage.File == null)
                focAttestationTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            else
                focAttestationTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return focAttestationTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;

            newTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
            var newFocAttestationTestResult = (FocAttestationTestResult)newTestResult;

            if (newFocAttestationTestResult.UnableScreenReason != null && newFocAttestationTestResult.UnableScreenReason.Count > 0)
            {
                newFocAttestationTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newFocAttestationTestResult;
            }

            if (newFocAttestationTestResult.ResultImage != null && newFocAttestationTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newFocAttestationTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newFocAttestationTestResult;
            }

            newFocAttestationTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;

            return newFocAttestationTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;

            newTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            var newFocAttestationTestResult = (FocAttestationTestResult)newTestResult;

            if (newFocAttestationTestResult.UnableScreenReason != null && newFocAttestationTestResult.UnableScreenReason.Count > 0)
            {
                newFocAttestationTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newFocAttestationTestResult;
            }

            if (newFocAttestationTestResult.ResultImage != null && newFocAttestationTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newFocAttestationTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newFocAttestationTestResult;
            }

            newFocAttestationTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;

            return newFocAttestationTestResult;
        }
    }
}