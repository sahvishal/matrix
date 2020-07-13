using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class HearingTestResultSynchronizationService : TestResultSynchronizationService
    {
        public HearingTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var hearingTestResult = newTestResult as HearingTestResult;
            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (hearingTestResult.HearingSummary != null && hearingTestResult.HearingSummary.Reading == null) hearingTestResult.HearingSummary = null;

                if (hearingTestResult.RightEar500Hz != null && hearingTestResult.RightEar500Hz.Reading == null) hearingTestResult.RightEar500Hz = null;
                if (hearingTestResult.LeftEar500Hz != null && hearingTestResult.LeftEar500Hz.Reading == null) hearingTestResult.LeftEar500Hz = null;

                if (hearingTestResult.RightEar1000Hz != null && hearingTestResult.RightEar1000Hz.Reading == null) hearingTestResult.RightEar1000Hz = null;
                if (hearingTestResult.LeftEar1000Hz != null && hearingTestResult.LeftEar1000Hz.Reading == null) hearingTestResult.LeftEar1000Hz = null;

                if (hearingTestResult.RightEar2000Hz != null && hearingTestResult.RightEar2000Hz.Reading == null) hearingTestResult.RightEar2000Hz = null;
                if (hearingTestResult.LeftEar2000Hz != null && hearingTestResult.LeftEar2000Hz.Reading == null) hearingTestResult.LeftEar2000Hz = null;

                if (hearingTestResult.RightEar3000Hz != null && hearingTestResult.RightEar3000Hz.Reading == null) hearingTestResult.RightEar3000Hz = null;
                if (hearingTestResult.LeftEar3000Hz != null && hearingTestResult.LeftEar3000Hz.Reading == null) hearingTestResult.LeftEar3000Hz = null;

                if (hearingTestResult.RightEar4000Hz != null && hearingTestResult.RightEar4000Hz.Reading == null) hearingTestResult.RightEar4000Hz = null;
                if (hearingTestResult.LeftEar4000Hz != null && hearingTestResult.LeftEar4000Hz.Reading == null) hearingTestResult.LeftEar4000Hz = null;

                if (hearingTestResult.RightEar6000Hz != null && hearingTestResult.RightEar6000Hz.Reading == null) hearingTestResult.RightEar6000Hz = null;
                if (hearingTestResult.LeftEar6000Hz != null && hearingTestResult.LeftEar6000Hz.Reading == null) hearingTestResult.LeftEar6000Hz = null;

                if (hearingTestResult.RightEar8000Hz != null && hearingTestResult.RightEar8000Hz.Reading == null) hearingTestResult.RightEar8000Hz = null;
                if (hearingTestResult.LeftEar8000Hz != null && hearingTestResult.LeftEar8000Hz.Reading == null) hearingTestResult.LeftEar8000Hz = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return hearingTestResult;
            }

            var currentHearingTestResult = (HearingTestResult)currentTestResult;

            hearingTestResult.Id = currentHearingTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            hearingTestResult.HearingSummary = SynchronizeResultReading(currentHearingTestResult.HearingSummary, hearingTestResult.HearingSummary, newTestResult.DataRecorderMetaData);

            hearingTestResult.RightEar500Hz = SynchronizeResultReading(currentHearingTestResult.RightEar500Hz, hearingTestResult.RightEar500Hz, newTestResult.DataRecorderMetaData);
            hearingTestResult.LeftEar500Hz = SynchronizeResultReading(currentHearingTestResult.LeftEar500Hz, hearingTestResult.LeftEar500Hz, newTestResult.DataRecorderMetaData);

            hearingTestResult.RightEar1000Hz = SynchronizeResultReading(currentHearingTestResult.RightEar1000Hz, hearingTestResult.RightEar1000Hz, newTestResult.DataRecorderMetaData);
            hearingTestResult.LeftEar1000Hz = SynchronizeResultReading(currentHearingTestResult.LeftEar1000Hz, hearingTestResult.LeftEar1000Hz, newTestResult.DataRecorderMetaData);

            hearingTestResult.RightEar2000Hz = SynchronizeResultReading(currentHearingTestResult.RightEar2000Hz, hearingTestResult.RightEar2000Hz, newTestResult.DataRecorderMetaData);
            hearingTestResult.LeftEar2000Hz = SynchronizeResultReading(currentHearingTestResult.LeftEar2000Hz, hearingTestResult.LeftEar2000Hz, newTestResult.DataRecorderMetaData);

            hearingTestResult.RightEar3000Hz = SynchronizeResultReading(currentHearingTestResult.RightEar3000Hz, hearingTestResult.RightEar3000Hz, newTestResult.DataRecorderMetaData);
            hearingTestResult.LeftEar3000Hz = SynchronizeResultReading(currentHearingTestResult.LeftEar3000Hz, hearingTestResult.LeftEar3000Hz, newTestResult.DataRecorderMetaData);

            hearingTestResult.RightEar4000Hz = SynchronizeResultReading(currentHearingTestResult.RightEar4000Hz, hearingTestResult.RightEar4000Hz, newTestResult.DataRecorderMetaData);
            hearingTestResult.LeftEar4000Hz = SynchronizeResultReading(currentHearingTestResult.LeftEar4000Hz, hearingTestResult.LeftEar4000Hz, newTestResult.DataRecorderMetaData);

            hearingTestResult.RightEar6000Hz = SynchronizeResultReading(currentHearingTestResult.RightEar6000Hz, hearingTestResult.RightEar6000Hz, newTestResult.DataRecorderMetaData);
            hearingTestResult.LeftEar6000Hz = SynchronizeResultReading(currentHearingTestResult.LeftEar6000Hz, hearingTestResult.LeftEar6000Hz, newTestResult.DataRecorderMetaData);

            hearingTestResult.RightEar8000Hz = SynchronizeResultReading(currentHearingTestResult.RightEar8000Hz, hearingTestResult.RightEar8000Hz, newTestResult.DataRecorderMetaData);
            hearingTestResult.LeftEar8000Hz = SynchronizeResultReading(currentHearingTestResult.LeftEar8000Hz, hearingTestResult.LeftEar8000Hz, newTestResult.DataRecorderMetaData);

            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                hearingTestResult = (HearingTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentHearingTestResult, hearingTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return hearingTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var hearingTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (hearingTestResult.ResultStatus.Status == TestResultStatus.Complete && hearingTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    hearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return hearingTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var hearingTestResult = newTestResult as HearingTestResult;
            if (hearingTestResult == null) return null;

            if (hearingTestResult.TestPerformedExternally != null)
            {
                if (hearingTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && hearingTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return hearingTestResult;
            }

            foreach (var reading in compareToResultReadings)
            {
                switch (reading.Label)
                {
                    case ReadingLabels.HearingSummary:
                        if (hearingTestResult.HearingSummary == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.RightEar500Hz:
                        if (hearingTestResult.RightEar500Hz == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEar500Hz:
                        if (hearingTestResult.LeftEar500Hz == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.RightEar1000Hz:
                        if (hearingTestResult.RightEar1000Hz == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEar1000Hz:
                        if (hearingTestResult.LeftEar1000Hz == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.RightEar2000Hz:
                        if (hearingTestResult.RightEar2000Hz == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEar2000Hz:
                        if (hearingTestResult.LeftEar2000Hz == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.RightEar3000Hz:
                        if (hearingTestResult.RightEar3000Hz == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEar3000Hz:
                        if (hearingTestResult.LeftEar3000Hz == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.RightEar4000Hz:
                        if (hearingTestResult.RightEar4000Hz == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEar4000Hz:
                        if (hearingTestResult.LeftEar4000Hz == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.RightEar6000Hz:
                        if (hearingTestResult.RightEar6000Hz == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEar6000Hz:
                        if (hearingTestResult.LeftEar6000Hz == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.RightEar8000Hz:
                        if (hearingTestResult.RightEar8000Hz == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEar8000Hz:
                        if (hearingTestResult.LeftEar8000Hz == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;
                }
            }
            hearingTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return hearingTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var hearingTestResult = (HearingTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.HearingSummary:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.HearingSummary);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.RightEar500Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.RightEar500Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEar500Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.LeftEar500Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.RightEar1000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.RightEar1000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEar1000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.LeftEar1000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.RightEar2000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.RightEar2000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEar2000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.LeftEar2000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.RightEar3000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.RightEar3000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEar3000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.LeftEar3000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.RightEar4000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.RightEar4000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEar4000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.LeftEar4000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.RightEar6000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.RightEar6000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEar6000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.LeftEar6000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.RightEar8000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.RightEar8000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEar8000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.LeftEar8000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return hearingTestResult;
                        }
                        break;
                }
            }

            if (hearingTestResult.UnableScreenReason != null && hearingTestResult.UnableScreenReason.Count > 0)
            {
                hearingTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return hearingTestResult;
            }

            hearingTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return hearingTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var hearingTestResult = (HearingTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.HearingSummary:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.HearingSummary);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.RightEar500Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.RightEar500Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEar500Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.LeftEar500Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.RightEar1000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.RightEar1000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEar1000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.LeftEar1000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.RightEar2000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.RightEar2000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEar2000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.LeftEar2000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.RightEar3000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.RightEar3000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEar3000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.LeftEar3000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.RightEar4000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.RightEar4000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEar4000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.LeftEar4000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.RightEar6000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.RightEar6000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEar6000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.LeftEar6000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.RightEar8000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.RightEar8000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return hearingTestResult;
                        }
                        break;

                    case ReadingLabels.LeftEar8000Hz:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, hearingTestResult.LeftEar8000Hz);
                        if (returnStatus)
                        {
                            hearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return hearingTestResult;
                        }
                        break;
                }
            }

            if (hearingTestResult.UnableScreenReason != null && hearingTestResult.UnableScreenReason.Count > 0)
            {
                hearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return hearingTestResult;
            }

            hearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return hearingTestResult;
        }
    }
}
