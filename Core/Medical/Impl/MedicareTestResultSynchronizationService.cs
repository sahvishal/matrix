using System.Collections.Generic;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class MedicareTestResultSynchronizationService : TestResultSynchronizationService
    {
        public MedicareTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newMedicareTestResult = (MedicareTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (!newMedicareTestResult.ResultImages.IsNullOrEmpty())
                {
                    newMedicareTestResult.ResultImages = newMedicareTestResult.ResultImages.FindAll(resultImage => resultImage.File != null);

                    if (newMedicareTestResult.ResultImages.IsNullOrEmpty()) newMedicareTestResult.ResultImages = null;
                }

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newMedicareTestResult;
            }

            var currentMedicareTestResult = (MedicareTestResult)currentTestResult;
            newMedicareTestResult.Id = currentMedicareTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (NewReadingSource == ReadingSource.Automatic)
            {
                if (!currentMedicareTestResult.ResultImages.IsNullOrEmpty() && !newMedicareTestResult.ResultImages.IsNullOrEmpty())
                {
                    List<ResultMedia> resultImages = currentMedicareTestResult.ResultImages.FindAll(image => image.ReadingSource == ReadingSource.Manual);

                    if (resultImages.IsNullOrEmpty()) resultImages = newMedicareTestResult.ResultImages;
                    else resultImages.AddRange(newMedicareTestResult.ResultImages);

                    newMedicareTestResult.ResultImages = resultImages;
                }
                else if (!currentMedicareTestResult.ResultImages.IsNullOrEmpty())
                {
                    newMedicareTestResult.ResultImages = currentMedicareTestResult.ResultImages;
                }
            }
            else
            {
                if (!currentMedicareTestResult.ResultImages.IsNullOrEmpty() && !currentMedicareTestResult.ResultImages.IsNullOrEmpty())
                {
                    newMedicareTestResult.ResultImages.ForEach(resultImage =>
                    {
                        var selectedImage = currentMedicareTestResult.ResultImages.Find(currentImage => currentImage.File.Path == resultImage.File.Path);
                        if (selectedImage != null)
                            resultImage.ReadingSource = selectedImage.ReadingSource;
                    });
                }
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newMedicareTestResult.Finding = currentMedicareTestResult.Finding;
                newMedicareTestResult = (MedicareTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentMedicareTestResult, newMedicareTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newMedicareTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newMedicareTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newMedicareTestResult.ResultStatus.Status == TestResultStatus.Complete && newMedicareTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newMedicareTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newMedicareTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var medicareTestResult = newTestResult as MedicareTestResult;
            if (medicareTestResult == null) return null;

            if (medicareTestResult.TestPerformedExternally != null)
            {
                if (medicareTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && medicareTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return medicareTestResult;
            }


            if (medicareTestResult.TestPerformedExternally != null && medicareTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat)
            {

                if (medicareTestResult.TestPerformedExternally.EntryCompleted)
                    medicareTestResult.ResultStatus.Status = TestResultStatus.Complete;
                else
                    medicareTestResult.ResultStatus.Status = TestResultStatus.Incomplete;

                return medicareTestResult;

            }

            if (medicareTestResult.ResultImages != null && medicareTestResult.ResultImages.Count < 1)
                medicareTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            else
                medicareTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return medicareTestResult;
        }

        private TestResult OldResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
            var newMedicareTestResult = (MedicareTestResult)newTestResult;

            if (newMedicareTestResult.UnableScreenReason != null && newMedicareTestResult.UnableScreenReason.Count > 0)
            {
                newMedicareTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newMedicareTestResult;
            }

            newMedicareTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newMedicareTestResult;
        }

        private TestResult NewResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            var newMedicareTestResult = (MedicareTestResult)newTestResult;

            if (newMedicareTestResult.UnableScreenReason != null && newMedicareTestResult.UnableScreenReason.Count > 0)
            {
                newMedicareTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newMedicareTestResult;
            }

            newMedicareTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newMedicareTestResult;
        }
    }
}
