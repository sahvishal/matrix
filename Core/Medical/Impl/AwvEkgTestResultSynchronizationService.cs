using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class AwvEkgTestResultSynchronizationService : TestResultSynchronizationService
    {
        public AwvEkgTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newAwvEkgTestResult = (AwvEkgTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newAwvEkgTestResult.VentRate != null && newAwvEkgTestResult.VentRate.Reading == null) newAwvEkgTestResult.VentRate = null;
                if (newAwvEkgTestResult.PRInterval != null && newAwvEkgTestResult.PRInterval.Reading == null) newAwvEkgTestResult.PRInterval = null;
                if (newAwvEkgTestResult.QRSDuration != null && newAwvEkgTestResult.QRSDuration.Reading == null) newAwvEkgTestResult.QRSDuration = null;
                if (newAwvEkgTestResult.QTcInterval != null && newAwvEkgTestResult.QTcInterval.Reading == null) newAwvEkgTestResult.QTcInterval = null;
                if (newAwvEkgTestResult.QTInterval != null && newAwvEkgTestResult.QTInterval.Reading == null) newAwvEkgTestResult.QTInterval = null;
                if (newAwvEkgTestResult.ResultImage != null && newAwvEkgTestResult.ResultImage.File == null) newAwvEkgTestResult.ResultImage = null;
                SyncronizeTestResult(currentTestResult, newTestResult);

                return newAwvEkgTestResult;
            }

            var currentAwvEkgTestResult = (AwvEkgTestResult)currentTestResult;
            newAwvEkgTestResult.Id = currentAwvEkgTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            newAwvEkgTestResult.VentRate = SynchronizeResultReading(currentAwvEkgTestResult.VentRate, newAwvEkgTestResult.VentRate, newTestResult.DataRecorderMetaData);
            newAwvEkgTestResult.PRInterval = SynchronizeResultReading(currentAwvEkgTestResult.PRInterval, newAwvEkgTestResult.PRInterval, newTestResult.DataRecorderMetaData);
            newAwvEkgTestResult.QRSDuration = SynchronizeResultReading(currentAwvEkgTestResult.QRSDuration, newAwvEkgTestResult.QRSDuration, newTestResult.DataRecorderMetaData);
            newAwvEkgTestResult.QTcInterval = SynchronizeResultReading(currentAwvEkgTestResult.QTcInterval, newAwvEkgTestResult.QTcInterval, newTestResult.DataRecorderMetaData);
            newAwvEkgTestResult.QTInterval = SynchronizeResultReading(currentAwvEkgTestResult.QTInterval, newAwvEkgTestResult.QTInterval, newTestResult.DataRecorderMetaData);

            if (currentAwvEkgTestResult.ResultImage != null && newAwvEkgTestResult.ResultImage != null)
            {
                if (newAwvEkgTestResult.ResultImage.File != null && currentAwvEkgTestResult.ResultImage.File != null && currentAwvEkgTestResult.ResultImage.File.Path == newAwvEkgTestResult.ResultImage.File.Path)
                    newAwvEkgTestResult.ResultImage = currentAwvEkgTestResult.ResultImage;

                if (currentAwvEkgTestResult.ResultImage.ReadingSource == ReadingSource.Manual
                    && newAwvEkgTestResult.ResultImage.ReadingSource == ReadingSource.Automatic)
                    newAwvEkgTestResult.ResultImage = currentAwvEkgTestResult.ResultImage;

            }

            if (newAwvEkgTestResult.ResultImage != null)
            {
                if (newAwvEkgTestResult.ResultImage.File == null) newAwvEkgTestResult.ResultImage = null;
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newAwvEkgTestResult = (AwvEkgTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentAwvEkgTestResult, newAwvEkgTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newAwvEkgTestResult;
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (newTestResult == null) return null;
            var awvEkgTestResult = newTestResult as AwvEkgTestResult;

            if (awvEkgTestResult == null) return null;

            if (awvEkgTestResult.TestPerformedExternally != null)
            {
                if (awvEkgTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && awvEkgTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return awvEkgTestResult;
            }

            foreach (var resultReading in compareToResultReadings)
            {
                switch (resultReading.Label)
                {
                    case ReadingLabels.PRInterval:
                        if (awvEkgTestResult.PRInterval == null)
                        {
                            awvEkgTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return awvEkgTestResult;
                        }
                        break;

                    case ReadingLabels.VentRate:
                        if (awvEkgTestResult.VentRate == null)
                        {
                            awvEkgTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return awvEkgTestResult;
                        }
                        break;

                    case ReadingLabels.QRSDuration:
                        if (awvEkgTestResult.QRSDuration == null)
                        {
                            awvEkgTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return awvEkgTestResult;
                        }
                        break;

                    case ReadingLabels.QTcInterval:
                        if (awvEkgTestResult.QTcInterval == null)
                        {
                            awvEkgTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return awvEkgTestResult;
                        }
                        break;

                    case ReadingLabels.QTInterval:
                        if (awvEkgTestResult.QTInterval == null)
                        {
                            awvEkgTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return awvEkgTestResult;
                        }
                        break;
                }
            }

            if (awvEkgTestResult.ResultImage == null)
            {
                newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                return newTestResult;
            }

            newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return awvEkgTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var awvEkgTestResult = NewManualEntryUploadStatus(compareToResultReadings, newTestResult);
                if (awvEkgTestResult.ResultStatus.Status == TestResultStatus.Complete && awvEkgTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    awvEkgTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;

                return awvEkgTestResult;
            }

            return OldManualEntryUploadStatus(compareToResultReadings, newTestResult);
        }


        public TestResult NewManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;

            var awvEkgTestResult = (AwvEkgTestResult)newTestResult;

            foreach (var resultReading in compareToResultReadings)
            {
                bool returnStatus = false;
                switch (resultReading.Label)
                {
                    case ReadingLabels.PRInterval:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, awvEkgTestResult.PRInterval);
                        if (returnStatus) { awvEkgTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return awvEkgTestResult; }
                        break;

                    case ReadingLabels.VentRate:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, awvEkgTestResult.VentRate);
                        if (returnStatus) { awvEkgTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return awvEkgTestResult; }
                        break;

                    case ReadingLabels.QRSDuration:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, awvEkgTestResult.QRSDuration);
                        if (returnStatus) { awvEkgTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return awvEkgTestResult; }
                        break;

                    case ReadingLabels.QTcInterval:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, awvEkgTestResult.QTcInterval);
                        if (returnStatus) { awvEkgTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return awvEkgTestResult; }
                        break;

                    case ReadingLabels.QTInterval:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, awvEkgTestResult.QTInterval);
                        if (returnStatus) { awvEkgTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return awvEkgTestResult; }
                        break;
                }
            }

            if (awvEkgTestResult.ResultImage != null && awvEkgTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                awvEkgTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return awvEkgTestResult;
            }

            if ((awvEkgTestResult.UnableScreenReason != null && awvEkgTestResult.UnableScreenReason.Count > 0) || (awvEkgTestResult.IncidentalFindings != null && awvEkgTestResult.IncidentalFindings.Count > 0) || awvEkgTestResult.ResultStatus.SelfPresent)
            {
                awvEkgTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return awvEkgTestResult;
            }

            awvEkgTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return awvEkgTestResult;
        }

        public TestResult OldManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;

            var awvEkgTestResult = (AwvEkgTestResult)newTestResult;

            foreach (var resultReading in compareToResultReadings)
            {
                bool returnStatus = false;
                switch (resultReading.Label)
                {
                    case ReadingLabels.PRInterval:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, awvEkgTestResult.PRInterval);
                        if (returnStatus) { awvEkgTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return awvEkgTestResult; }
                        break;

                    case ReadingLabels.VentRate:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, awvEkgTestResult.VentRate);
                        if (returnStatus) { awvEkgTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return awvEkgTestResult; }
                        break;

                    case ReadingLabels.QRSDuration:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, awvEkgTestResult.QRSDuration);
                        if (returnStatus) { awvEkgTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return awvEkgTestResult; }
                        break;

                    case ReadingLabels.QTcInterval:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, awvEkgTestResult.QTcInterval);
                        if (returnStatus) { awvEkgTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return awvEkgTestResult; }
                        break;

                    case ReadingLabels.QTInterval:
                        returnStatus = SynchronizeForChangeReadingSource(resultReading.ReadingSource, awvEkgTestResult.QTInterval);
                        if (returnStatus) { awvEkgTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return awvEkgTestResult; }
                        break;
                }
            }

            if (awvEkgTestResult.ResultImage != null && awvEkgTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                awvEkgTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return awvEkgTestResult;
            }

            if ((awvEkgTestResult.UnableScreenReason != null && awvEkgTestResult.UnableScreenReason.Count > 0) || (awvEkgTestResult.IncidentalFindings != null && awvEkgTestResult.IncidentalFindings.Count > 0) || awvEkgTestResult.ResultStatus.SelfPresent)
            {
                awvEkgTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return awvEkgTestResult;
            }

            awvEkgTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return awvEkgTestResult;
        }
    }
}
