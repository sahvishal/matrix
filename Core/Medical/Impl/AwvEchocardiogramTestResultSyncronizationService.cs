using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class AwvEchocardiogramTestResultSyncronizationService : TestResultSynchronizationService
    {
        public AwvEchocardiogramTestResultSyncronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newAwvEchoTestResult = (AwvEchocardiogramTestResult)newTestResult;
            SyncronizeTestResult(currentTestResult, newTestResult);
            if (currentTestResult != null)
            {
                newAwvEchoTestResult.Id = currentTestResult.Id;
                newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newAwvEchoTestResult = (AwvEchocardiogramTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentTestResult, newAwvEchoTestResult);
            }

            return newAwvEchoTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newAwvEchoTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newAwvEchoTestResult.ResultStatus.Status == TestResultStatus.Complete && newAwvEchoTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newAwvEchoTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newAwvEchoTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var awvEchoTestResult = newTestResult as AwvEchocardiogramTestResult;

            if (awvEchoTestResult != null)
            {
                if (awvEchoTestResult.TestPerformedExternally != null)
                {
                    if (awvEchoTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && awvEchoTestResult.TestPerformedExternally.EntryCompleted)
                    {
                        newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                    }
                    else
                    {
                        newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                    }
                    return awvEchoTestResult;
                }

                if (awvEchoTestResult.Media == null || awvEchoTestResult.Media.Count < 1)
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                else newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            }

            return awvEchoTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newAwvEchoTestResult = (AwvEchocardiogramTestResult)newTestResult;

            if (newAwvEchoTestResult.UnableScreenReason != null && newAwvEchoTestResult.UnableScreenReason.Count > 0)
                newAwvEchoTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;

            return newAwvEchoTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newAwvEchoTestResult = (AwvEchocardiogramTestResult)newTestResult;

            if (newAwvEchoTestResult.UnableScreenReason != null && newAwvEchoTestResult.UnableScreenReason.Count > 0)
                newAwvEchoTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;

            return newAwvEchoTestResult;
        }
    }
}
