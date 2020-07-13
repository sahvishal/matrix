using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class AwvEkgIppeTestResultSynchronizationService : TestResultSynchronizationService
    {
        public AwvEkgIppeTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newAwvEkgIppeTestResult = (AwvEkgIppeTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newAwvEkgIppeTestResult.VentRate != null && newAwvEkgIppeTestResult.VentRate.Reading == null) newAwvEkgIppeTestResult.VentRate = null;
                if (newAwvEkgIppeTestResult.PRInterval != null && newAwvEkgIppeTestResult.PRInterval.Reading == null) newAwvEkgIppeTestResult.PRInterval = null;
                if (newAwvEkgIppeTestResult.QRSDuration != null && newAwvEkgIppeTestResult.QRSDuration.Reading == null) newAwvEkgIppeTestResult.QRSDuration = null;
                if (newAwvEkgIppeTestResult.QTcInterval != null && newAwvEkgIppeTestResult.QTcInterval.Reading == null) newAwvEkgIppeTestResult.QTcInterval = null;
                if (newAwvEkgIppeTestResult.QTInterval != null && newAwvEkgIppeTestResult.QTInterval.Reading == null) newAwvEkgIppeTestResult.QTInterval = null;
                if (newAwvEkgIppeTestResult.ResultImage != null && newAwvEkgIppeTestResult.ResultImage.File == null) newAwvEkgIppeTestResult.ResultImage = null;
                SyncronizeTestResult(currentTestResult, newTestResult);

                return newAwvEkgIppeTestResult;
            }

            var currentAwvEkgTestResult = (AwvEkgIppeTestResult)currentTestResult;
            newAwvEkgIppeTestResult.Id = currentAwvEkgTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            newAwvEkgIppeTestResult.VentRate = SynchronizeResultReading(currentAwvEkgTestResult.VentRate, newAwvEkgIppeTestResult.VentRate, newTestResult.DataRecorderMetaData);
            newAwvEkgIppeTestResult.PRInterval = SynchronizeResultReading(currentAwvEkgTestResult.PRInterval, newAwvEkgIppeTestResult.PRInterval, newTestResult.DataRecorderMetaData);
            newAwvEkgIppeTestResult.QRSDuration = SynchronizeResultReading(currentAwvEkgTestResult.QRSDuration, newAwvEkgIppeTestResult.QRSDuration, newTestResult.DataRecorderMetaData);
            newAwvEkgIppeTestResult.QTcInterval = SynchronizeResultReading(currentAwvEkgTestResult.QTcInterval, newAwvEkgIppeTestResult.QTcInterval, newTestResult.DataRecorderMetaData);
            newAwvEkgIppeTestResult.QTInterval = SynchronizeResultReading(currentAwvEkgTestResult.QTInterval, newAwvEkgIppeTestResult.QTInterval, newTestResult.DataRecorderMetaData);

            if (currentAwvEkgTestResult.ResultImage != null && newAwvEkgIppeTestResult.ResultImage != null)
            {
                if (newAwvEkgIppeTestResult.ResultImage.File != null && currentAwvEkgTestResult.ResultImage.File != null && currentAwvEkgTestResult.ResultImage.File.Path == newAwvEkgIppeTestResult.ResultImage.File.Path)
                    newAwvEkgIppeTestResult.ResultImage = currentAwvEkgTestResult.ResultImage;

                if (currentAwvEkgTestResult.ResultImage.ReadingSource == ReadingSource.Manual
                    && newAwvEkgIppeTestResult.ResultImage.ReadingSource == ReadingSource.Automatic)
                    newAwvEkgIppeTestResult.ResultImage = currentAwvEkgTestResult.ResultImage;

            }

            if (newAwvEkgIppeTestResult.ResultImage != null)
            {
                if (newAwvEkgIppeTestResult.ResultImage.File == null) newAwvEkgIppeTestResult.ResultImage = null;
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newAwvEkgIppeTestResult = (AwvEkgIppeTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentAwvEkgTestResult, newAwvEkgIppeTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newAwvEkgIppeTestResult;
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (newTestResult == null) return null;
            var awvEkgIppeTestResult = newTestResult as AwvEkgIppeTestResult;

            if (awvEkgIppeTestResult == null) return null;

            if (awvEkgIppeTestResult.TestPerformedExternally != null)
            {
                if (awvEkgIppeTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && awvEkgIppeTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return awvEkgIppeTestResult;
            }

            foreach (var resultReading in compareToResultReadings)
            {
                switch (resultReading.Label)
                {
                    case ReadingLabels.PRInterval:
                        if (awvEkgIppeTestResult.PRInterval == null)
                        {
                            awvEkgIppeTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return awvEkgIppeTestResult;
                        }
                        break;

                    case ReadingLabels.VentRate:
                        if (awvEkgIppeTestResult.VentRate == null)
                        {
                            awvEkgIppeTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return awvEkgIppeTestResult;
                        }
                        break;

                    case ReadingLabels.QRSDuration:
                        if (awvEkgIppeTestResult.QRSDuration == null)
                        {
                            awvEkgIppeTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return awvEkgIppeTestResult;
                        }
                        break;

                    case ReadingLabels.QTcInterval:
                        if (awvEkgIppeTestResult.QTcInterval == null)
                        {
                            awvEkgIppeTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return awvEkgIppeTestResult;
                        }
                        break;

                    case ReadingLabels.QTInterval:
                        if (awvEkgIppeTestResult.QTInterval == null)
                        {
                            awvEkgIppeTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return awvEkgIppeTestResult;
                        }
                        break;
                }
            }

            if (awvEkgIppeTestResult.ResultImage == null)
            {
                newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                return newTestResult;
            }

            newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return awvEkgIppeTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var awvEkgIppeTestResult = NewManualEntryUploadStatus(compareToResultReadings, newTestResult);
                if (awvEkgIppeTestResult.ResultStatus.Status == TestResultStatus.Complete && awvEkgIppeTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    awvEkgIppeTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;

                return awvEkgIppeTestResult;
            }

            return OldManualEntryUploadStatus(compareToResultReadings, newTestResult);
        }

        private TestResult OldManualEntryUploadStatus(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;

            var awvEkgIppeTestResult = (AwvEkgIppeTestResult)newTestResult;

            foreach (var resultReading in compareToResultReadings)
            {
                bool returnStatus = false;
                switch (resultReading.Label)
                {
                    case ReadingLabels.PRInterval:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, awvEkgIppeTestResult.PRInterval);
                        if (returnStatus) { awvEkgIppeTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return awvEkgIppeTestResult; }
                        break;

                    case ReadingLabels.VentRate:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, awvEkgIppeTestResult.VentRate);
                        if (returnStatus) { awvEkgIppeTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return awvEkgIppeTestResult; }
                        break;

                    case ReadingLabels.QRSDuration:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, awvEkgIppeTestResult.QRSDuration);
                        if (returnStatus) { awvEkgIppeTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return awvEkgIppeTestResult; }
                        break;

                    case ReadingLabels.QTcInterval:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, awvEkgIppeTestResult.QTcInterval);
                        if (returnStatus) { awvEkgIppeTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return awvEkgIppeTestResult; }
                        break;

                    case ReadingLabels.QTInterval:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, awvEkgIppeTestResult.QTInterval);
                        if (returnStatus) { awvEkgIppeTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return awvEkgIppeTestResult; }
                        break;
                }
            }

            if (awvEkgIppeTestResult.ResultImage != null && awvEkgIppeTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                awvEkgIppeTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return awvEkgIppeTestResult;
            }

            if ((awvEkgIppeTestResult.UnableScreenReason != null && awvEkgIppeTestResult.UnableScreenReason.Count > 0) || (awvEkgIppeTestResult.IncidentalFindings != null && awvEkgIppeTestResult.IncidentalFindings.Count > 0) || awvEkgIppeTestResult.ResultStatus.SelfPresent)
            {
                awvEkgIppeTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return awvEkgIppeTestResult;
            }

            awvEkgIppeTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return awvEkgIppeTestResult;
        }

        private TestResult NewManualEntryUploadStatus(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;

            var awvEkgIppeTestResult = (AwvEkgIppeTestResult)newTestResult;

            foreach (var resultReading in compareToResultReadings)
            {
                bool returnStatus = false;
                switch (resultReading.Label)
                {
                    case ReadingLabels.PRInterval:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, awvEkgIppeTestResult.PRInterval);
                        if (returnStatus) { awvEkgIppeTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return awvEkgIppeTestResult; }
                        break;

                    case ReadingLabels.VentRate:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, awvEkgIppeTestResult.VentRate);
                        if (returnStatus) { awvEkgIppeTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return awvEkgIppeTestResult; }
                        break;

                    case ReadingLabels.QRSDuration:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, awvEkgIppeTestResult.QRSDuration);
                        if (returnStatus) { awvEkgIppeTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return awvEkgIppeTestResult; }
                        break;

                    case ReadingLabels.QTcInterval:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, awvEkgIppeTestResult.QTcInterval);
                        if (returnStatus) { awvEkgIppeTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return awvEkgIppeTestResult; }
                        break;

                    case ReadingLabels.QTInterval:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, awvEkgIppeTestResult.QTInterval);
                        if (returnStatus) { awvEkgIppeTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return awvEkgIppeTestResult; }
                        break;
                }
            }

            if (awvEkgIppeTestResult.ResultImage != null && awvEkgIppeTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                awvEkgIppeTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return awvEkgIppeTestResult;
            }

            if ((awvEkgIppeTestResult.UnableScreenReason != null && awvEkgIppeTestResult.UnableScreenReason.Count > 0) || (awvEkgIppeTestResult.IncidentalFindings != null && awvEkgIppeTestResult.IncidentalFindings.Count > 0) || awvEkgIppeTestResult.ResultStatus.SelfPresent)
            {
                awvEkgIppeTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return awvEkgIppeTestResult;
            }

            awvEkgIppeTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return awvEkgIppeTestResult;
        }
    }
}
