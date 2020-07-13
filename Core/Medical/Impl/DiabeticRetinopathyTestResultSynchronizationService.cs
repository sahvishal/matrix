using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class DiabeticRetinopathyTestResultSynchronizationService : TestResultSynchronizationService
    {
        public DiabeticRetinopathyTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newDiabeticRetinopathyTestResult = (DiabeticRetinopathyTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newDiabeticRetinopathyTestResult.ResultImage != null)
                {
                    if (newDiabeticRetinopathyTestResult.ResultImage.File == null) newDiabeticRetinopathyTestResult.ResultImage = null;
                }

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newDiabeticRetinopathyTestResult;
            }

            var currentDiabeticRetinopathyTestResultTestResult = (DiabeticRetinopathyTestResult)currentTestResult;
            newDiabeticRetinopathyTestResult.Id = currentDiabeticRetinopathyTestResultTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (currentDiabeticRetinopathyTestResultTestResult.ResultImage != null && newDiabeticRetinopathyTestResult.ResultImage != null)
            {
                if (newDiabeticRetinopathyTestResult.ResultImage.File != null && currentDiabeticRetinopathyTestResultTestResult.ResultImage.File != null && currentDiabeticRetinopathyTestResultTestResult.ResultImage.File.Path == newDiabeticRetinopathyTestResult.ResultImage.File.Path)
                    newDiabeticRetinopathyTestResult.ResultImage = currentDiabeticRetinopathyTestResultTestResult.ResultImage;

                if (currentDiabeticRetinopathyTestResultTestResult.ResultImage.ReadingSource == ReadingSource.Manual && newDiabeticRetinopathyTestResult.ResultImage.ReadingSource == ReadingSource.Automatic)
                    newDiabeticRetinopathyTestResult.ResultImage = currentDiabeticRetinopathyTestResultTestResult.ResultImage;
            }

            if (newDiabeticRetinopathyTestResult.ResultImage != null)
            {
                if (newDiabeticRetinopathyTestResult.ResultImage.File == null) newDiabeticRetinopathyTestResult.ResultImage = null;
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newDiabeticRetinopathyTestResult.Finding = currentDiabeticRetinopathyTestResultTestResult.Finding;
                newDiabeticRetinopathyTestResult = (DiabeticRetinopathyTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentDiabeticRetinopathyTestResultTestResult, newDiabeticRetinopathyTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newDiabeticRetinopathyTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newDiabeticRetinopathyTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newDiabeticRetinopathyTestResult.ResultStatus.Status == TestResultStatus.Complete && newDiabeticRetinopathyTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newDiabeticRetinopathyTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newDiabeticRetinopathyTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var dabeticRetinopathyTestResult = newTestResult as DiabeticRetinopathyTestResult;
            if (dabeticRetinopathyTestResult == null) return null;

            if (dabeticRetinopathyTestResult.TestPerformedExternally != null)
            {
                if (dabeticRetinopathyTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && dabeticRetinopathyTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return dabeticRetinopathyTestResult;
            }


            if (dabeticRetinopathyTestResult.ResultImage == null || dabeticRetinopathyTestResult.ResultImage.File == null)
                dabeticRetinopathyTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            else
                dabeticRetinopathyTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return dabeticRetinopathyTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
            var newDiabeticRetinopathyTestResult = (DiabeticRetinopathyTestResult)newTestResult;

            if (newDiabeticRetinopathyTestResult.UnableScreenReason != null && newDiabeticRetinopathyTestResult.UnableScreenReason.Count > 0)
            {
                newDiabeticRetinopathyTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newDiabeticRetinopathyTestResult;
            }

            newDiabeticRetinopathyTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newDiabeticRetinopathyTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            var newDiabeticRetinopathyTestResult = (DiabeticRetinopathyTestResult)newTestResult;

            if (newDiabeticRetinopathyTestResult.UnableScreenReason != null && newDiabeticRetinopathyTestResult.UnableScreenReason.Count > 0)
            {
                newDiabeticRetinopathyTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newDiabeticRetinopathyTestResult;
            }

            newDiabeticRetinopathyTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newDiabeticRetinopathyTestResult;
        }
    }
}