using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class DiabeticNeuropathyTestResultSynchronizationService : TestResultSynchronizationService
    {
        public DiabeticNeuropathyTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newDiabeticNeuropathyTestResult = (DiabeticNeuropathyTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newDiabeticNeuropathyTestResult.Amplitude != null && newDiabeticNeuropathyTestResult.Amplitude.Reading == null) newDiabeticNeuropathyTestResult.Amplitude = null;
                if (newDiabeticNeuropathyTestResult.ConductionVelocity != null && newDiabeticNeuropathyTestResult.ConductionVelocity.Reading == null) newDiabeticNeuropathyTestResult.ConductionVelocity = null;

                if (newDiabeticNeuropathyTestResult.RightLeg != null && newDiabeticNeuropathyTestResult.RightLeg.Reading == null) newDiabeticNeuropathyTestResult.RightLeg = null;
                if (newDiabeticNeuropathyTestResult.LeftLeg != null && newDiabeticNeuropathyTestResult.LeftLeg.Reading == null) newDiabeticNeuropathyTestResult.LeftLeg = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newDiabeticNeuropathyTestResult;
            }

            var currentDiabeticNeuropathyTestResultTestResult = (DiabeticNeuropathyTestResult)currentTestResult;
            newDiabeticNeuropathyTestResult.Id = currentDiabeticNeuropathyTestResultTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            newDiabeticNeuropathyTestResult.Amplitude = SynchronizeResultReading(currentDiabeticNeuropathyTestResultTestResult.Amplitude, newDiabeticNeuropathyTestResult.Amplitude, newTestResult.DataRecorderMetaData);
            newDiabeticNeuropathyTestResult.ConductionVelocity = SynchronizeResultReading(currentDiabeticNeuropathyTestResultTestResult.ConductionVelocity, newDiabeticNeuropathyTestResult.ConductionVelocity, newTestResult.DataRecorderMetaData);

            newDiabeticNeuropathyTestResult.RightLeg = SynchronizeResultReading(currentDiabeticNeuropathyTestResultTestResult.RightLeg, newDiabeticNeuropathyTestResult.RightLeg, newTestResult.DataRecorderMetaData);
            newDiabeticNeuropathyTestResult.LeftLeg = SynchronizeResultReading(currentDiabeticNeuropathyTestResultTestResult.LeftLeg, newDiabeticNeuropathyTestResult.LeftLeg, newTestResult.DataRecorderMetaData);


            if (NewReadingSource == ReadingSource.Automatic)
            {
                newDiabeticNeuropathyTestResult.Finding = currentDiabeticNeuropathyTestResultTestResult.Finding;
                newDiabeticNeuropathyTestResult = (DiabeticNeuropathyTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentDiabeticNeuropathyTestResultTestResult, newDiabeticNeuropathyTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newDiabeticNeuropathyTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newDiabeticRetinopathyTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newDiabeticRetinopathyTestResult.ResultStatus.Status == TestResultStatus.Complete && newDiabeticRetinopathyTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newDiabeticRetinopathyTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newDiabeticRetinopathyTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var dabeticNeuropathyTestResult = newTestResult as DiabeticNeuropathyTestResult;
            if (dabeticNeuropathyTestResult == null) return null;

            if (dabeticNeuropathyTestResult.TestPerformedExternally != null)
            {
                if (dabeticNeuropathyTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && dabeticNeuropathyTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return dabeticNeuropathyTestResult;
            }


            if (dabeticNeuropathyTestResult.Amplitude == null || dabeticNeuropathyTestResult.ConductionVelocity == null && (dabeticNeuropathyTestResult.RightLeg == null && dabeticNeuropathyTestResult.LeftLeg == null))
                dabeticNeuropathyTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            else
                dabeticNeuropathyTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return dabeticNeuropathyTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
            var newDiabeticRetinopathyTestResult = (DiabeticNeuropathyTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {

                    case ReadingLabels.Amplitude:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newDiabeticRetinopathyTestResult.Amplitude);
                        if (returnStatus)
                        {
                            newDiabeticRetinopathyTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newDiabeticRetinopathyTestResult;
                        }
                        break;

                    case ReadingLabels.ConductionVelocity:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newDiabeticRetinopathyTestResult.ConductionVelocity);
                        if (returnStatus)
                        {
                            newDiabeticRetinopathyTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newDiabeticRetinopathyTestResult;
                        }
                        break;

                    case ReadingLabels.RightLeg:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newDiabeticRetinopathyTestResult.RightLeg);
                        if (returnStatus)
                        {
                            newDiabeticRetinopathyTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newDiabeticRetinopathyTestResult;
                        }
                        break;

                    case ReadingLabels.LeftLeg:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newDiabeticRetinopathyTestResult.LeftLeg);
                        if (returnStatus)
                        {
                            newDiabeticRetinopathyTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newDiabeticRetinopathyTestResult;
                        }
                        break;
                }
            }

            if (newDiabeticRetinopathyTestResult.UnableScreenReason != null && newDiabeticRetinopathyTestResult.UnableScreenReason.Count > 0)
            {
                newDiabeticRetinopathyTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newDiabeticRetinopathyTestResult;
            }

            newDiabeticRetinopathyTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newDiabeticRetinopathyTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            var newDiabeticRetinopathyTestResult = (DiabeticNeuropathyTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {

                    case ReadingLabels.Amplitude:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newDiabeticRetinopathyTestResult.Amplitude);
                        if (returnStatus)
                        {
                            newDiabeticRetinopathyTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newDiabeticRetinopathyTestResult;
                        }
                        break;

                    case ReadingLabels.ConductionVelocity:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newDiabeticRetinopathyTestResult.ConductionVelocity);
                        if (returnStatus)
                        {
                            newDiabeticRetinopathyTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newDiabeticRetinopathyTestResult;
                        }
                        break;

                    case ReadingLabels.RightLeg:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newDiabeticRetinopathyTestResult.RightLeg);
                        if (returnStatus)
                        {
                            newDiabeticRetinopathyTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newDiabeticRetinopathyTestResult;
                        }
                        break;

                    case ReadingLabels.LeftLeg:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newDiabeticRetinopathyTestResult.LeftLeg);
                        if (returnStatus)
                        {
                            newDiabeticRetinopathyTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newDiabeticRetinopathyTestResult;
                        }
                        break;
                }
            }

            if (newDiabeticRetinopathyTestResult.UnableScreenReason != null && newDiabeticRetinopathyTestResult.UnableScreenReason.Count > 0)
            {
                newDiabeticRetinopathyTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newDiabeticRetinopathyTestResult;
            }

            newDiabeticRetinopathyTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newDiabeticRetinopathyTestResult;
        }
    }
}
