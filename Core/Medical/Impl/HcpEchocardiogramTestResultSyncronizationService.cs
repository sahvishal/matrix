using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class HcpEchocardiogramTestResultSyncronizationService : TestResultSynchronizationService
    {
        public HcpEchocardiogramTestResultSyncronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newHcpEchoTestResult = (HcpEchocardiogramTestResult)newTestResult;
            SyncronizeTestResult(currentTestResult, newTestResult);
            if (currentTestResult != null)
            {
                newHcpEchoTestResult.Id = currentTestResult.Id;
                newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newHcpEchoTestResult = (HcpEchocardiogramTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentTestResult, newHcpEchoTestResult);
            }

            return newHcpEchoTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newHcpEchoTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newHcpEchoTestResult.ResultStatus.Status == TestResultStatus.Complete && newHcpEchoTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newHcpEchoTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newHcpEchoTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var hcpEchoTestResult = newTestResult as HcpEchocardiogramTestResult;

            if (hcpEchoTestResult != null)
            {
                if (hcpEchoTestResult.TestPerformedExternally != null)
                {
                    if (hcpEchoTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && hcpEchoTestResult.TestPerformedExternally.EntryCompleted)
                    {
                        newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                    }
                    else
                    {
                        newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                    }
                    return hcpEchoTestResult;
                }

                if (hcpEchoTestResult.Media == null || hcpEchoTestResult.Media.Count < 1)
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                else newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            }

            return hcpEchoTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newHcpEchoTestResult = (HcpEchocardiogramTestResult)newTestResult;

            if (newHcpEchoTestResult.UnableScreenReason != null && newHcpEchoTestResult.UnableScreenReason.Count > 0)
                newHcpEchoTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;

            return newHcpEchoTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newHcpEchoTestResult = (HcpEchocardiogramTestResult)newTestResult;

            if (newHcpEchoTestResult.UnableScreenReason != null && newHcpEchoTestResult.UnableScreenReason.Count > 0)
                newHcpEchoTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;

            return newHcpEchoTestResult;
        }
    }
}