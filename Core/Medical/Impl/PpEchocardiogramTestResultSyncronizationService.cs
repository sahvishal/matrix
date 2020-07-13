using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class PpEchocardiogramTestResultSyncronizationService : TestResultSynchronizationService
    {
        public PpEchocardiogramTestResultSyncronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newEchoTestResult = (PpEchocardiogramTestResult)newTestResult;
            SyncronizeTestResult(currentTestResult, newTestResult);
            if (currentTestResult != null)
            {
                newEchoTestResult.Id = currentTestResult.Id;
                newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newEchoTestResult = (PpEchocardiogramTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentTestResult, newEchoTestResult);
            }

            return newEchoTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newEchoTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newEchoTestResult.ResultStatus.Status == TestResultStatus.Complete && newEchoTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newEchoTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newEchoTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var echoTestResult = newTestResult as PpEchocardiogramTestResult;

            if (echoTestResult != null)
            {
                if (echoTestResult.TestPerformedExternally != null)
                {
                    if (echoTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && echoTestResult.TestPerformedExternally.EntryCompleted)
                    {
                        newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                    }
                    else
                    {
                        newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                    }
                    return echoTestResult;
                }

                if (echoTestResult.Media == null || echoTestResult.Media.Count < 1)
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                else newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            }

            return echoTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newEchoTestResult = (PpEchocardiogramTestResult)newTestResult;

            if (newEchoTestResult.UnableScreenReason != null && newEchoTestResult.UnableScreenReason.Count > 0)
                newEchoTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;

            return newEchoTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newEchoTestResult = (PpEchocardiogramTestResult)newTestResult;

            if (newEchoTestResult.UnableScreenReason != null && newEchoTestResult.UnableScreenReason.Count > 0)
                newEchoTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;

            return newEchoTestResult;
        }
    }
}
