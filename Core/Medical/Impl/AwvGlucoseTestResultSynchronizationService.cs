using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class AwvGlucoseTestResultSynchronizationService : TestResultSynchronizationService
    {
        public AwvGlucoseTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newAwvGlucoseTestResult = (AwvGlucoseTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newAwvGlucoseTestResult.Glucose != null && newAwvGlucoseTestResult.Glucose.Reading == null && newAwvGlucoseTestResult.Glucose.Finding == null) newAwvGlucoseTestResult.Glucose = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newAwvGlucoseTestResult;
            }

            var currentAwvGlucoseTestResult = (AwvGlucoseTestResult)currentTestResult;
            newAwvGlucoseTestResult.Id = currentAwvGlucoseTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            newAwvGlucoseTestResult.Glucose = SynchronizeResultReading(currentAwvGlucoseTestResult.Glucose, newAwvGlucoseTestResult.Glucose, newTestResult.DataRecorderMetaData);

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newAwvGlucoseTestResult = (AwvGlucoseTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentAwvGlucoseTestResult, newAwvGlucoseTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newAwvGlucoseTestResult;
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var awvGlucoseTestResult = newTestResult as AwvGlucoseTestResult;
            if (awvGlucoseTestResult == null) return awvGlucoseTestResult;

            if (awvGlucoseTestResult.TestPerformedExternally != null)
            {
                if (awvGlucoseTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && awvGlucoseTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return awvGlucoseTestResult;
            }

            foreach (var reading in compareToResultReadings)
            {
                switch (reading.Label)
                {
                    case ReadingLabels.Glucose:
                        if (IsIncompleteReading(awvGlucoseTestResult.Glucose))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;
                }
            }

            newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return awvGlucoseTestResult;
        }


        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newAwvGlucoseTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newAwvGlucoseTestResult.ResultStatus.Status == TestResultStatus.Complete && newAwvGlucoseTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newAwvGlucoseTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newAwvGlucoseTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newAwvGlucoseTestResult = (AwvGlucoseTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.Glucose:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvGlucoseTestResult.Glucose);
                        if (returnStatus) { newAwvGlucoseTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newAwvGlucoseTestResult; }
                        break;

                }
            }

            if (newAwvGlucoseTestResult.UnableScreenReason != null && newAwvGlucoseTestResult.UnableScreenReason.Count > 0)
            {
                newAwvGlucoseTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newAwvGlucoseTestResult;
            }

            newAwvGlucoseTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newAwvGlucoseTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newAwvGlucoseTestResult = (AwvGlucoseTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.Glucose:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvGlucoseTestResult.Glucose);
                        if (returnStatus) { newAwvGlucoseTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newAwvGlucoseTestResult; }
                        break;

                }
            }

            if (newAwvGlucoseTestResult.UnableScreenReason != null && newAwvGlucoseTestResult.UnableScreenReason.Count > 0)
            {
                newAwvGlucoseTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newAwvGlucoseTestResult;
            }

            newAwvGlucoseTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newAwvGlucoseTestResult;
        }
    }
}
