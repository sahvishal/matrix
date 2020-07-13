using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class DiabetesTestResultSynchronizationService : TestResultSynchronizationService
    {
        public DiabetesTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newDiabetesTestResult = (DiabetesTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newDiabetesTestResult.Glucose != null && newDiabetesTestResult.Glucose.Reading == null && newDiabetesTestResult.Glucose.Finding == null) newDiabetesTestResult.Glucose = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newDiabetesTestResult;
            }

            var currentDiabetesTestResult = (DiabetesTestResult)currentTestResult;
            newDiabetesTestResult.Id = currentDiabetesTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            newDiabetesTestResult.Glucose = SynchronizeResultReading(currentDiabetesTestResult.Glucose, newDiabetesTestResult.Glucose, newTestResult.DataRecorderMetaData);

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newDiabetesTestResult = (DiabetesTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentDiabetesTestResult, newDiabetesTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newDiabetesTestResult;
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var diabetesTestResult = newTestResult as DiabetesTestResult;
            if (diabetesTestResult == null) return diabetesTestResult;

            if (diabetesTestResult.TestPerformedExternally != null)
            {
                if (diabetesTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && diabetesTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return diabetesTestResult;
            }


            foreach (var reading in compareToResultReadings)
            {
                switch (reading.Label)
                {
                    case ReadingLabels.Glucose:
                        if (IsIncompleteReading(diabetesTestResult.Glucose))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;
                }
            }

            newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return diabetesTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newDiabetesTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newDiabetesTestResult.ResultStatus.Status == TestResultStatus.Complete && newDiabetesTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newDiabetesTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newDiabetesTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newDiabetesTestResult = (DiabetesTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.Glucose:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newDiabetesTestResult.Glucose);
                        if (returnStatus) { newDiabetesTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newDiabetesTestResult; }
                        break;

                }
            }

            if (newDiabetesTestResult.UnableScreenReason != null && newDiabetesTestResult.UnableScreenReason.Count > 0)
            {
                newDiabetesTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newDiabetesTestResult;
            }

            newDiabetesTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newDiabetesTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newDiabetesTestResult = (DiabetesTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.Glucose:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newDiabetesTestResult.Glucose);
                        if (returnStatus) { newDiabetesTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newDiabetesTestResult; }
                        break;

                }
            }

            if (newDiabetesTestResult.UnableScreenReason != null && newDiabetesTestResult.UnableScreenReason.Count > 0)
            {
                newDiabetesTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newDiabetesTestResult;
            }

            newDiabetesTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newDiabetesTestResult;
        }
    }
}