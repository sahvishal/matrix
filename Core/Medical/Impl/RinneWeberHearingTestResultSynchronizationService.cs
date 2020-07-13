using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class RinneWeberHearingTestResultSynchronizationService : TestResultSynchronizationService
    {
        public RinneWeberHearingTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var rinneWeberHearingTestResult = newTestResult as RinneWeberHearingTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);


                if (rinneWeberHearingTestResult.WeberNormal != null && rinneWeberHearingTestResult.WeberNormal.Reading == null) rinneWeberHearingTestResult.WeberNormal = null;
                if (rinneWeberHearingTestResult.WeberAbnormal != null && rinneWeberHearingTestResult.WeberAbnormal.Reading == null) rinneWeberHearingTestResult.WeberAbnormal = null;

                if (rinneWeberHearingTestResult.RinneNormal != null && rinneWeberHearingTestResult.RinneNormal.Reading == null) rinneWeberHearingTestResult.RinneNormal = null;
                if (rinneWeberHearingTestResult.RinneAbnormal != null && rinneWeberHearingTestResult.RinneAbnormal.Reading == null) rinneWeberHearingTestResult.RinneAbnormal = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return rinneWeberHearingTestResult;
            }

            var currentrinneWeberHearingTestResult = (RinneWeberHearingTestResult)currentTestResult;

            rinneWeberHearingTestResult.Id = currentrinneWeberHearingTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            rinneWeberHearingTestResult.WeberNormal = SynchronizeResultReading(currentrinneWeberHearingTestResult.WeberNormal, rinneWeberHearingTestResult.WeberNormal, newTestResult.DataRecorderMetaData);
            rinneWeberHearingTestResult.WeberAbnormal = SynchronizeResultReading(currentrinneWeberHearingTestResult.WeberAbnormal, rinneWeberHearingTestResult.WeberAbnormal, newTestResult.DataRecorderMetaData);

            rinneWeberHearingTestResult.RinneNormal = SynchronizeResultReading(currentrinneWeberHearingTestResult.RinneNormal, rinneWeberHearingTestResult.RinneNormal, newTestResult.DataRecorderMetaData);
            rinneWeberHearingTestResult.RinneAbnormal = SynchronizeResultReading(currentrinneWeberHearingTestResult.RinneAbnormal, rinneWeberHearingTestResult.RinneAbnormal, newTestResult.DataRecorderMetaData);


            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                rinneWeberHearingTestResult = (RinneWeberHearingTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentrinneWeberHearingTestResult, rinneWeberHearingTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return rinneWeberHearingTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var rinneWeberHearingTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (rinneWeberHearingTestResult.ResultStatus.Status == TestResultStatus.Complete && rinneWeberHearingTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    rinneWeberHearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return rinneWeberHearingTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var rinneWeberHearingTestResult = newTestResult as RinneWeberHearingTestResult;
            if (rinneWeberHearingTestResult == null) return null;

            if (rinneWeberHearingTestResult.TestPerformedExternally != null)
            {
                if (rinneWeberHearingTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && rinneWeberHearingTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return rinneWeberHearingTestResult;
            }


            if ((rinneWeberHearingTestResult.WeberNormal == null && rinneWeberHearingTestResult.WeberAbnormal == null) || (rinneWeberHearingTestResult.RinneNormal == null && rinneWeberHearingTestResult.RinneAbnormal == null))
            {
                rinneWeberHearingTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            }

            rinneWeberHearingTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return rinneWeberHearingTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var rinneWeberHearingTestResult = (RinneWeberHearingTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {

                    case ReadingLabels.WeberNormal:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, rinneWeberHearingTestResult.WeberNormal);
                        if (returnStatus)
                        {
                            rinneWeberHearingTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return rinneWeberHearingTestResult;
                        }
                        break;

                    case ReadingLabels.WeberAbnormal:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, rinneWeberHearingTestResult.WeberAbnormal);
                        if (returnStatus)
                        {
                            rinneWeberHearingTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return rinneWeberHearingTestResult;
                        }
                        break;

                    case ReadingLabels.RinneNormal:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, rinneWeberHearingTestResult.RinneNormal);
                        if (returnStatus)
                        {
                            rinneWeberHearingTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return rinneWeberHearingTestResult;
                        }
                        break;

                    case ReadingLabels.RinneAbnormal:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, rinneWeberHearingTestResult.RinneAbnormal);
                        if (returnStatus)
                        {
                            rinneWeberHearingTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return rinneWeberHearingTestResult;
                        }
                        break;
                }
            }

            if (rinneWeberHearingTestResult.UnableScreenReason != null && rinneWeberHearingTestResult.UnableScreenReason.Count > 0)
            {
                rinneWeberHearingTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return rinneWeberHearingTestResult;
            }

            rinneWeberHearingTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return rinneWeberHearingTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var rinneWeberHearingTestResult = (RinneWeberHearingTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {

                    case ReadingLabels.WeberNormal:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, rinneWeberHearingTestResult.WeberNormal);
                        if (returnStatus)
                        {
                            rinneWeberHearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return rinneWeberHearingTestResult;
                        }
                        break;

                    case ReadingLabels.WeberAbnormal:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, rinneWeberHearingTestResult.WeberAbnormal);
                        if (returnStatus)
                        {
                            rinneWeberHearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return rinneWeberHearingTestResult;
                        }
                        break;

                    case ReadingLabels.RinneNormal:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, rinneWeberHearingTestResult.RinneNormal);
                        if (returnStatus)
                        {
                            rinneWeberHearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return rinneWeberHearingTestResult;
                        }
                        break;

                    case ReadingLabels.RinneAbnormal:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, rinneWeberHearingTestResult.RinneAbnormal);
                        if (returnStatus)
                        {
                            rinneWeberHearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return rinneWeberHearingTestResult;
                        }
                        break;
                }
            }

            if (rinneWeberHearingTestResult.UnableScreenReason != null && rinneWeberHearingTestResult.UnableScreenReason.Count > 0)
            {
                rinneWeberHearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return rinneWeberHearingTestResult;
            }

            rinneWeberHearingTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return rinneWeberHearingTestResult;
        }
    }
}