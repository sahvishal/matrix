using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class UrineMicroalbuminSynchronizationService : TestResultSynchronizationService
    {
        public UrineMicroalbuminSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newurineMicroalbuminTestResult = (UrineMicroalbuminTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newurineMicroalbuminTestResult.ResultImage != null)
                {
                    if (newurineMicroalbuminTestResult.ResultImage.File == null) newurineMicroalbuminTestResult.ResultImage = null;
                }

                if (newurineMicroalbuminTestResult.SerialKey != null && newurineMicroalbuminTestResult.SerialKey.Reading == null) newurineMicroalbuminTestResult.SerialKey = null;
                if (newurineMicroalbuminTestResult.MicroalbuminValue != null && newurineMicroalbuminTestResult.MicroalbuminValue.Reading == null) newurineMicroalbuminTestResult.MicroalbuminValue = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newurineMicroalbuminTestResult;
            }

            var currentUrineMicroalbuminTestResult = (UrineMicroalbuminTestResult)currentTestResult;
            newurineMicroalbuminTestResult.Id = currentUrineMicroalbuminTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (currentUrineMicroalbuminTestResult.ResultImage != null && newurineMicroalbuminTestResult.ResultImage != null)
            {
                if (newurineMicroalbuminTestResult.ResultImage.File != null && currentUrineMicroalbuminTestResult.ResultImage.File != null && currentUrineMicroalbuminTestResult.ResultImage.File.Path == newurineMicroalbuminTestResult.ResultImage.File.Path)
                    newurineMicroalbuminTestResult.ResultImage = currentUrineMicroalbuminTestResult.ResultImage;

                if (currentUrineMicroalbuminTestResult.ResultImage.ReadingSource == ReadingSource.Manual && newurineMicroalbuminTestResult.ResultImage.ReadingSource == ReadingSource.Automatic)
                    newurineMicroalbuminTestResult.ResultImage = currentUrineMicroalbuminTestResult.ResultImage;
            }

            newurineMicroalbuminTestResult.SerialKey = SynchronizeResultReading(currentUrineMicroalbuminTestResult.SerialKey, newurineMicroalbuminTestResult.SerialKey, newTestResult.DataRecorderMetaData);
            newurineMicroalbuminTestResult.MicroalbuminValue = SynchronizeResultReading(currentUrineMicroalbuminTestResult.MicroalbuminValue, newurineMicroalbuminTestResult.MicroalbuminValue, newTestResult.DataRecorderMetaData);

            if (newurineMicroalbuminTestResult.ResultImage != null)
            {
                if (newurineMicroalbuminTestResult.ResultImage.File == null) newurineMicroalbuminTestResult.ResultImage = null;
            }

            if (newurineMicroalbuminTestResult.Finding != null)
            {
                //newurineMicroalbuminTestResult.Finding = currentUrineMicroalbuminTestResult.Finding;
                currentUrineMicroalbuminTestResult.Finding = newurineMicroalbuminTestResult.Finding;
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newurineMicroalbuminTestResult = (UrineMicroalbuminTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentUrineMicroalbuminTestResult, newurineMicroalbuminTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newurineMicroalbuminTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newUrineMicroalbuminTestResult = NewManualEntryUploadStatus(compareToResultReadings, newTestResult);
                if (newUrineMicroalbuminTestResult.ResultStatus.Status == TestResultStatus.Complete && newUrineMicroalbuminTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newUrineMicroalbuminTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;

                return newUrineMicroalbuminTestResult;
            }

            return OldManualEntryUploadStatus(compareToResultReadings, newTestResult);
        }

        private TestResult NewManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            var newUrineMicroalbuminTestResult = (UrineMicroalbuminTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;

                switch (reading.Label)
                {
                    case ReadingLabels.MicroalbuminSerialKey:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.MicroalbuminSerialKey).ReadingSource, newUrineMicroalbuminTestResult.SerialKey);
                        if (returnStatus) { newUrineMicroalbuminTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newUrineMicroalbuminTestResult; }
                        break;
                    case ReadingLabels.MicroalbuminValue:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.MicroalbuminValue).ReadingSource, newUrineMicroalbuminTestResult.MicroalbuminValue);
                        if (returnStatus) { newUrineMicroalbuminTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newUrineMicroalbuminTestResult; }
                        break;
                }
            }

            if (newUrineMicroalbuminTestResult.UnableScreenReason != null && newUrineMicroalbuminTestResult.UnableScreenReason.Count > 0)
            {
                newUrineMicroalbuminTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newUrineMicroalbuminTestResult;
            }

            if (newUrineMicroalbuminTestResult.ResultImage != null && newUrineMicroalbuminTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newUrineMicroalbuminTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newUrineMicroalbuminTestResult;
            }

            newUrineMicroalbuminTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newUrineMicroalbuminTestResult;
        }

        private TestResult OldManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
            var newUrineMicroalbuminTestResult = (UrineMicroalbuminTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;

                switch (reading.Label)
                {
                    case ReadingLabels.MicroalbuminSerialKey:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.MicroalbuminSerialKey).ReadingSource, newUrineMicroalbuminTestResult.SerialKey);
                        if (returnStatus) { newUrineMicroalbuminTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newUrineMicroalbuminTestResult; }
                        break;
                    case ReadingLabels.MicroalbuminValue:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.MicroalbuminValue).ReadingSource, newUrineMicroalbuminTestResult.MicroalbuminValue);
                        if (returnStatus) { newUrineMicroalbuminTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newUrineMicroalbuminTestResult; }
                        break;
                }
            }

            if (newUrineMicroalbuminTestResult.UnableScreenReason != null && newUrineMicroalbuminTestResult.UnableScreenReason.Count > 0)
            {
                newUrineMicroalbuminTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newUrineMicroalbuminTestResult;
            }

            if (newUrineMicroalbuminTestResult.ResultImage != null && newUrineMicroalbuminTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newUrineMicroalbuminTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newUrineMicroalbuminTestResult;
            }

            newUrineMicroalbuminTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newUrineMicroalbuminTestResult;
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var urineMicroalbuminTestResultTestResult = newTestResult as UrineMicroalbuminTestResult;
            if (urineMicroalbuminTestResultTestResult == null) return null;

            if (urineMicroalbuminTestResultTestResult.TestPerformedExternally != null)
            {
                if (urineMicroalbuminTestResultTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && urineMicroalbuminTestResultTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return urineMicroalbuminTestResultTestResult;
            }


            if (urineMicroalbuminTestResultTestResult.Finding == null)
            {
                urineMicroalbuminTestResultTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                return urineMicroalbuminTestResultTestResult;
            }

            if (urineMicroalbuminTestResultTestResult.ResultImage == null || urineMicroalbuminTestResultTestResult.ResultImage.File == null)
            {
                urineMicroalbuminTestResultTestResult.ResultStatus.Status = TestResultStatus.Incomplete;

                return urineMicroalbuminTestResultTestResult;
            }

            urineMicroalbuminTestResultTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return urineMicroalbuminTestResultTestResult;
        }
    }
}