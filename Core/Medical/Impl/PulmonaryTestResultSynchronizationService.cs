using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class PulmonaryTestResultSynchronizationService : TestResultSynchronizationService
    {
        public PulmonaryTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var pulmonaryTestResult = (PulmonaryFunctionTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);
                if (pulmonaryTestResult.ResultImage != null && pulmonaryTestResult.ResultImage.File == null) pulmonaryTestResult.ResultImage = null;
                SyncronizeTestResult(currentTestResult, newTestResult);

                return pulmonaryTestResult;
            }

            var currentPulmonTestResult = (PulmonaryFunctionTestResult)currentTestResult;
            pulmonaryTestResult.Id = currentPulmonTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;



            if (currentPulmonTestResult.ResultImage != null && pulmonaryTestResult.ResultImage != null)
            {
                if (pulmonaryTestResult.ResultImage.File != null && currentPulmonTestResult.ResultImage.File != null && currentPulmonTestResult.ResultImage.File.Path == pulmonaryTestResult.ResultImage.File.Path)
                    pulmonaryTestResult.ResultImage = currentPulmonTestResult.ResultImage;

                if (currentPulmonTestResult.ResultImage.ReadingSource == ReadingSource.Manual
                    && pulmonaryTestResult.ResultImage.ReadingSource == ReadingSource.Automatic)
                    pulmonaryTestResult.ResultImage = currentPulmonTestResult.ResultImage;

            }

            if (pulmonaryTestResult.ResultImage != null)
            {
                if (pulmonaryTestResult.ResultImage.File == null) pulmonaryTestResult.ResultImage = null;
            }


            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                pulmonaryTestResult.Finding = currentPulmonTestResult.Finding;
                pulmonaryTestResult = (PulmonaryFunctionTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentPulmonTestResult, pulmonaryTestResult);
            }
            SyncronizeTestResult(currentTestResult, newTestResult);

            return pulmonaryTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var pulmonaryTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (pulmonaryTestResult.ResultStatus.Status == TestResultStatus.Complete && pulmonaryTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    pulmonaryTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return pulmonaryTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var pulmonaryFunctionTestResult = newTestResult as PulmonaryFunctionTestResult;

            if (pulmonaryFunctionTestResult != null)
            {
                if (pulmonaryFunctionTestResult.TestPerformedExternally != null)
                {
                    if (pulmonaryFunctionTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && pulmonaryFunctionTestResult.TestPerformedExternally.EntryCompleted)
                    {
                        newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                    }
                    else
                    {
                        newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                    }
                    return pulmonaryFunctionTestResult;
                }
            }

            if (pulmonaryFunctionTestResult.Finding == null || pulmonaryFunctionTestResult.ResultImage == null)
                pulmonaryFunctionTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            else
                pulmonaryFunctionTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return pulmonaryFunctionTestResult;
        }

        private TestResult OldResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;

            newTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
            var pulmonaryTestResult = (PulmonaryFunctionTestResult)newTestResult;

            if (pulmonaryTestResult.ResultImage != null && pulmonaryTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                pulmonaryTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return pulmonaryTestResult;
            }

            return newTestResult;
        }

        private TestResult NewResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;

            newTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            var pulmonaryTestResult = (PulmonaryFunctionTestResult)newTestResult;

            if (pulmonaryTestResult.ResultImage != null && pulmonaryTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                pulmonaryTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return pulmonaryTestResult;
            }

            return newTestResult;
        }
    }
}