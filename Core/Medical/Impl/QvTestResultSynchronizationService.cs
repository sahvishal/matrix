using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical.Impl
{
    public class QvTestResultSynchronizationService : TestResultSynchronizationService
    {
        public QvTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newQvTestResult = (QvTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newQvTestResult.ResultImage != null)
                {
                    if (newQvTestResult.ResultImage.File == null) newQvTestResult.ResultImage = null;
                }

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newQvTestResult;
            }

            var currentQvTestResult = (QvTestResult)currentTestResult;
            newQvTestResult.Id = currentQvTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (currentQvTestResult.ResultImage != null && newQvTestResult.ResultImage != null)
            {
                if (newQvTestResult.ResultImage.File != null && currentQvTestResult.ResultImage.File != null && currentQvTestResult.ResultImage.File.Path == newQvTestResult.ResultImage.File.Path)
                    newQvTestResult.ResultImage = currentQvTestResult.ResultImage;

                if (currentQvTestResult.ResultImage.ReadingSource == ReadingSource.Manual && newQvTestResult.ResultImage.ReadingSource == ReadingSource.Automatic)
                    newQvTestResult.ResultImage = currentQvTestResult.ResultImage;
            }

            if (newQvTestResult.ResultImage != null)
            {
                if (newQvTestResult.ResultImage.File == null) newQvTestResult.ResultImage = null;
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newQvTestResult = (QvTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentQvTestResult, newQvTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newQvTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newQvTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newQvTestResult.ResultStatus.Status == TestResultStatus.Complete && newQvTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newQvTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newQvTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var qvTestResult = newTestResult as QvTestResult;
            if (qvTestResult == null) return null;

            if (qvTestResult.TestPerformedExternally != null)
            {
                if (qvTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && qvTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return qvTestResult;
            }

            if (qvTestResult.ResultImage == null || qvTestResult.ResultImage.File == null)
            {
                qvTestResult.ResultStatus.Status = TestResultStatus.Incomplete;

                return qvTestResult;
            }

            newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return qvTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newQvTestResult = (QvTestResult)newTestResult;

            if (newQvTestResult.ResultImage != null && newQvTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newQvTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newQvTestResult;
            }


            if (newQvTestResult.UnableScreenReason != null && newQvTestResult.UnableScreenReason.Count > 0)
            {
                newQvTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newQvTestResult;
            }

            newQvTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newQvTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {

            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newQvTestResult = (QvTestResult)newTestResult;

            if (newQvTestResult.ResultImage != null && newQvTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newQvTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newQvTestResult;
            }


            if (newQvTestResult.UnableScreenReason != null && newQvTestResult.UnableScreenReason.Count > 0)
            {
                newQvTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newQvTestResult;
            }

            newQvTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newQvTestResult;
        }
    }
}
