using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class LiverTestResultSynchronizationService : TestResultSynchronizationService
    {
        public LiverTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {

            var newLiverTestResult = (LiverTestResult)newTestResult;


            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newLiverTestResult.AST.Reading == null && newLiverTestResult.AST.Finding == null) newLiverTestResult.AST = null;
                if (newLiverTestResult.ALT.Reading == null && newLiverTestResult.ALT.Finding == null) newLiverTestResult.ALT = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newLiverTestResult;
            }

            var currentLiverTestResult = (LiverTestResult)currentTestResult;
            newLiverTestResult.Id = currentLiverTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            newLiverTestResult.AST = SynchronizeResultReading(currentLiverTestResult.AST, newLiverTestResult.AST, newTestResult.DataRecorderMetaData);
            newLiverTestResult.ALT = SynchronizeResultReading(currentLiverTestResult.ALT, newLiverTestResult.ALT, newTestResult.DataRecorderMetaData);

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newLiverTestResult = (LiverTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentLiverTestResult, newLiverTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newLiverTestResult;
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var liverTestResult = newTestResult as LiverTestResult;

            if (liverTestResult != null)
            {
                if (liverTestResult.TestPerformedExternally != null)
                {
                    if (liverTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && liverTestResult.TestPerformedExternally.EntryCompleted)
                    {
                        newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                    }
                    else
                    {
                        newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                    }
                    return liverTestResult;
                }

                if (IsIncompleteReading<int?>(liverTestResult.AST) ||
                    IsIncompleteReading<int?>(liverTestResult.ALT))
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                else newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            }
            return liverTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newLiverTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newLiverTestResult.ResultStatus.Status == TestResultStatus.Complete && newLiverTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newLiverTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newLiverTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        private TestResult OldResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;

            LiverTestResult newLiverTestResult = newTestResult as LiverTestResult;

            bool returnStatus = SynchronizeForChangeReadingSource<int?>(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.AST).ReadingSource, newLiverTestResult.AST);
            if (returnStatus) { newLiverTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newLiverTestResult; }

            returnStatus = SynchronizeForChangeReadingSource<int?>(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.ALT).ReadingSource, newLiverTestResult.ALT);
            if (returnStatus) { newLiverTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newLiverTestResult; }

            newLiverTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newLiverTestResult;
        }

        private TestResult NewResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;

            LiverTestResult newLiverTestResult = newTestResult as LiverTestResult;

            bool returnStatus = SynchronizeForChangeReadingSource<int?>(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.AST).ReadingSource, newLiverTestResult.AST);
            if (returnStatus) { newLiverTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newLiverTestResult; }

            returnStatus = SynchronizeForChangeReadingSource<int?>(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.ALT).ReadingSource, newLiverTestResult.ALT);
            if (returnStatus) { newLiverTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newLiverTestResult; }

            newLiverTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newLiverTestResult;
        }
    }
}
