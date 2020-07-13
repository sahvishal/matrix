using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class IFOBTTestResultSynchronizationService : TestResultSynchronizationService
    {
        public IFOBTTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newIFOBTTestResult = (IFOBTTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newIFOBTTestResult.ResultImage != null)
                {
                    if (newIFOBTTestResult.ResultImage.File == null) newIFOBTTestResult.ResultImage = null;
                }

                if (newIFOBTTestResult.SerialKey != null && newIFOBTTestResult.SerialKey.Reading == null) newIFOBTTestResult.SerialKey = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newIFOBTTestResult;
            }

            var currentIFOBTTestResult = (IFOBTTestResult)currentTestResult;
            newIFOBTTestResult.Id = currentIFOBTTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (currentIFOBTTestResult.ResultImage != null && newIFOBTTestResult.ResultImage != null)
            {
                if (newIFOBTTestResult.ResultImage.File != null && currentIFOBTTestResult.ResultImage.File != null && currentIFOBTTestResult.ResultImage.File.Path == newIFOBTTestResult.ResultImage.File.Path)
                    newIFOBTTestResult.ResultImage = currentIFOBTTestResult.ResultImage;

                if (currentIFOBTTestResult.ResultImage.ReadingSource == ReadingSource.Manual && newIFOBTTestResult.ResultImage.ReadingSource == ReadingSource.Automatic)
                    newIFOBTTestResult.ResultImage = currentIFOBTTestResult.ResultImage;
            }

            newIFOBTTestResult.SerialKey = SynchronizeResultReading(currentIFOBTTestResult.SerialKey, newIFOBTTestResult.SerialKey, newTestResult.DataRecorderMetaData);


            if (newIFOBTTestResult.ResultImage != null)
            {
                if (newIFOBTTestResult.ResultImage.File == null) newIFOBTTestResult.ResultImage = null;
            }

            if (newIFOBTTestResult.Finding != null)
            {
                // newIFOBTTestResult.Finding = currentIFOBTTestResult.Finding;
                currentIFOBTTestResult.Finding = newIFOBTTestResult.Finding;
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newIFOBTTestResult = (IFOBTTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentIFOBTTestResult, newIFOBTTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newIFOBTTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newIfobtTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newIfobtTestResult.ResultStatus.Status == TestResultStatus.Complete && newIfobtTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newIfobtTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;

                return newIfobtTestResult;
            }

            return OldResultStateManualEntry(compareToResultReadings, newTestResult);

        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var IFOBTTestResult = newTestResult as IFOBTTestResult;
            if (IFOBTTestResult == null) return null;

            if (IFOBTTestResult.TestPerformedExternally != null)
            {
                if (IFOBTTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && IFOBTTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return IFOBTTestResult;
            }


            if (IFOBTTestResult.Finding == null)
            {
                IFOBTTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                return IFOBTTestResult;
            }

            if (IFOBTTestResult.ResultImage == null || IFOBTTestResult.ResultImage.File == null)
            {
                IFOBTTestResult.ResultStatus.Status = TestResultStatus.Incomplete;

                return IFOBTTestResult;
            }

            IFOBTTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return IFOBTTestResult;
        }

        private TestResult NewResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;

            newTestResult.ResultStatus.StateNumber = (int)(NewTestResultStateNumber.ResultEntryPartial);
            var newIFOBTTestResult = (IFOBTTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;

                switch (reading.Label)
                {
                    case ReadingLabels.IFOBTSerialKey:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.IFOBTSerialKey).ReadingSource, newIFOBTTestResult.SerialKey);
                        if (returnStatus) { newIFOBTTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newIFOBTTestResult; }
                        break;
                }
            }

            if (newIFOBTTestResult.UnableScreenReason != null && newIFOBTTestResult.UnableScreenReason.Count > 0)
            {
                newIFOBTTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newIFOBTTestResult;
            }

            if (newIFOBTTestResult.ResultImage != null && newIFOBTTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newIFOBTTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newIFOBTTestResult;
            }

            newIFOBTTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newIFOBTTestResult;
        }

        private TestResult OldResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;

            newTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
            var newIFOBTTestResult = (IFOBTTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;

                switch (reading.Label)
                {
                    case ReadingLabels.IFOBTSerialKey:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.IFOBTSerialKey).ReadingSource, newIFOBTTestResult.SerialKey);
                        if (returnStatus) { newIFOBTTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newIFOBTTestResult; }
                        break;
                }
            }

            if (newIFOBTTestResult.UnableScreenReason != null && newIFOBTTestResult.UnableScreenReason.Count > 0)
            {
                newIFOBTTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newIFOBTTestResult;
            }

            if (newIFOBTTestResult.ResultImage != null && newIFOBTTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newIFOBTTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newIFOBTTestResult;
            }

            newIFOBTTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newIFOBTTestResult;
        }
    }
}