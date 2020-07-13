using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical.Impl
{
    public class CsTestResultSynchronizationService : TestResultSynchronizationService
    {
        public CsTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newCsTestResult = (CsTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newCsTestResult.ResultImage != null)
                {
                    if (newCsTestResult.ResultImage.File == null) newCsTestResult.ResultImage = null;
                }

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newCsTestResult;
            }

            var currentCsTestResult = (CsTestResult)currentTestResult;
            newCsTestResult.Id = currentCsTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (currentCsTestResult.ResultImage != null && newCsTestResult.ResultImage != null)
            {
                if (newCsTestResult.ResultImage.File != null && currentCsTestResult.ResultImage.File != null && currentCsTestResult.ResultImage.File.Path == newCsTestResult.ResultImage.File.Path)
                    newCsTestResult.ResultImage = currentCsTestResult.ResultImage;

                if (currentCsTestResult.ResultImage.ReadingSource == ReadingSource.Manual && newCsTestResult.ResultImage.ReadingSource == ReadingSource.Automatic)
                    newCsTestResult.ResultImage = currentCsTestResult.ResultImage;
            }

            if (newCsTestResult.ResultImage != null)
            {
                if (newCsTestResult.ResultImage.File == null) newCsTestResult.ResultImage = null;
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newCsTestResult = (CsTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentCsTestResult, newCsTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newCsTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newCsTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newCsTestResult.ResultStatus.Status == TestResultStatus.Complete && newCsTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newCsTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newCsTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var csTestResult = newTestResult as CsTestResult;
            if (csTestResult == null) return null;

            if (csTestResult.TestPerformedExternally != null)
            {
                if (csTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && csTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return csTestResult;
            }

            if (csTestResult.ResultImage == null || csTestResult.ResultImage.File == null)
            {
                csTestResult.ResultStatus.Status = TestResultStatus.Incomplete;

                return csTestResult;
            }

            newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return csTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newCsTestResult = (CsTestResult)newTestResult;

            if (newCsTestResult.ResultImage != null && newCsTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newCsTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newCsTestResult;
            }


            if (newCsTestResult.UnableScreenReason != null && newCsTestResult.UnableScreenReason.Count > 0)
            {
                newCsTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newCsTestResult;
            }

            newCsTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newCsTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {

            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newCsTestResult = (CsTestResult)newTestResult;

            if (newCsTestResult.ResultImage != null && newCsTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newCsTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newCsTestResult;
            }


            if (newCsTestResult.UnableScreenReason != null && newCsTestResult.UnableScreenReason.Count > 0)
            {
                newCsTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newCsTestResult;
            }

            newCsTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newCsTestResult;
        }
    }
}
