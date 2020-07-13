using System.Collections.Generic;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class AsiTestResultSynchronizationService : TestResultSynchronizationService
    {
        public AsiTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newAsiTestResult = (ASITestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newAsiTestResult.Pattern != null && string.IsNullOrEmpty(newAsiTestResult.Pattern.Reading)) newAsiTestResult.Pattern = null;

                if (newAsiTestResult.RawASI.IsNullOrEmpty()) newAsiTestResult.RawASI = null;

                if (newAsiTestResult.PressureReadings != null)
                {
                    if (newAsiTestResult.PressureReadings.DiastolicRightArm != null && newAsiTestResult.PressureReadings.DiastolicRightArm.Reading == null) newAsiTestResult.PressureReadings.DiastolicRightArm = null;
                    if (newAsiTestResult.PressureReadings.SystolicRightArm != null && newAsiTestResult.PressureReadings.SystolicRightArm.Reading == null) newAsiTestResult.PressureReadings.SystolicRightArm = null;
                    if (newAsiTestResult.PressureReadings.DiastolicLeftArm != null && newAsiTestResult.PressureReadings.DiastolicLeftArm.Reading == null) newAsiTestResult.PressureReadings.DiastolicLeftArm = null;
                    if (newAsiTestResult.PressureReadings.SystolicLeftArm != null && newAsiTestResult.PressureReadings.SystolicLeftArm.Reading == null) newAsiTestResult.PressureReadings.SystolicLeftArm = null;
                    if (newAsiTestResult.PressureReadings.Pulse != null && newAsiTestResult.PressureReadings.Pulse.Reading == null) newAsiTestResult.PressureReadings.Pulse = null;
                    if (newAsiTestResult.PressureReadings.PulsePressure != null && newAsiTestResult.PressureReadings.PulsePressure.Reading == null) newAsiTestResult.PressureReadings.PulsePressure = null;
                }

                if (newAsiTestResult.ASI != null && newAsiTestResult.ASI.Reading == null && newAsiTestResult.ASI.Finding == null) newAsiTestResult.ASI = null;
                SyncronizeTestResult(currentTestResult, newTestResult);

                return newAsiTestResult;
            }

            var currentAsiTestResult = (ASITestResult)currentTestResult;
            newAsiTestResult.Id = currentAsiTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;
            newAsiTestResult.Pattern = SynchronizeResultReading(currentAsiTestResult.Pattern, newAsiTestResult.Pattern, newTestResult.DataRecorderMetaData);

            if (newAsiTestResult.PressureReadings != null)
            {
                newAsiTestResult.PressureReadings.DiastolicRightArm = SynchronizeResultReading(currentAsiTestResult.PressureReadings.DiastolicRightArm, newAsiTestResult.PressureReadings.DiastolicRightArm, newTestResult.DataRecorderMetaData);
                newAsiTestResult.PressureReadings.SystolicRightArm = SynchronizeResultReading(currentAsiTestResult.PressureReadings.SystolicRightArm, newAsiTestResult.PressureReadings.SystolicRightArm, newTestResult.DataRecorderMetaData);

                newAsiTestResult.PressureReadings.DiastolicLeftArm = SynchronizeResultReading(currentAsiTestResult.PressureReadings.DiastolicLeftArm, newAsiTestResult.PressureReadings.DiastolicLeftArm, newTestResult.DataRecorderMetaData);
                newAsiTestResult.PressureReadings.SystolicLeftArm = SynchronizeResultReading(currentAsiTestResult.PressureReadings.SystolicLeftArm, newAsiTestResult.PressureReadings.SystolicLeftArm, newTestResult.DataRecorderMetaData);

                newAsiTestResult.PressureReadings.PulsePressure = SynchronizeResultReading(currentAsiTestResult.PressureReadings.PulsePressure, newAsiTestResult.PressureReadings.PulsePressure, newTestResult.DataRecorderMetaData);
                newAsiTestResult.PressureReadings.Pulse = SynchronizeResultReading(currentAsiTestResult.PressureReadings.Pulse, newAsiTestResult.PressureReadings.Pulse, newTestResult.DataRecorderMetaData);
            }

            if (!newAsiTestResult.RawASI.IsNullOrEmpty() && !currentAsiTestResult.RawASI.IsNullOrEmpty())
            {
                var rawAsi = new List<ResultReading<int>>();
                newAsiTestResult.RawASI.ForEach(ra =>
                                                    {
                                                        if (ra.Id < 1)
                                                        {
                                                            ra = SynchronizeResultReading(null, ra, newTestResult.DataRecorderMetaData);
                                                        }
                                                        else
                                                        {
                                                            var raInDb = currentAsiTestResult.RawASI.Find(inDb => inDb.Id == ra.Id);
                                                            ra = SynchronizeResultReading(raInDb, ra, newTestResult.DataRecorderMetaData);
                                                        }

                                                        if (ra != null) rawAsi.Add(ra);
                                                    });

                newAsiTestResult.RawASI = rawAsi;
            }
            else if (!newAsiTestResult.RawASI.IsNullOrEmpty())
            {
                var rawAsi = new List<ResultReading<int>>();
                newAsiTestResult.RawASI.ForEach(ra =>
                                                    {
                                                        ra = SynchronizeResultReading(null, ra, newTestResult.DataRecorderMetaData);
                                                        if (ra != null) rawAsi.Add(ra);
                                                    });
                newAsiTestResult.RawASI = rawAsi;
            }

            newAsiTestResult.ASI = SynchronizeResultReading(currentAsiTestResult.ASI, newAsiTestResult.ASI, newTestResult.DataRecorderMetaData);

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newAsiTestResult = (ASITestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentAsiTestResult, newAsiTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newAsiTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var asiTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (asiTestResult.ResultStatus.Status == TestResultStatus.Complete && asiTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    asiTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return asiTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (newTestResult == null) return null;
            var asiTestResult = newTestResult as ASITestResult;
            if (asiTestResult == null) return null;

            bool isSystolicRightIncomp = false;
            bool isSystolicLeftIncomp = false;
            bool isDiastolicRightIncomp = false;
            bool isDiastolicLeftIncomp = false;

            if (asiTestResult.TestPerformedExternally != null)
            {
                if (asiTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && asiTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return asiTestResult;
            }

            foreach (var resultReading in compareToResultReadings)
            {
                switch (resultReading.Label)
                {
                    case ReadingLabels.Pattern:
                        if (asiTestResult.Pattern == null)
                        {
                            asiTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return asiTestResult;
                        }
                        break;

                    case ReadingLabels.ASI:
                        if (IsIncompleteReading(asiTestResult.ASI))
                        {
                            asiTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return asiTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicRight:
                        if (asiTestResult.PressureReadings == null)
                        {
                            asiTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return asiTestResult;
                        }
                        if (asiTestResult.PressureReadings.SystolicRightArm == null)
                        {
                            isSystolicRightIncomp = true;
                        }
                        break;

                    case ReadingLabels.SystolicLeft:
                        if (asiTestResult.PressureReadings == null)
                        {
                            asiTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return asiTestResult;
                        }
                        if (asiTestResult.PressureReadings.SystolicLeftArm == null)
                        {
                            isSystolicLeftIncomp = true;
                        }
                        break;

                    case ReadingLabels.DiastolicLeft:
                        if (asiTestResult.PressureReadings == null)
                        {
                            asiTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return asiTestResult;
                        }
                        if (asiTestResult.PressureReadings.DiastolicLeftArm == null)
                        {
                            isDiastolicLeftIncomp = true;
                        }
                        break;

                    case ReadingLabels.DiastolicRight:
                        if (asiTestResult.PressureReadings == null)
                        {
                            asiTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return asiTestResult;
                        }
                        if (asiTestResult.PressureReadings.DiastolicRightArm == null)
                        {
                            isDiastolicRightIncomp = true;
                        }
                        break;

                    case ReadingLabels.Pulse:
                        if (asiTestResult.PressureReadings == null || asiTestResult.PressureReadings.Pulse == null)
                        {
                            asiTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return asiTestResult;
                        }
                        break;

                    case ReadingLabels.PulsePressure:
                        if (asiTestResult.PressureReadings == null || asiTestResult.PressureReadings.PulsePressure == null)
                        {
                            asiTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return asiTestResult;
                        }
                        break;
                }
            }

            if (!((!isDiastolicLeftIncomp && !isSystolicLeftIncomp) || (!isDiastolicRightIncomp && !isSystolicRightIncomp)))
            {
                newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                return newTestResult;
            }

            asiTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return asiTestResult;
        }

        private TestResult OldResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;

            var asiTestResult = (ASITestResult)newTestResult;
            bool returnStatus;

            foreach (var resultReading in compareToResultReadings)
            {
                switch (resultReading.Label)
                {
                    case ReadingLabels.Pattern:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, asiTestResult.Pattern);
                        if (returnStatus) { asiTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return asiTestResult; }
                        break;

                    case ReadingLabels.ASI:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, asiTestResult.ASI);
                        if (returnStatus) { asiTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return asiTestResult; }
                        break;

                    case ReadingLabels.SystolicRight:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, asiTestResult.PressureReadings.SystolicRightArm);
                        if (returnStatus) { asiTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return asiTestResult; }
                        break;

                    case ReadingLabels.SystolicLeft:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, asiTestResult.PressureReadings.SystolicLeftArm);
                        if (returnStatus) { asiTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return asiTestResult; }
                        break;

                    case ReadingLabels.DiastolicLeft:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, asiTestResult.PressureReadings.DiastolicLeftArm);
                        if (returnStatus) { asiTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return asiTestResult; }
                        break;

                    case ReadingLabels.DiastolicRight:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, asiTestResult.PressureReadings.DiastolicRightArm);
                        if (returnStatus) { asiTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return asiTestResult; }
                        break;

                    case ReadingLabels.Pulse:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, asiTestResult.PressureReadings.Pulse);
                        if (returnStatus) { asiTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return asiTestResult; }
                        break;

                    case ReadingLabels.PulsePressure:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, asiTestResult.PressureReadings.PulsePressure);
                        if (returnStatus) { asiTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return asiTestResult; }
                        break;
                }
            }

            ReadingSource? readingSourceAsi = compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.ASI).ReadingSource;
            returnStatus = false;

            if (!asiTestResult.RawASI.IsNullOrEmpty())
            {
                asiTestResult.RawASI.ForEach(asi =>
                {
                    var isDifferent = SynchronizeForChangeReadingSource(readingSourceAsi, asi);
                    if (isDifferent) returnStatus = true;
                });
            }

            if (returnStatus || (asiTestResult.UnableScreenReason != null && asiTestResult.UnableScreenReason.Count > 0) || (asiTestResult.IncidentalFindings != null && asiTestResult.IncidentalFindings.Count > 0))
            {
                asiTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return asiTestResult;
            }

            asiTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return asiTestResult;
        }

        private TestResult NewResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;

            var asiTestResult = (ASITestResult)newTestResult;
            bool returnStatus;

            foreach (var resultReading in compareToResultReadings)
            {
                switch (resultReading.Label)
                {
                    case ReadingLabels.Pattern:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, asiTestResult.Pattern);
                        if (returnStatus) { asiTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return asiTestResult; }
                        break;

                    case ReadingLabels.ASI:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, asiTestResult.ASI);
                        if (returnStatus) { asiTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return asiTestResult; }
                        break;

                    case ReadingLabels.SystolicRight:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, asiTestResult.PressureReadings.SystolicRightArm);
                        if (returnStatus) { asiTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return asiTestResult; }
                        break;

                    case ReadingLabels.SystolicLeft:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, asiTestResult.PressureReadings.SystolicLeftArm);
                        if (returnStatus) { asiTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return asiTestResult; }
                        break;

                    case ReadingLabels.DiastolicLeft:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, asiTestResult.PressureReadings.DiastolicLeftArm);
                        if (returnStatus) { asiTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return asiTestResult; }
                        break;

                    case ReadingLabels.DiastolicRight:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, asiTestResult.PressureReadings.DiastolicRightArm);
                        if (returnStatus) { asiTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return asiTestResult; }
                        break;

                    case ReadingLabels.Pulse:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, asiTestResult.PressureReadings.Pulse);
                        if (returnStatus) { asiTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return asiTestResult; }
                        break;

                    case ReadingLabels.PulsePressure:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, asiTestResult.PressureReadings.PulsePressure);
                        if (returnStatus) { asiTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return asiTestResult; }
                        break;
                }
            }

            ReadingSource? readingSourceAsi = compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.ASI).ReadingSource;
            returnStatus = false;

            if (!asiTestResult.RawASI.IsNullOrEmpty())
            {
                asiTestResult.RawASI.ForEach(asi =>
                {
                    var isDifferent = SynchronizeForChangeReadingSource(readingSourceAsi, asi);
                    if (isDifferent) returnStatus = true;
                });
            }

            if (returnStatus || (asiTestResult.UnableScreenReason != null && asiTestResult.UnableScreenReason.Count > 0) || (asiTestResult.IncidentalFindings != null && asiTestResult.IncidentalFindings.Count > 0))
            {
                asiTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return asiTestResult;
            }

            asiTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return asiTestResult;
        }
    }
}
