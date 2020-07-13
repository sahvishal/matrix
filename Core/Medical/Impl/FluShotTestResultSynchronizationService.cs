using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class FluShotTestResultSynchronizationService : TestResultSynchronizationService
    {
        public FluShotTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newFluShotTestResult = (FluShotTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newFluShotTestResult.Manufacturer != null && newFluShotTestResult.Manufacturer.Reading == null) newFluShotTestResult.Manufacturer = null;
                if (newFluShotTestResult.LotNumber != null && newFluShotTestResult.LotNumber.Reading == null) newFluShotTestResult.LotNumber = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newFluShotTestResult;
            }

            var currentFluShotTestResult = (FluShotTestResult)currentTestResult;
            newFluShotTestResult.Id = currentFluShotTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            newFluShotTestResult.Manufacturer = SynchronizeResultReading(currentFluShotTestResult.Manufacturer, newFluShotTestResult.Manufacturer, newTestResult.DataRecorderMetaData);
            newFluShotTestResult.LotNumber = SynchronizeResultReading(currentFluShotTestResult.LotNumber, newFluShotTestResult.LotNumber, newTestResult.DataRecorderMetaData);

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newFluShotTestResult = (FluShotTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentFluShotTestResult, newFluShotTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);

            return newFluShotTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newFluShotTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newFluShotTestResult.ResultStatus.Status == TestResultStatus.Complete && newFluShotTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newFluShotTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newFluShotTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var fluShotTestResult = newTestResult as FluShotTestResult;
            if (fluShotTestResult == null) return null;

            if (fluShotTestResult.TestPerformedExternally != null)
            {
                if (fluShotTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && fluShotTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return fluShotTestResult;
            }

            if (fluShotTestResult.Manufacturer == null || fluShotTestResult.Manufacturer.Reading == null)
            {
                fluShotTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                return fluShotTestResult;
            }

            if (fluShotTestResult.LotNumber == null || fluShotTestResult.LotNumber.Reading == null)
            {
                fluShotTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                return fluShotTestResult;
            }

            fluShotTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return fluShotTestResult;
        }

        private TestResult OldResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
            var newFluShotTestResult = (FluShotTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;

                switch (reading.Label)
                {
                    case ReadingLabels.FluShotManufacturer:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.FluShotManufacturer).ReadingSource, newFluShotTestResult.Manufacturer);
                        if (returnStatus) { newFluShotTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newFluShotTestResult; }
                        break;

                    case ReadingLabels.FluShotLotNumber:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.FluShotLotNumber).ReadingSource, newFluShotTestResult.LotNumber);
                        if (returnStatus) { newFluShotTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newFluShotTestResult; }
                        break;
                }
            }

            if (newFluShotTestResult.UnableScreenReason != null && newFluShotTestResult.UnableScreenReason.Count > 0)
            {
                newFluShotTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newFluShotTestResult;
            }

            newFluShotTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newFluShotTestResult;
        }

        private TestResult NewResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            var newFluShotTestResult = (FluShotTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;

                switch (reading.Label)
                {
                    case ReadingLabels.FluShotManufacturer:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.FluShotManufacturer).ReadingSource, newFluShotTestResult.Manufacturer);
                        if (returnStatus) { newFluShotTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newFluShotTestResult; }
                        break;

                    case ReadingLabels.FluShotLotNumber:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.FluShotLotNumber).ReadingSource, newFluShotTestResult.LotNumber);
                        if (returnStatus) { newFluShotTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newFluShotTestResult; }
                        break;
                }
            }

            if (newFluShotTestResult.UnableScreenReason != null && newFluShotTestResult.UnableScreenReason.Count > 0)
            {
                newFluShotTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newFluShotTestResult;
            }

            newFluShotTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newFluShotTestResult;
        }
    }
}