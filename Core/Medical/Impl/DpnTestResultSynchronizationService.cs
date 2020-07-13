using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class DpnTestResultSynchronizationService : TestResultSynchronizationService
    {
        public DpnTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newDpnTestResult = (DpnTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newDpnTestResult.Amplitude != null && newDpnTestResult.Amplitude.Reading == null) newDpnTestResult.Amplitude = null;
                if (newDpnTestResult.ConductionVelocity != null && newDpnTestResult.ConductionVelocity.Reading == null) newDpnTestResult.ConductionVelocity = null;

                if (newDpnTestResult.RightLeg != null && newDpnTestResult.RightLeg.Reading == null) newDpnTestResult.RightLeg = null;
                if (newDpnTestResult.LeftLeg != null && newDpnTestResult.LeftLeg.Reading == null) newDpnTestResult.LeftLeg = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newDpnTestResult;
            }

            var currentDpnTestResultTestResult = (DpnTestResult)currentTestResult;
            newDpnTestResult.Id = currentDpnTestResultTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (currentDpnTestResultTestResult.ResultImage != null && newDpnTestResult.ResultImage != null)
            {
                if (newDpnTestResult.ResultImage.File != null && currentDpnTestResultTestResult.ResultImage.File != null && currentDpnTestResultTestResult.ResultImage.File.Path == newDpnTestResult.ResultImage.File.Path)
                    newDpnTestResult.ResultImage = currentDpnTestResultTestResult.ResultImage;

                if (currentDpnTestResultTestResult.ResultImage.ReadingSource == ReadingSource.Manual && newDpnTestResult.ResultImage.ReadingSource == ReadingSource.Automatic)
                    newDpnTestResult.ResultImage = currentDpnTestResultTestResult.ResultImage;
            }

            newDpnTestResult.Amplitude = SynchronizeResultReading(currentDpnTestResultTestResult.Amplitude, newDpnTestResult.Amplitude, newTestResult.DataRecorderMetaData);
            newDpnTestResult.ConductionVelocity = SynchronizeResultReading(currentDpnTestResultTestResult.ConductionVelocity, newDpnTestResult.ConductionVelocity, newTestResult.DataRecorderMetaData);

            newDpnTestResult.RightLeg = SynchronizeResultReading(currentDpnTestResultTestResult.RightLeg, newDpnTestResult.RightLeg, newTestResult.DataRecorderMetaData);
            newDpnTestResult.LeftLeg = SynchronizeResultReading(currentDpnTestResultTestResult.LeftLeg, newDpnTestResult.LeftLeg, newTestResult.DataRecorderMetaData);


            if (NewReadingSource == ReadingSource.Automatic)
            {
                newDpnTestResult.Finding = currentDpnTestResultTestResult.Finding;
                newDpnTestResult = (DpnTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentDpnTestResultTestResult, newDpnTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newDpnTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newDpnTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newDpnTestResult.ResultStatus.Status == TestResultStatus.Complete && newDpnTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newDpnTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newDpnTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var dpnTestResult = newTestResult as DpnTestResult;
            if (dpnTestResult == null) return null;

            if (dpnTestResult.TestPerformedExternally != null)
            {
                if (dpnTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && dpnTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return dpnTestResult;
            }

            if (dpnTestResult.Amplitude == null || dpnTestResult.ConductionVelocity == null && (dpnTestResult.RightLeg == null && dpnTestResult.LeftLeg == null))
                dpnTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            else
                dpnTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return dpnTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
            var newDpnTestResult = (DpnTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {

                    case ReadingLabels.DpnAmplitude:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newDpnTestResult.Amplitude);
                        if (returnStatus)
                        {
                            newDpnTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newDpnTestResult;
                        }
                        break;

                    case ReadingLabels.DpnConductionVelocity:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newDpnTestResult.ConductionVelocity);
                        if (returnStatus)
                        {
                            newDpnTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newDpnTestResult;
                        }
                        break;

                    case ReadingLabels.DpnRightLeg:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newDpnTestResult.RightLeg);
                        if (returnStatus)
                        {
                            newDpnTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newDpnTestResult;
                        }
                        break;

                    case ReadingLabels.DpnLeftLeg:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newDpnTestResult.LeftLeg);
                        if (returnStatus)
                        {
                            newDpnTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newDpnTestResult;
                        }
                        break;
                }
            }

            if (newDpnTestResult.UnableScreenReason != null && newDpnTestResult.UnableScreenReason.Count > 0)
            {
                newDpnTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newDpnTestResult;
            }

            newDpnTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newDpnTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {

            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            var newDpnTestResult = (DpnTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {

                    case ReadingLabels.DpnAmplitude:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newDpnTestResult.Amplitude);
                        if (returnStatus)
                        {
                            newDpnTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newDpnTestResult;
                        }
                        break;

                    case ReadingLabels.DpnConductionVelocity:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newDpnTestResult.ConductionVelocity);
                        if (returnStatus)
                        {
                            newDpnTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newDpnTestResult;
                        }
                        break;

                    case ReadingLabels.DpnRightLeg:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newDpnTestResult.RightLeg);
                        if (returnStatus)
                        {
                            newDpnTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newDpnTestResult;
                        }
                        break;

                    case ReadingLabels.DpnLeftLeg:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newDpnTestResult.LeftLeg);
                        if (returnStatus)
                        {
                            newDpnTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newDpnTestResult;
                        }
                        break;
                }
            }

            if (newDpnTestResult.UnableScreenReason != null && newDpnTestResult.UnableScreenReason.Count > 0)
            {
                newDpnTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newDpnTestResult;
            }

            newDpnTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newDpnTestResult;
        }
    }
}