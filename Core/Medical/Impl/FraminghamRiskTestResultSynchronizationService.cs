using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class FraminghamRiskTestResultSynchronizationService : TestResultSynchronizationService
    {
        public FraminghamRiskTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newFraminghamRiskTestResult = newTestResult as FraminghamRiskTestResult;

            if ((currentTestResult == null || currentTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.NoResults)
                && newFraminghamRiskTestResult != null)
            {
                if (newFraminghamRiskTestResult.FraminghamRisk.Reading == null) newFraminghamRiskTestResult.FraminghamRisk = null;

                return newFraminghamRiskTestResult;
            }

            var currentFraminghamRiskTestResult = currentTestResult as FraminghamRiskTestResult;
            if (newFraminghamRiskTestResult != null &&
                (currentFraminghamRiskTestResult != null && currentFraminghamRiskTestResult.ResultStatus.StateNumber != (int)TestResultStateNumber.NoResults))
            {
                newFraminghamRiskTestResult.FraminghamRisk = SynchronizeResultReading(currentFraminghamRiskTestResult.FraminghamRisk, newFraminghamRiskTestResult.FraminghamRisk, newTestResult.DataRecorderMetaData);
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newFraminghamRiskTestResult = (FraminghamRiskTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentFraminghamRiskTestResult, newFraminghamRiskTestResult);
            }
            newFraminghamRiskTestResult.Id = currentFraminghamRiskTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newFraminghamRiskTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newFraminghamTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newFraminghamTestResult.ResultStatus.Status == TestResultStatus.Complete && newFraminghamTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newFraminghamTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newFraminghamTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var framinghamRiskTestResult = newTestResult as FraminghamRiskTestResult;

            if (framinghamRiskTestResult != null)
            {

                if (framinghamRiskTestResult.TestPerformedExternally != null)
                {
                    if (framinghamRiskTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && framinghamRiskTestResult.TestPerformedExternally.EntryCompleted)
                    {
                        newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                    }
                    else
                    {
                        newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                    }
                    return framinghamRiskTestResult;
                }

                newTestResult.ResultStatus.Status = framinghamRiskTestResult.FraminghamRisk == null
                                                        ? TestResultStatus.Incomplete
                                                        : TestResultStatus.Complete;
            }

            return framinghamRiskTestResult;
        }

        private TestResult OldResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit)
                return newTestResult;

            var newFraminghamTestResult = newTestResult as FraminghamRiskTestResult;
            if (newFraminghamTestResult != null)
            {
                bool returnStatus =
                    SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.FraminghamRisk).ReadingSource, newFraminghamTestResult.FraminghamRisk);

                if (returnStatus)
                {
                    newFraminghamTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                    return newFraminghamTestResult;
                }

                newFraminghamTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            }

            return newFraminghamTestResult;
        }

        private TestResult NewResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit)
                return newTestResult;

            var newFraminghamTestResult = newTestResult as FraminghamRiskTestResult;
            if (newFraminghamTestResult != null)
            {
                bool returnStatus =
                    SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.FraminghamRisk).ReadingSource, newFraminghamTestResult.FraminghamRisk);

                if (returnStatus)
                {
                    newFraminghamTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                    return newFraminghamTestResult;
                }

                newFraminghamTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            }

            return newFraminghamTestResult;
        }
    }
}
