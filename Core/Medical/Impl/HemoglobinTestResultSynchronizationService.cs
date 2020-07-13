using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class HemoglobinTestResultSynchronizationService : TestResultSynchronizationService
    {
        public HemoglobinTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newHemoglobinTestResult = (HemoglobinTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newHemoglobinTestResult.Hemoglobin != null && newHemoglobinTestResult.Hemoglobin.Reading == null && newHemoglobinTestResult.Hemoglobin.Finding == null) newHemoglobinTestResult.Hemoglobin = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newHemoglobinTestResult;
            }

            var currentHemoglobinTestResult = (HemoglobinTestResult)currentTestResult;
            newHemoglobinTestResult.Id = currentHemoglobinTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            newHemoglobinTestResult.Hemoglobin = SynchronizeResultReading(currentHemoglobinTestResult.Hemoglobin, newHemoglobinTestResult.Hemoglobin, newTestResult.DataRecorderMetaData);


            if (NewReadingSource == ReadingSource.Automatic)
            {
                newHemoglobinTestResult = (HemoglobinTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentHemoglobinTestResult, newHemoglobinTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newHemoglobinTestResult;
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var hemoglobinTestResult = newTestResult as HemoglobinTestResult;
            if (hemoglobinTestResult == null) return hemoglobinTestResult;

            if (hemoglobinTestResult.TestPerformedExternally != null)
            {
                if (hemoglobinTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && hemoglobinTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return hemoglobinTestResult;
            }


            foreach (var reading in compareToResultReadings)
            {
                switch (reading.Label)
                {

                    case ReadingLabels.Hemoglobin:
                        if (IsIncompleteReading(hemoglobinTestResult.Hemoglobin))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;
                }
            }

            newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return hemoglobinTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newHemoglobinTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newHemoglobinTestResult.ResultStatus.Status == TestResultStatus.Complete && newHemoglobinTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newHemoglobinTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newHemoglobinTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newHemoglobinTestResult = (HemoglobinTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {

                    case ReadingLabels.Hemoglobin:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHemoglobinTestResult.Hemoglobin);
                        if (returnStatus) { newHemoglobinTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newHemoglobinTestResult; }
                        break;
                }
            }

            if (newHemoglobinTestResult.UnableScreenReason != null && newHemoglobinTestResult.UnableScreenReason.Count > 0)
            {
                newHemoglobinTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newHemoglobinTestResult;
            }

            newHemoglobinTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newHemoglobinTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newHemoglobinTestResult = (HemoglobinTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {

                    case ReadingLabels.Hemoglobin:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHemoglobinTestResult.Hemoglobin);
                        if (returnStatus) { newHemoglobinTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newHemoglobinTestResult; }
                        break;
                }
            }

            if (newHemoglobinTestResult.UnableScreenReason != null && newHemoglobinTestResult.UnableScreenReason.Count > 0)
            {
                newHemoglobinTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newHemoglobinTestResult;
            }

            newHemoglobinTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newHemoglobinTestResult;
        }
    }
}
