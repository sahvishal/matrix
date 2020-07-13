using System.Collections.Generic;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class LeadTestResultSynchronizationService : TestResultSynchronizationService
    {
        public LeadTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newLeadTestResult = (LeadTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newLeadTestResult.DiagnosisCode != null && newLeadTestResult.DiagnosisCode.Reading == null) newLeadTestResult.DiagnosisCode = null;

                if (newLeadTestResult.LeftResultReadings != null)
                {
                    if (newLeadTestResult.LeftResultReadings.CFAPSV != null && newLeadTestResult.LeftResultReadings.CFAPSV.Reading == null) newLeadTestResult.LeftResultReadings.CFAPSV = null;
                    if (newLeadTestResult.LeftResultReadings.PSFAPSV != null && newLeadTestResult.LeftResultReadings.PSFAPSV.Reading == null) newLeadTestResult.LeftResultReadings.PSFAPSV = null;

                    if (newLeadTestResult.LeftResultReadings.NoVisualPlaque != null && newLeadTestResult.LeftResultReadings.NoVisualPlaque.Reading == null) newLeadTestResult.LeftResultReadings.NoVisualPlaque = null;
                    if (newLeadTestResult.LeftResultReadings.VisuallyDemonstratedPlaque != null && newLeadTestResult.LeftResultReadings.VisuallyDemonstratedPlaque.Reading == null) newLeadTestResult.LeftResultReadings.VisuallyDemonstratedPlaque = null;
                    if (newLeadTestResult.LeftResultReadings.ModerateStenosis != null && newLeadTestResult.LeftResultReadings.ModerateStenosis.Reading == null) newLeadTestResult.LeftResultReadings.ModerateStenosis = null;
                    if (newLeadTestResult.LeftResultReadings.PossibleOcclusion != null && newLeadTestResult.LeftResultReadings.PossibleOcclusion.Reading == null) newLeadTestResult.LeftResultReadings.PossibleOcclusion = null;
                }

                if (newLeadTestResult.RightResultReadings != null)
                {
                    if (newLeadTestResult.RightResultReadings.CFAPSV != null && newLeadTestResult.RightResultReadings.CFAPSV.Reading == null) newLeadTestResult.RightResultReadings.CFAPSV = null;
                    if (newLeadTestResult.RightResultReadings.PSFAPSV != null && newLeadTestResult.RightResultReadings.PSFAPSV.Reading == null) newLeadTestResult.RightResultReadings.PSFAPSV = null;

                    if (newLeadTestResult.RightResultReadings.NoVisualPlaque != null && newLeadTestResult.RightResultReadings.NoVisualPlaque.Reading == null) newLeadTestResult.RightResultReadings.NoVisualPlaque = null;
                    if (newLeadTestResult.RightResultReadings.VisuallyDemonstratedPlaque != null && newLeadTestResult.RightResultReadings.VisuallyDemonstratedPlaque.Reading == null) newLeadTestResult.RightResultReadings.VisuallyDemonstratedPlaque = null;
                    if (newLeadTestResult.RightResultReadings.ModerateStenosis != null && newLeadTestResult.RightResultReadings.ModerateStenosis.Reading == null) newLeadTestResult.RightResultReadings.ModerateStenosis = null;
                    if (newLeadTestResult.RightResultReadings.PossibleOcclusion != null && newLeadTestResult.RightResultReadings.PossibleOcclusion.Reading == null) newLeadTestResult.RightResultReadings.PossibleOcclusion = null;
                }

                if (!newLeadTestResult.ResultImages.IsNullOrEmpty())
                {
                    newLeadTestResult.ResultImages = newLeadTestResult.ResultImages.FindAll(resultImage =>
                        resultImage.File != null);

                    if (newLeadTestResult.ResultImages.IsNullOrEmpty()) newLeadTestResult.ResultImages = null;
                }

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newLeadTestResult;
            }

            var currentLeadTestResult = (LeadTestResult)currentTestResult;
            newLeadTestResult.Id = currentLeadTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            newLeadTestResult.DiagnosisCode = SynchronizeResultReading(currentLeadTestResult.DiagnosisCode, newLeadTestResult.DiagnosisCode, newTestResult.DataRecorderMetaData);

            if (newLeadTestResult.LeftResultReadings == null && currentLeadTestResult.LeftResultReadings != null) newLeadTestResult.LeftResultReadings = new LeadTestReadings();

            if (newLeadTestResult.LeftResultReadings != null)
            {
                newLeadTestResult.LeftResultReadings.CFAPSV = SynchronizeResultReading(currentLeadTestResult.LeftResultReadings.CFAPSV, newLeadTestResult.LeftResultReadings.CFAPSV, newTestResult.DataRecorderMetaData);
                newLeadTestResult.LeftResultReadings.PSFAPSV = SynchronizeResultReading(currentLeadTestResult.LeftResultReadings.PSFAPSV, newLeadTestResult.LeftResultReadings.PSFAPSV, newTestResult.DataRecorderMetaData);

                newLeadTestResult.LeftResultReadings.NoVisualPlaque = SynchronizeResultReading(currentLeadTestResult.LeftResultReadings.NoVisualPlaque, newLeadTestResult.LeftResultReadings.NoVisualPlaque, newTestResult.DataRecorderMetaData);
                newLeadTestResult.LeftResultReadings.VisuallyDemonstratedPlaque = SynchronizeResultReading(currentLeadTestResult.LeftResultReadings.VisuallyDemonstratedPlaque, newLeadTestResult.LeftResultReadings.VisuallyDemonstratedPlaque, newTestResult.DataRecorderMetaData);
                newLeadTestResult.LeftResultReadings.ModerateStenosis = SynchronizeResultReading(currentLeadTestResult.LeftResultReadings.ModerateStenosis, newLeadTestResult.LeftResultReadings.ModerateStenosis, newTestResult.DataRecorderMetaData);
                newLeadTestResult.LeftResultReadings.PossibleOcclusion = SynchronizeResultReading(currentLeadTestResult.LeftResultReadings.PossibleOcclusion, newLeadTestResult.LeftResultReadings.PossibleOcclusion, newTestResult.DataRecorderMetaData);
            }

            if (newLeadTestResult.RightResultReadings == null && currentLeadTestResult.RightResultReadings != null) newLeadTestResult.RightResultReadings = new LeadTestReadings();

            if (newLeadTestResult.RightResultReadings != null)
            {
                newLeadTestResult.RightResultReadings.CFAPSV = SynchronizeResultReading(currentLeadTestResult.RightResultReadings.CFAPSV, newLeadTestResult.RightResultReadings.CFAPSV, newTestResult.DataRecorderMetaData);
                newLeadTestResult.RightResultReadings.PSFAPSV = SynchronizeResultReading(currentLeadTestResult.RightResultReadings.PSFAPSV, newLeadTestResult.RightResultReadings.PSFAPSV, newTestResult.DataRecorderMetaData);

                newLeadTestResult.RightResultReadings.NoVisualPlaque = SynchronizeResultReading(currentLeadTestResult.RightResultReadings.NoVisualPlaque, newLeadTestResult.RightResultReadings.NoVisualPlaque, newTestResult.DataRecorderMetaData);
                newLeadTestResult.RightResultReadings.VisuallyDemonstratedPlaque = SynchronizeResultReading(currentLeadTestResult.RightResultReadings.VisuallyDemonstratedPlaque, newLeadTestResult.RightResultReadings.VisuallyDemonstratedPlaque, newTestResult.DataRecorderMetaData);
                newLeadTestResult.RightResultReadings.ModerateStenosis = SynchronizeResultReading(currentLeadTestResult.RightResultReadings.ModerateStenosis, newLeadTestResult.RightResultReadings.ModerateStenosis, newTestResult.DataRecorderMetaData);
                newLeadTestResult.RightResultReadings.PossibleOcclusion = SynchronizeResultReading(currentLeadTestResult.RightResultReadings.PossibleOcclusion, newLeadTestResult.RightResultReadings.PossibleOcclusion, newTestResult.DataRecorderMetaData);
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                if (!currentLeadTestResult.ResultImages.IsNullOrEmpty() && !newLeadTestResult.ResultImages.IsNullOrEmpty())
                {
                    List<ResultMedia> resultImages = currentLeadTestResult.ResultImages.FindAll(image => image.ReadingSource == ReadingSource.Manual);

                    if (resultImages.IsNullOrEmpty()) resultImages = newLeadTestResult.ResultImages;
                    else resultImages.AddRange(newLeadTestResult.ResultImages);

                    newLeadTestResult.ResultImages = resultImages;
                }
                else if (!currentLeadTestResult.ResultImages.IsNullOrEmpty())
                {
                    newLeadTestResult.ResultImages = currentLeadTestResult.ResultImages;
                }
            }
            else
            {
                if (!currentLeadTestResult.ResultImages.IsNullOrEmpty() && !newLeadTestResult.ResultImages.IsNullOrEmpty())
                {
                    newLeadTestResult.ResultImages.ForEach(resultImage =>
                    {
                        var selectedImage = currentLeadTestResult.ResultImages.Find(currentImage => currentImage.File.Path == resultImage.File.Path);
                        if (selectedImage != null)
                            resultImage.ReadingSource = selectedImage.ReadingSource;
                    });
                }
            }

            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                if (newLeadTestResult.RightResultReadings != null)
                {
                    newLeadTestResult.RightResultReadings.Finding = currentLeadTestResult.RightResultReadings.Finding;
                }
                else if (currentLeadTestResult.RightResultReadings.Finding != null)
                {
                    newLeadTestResult.RightResultReadings = new LeadTestReadings { Finding = currentLeadTestResult.RightResultReadings.Finding };
                }

                if (newLeadTestResult.LeftResultReadings != null) newLeadTestResult.LeftResultReadings.Finding = currentLeadTestResult.LeftResultReadings.Finding;
                else if (currentLeadTestResult.LeftResultReadings.Finding != null)
                {
                    newLeadTestResult.LeftResultReadings = new LeadTestReadings { Finding = currentLeadTestResult.LeftResultReadings.Finding };
                }

                newLeadTestResult = (LeadTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentLeadTestResult, newLeadTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newLeadTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newLeadTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newLeadTestResult.ResultStatus.Status == TestResultStatus.Complete && newLeadTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newLeadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newLeadTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var leadTestResult = newTestResult as LeadTestResult;
            if (leadTestResult == null) return null;

            if (leadTestResult.TestPerformedExternally != null)
            {
                if (leadTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && leadTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return leadTestResult;
            }


            if (NewReadingSource != ReadingSource.Automatic)
            {
                foreach (var reading in compareToResultReadings)
                {
                    switch (reading.Label)
                    {
                        case ReadingLabels.RightCFAPSV:
                            if (leadTestResult.RightResultReadings == null ||
                                leadTestResult.RightResultReadings.CFAPSV == null)
                            {
                                leadTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return leadTestResult;
                            }
                            break;

                        case ReadingLabels.RightPSFAPSV:
                            if (leadTestResult.RightResultReadings == null ||
                                leadTestResult.RightResultReadings.PSFAPSV == null)
                            {
                                leadTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return leadTestResult;
                            }
                            break;

                        case ReadingLabels.LeftCFAPSV:
                            if (leadTestResult.LeftResultReadings == null ||
                                leadTestResult.LeftResultReadings.CFAPSV == null)
                            {
                                leadTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return leadTestResult;
                            }
                            break;

                        case ReadingLabels.LeftPSFAPSV:
                            if (leadTestResult.LeftResultReadings == null ||
                                leadTestResult.LeftResultReadings.PSFAPSV == null)
                            {
                                leadTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return leadTestResult;
                            }
                            break;

                    }
                }
            }

            if (leadTestResult.ResultImages == null || leadTestResult.ResultImages.Count < 1)
                newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            else
                newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return leadTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newLeadTestResult = (LeadTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.RightCFAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLeadTestResult.RightResultReadings != null ? newLeadTestResult.RightResultReadings.CFAPSV : null);
                        if (returnStatus)
                        {
                            newLeadTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newLeadTestResult;
                        }
                        break;

                    case ReadingLabels.RightPSFAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLeadTestResult.RightResultReadings != null ? newLeadTestResult.RightResultReadings.PSFAPSV : null);
                        if (returnStatus)
                        {
                            newLeadTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newLeadTestResult;
                        }
                        break;

                    case ReadingLabels.LeftCFAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLeadTestResult.LeftResultReadings != null ? newLeadTestResult.LeftResultReadings.CFAPSV : null);
                        if (returnStatus)
                        {
                            newLeadTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newLeadTestResult;
                        }
                        break;

                    case ReadingLabels.LeftPSFAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLeadTestResult.LeftResultReadings != null ? newLeadTestResult.LeftResultReadings.PSFAPSV : null);
                        if (returnStatus)
                        {
                            newLeadTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newLeadTestResult;
                        }
                        break;

                    case ReadingLabels.DiagnosisCode:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLeadTestResult.DiagnosisCode);
                        if (returnStatus)
                        {
                            newLeadTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newLeadTestResult;
                        }
                        break;
                }
            }

            if (!newLeadTestResult.ResultImages.IsNullOrEmpty())
            {
                var manuallyUploadedImage = newLeadTestResult.ResultImages.Find(resultImage => resultImage.ReadingSource == ReadingSource.Manual);
                if (manuallyUploadedImage != null)
                {
                    newLeadTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                    return newLeadTestResult;
                }
            }

            if ((newLeadTestResult.UnableScreenReason != null && newLeadTestResult.UnableScreenReason.Count > 0) || (newLeadTestResult.IncidentalFindings != null && newLeadTestResult.IncidentalFindings.Count > 0))
            {
                newLeadTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newLeadTestResult;
            }

            newLeadTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newLeadTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newLeadTestResult = (LeadTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.RightCFAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLeadTestResult.RightResultReadings != null ? newLeadTestResult.RightResultReadings.CFAPSV : null);
                        if (returnStatus)
                        {
                            newLeadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newLeadTestResult;
                        }
                        break;

                    case ReadingLabels.RightPSFAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLeadTestResult.RightResultReadings != null ? newLeadTestResult.RightResultReadings.PSFAPSV : null);
                        if (returnStatus)
                        {
                            newLeadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newLeadTestResult;
                        }
                        break;

                    case ReadingLabels.LeftCFAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLeadTestResult.LeftResultReadings != null ? newLeadTestResult.LeftResultReadings.CFAPSV : null);
                        if (returnStatus)
                        {
                            newLeadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newLeadTestResult;
                        }
                        break;

                    case ReadingLabels.LeftPSFAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLeadTestResult.LeftResultReadings != null ? newLeadTestResult.LeftResultReadings.PSFAPSV : null);
                        if (returnStatus)
                        {
                            newLeadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newLeadTestResult;
                        }
                        break;

                    case ReadingLabels.DiagnosisCode:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLeadTestResult.DiagnosisCode);
                        if (returnStatus)
                        {
                            newLeadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newLeadTestResult;
                        }
                        break;
                }
            }

            if (!newLeadTestResult.ResultImages.IsNullOrEmpty())
            {
                var manuallyUploadedImage = newLeadTestResult.ResultImages.Find(resultImage => resultImage.ReadingSource == ReadingSource.Manual);
                if (manuallyUploadedImage != null)
                {
                    newLeadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                    return newLeadTestResult;
                }
            }

            if ((newLeadTestResult.UnableScreenReason != null && newLeadTestResult.UnableScreenReason.Count > 0) || (newLeadTestResult.IncidentalFindings != null && newLeadTestResult.IncidentalFindings.Count > 0))
            {
                newLeadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newLeadTestResult;
            }

            newLeadTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newLeadTestResult;
        }
    }
}
