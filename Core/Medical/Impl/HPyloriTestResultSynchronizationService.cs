using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class HPyloriTestResultSynchronizationService : TestResultSynchronizationService
    {
        public HPyloriTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newHPyloriTestResult = (HPyloriTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newHPyloriTestResult;
            }

            var currentHPyloriTestResult = (HPyloriTestResult)currentTestResult;
            newHPyloriTestResult.Id = currentHPyloriTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;





            if (NewReadingSource == ReadingSource.Automatic)
            {
                newHPyloriTestResult.Finding = currentHPyloriTestResult.Finding;
                newHPyloriTestResult = (HPyloriTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentHPyloriTestResult, newHPyloriTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newHPyloriTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newHPyloriTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newHPyloriTestResult.ResultStatus.Status == TestResultStatus.Complete && newHPyloriTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newHPyloriTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newHPyloriTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var hPyloriTestResult = newTestResult as HPyloriTestResult;
            if (hPyloriTestResult == null) return null;

            if (hPyloriTestResult.TestPerformedExternally != null)
            {
                if (hPyloriTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && hPyloriTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return hPyloriTestResult;
            }

            hPyloriTestResult.ResultStatus.Status = hPyloriTestResult.Finding == null
                ? TestResultStatus.Incomplete
                : TestResultStatus.Complete;

            return hPyloriTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
            var newHPyloriTestResult = (HPyloriTestResult)newTestResult;

            if (newHPyloriTestResult.UnableScreenReason != null && newHPyloriTestResult.UnableScreenReason.Count > 0)
            {
                newHPyloriTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newHPyloriTestResult;
            }

            newHPyloriTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newHPyloriTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            var newHPyloriTestResult = (HPyloriTestResult)newTestResult;

            if (newHPyloriTestResult.UnableScreenReason != null && newHPyloriTestResult.UnableScreenReason.Count > 0)
            {
                newHPyloriTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newHPyloriTestResult;
            }

            newHPyloriTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newHPyloriTestResult;
        }
    }
}