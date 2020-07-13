using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class EkgTestResultSynchronizationService : TestResultSynchronizationService
    {
        public EkgTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newEkgTestResult = (EKGTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newEkgTestResult.VentRate != null && newEkgTestResult.VentRate.Reading == null) newEkgTestResult.VentRate = null;
                if (newEkgTestResult.PRInterval != null && newEkgTestResult.PRInterval.Reading == null) newEkgTestResult.PRInterval = null;
                if (newEkgTestResult.QRSDuration != null && newEkgTestResult.QRSDuration.Reading == null) newEkgTestResult.QRSDuration = null;
                if (newEkgTestResult.QTcInterval != null && newEkgTestResult.QTcInterval.Reading == null) newEkgTestResult.QTcInterval = null;
                if (newEkgTestResult.QTInterval != null && newEkgTestResult.QTInterval.Reading == null) newEkgTestResult.QTInterval = null;
                if (newEkgTestResult.ResultImage != null && newEkgTestResult.ResultImage.File == null) newEkgTestResult.ResultImage = null;
                SyncronizeTestResult(currentTestResult, newTestResult);

                return newEkgTestResult;
            }

            var currentEkgTestResult = (EKGTestResult)currentTestResult;
            newEkgTestResult.Id = currentEkgTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            newEkgTestResult.VentRate = SynchronizeResultReading(currentEkgTestResult.VentRate, newEkgTestResult.VentRate, newTestResult.DataRecorderMetaData);
            newEkgTestResult.PRInterval = SynchronizeResultReading(currentEkgTestResult.PRInterval, newEkgTestResult.PRInterval, newTestResult.DataRecorderMetaData);
            newEkgTestResult.QRSDuration = SynchronizeResultReading(currentEkgTestResult.QRSDuration, newEkgTestResult.QRSDuration, newTestResult.DataRecorderMetaData);
            newEkgTestResult.QTcInterval = SynchronizeResultReading(currentEkgTestResult.QTcInterval, newEkgTestResult.QTcInterval, newTestResult.DataRecorderMetaData);
            newEkgTestResult.QTInterval = SynchronizeResultReading(currentEkgTestResult.QTInterval, newEkgTestResult.QTInterval, newTestResult.DataRecorderMetaData);

            if (currentEkgTestResult.ResultImage != null && newEkgTestResult.ResultImage != null)
            {
                if (newEkgTestResult.ResultImage.File != null && currentEkgTestResult.ResultImage.File != null && currentEkgTestResult.ResultImage.File.Path == newEkgTestResult.ResultImage.File.Path)
                    newEkgTestResult.ResultImage = currentEkgTestResult.ResultImage;

                if (currentEkgTestResult.ResultImage.ReadingSource == ReadingSource.Manual
                    && newEkgTestResult.ResultImage.ReadingSource == ReadingSource.Automatic)
                    newEkgTestResult.ResultImage = currentEkgTestResult.ResultImage;

            }

            if (newEkgTestResult.ResultImage != null)
            {
                if (newEkgTestResult.ResultImage.File == null) newEkgTestResult.ResultImage = null;
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newEkgTestResult = (EKGTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentEkgTestResult, newEkgTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newEkgTestResult;
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (newTestResult == null) return null;
            var ekgTestResult = newTestResult as EKGTestResult;

            if (ekgTestResult == null) return null;

            if (ekgTestResult.TestPerformedExternally != null)
            {
                if (ekgTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && ekgTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return ekgTestResult;
            }

            foreach (var resultReading in compareToResultReadings)
            {
                switch (resultReading.Label)
                {
                    case ReadingLabels.PRInterval:
                        if (ekgTestResult.PRInterval == null)
                        {
                            ekgTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return ekgTestResult;
                        }
                        break;

                    case ReadingLabels.VentRate:
                        if (ekgTestResult.VentRate == null)
                        {
                            ekgTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return ekgTestResult;
                        }
                        break;

                    case ReadingLabels.QRSDuration:
                        if (ekgTestResult.QRSDuration == null)
                        {
                            ekgTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return ekgTestResult;
                        }
                        break;

                    case ReadingLabels.QTcInterval:
                        if (ekgTestResult.QTcInterval == null)
                        {
                            ekgTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return ekgTestResult;
                        }
                        break;

                    case ReadingLabels.QTInterval:
                        if (ekgTestResult.QTInterval == null)
                        {
                            ekgTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return ekgTestResult;
                        }
                        break;
                }
            }

            if (ekgTestResult.ResultImage == null)
            {
                newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                return newTestResult;
            }

            newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return ekgTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var ekgTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (ekgTestResult.ResultStatus.Status == TestResultStatus.Complete && ekgTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    ekgTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return ekgTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;

            var ekgTestResult = (EKGTestResult)newTestResult;

            foreach (var resultReading in compareToResultReadings)
            {
                bool returnStatus = false;
                switch (resultReading.Label)
                {
                    case ReadingLabels.PRInterval:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, ekgTestResult.PRInterval);
                        if (returnStatus) { ekgTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return ekgTestResult; }
                        break;

                    case ReadingLabels.VentRate:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, ekgTestResult.VentRate);
                        if (returnStatus) { ekgTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return ekgTestResult; }
                        break;

                    case ReadingLabels.QRSDuration:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, ekgTestResult.QRSDuration);
                        if (returnStatus) { ekgTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return ekgTestResult; }
                        break;

                    case ReadingLabels.QTcInterval:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, ekgTestResult.QTcInterval);
                        if (returnStatus) { ekgTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return ekgTestResult; }
                        break;

                    case ReadingLabels.QTInterval:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, ekgTestResult.QTInterval);
                        if (returnStatus) { ekgTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return ekgTestResult; }
                        break;
                }
            }

            if (ekgTestResult.ResultImage != null && ekgTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                ekgTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return ekgTestResult;
            }

            if ((ekgTestResult.UnableScreenReason != null && ekgTestResult.UnableScreenReason.Count > 0) || (ekgTestResult.IncidentalFindings != null && ekgTestResult.IncidentalFindings.Count > 0) || ekgTestResult.ResultStatus.SelfPresent)
            {
                ekgTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return ekgTestResult;
            }

            ekgTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return ekgTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;

            var ekgTestResult = (EKGTestResult)newTestResult;

            foreach (var resultReading in compareToResultReadings)
            {
                bool returnStatus = false;
                switch (resultReading.Label)
                {
                    case ReadingLabels.PRInterval:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, ekgTestResult.PRInterval);
                        if (returnStatus) { ekgTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return ekgTestResult; }
                        break;

                    case ReadingLabels.VentRate:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, ekgTestResult.VentRate);
                        if (returnStatus) { ekgTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return ekgTestResult; }
                        break;

                    case ReadingLabels.QRSDuration:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, ekgTestResult.QRSDuration);
                        if (returnStatus) { ekgTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return ekgTestResult; }
                        break;

                    case ReadingLabels.QTcInterval:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, ekgTestResult.QTcInterval);
                        if (returnStatus) { ekgTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return ekgTestResult; }
                        break;

                    case ReadingLabels.QTInterval:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, ekgTestResult.QTInterval);
                        if (returnStatus) { ekgTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return ekgTestResult; }
                        break;
                }
            }

            if (ekgTestResult.ResultImage != null && ekgTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                ekgTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return ekgTestResult;
            }

            if ((ekgTestResult.UnableScreenReason != null && ekgTestResult.UnableScreenReason.Count > 0) || (ekgTestResult.IncidentalFindings != null && ekgTestResult.IncidentalFindings.Count > 0) || ekgTestResult.ResultStatus.SelfPresent)
            {
                ekgTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return ekgTestResult;
            }

            ekgTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return ekgTestResult;
        }
    }
}
