using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class QuantaFloABITestResultSynchronizationService : TestResultSynchronizationService
    {
        public QuantaFloABITestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newQuantaFloABITestResult = (QuantaFloABITestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newQuantaFloABITestResult.ResultImage != null)
                {
                    if (newQuantaFloABITestResult.ResultImage.File == null) newQuantaFloABITestResult.ResultImage = null;
                }

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newQuantaFloABITestResult;
            }

            var currentQuantaFloABITestResult = (QuantaFloABITestResult)currentTestResult;
            newQuantaFloABITestResult.Id = currentQuantaFloABITestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (currentQuantaFloABITestResult.ResultImage != null && newQuantaFloABITestResult.ResultImage != null)
            {
                if (newQuantaFloABITestResult.ResultImage.File != null && currentQuantaFloABITestResult.ResultImage.File != null && currentQuantaFloABITestResult.ResultImage.File.Path == newQuantaFloABITestResult.ResultImage.File.Path)
                    newQuantaFloABITestResult.ResultImage = currentQuantaFloABITestResult.ResultImage;

                if (currentQuantaFloABITestResult.ResultImage.ReadingSource == ReadingSource.Manual && newQuantaFloABITestResult.ResultImage.ReadingSource == ReadingSource.Automatic)
                    newQuantaFloABITestResult.ResultImage = currentQuantaFloABITestResult.ResultImage;
            }

            if (newQuantaFloABITestResult.ResultImage != null)
            {
                if (newQuantaFloABITestResult.ResultImage.File == null) newQuantaFloABITestResult.ResultImage = null;
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newQuantaFloABITestResult.Finding = currentQuantaFloABITestResult.Finding;
                newQuantaFloABITestResult = (QuantaFloABITestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentQuantaFloABITestResult, newQuantaFloABITestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newQuantaFloABITestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newQuantaFloABITestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newQuantaFloABITestResult.ResultStatus.Status == TestResultStatus.Complete && newQuantaFloABITestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newQuantaFloABITestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newQuantaFloABITestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var quantaFloABITestResult = newTestResult as QuantaFloABITestResult;
            if (quantaFloABITestResult == null) return null;

            if (quantaFloABITestResult.TestPerformedExternally != null)
            {
                if (quantaFloABITestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && quantaFloABITestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return quantaFloABITestResult;
            }


            if (quantaFloABITestResult.Finding == null)
            {
                quantaFloABITestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                return quantaFloABITestResult;
            }

            if (quantaFloABITestResult.ResultImage == null || quantaFloABITestResult.ResultImage.File == null)
            {
                quantaFloABITestResult.ResultStatus.Status = TestResultStatus.Incomplete;

                return quantaFloABITestResult;
            }

            quantaFloABITestResult.ResultStatus.Status = TestResultStatus.Complete;

            return quantaFloABITestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
            var newQuantaFloABITestResult = (QuantaFloABITestResult)newTestResult;

            if (newQuantaFloABITestResult.UnableScreenReason != null && newQuantaFloABITestResult.UnableScreenReason.Count > 0)
            {
                newQuantaFloABITestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newQuantaFloABITestResult;
            }

            if (newQuantaFloABITestResult.ResultImage != null && newQuantaFloABITestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newQuantaFloABITestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newQuantaFloABITestResult;
            }

            newQuantaFloABITestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newQuantaFloABITestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            var newQuantaFloABITestResult = (QuantaFloABITestResult)newTestResult;

            if (newQuantaFloABITestResult.UnableScreenReason != null && newQuantaFloABITestResult.UnableScreenReason.Count > 0)
            {
                newQuantaFloABITestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newQuantaFloABITestResult;
            }

            if (newQuantaFloABITestResult.ResultImage != null && newQuantaFloABITestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newQuantaFloABITestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newQuantaFloABITestResult;
            }

            newQuantaFloABITestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newQuantaFloABITestResult;
        }
    }
}