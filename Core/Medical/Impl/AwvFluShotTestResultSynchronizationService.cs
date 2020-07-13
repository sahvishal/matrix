using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class AwvFluShotTestResultSynchronizationService : TestResultSynchronizationService
    {
        public AwvFluShotTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newAwvFluShotTestResult = (AwvFluShotTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newAwvFluShotTestResult.Manufacturer != null && newAwvFluShotTestResult.Manufacturer.Reading == null) newAwvFluShotTestResult.Manufacturer = null;
                if (newAwvFluShotTestResult.LotNumber != null && newAwvFluShotTestResult.LotNumber.Reading == null) newAwvFluShotTestResult.LotNumber = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newAwvFluShotTestResult;
            }

            var currentAwvFluShotTestResult = (AwvFluShotTestResult)currentTestResult;
            newAwvFluShotTestResult.Id = currentAwvFluShotTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            newAwvFluShotTestResult.Manufacturer = SynchronizeResultReading(currentAwvFluShotTestResult.Manufacturer, newAwvFluShotTestResult.Manufacturer, newTestResult.DataRecorderMetaData);
            newAwvFluShotTestResult.LotNumber = SynchronizeResultReading(currentAwvFluShotTestResult.LotNumber, newAwvFluShotTestResult.LotNumber, newTestResult.DataRecorderMetaData);

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newAwvFluShotTestResult = (AwvFluShotTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentAwvFluShotTestResult, newAwvFluShotTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);

            return newAwvFluShotTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newAwvFluShotTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newAwvFluShotTestResult.ResultStatus.Status == TestResultStatus.Complete && newAwvFluShotTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newAwvFluShotTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newAwvFluShotTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var awvFluShotTestResult = newTestResult as AwvFluShotTestResult;
            if (awvFluShotTestResult == null) return null;

            if (awvFluShotTestResult.TestPerformedExternally != null)
            {
                if (awvFluShotTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && awvFluShotTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return awvFluShotTestResult;
            }

            if (awvFluShotTestResult.Manufacturer == null || awvFluShotTestResult.Manufacturer.Reading == null)
            {
                awvFluShotTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                return awvFluShotTestResult;
            }

            if (awvFluShotTestResult.LotNumber == null || awvFluShotTestResult.LotNumber.Reading == null)
            {
                awvFluShotTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                return awvFluShotTestResult;
            }

            awvFluShotTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return awvFluShotTestResult;
        }

        private TestResult OldResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
            var newAwvFluShotTestResult = (AwvFluShotTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;

                switch (reading.Label)
                {
                    case ReadingLabels.AwvFluShotManufacturer:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.AwvFluShotManufacturer).ReadingSource, newAwvFluShotTestResult.Manufacturer);
                        if (returnStatus) { newAwvFluShotTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newAwvFluShotTestResult; }
                        break;

                    case ReadingLabels.AwvFluShotLotNumber:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.AwvFluShotLotNumber).ReadingSource, newAwvFluShotTestResult.LotNumber);
                        if (returnStatus) { newAwvFluShotTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newAwvFluShotTestResult; }
                        break;
                }
            }

            if (newAwvFluShotTestResult.UnableScreenReason != null && newAwvFluShotTestResult.UnableScreenReason.Count > 0)
            {
                newAwvFluShotTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newAwvFluShotTestResult;
            }

            newAwvFluShotTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newAwvFluShotTestResult;
        }

        private TestResult NewResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            var newAwvFluShotTestResult = (AwvFluShotTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;

                switch (reading.Label)
                {
                    case ReadingLabels.AwvFluShotManufacturer:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.AwvFluShotManufacturer).ReadingSource, newAwvFluShotTestResult.Manufacturer);
                        if (returnStatus) { newAwvFluShotTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newAwvFluShotTestResult; }
                        break;

                    case ReadingLabels.AwvFluShotLotNumber:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.AwvFluShotLotNumber).ReadingSource, newAwvFluShotTestResult.LotNumber);
                        if (returnStatus) { newAwvFluShotTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newAwvFluShotTestResult; }
                        break;
                }
            }

            if (newAwvFluShotTestResult.UnableScreenReason != null && newAwvFluShotTestResult.UnableScreenReason.Count > 0)
            {
                newAwvFluShotTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newAwvFluShotTestResult;
            }

            newAwvFluShotTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newAwvFluShotTestResult;
        }
    }
}