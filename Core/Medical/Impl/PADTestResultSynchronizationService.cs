using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class PadTestResultSynchronizationService : TestResultSynchronizationService
    {
        public PadTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newPadTestResult = (PADTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newPadTestResult.LeftResultReadings != null)
                {
                    if (newPadTestResult.LeftResultReadings.ABI != null && newPadTestResult.LeftResultReadings.ABI.Reading == null) newPadTestResult.LeftResultReadings.ABI = null;
                    if (newPadTestResult.LeftResultReadings.SystolicAnkle != null && newPadTestResult.LeftResultReadings.SystolicAnkle.Reading == null) newPadTestResult.LeftResultReadings.SystolicAnkle = null;
                    if (newPadTestResult.LeftResultReadings.SystolicArm != null && newPadTestResult.LeftResultReadings.SystolicArm.Reading == null) newPadTestResult.LeftResultReadings.SystolicArm = null;
                }

                if (newPadTestResult.RightResultReadings != null)
                {
                    if (newPadTestResult.RightResultReadings.ABI != null && newPadTestResult.RightResultReadings.ABI.Reading == null) newPadTestResult.RightResultReadings.ABI = null;
                    if (newPadTestResult.RightResultReadings.SystolicAnkle != null && newPadTestResult.RightResultReadings.SystolicAnkle.Reading == null) newPadTestResult.RightResultReadings.SystolicAnkle = null;
                    if (newPadTestResult.RightResultReadings.SystolicArm != null && newPadTestResult.RightResultReadings.SystolicArm.Reading == null) newPadTestResult.RightResultReadings.SystolicArm = null;
                }

                if (newPadTestResult.PressureReadings != null)
                {
                    if (newPadTestResult.PressureReadings.DiastolicRightArm != null && newPadTestResult.PressureReadings.DiastolicRightArm.Reading == null) newPadTestResult.PressureReadings.DiastolicRightArm = null;
                    if (newPadTestResult.PressureReadings.SystolicRightArm != null && newPadTestResult.PressureReadings.SystolicRightArm.Reading == null) newPadTestResult.PressureReadings.SystolicRightArm = null;
                    if (newPadTestResult.PressureReadings.DiastolicLeftArm != null && newPadTestResult.PressureReadings.DiastolicLeftArm.Reading == null) newPadTestResult.PressureReadings.DiastolicLeftArm = null;
                    if (newPadTestResult.PressureReadings.SystolicLeftArm != null && newPadTestResult.PressureReadings.SystolicLeftArm.Reading == null) newPadTestResult.PressureReadings.SystolicLeftArm = null;
                    if (newPadTestResult.PressureReadings.Pulse != null && newPadTestResult.PressureReadings.Pulse.Reading == null) newPadTestResult.PressureReadings.Pulse = null;
                    if (newPadTestResult.PressureReadings.PulsePressure != null && newPadTestResult.PressureReadings.PulsePressure.Reading == null) newPadTestResult.PressureReadings.PulsePressure = null;
                }

                if (newPadTestResult.PencilDopplerUsed != null && !newPadTestResult.PencilDopplerUsed.Reading)
                    newPadTestResult.PencilDopplerUsed = null;

                if (newPadTestResult.SystolicHighestArm != null && newPadTestResult.SystolicHighestArm.Reading == null) newPadTestResult.SystolicHighestArm = null;
                SyncronizeTestResult(currentTestResult, newTestResult);
                return newPadTestResult;
            }

            var currentPadTestResult = (PADTestResult)currentTestResult;
            newPadTestResult.Id = currentPadTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (newPadTestResult.PressureReadings != null)
            {
                newPadTestResult.PressureReadings.DiastolicRightArm =
                    SynchronizeResultReading(currentPadTestResult.PressureReadings.DiastolicRightArm,
                                             newPadTestResult.PressureReadings.DiastolicRightArm, newTestResult.DataRecorderMetaData);
                newPadTestResult.PressureReadings.SystolicRightArm =
                    SynchronizeResultReading(currentPadTestResult.PressureReadings.SystolicRightArm,
                                             newPadTestResult.PressureReadings.SystolicRightArm, newTestResult.DataRecorderMetaData);
                newPadTestResult.PressureReadings.DiastolicLeftArm =
                    SynchronizeResultReading(currentPadTestResult.PressureReadings.DiastolicLeftArm,
                                             newPadTestResult.PressureReadings.DiastolicLeftArm, newTestResult.DataRecorderMetaData);
                newPadTestResult.PressureReadings.SystolicLeftArm =
                    SynchronizeResultReading(currentPadTestResult.PressureReadings.SystolicLeftArm,
                                             newPadTestResult.PressureReadings.SystolicLeftArm, newTestResult.DataRecorderMetaData);

                newPadTestResult.PressureReadings.PulsePressure =
                    SynchronizeResultReading(currentPadTestResult.PressureReadings.PulsePressure,
                                             newPadTestResult.PressureReadings.PulsePressure, newTestResult.DataRecorderMetaData);
                newPadTestResult.PressureReadings.Pulse =
                    SynchronizeResultReading(currentPadTestResult.PressureReadings.Pulse,
                                             newPadTestResult.PressureReadings.Pulse, newTestResult.DataRecorderMetaData);
            }

            if (newPadTestResult.LeftResultReadings == null && currentPadTestResult.LeftResultReadings != null)
            {
                newPadTestResult.LeftResultReadings = new PadTestReadings();
            }

            if (currentPadTestResult.LeftResultReadings != null)
            {
                newPadTestResult.LeftResultReadings.ABI = SynchronizeResultReading(currentPadTestResult.LeftResultReadings.ABI, newPadTestResult.LeftResultReadings.ABI, newTestResult.DataRecorderMetaData);

                newPadTestResult.LeftResultReadings.SystolicArm = SynchronizeResultReading(currentPadTestResult.LeftResultReadings.SystolicArm, newPadTestResult.LeftResultReadings.SystolicArm, newTestResult.DataRecorderMetaData);

                newPadTestResult.LeftResultReadings.SystolicAnkle = SynchronizeResultReading(currentPadTestResult.LeftResultReadings.SystolicAnkle, newPadTestResult.LeftResultReadings.SystolicAnkle, newTestResult.DataRecorderMetaData);
            }


            if (newPadTestResult.RightResultReadings == null && currentPadTestResult.RightResultReadings != null)
            {
                newPadTestResult.RightResultReadings = new PadTestReadings();
            }

            if (currentPadTestResult.RightResultReadings != null)
            {
                newPadTestResult.RightResultReadings.ABI =
                    SynchronizeResultReading(currentPadTestResult.RightResultReadings.ABI, newPadTestResult.RightResultReadings.ABI, newTestResult.DataRecorderMetaData);
                newPadTestResult.RightResultReadings.SystolicArm =
                    SynchronizeResultReading(currentPadTestResult.RightResultReadings.SystolicArm, newPadTestResult.RightResultReadings.SystolicArm, newTestResult.DataRecorderMetaData);
                newPadTestResult.RightResultReadings.SystolicAnkle =
                    SynchronizeResultReading(currentPadTestResult.RightResultReadings.SystolicAnkle, newPadTestResult.RightResultReadings.SystolicAnkle, newTestResult.DataRecorderMetaData);
            }

            newPadTestResult.SystolicHighestArm = SynchronizeResultReading(currentPadTestResult.SystolicHighestArm, newPadTestResult.SystolicHighestArm, newTestResult.DataRecorderMetaData);

            if (newPadTestResult.Finding == null && newPadTestResult.LeftResultReadings != null && newPadTestResult.RightResultReadings != null && currentPadTestResult.Finding != null)
            {
                if (currentPadTestResult.LeftResultReadings != null && ((newPadTestResult.LeftResultReadings.ABI == null && currentPadTestResult.LeftResultReadings.ABI == null)
                    || (newPadTestResult.LeftResultReadings.ABI != null && currentPadTestResult.LeftResultReadings.ABI != null && currentPadTestResult.LeftResultReadings.ABI.Reading == newPadTestResult.LeftResultReadings.ABI.Reading))
                    &&
                    currentPadTestResult.RightResultReadings != null && ((newPadTestResult.RightResultReadings.ABI == null && currentPadTestResult.RightResultReadings.ABI == null)
                    || (newPadTestResult.RightResultReadings.ABI != null && currentPadTestResult.RightResultReadings.ABI != null && currentPadTestResult.RightResultReadings.ABI.Reading == newPadTestResult.RightResultReadings.ABI.Reading)))
                    newPadTestResult.Finding = currentPadTestResult.Finding;
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newPadTestResult = (PADTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentPadTestResult, newPadTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newPadTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newPadTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newPadTestResult.ResultStatus.Status == TestResultStatus.Complete && newPadTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newPadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newPadTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var padTestResult = newTestResult as PADTestResult;
            if (padTestResult == null) return null;

            if (padTestResult.TestPerformedExternally != null)
            {
                if (padTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && padTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return padTestResult;
            }

            bool isSystolicRightIncomp = false;
            bool isSystolicLeftIncomp = false;
            bool isDiastolicRightIncomp = false;
            bool isDiastolicLeftIncomp = false;
            foreach (var reading in compareToResultReadings)
            {
                switch (reading.Label)
                {
                    case ReadingLabels.LeftABI:
                        if (padTestResult.LeftResultReadings == null || padTestResult.LeftResultReadings.ABI == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicLArm:
                        if (padTestResult.LeftResultReadings == null || padTestResult.LeftResultReadings.SystolicArm == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicLAnkle:
                        if (padTestResult.LeftResultReadings == null || padTestResult.LeftResultReadings.SystolicAnkle == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.RightABI:
                        if (padTestResult.RightResultReadings == null || padTestResult.RightResultReadings.ABI == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicRArm:
                        if (padTestResult.RightResultReadings == null || padTestResult.RightResultReadings.SystolicArm == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicRAnkle:
                        if (padTestResult.RightResultReadings == null || padTestResult.RightResultReadings.SystolicAnkle == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.Pulse:
                        if (padTestResult.PressureReadings == null || padTestResult.PressureReadings.Pulse == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.PulsePressure:
                        if (padTestResult.PressureReadings == null || padTestResult.PressureReadings.PulsePressure == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicRight:
                        if (padTestResult.PressureReadings == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        if (padTestResult.PressureReadings.SystolicRightArm == null)
                        {
                            isSystolicRightIncomp = true;
                        }
                        break;

                    case ReadingLabels.SystolicLeft:
                        if (padTestResult.PressureReadings == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        if (padTestResult.PressureReadings.SystolicLeftArm == null)
                        {
                            isSystolicLeftIncomp = true;
                        }
                        break;

                    case ReadingLabels.DiastolicLeft:
                        if (padTestResult.PressureReadings == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        if (padTestResult.PressureReadings.DiastolicLeftArm == null)
                        {
                            isDiastolicLeftIncomp = true;
                        }
                        break;

                    case ReadingLabels.DiastolicRight:
                        if (padTestResult.PressureReadings == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        if (padTestResult.PressureReadings.DiastolicRightArm == null)
                        {
                            isDiastolicRightIncomp = true;
                        }
                        break;

                    case ReadingLabels.SystolicHighestArm:
                        if (padTestResult.SystolicHighestArm == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;
                }
            }

            if (!((!isDiastolicLeftIncomp && !isSystolicLeftIncomp) || (!isDiastolicRightIncomp && !isSystolicRightIncomp)))
            {
                newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                return newTestResult;
            }

            newTestResult.ResultStatus.Status = padTestResult.Finding == null ? TestResultStatus.Incomplete : TestResultStatus.Complete;

            return padTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newPadTestResult = (PADTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.LeftABI:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.LeftResultReadings != null ? newPadTestResult.LeftResultReadings.ABI : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicLArm:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.LeftResultReadings != null ? newPadTestResult.LeftResultReadings.SystolicArm : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicLAnkle:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.LeftResultReadings != null ? newPadTestResult.LeftResultReadings.SystolicAnkle : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.RightABI:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.RightResultReadings != null ? newPadTestResult.RightResultReadings.ABI : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicRArm:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.RightResultReadings != null ? newPadTestResult.RightResultReadings.SystolicArm : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicRAnkle:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.RightResultReadings != null ? newPadTestResult.RightResultReadings.SystolicAnkle : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.Pulse:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.PressureReadings != null ? newPadTestResult.PressureReadings.Pulse : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.PulsePressure:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.PressureReadings != null ? newPadTestResult.PressureReadings.PulsePressure : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicRight:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.PressureReadings != null ? newPadTestResult.PressureReadings.SystolicRightArm : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicLeft:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.PressureReadings != null ? newPadTestResult.PressureReadings.SystolicLeftArm : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.DiastolicLeft:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.PressureReadings != null ? newPadTestResult.PressureReadings.DiastolicLeftArm : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.DiastolicRight:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.PressureReadings != null ? newPadTestResult.PressureReadings.DiastolicRightArm : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicHighestArm:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.SystolicHighestArm);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newPadTestResult;
                        }
                        break;
                }
            }

            if ((newPadTestResult.UnableScreenReason != null && newPadTestResult.UnableScreenReason.Count > 0) || (newPadTestResult.IncidentalFindings != null && newPadTestResult.IncidentalFindings.Count > 0))
            {
                newPadTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newPadTestResult;
            }

            newPadTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newPadTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newPadTestResult = (PADTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.LeftABI:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.LeftResultReadings != null ? newPadTestResult.LeftResultReadings.ABI : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicLArm:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.LeftResultReadings != null ? newPadTestResult.LeftResultReadings.SystolicArm : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicLAnkle:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.LeftResultReadings != null ? newPadTestResult.LeftResultReadings.SystolicAnkle : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.RightABI:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.RightResultReadings != null ? newPadTestResult.RightResultReadings.ABI : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicRArm:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.RightResultReadings != null ? newPadTestResult.RightResultReadings.SystolicArm : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicRAnkle:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.RightResultReadings != null ? newPadTestResult.RightResultReadings.SystolicAnkle : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.Pulse:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.PressureReadings != null ? newPadTestResult.PressureReadings.Pulse : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.PulsePressure:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.PressureReadings != null ? newPadTestResult.PressureReadings.PulsePressure : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicRight:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.PressureReadings != null ? newPadTestResult.PressureReadings.SystolicRightArm : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicLeft:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.PressureReadings != null ? newPadTestResult.PressureReadings.SystolicLeftArm : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.DiastolicLeft:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.PressureReadings != null ? newPadTestResult.PressureReadings.DiastolicLeftArm : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.DiastolicRight:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.PressureReadings != null ? newPadTestResult.PressureReadings.DiastolicRightArm : null);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newPadTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicHighestArm:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newPadTestResult.SystolicHighestArm);
                        if (returnStatus)
                        {
                            newPadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newPadTestResult;
                        }
                        break;
                }
            }

            if ((newPadTestResult.UnableScreenReason != null && newPadTestResult.UnableScreenReason.Count > 0) || (newPadTestResult.IncidentalFindings != null && newPadTestResult.IncidentalFindings.Count > 0))
            {
                newPadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newPadTestResult;
            }

            newPadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newPadTestResult;
        }
    }
}
