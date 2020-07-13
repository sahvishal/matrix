using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class AwvSpiroTestResultSynchronizationService : TestResultSynchronizationService
    {
        public AwvSpiroTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newAwvSpiroTestResult = (AwvSpiroTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newAwvSpiroTestResult;
            }

            var currentAwvSpiroTestResult = (AwvSpiroTestResult)currentTestResult;
            newAwvSpiroTestResult.Id = currentAwvSpiroTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (currentAwvSpiroTestResult.ResultImage != null && newAwvSpiroTestResult.ResultImage != null)
            {
                if (newAwvSpiroTestResult.ResultImage.File != null && currentAwvSpiroTestResult.ResultImage.File != null && currentAwvSpiroTestResult.ResultImage.File.Path == newAwvSpiroTestResult.ResultImage.File.Path)
                    newAwvSpiroTestResult.ResultImage = currentAwvSpiroTestResult.ResultImage;

                if (currentAwvSpiroTestResult.ResultImage.ReadingSource == ReadingSource.Manual
                    && newAwvSpiroTestResult.ResultImage.ReadingSource == ReadingSource.Automatic)
                    newAwvSpiroTestResult.ResultImage = currentAwvSpiroTestResult.ResultImage;

            }

            if (newAwvSpiroTestResult.ResultImage != null)
            {
                if (newAwvSpiroTestResult.ResultImage.File == null) newAwvSpiroTestResult.ResultImage = null;
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newAwvSpiroTestResult.Finding = currentAwvSpiroTestResult.Finding;
                newAwvSpiroTestResult = (AwvSpiroTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentAwvSpiroTestResult, newAwvSpiroTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newAwvSpiroTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newAwvSpiroTestResult = NewManualEntryUploadStatus(compareToResultReadings, newTestResult);
                if (newAwvSpiroTestResult.ResultStatus.Status == TestResultStatus.Complete && newAwvSpiroTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newAwvSpiroTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;

                return newAwvSpiroTestResult;
            }

            return OldManualEntryUploadStatus(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var awvSpiroTestResult = newTestResult as AwvSpiroTestResult;
            if (awvSpiroTestResult == null) return null;

            if (awvSpiroTestResult.TestPerformedExternally != null)
            {
                if (awvSpiroTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && awvSpiroTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return awvSpiroTestResult;
            }


            if (awvSpiroTestResult.Finding == null || awvSpiroTestResult.ResultImage == null)
                awvSpiroTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            else
                awvSpiroTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return awvSpiroTestResult;
        }

        private TestResult OldManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
            var newAwvSpiroTestResult = (AwvSpiroTestResult)newTestResult;

            if (newAwvSpiroTestResult.UnableScreenReason != null && newAwvSpiroTestResult.UnableScreenReason.Count > 0)
            {
                newAwvSpiroTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newAwvSpiroTestResult;
            }

            newAwvSpiroTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newAwvSpiroTestResult;
        }

        private TestResult NewManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            var newAwvSpiroTestResult = (AwvSpiroTestResult)newTestResult;

            if (newAwvSpiroTestResult.UnableScreenReason != null && newAwvSpiroTestResult.UnableScreenReason.Count > 0)
            {
                newAwvSpiroTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newAwvSpiroTestResult;
            }

            newAwvSpiroTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newAwvSpiroTestResult;
        }
    }
}
